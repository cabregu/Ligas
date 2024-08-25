Imports System.Data.SQLite

Public Class ConexionSqlite
    Private Shared Function ObtenerConexion() As String
        Dim connectionString As String
        connectionString = $"Data Source={System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "liga.db")};Version=3;"
        Return connectionString

    End Function
    Public Shared Function ObtenerEquiposPorLiga(idLiga As Integer) As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM Equipos WHERE idliga = @idLiga"
        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()
            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@idLiga", idLiga)
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
        Dim queryObtenerValores As String = "SELECT puntosfecha, b, t, s, l FROM registro WHERE idequipo = @idequipo AND idjugador = @idjugador AND nrofecha = @nrofecha"
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
                    ' Si el registro existe, obtener los valores actuales
                    cmd.CommandText = queryObtenerValores
                    Dim reader As SQLiteDataReader = cmd.ExecuteReader()

                    Dim puntosActuales As Decimal? = Nothing
                    Dim bActual As Integer = 0
                    Dim tActual As Integer = 0
                    Dim sActual As Integer = 0
                    Dim lActual As Integer = 0

                    If reader.Read() Then
                        puntosActuales = If(reader("puntosfecha") IsNot DBNull.Value, Convert.ToDecimal(reader("puntosfecha")), CType(Nothing, Decimal?))
                        bActual = If(reader("b") IsNot DBNull.Value, Convert.ToInt32(reader("b")), 0)
                        tActual = If(reader("t") IsNot DBNull.Value, Convert.ToInt32(reader("t")), 0)
                        sActual = If(reader("s") IsNot DBNull.Value, Convert.ToInt32(reader("s")), 0)
                        lActual = If(reader("l") IsNot DBNull.Value, Convert.ToInt32(reader("l")), 0)
                    End If
                    reader.Close()

                    ' Comprobar si puntosfecha o cualquier otro valor es diferente
                    If puntosfecha <> puntosActuales OrElse b <> bActual OrElse t <> tActual OrElse s <> sActual OrElse l <> lActual Then
                        cmd.CommandText = queryActualizar

                        ' Asegurarse de que los valores se pasen correctamente
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@puntosfecha", If(puntosfecha.HasValue, puntosfecha.Value, DBNull.Value))
                        cmd.Parameters.AddWithValue("@b", b)
                        cmd.Parameters.AddWithValue("@t", t)
                        cmd.Parameters.AddWithValue("@s", s)
                        cmd.Parameters.AddWithValue("@l", l)
                        cmd.Parameters.AddWithValue("@idequipo", idequipo)
                        cmd.Parameters.AddWithValue("@idjugador", idjugador)
                        cmd.Parameters.AddWithValue("@nrofecha", nrofecha)

                        cmd.ExecuteNonQuery()
                    End If
                Else
                    ' Si el registro no existe, insertar un nuevo registro
                    cmd.CommandText = queryInsertar

                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@puntosfecha", If(puntosfecha.HasValue, puntosfecha.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@b", b)
                    cmd.Parameters.AddWithValue("@t", t)
                    cmd.Parameters.AddWithValue("@s", s)
                    cmd.Parameters.AddWithValue("@l", l)
                    cmd.Parameters.AddWithValue("@idequipo", idequipo)
                    cmd.Parameters.AddWithValue("@idjugador", idjugador)
                    cmd.Parameters.AddWithValue("@nrofecha", nrofecha)

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

    Public Shared Function InsertarLiga(nombreLiga As String) As Boolean
        Dim queryInsertar As String = "INSERT INTO liga (nombreliga) VALUES (@nombreliga)"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(queryInsertar, conn)
                    cmd.Parameters.AddWithValue("@nombreliga", nombreLiga)
                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return filasAfectadas > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function ObtenerLigasParaCombo() As DataTable
        Dim query As String = "SELECT idliga, nombreliga FROM liga"
        Dim dt As New DataTable()

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(query, conn)
                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try

        Return dt
    End Function

    Public Shared Function EliminarLiga(idLiga As Integer) As String

        Dim queryVerificar As String = "SELECT COUNT(*) FROM equipos WHERE idliga = @idliga"

        Dim queryEliminar As String = "DELETE FROM liga WHERE idliga = @idliga"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()


                Using cmdVerificar As New SQLiteCommand(queryVerificar, conn)
                    cmdVerificar.Parameters.AddWithValue("@idliga", idLiga)
                    Dim equiposCount As Integer = Convert.ToInt32(cmdVerificar.ExecuteScalar())

                    If equiposCount > 0 Then

                        Return "Esa liga ya tiene equipos asociados y no puede ser eliminada."
                    End If
                End Using


                Using cmdEliminar As New SQLiteCommand(queryEliminar, conn)
                    cmdEliminar.Parameters.AddWithValue("@idliga", idLiga)
                    Dim filasAfectadas As Integer = cmdEliminar.ExecuteNonQuery()

                    If filasAfectadas > 0 Then
                        Return "Liga eliminada correctamente."
                    Else
                        Return "No se encontró la liga especificada."
                    End If
                End Using
            End Using
        Catch ex As Exception

            Return "Ocurrió un error al intentar eliminar la liga."
        End Try
    End Function

    Public Shared Function InsertarEquipo(nombreEquipo As String, idLiga As Integer) As Boolean
        Dim query As String = "INSERT INTO Equipos (nombre, idliga) VALUES (@nombre, @idliga)"
        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()
                Using cmd As New SQLiteCommand(query, conn)
                    ' Agregar los parámetros a la consulta
                    cmd.Parameters.AddWithValue("@nombre", nombreEquipo)
                    cmd.Parameters.AddWithValue("@idliga", idLiga)

                    ' Ejecutar la consulta de inserción
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            ' Manejo de excepciones (opcional)
            Console.WriteLine("Error al insertar el equipo: " & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function InsertarJugador(jugador As String, posicion As String, idequipo As Integer) As Boolean
        Dim query As String = "INSERT INTO jugadores (jugador, posicion, idequipo) VALUES (@jugador, @posicion, @idequipo)"

        Using conn As New SQLiteConnection(ObtenerConexion())
            Try
                conn.Open()
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@jugador", jugador)
                    cmd.Parameters.AddWithValue("@posicion", posicion)
                    cmd.Parameters.AddWithValue("@idequipo", idequipo)

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return filasAfectadas > 0
                End Using
            Catch ex As Exception
                ' Manejar cualquier excepción si es necesario
                MessageBox.Show("Error al insertar el jugador: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function


End Class
