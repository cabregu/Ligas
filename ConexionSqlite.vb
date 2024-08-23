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



End Class
