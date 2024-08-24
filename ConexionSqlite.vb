Imports System.Data.SQLite

Public Class ConexionSqlite
    Private Shared Function ObtenerConexion() As String
        Dim connectionString As String
        connectionString = $"Data Source={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "liga.db")};Version=3;"
        Return connectionString

    End Function

    Public Shared Function ObtenerEquipos() As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM Equipos"
        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()
            Using cmd As New SQLiteCommand(query, conn)
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    Public Shared Function ObtenerJugadoresConEquipos(idEquipo As Long) As DataTable
        Dim dt As New DataTable()

        Dim query As String = "SELECT jugadores.idjugadores, jugadores.jugador, jugadores.posicion " &
                          "FROM jugadores " &
                          "INNER JOIN equipos ON jugadores.idequipo = equipos.idequipo " &
                          "WHERE equipos.idequipo = @IdEquipo "

        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()

            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@IdEquipo", idEquipo)

                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Shared Function ObtenerDatoFechas() As Integer
        Dim resultado As Integer = 0
        Dim query As String = "SELECT datoint FROM configuracion WHERE tipo = 'fechas' LIMIT 1"

        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()

            Using cmd As New SQLiteCommand(query, conn)
                Dim result = cmd.ExecuteScalar()

                If result IsNot Nothing AndAlso Integer.TryParse(result.ToString(), resultado) Then
                    Return resultado
                Else
                    Throw New InvalidOperationException("No se encontró un valor válido para el tipo 'fechas'.")
                End If
            End Using
        End Using
    End Function
    Public Shared Sub GuardarRegistro(idequipo As Integer, idjugador As Integer, nrofecha As Integer, puntosfecha As Decimal?, b As Integer, t As Integer, s As Integer, l As Integer)
        Dim queryExistencia As String = "SELECT COUNT(*) FROM registro WHERE idequipo = @idequipo AND idjugador = @idjugador AND nrofecha = @nrofecha"
        Dim queryObtenerPuntos As String = "SELECT puntosfecha FROM registro WHERE idequipo = @idequipo AND idjugador = @idjugador AND nrofecha = @nrofecha"
        Dim queryInsertar As String = "INSERT INTO registro (idequipo, idjugador, nrofecha, puntosfecha, b, t, s, l) VALUES (@idequipo, @idjugador, @nrofecha, @puntosfecha, @b, @t, @s, @l)"
        Dim queryActualizar As String = "UPDATE registro SET puntosfecha = @puntosfecha, b = @b, t = @t, s = @s, l = @l WHERE idequipo = @idequipo AND idjugador = @idjugador AND nrofecha = @nrofecha"

        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()

            Using cmd As New SQLiteCommand(queryExistencia, conn)
                ' Verificar si el registro ya existe
                cmd.Parameters.AddWithValue("@idequipo", idequipo)
                cmd.Parameters.AddWithValue("@idjugador", idjugador)
                cmd.Parameters.AddWithValue("@nrofecha", nrofecha)

                Dim existeRegistro As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If existeRegistro > 0 Then
                    ' Si el registro existe, obtener el valor actual de puntosfecha
                    cmd.CommandText = queryObtenerPuntos
                    Dim puntosActuales As Decimal? = If(cmd.ExecuteScalar() IsNot DBNull.Value, Convert.ToDecimal(cmd.ExecuteScalar()), CType(Nothing, Decimal?))

                    ' Si puntosfecha es diferente, actualizar el registro
                    If puntosfecha.HasValue AndAlso puntosfecha <> puntosActuales Then
                        cmd.CommandText = queryActualizar

                        If puntosfecha.HasValue Then
                            cmd.Parameters.AddWithValue("@puntosfecha", puntosfecha.Value)
                        Else
                            cmd.Parameters.AddWithValue("@puntosfecha", DBNull.Value)
                        End If

                        cmd.Parameters.AddWithValue("@b", b)
                        cmd.Parameters.AddWithValue("@t", t)
                        cmd.Parameters.AddWithValue("@s", s)
                        cmd.Parameters.AddWithValue("@l", l)

                        cmd.ExecuteNonQuery()
                    End If
                Else
                    ' Si el registro no existe, insertar un nuevo registro
                    cmd.CommandText = queryInsertar

                    If puntosfecha.HasValue Then
                        cmd.Parameters.AddWithValue("@puntosfecha", puntosfecha.Value)
                    Else
                        cmd.Parameters.AddWithValue("@puntosfecha", DBNull.Value)
                    End If

                    cmd.Parameters.AddWithValue("@b", b)
                    cmd.Parameters.AddWithValue("@t", t)
                    cmd.Parameters.AddWithValue("@s", s)
                    cmd.Parameters.AddWithValue("@l", l)

                    cmd.ExecuteNonQuery()
                End If
            End Using
        End Using
    End Sub


    Public Shared Function ObtenerRegistrosExistentes(idequipo As Long, nrofecha As Integer) As DataTable
        Dim query As String = "SELECT idjugador, puntosfecha, b, t, s, l FROM registro WHERE idequipo = @idequipo AND nrofecha = @nrofecha"
        Dim DtRegistros As New DataTable

        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()

            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@idequipo", idequipo)
                cmd.Parameters.AddWithValue("@nrofecha", nrofecha)

                Dim adapter As New SQLiteDataAdapter(cmd)
                adapter.Fill(DtRegistros)
            End Using
        End Using

        Return DtRegistros

    End Function


End Class
