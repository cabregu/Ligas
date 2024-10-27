Imports System.Data.SQLite

Public Class ConexionSqlite
    Private Shared Function ObtenerConexion() As String
        Dim connectionString As String
        ' Configura la ruta directamente a C:\baseligas\liga.db
        connectionString = "Data Source=C:\baseligas\liga.db;Version=3;"
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
                          "WHERE equipos.idequipo = @IdEquipo " &
                          "ORDER BY CASE jugadores.posicion " &
                          "    WHEN 'Por' THEN 1 " &
                          "    WHEN 'Def' THEN 2 " &
                          "    WHEN 'Med' THEN 3 " &
                          "    WHEN 'Del' THEN 4 " &
                          "END"

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

    Public Shared Function TransferirJugadoraequipo(idJugador As Integer, nuevoIdequipo As Integer) As Boolean
        Dim queryRegistro As String = "UPDATE registro SET idequipo = @nuevoIdequipo WHERE idjugador = @idJugador"
        Dim queryJugadores As String = "UPDATE jugadores SET idequipo = @nuevoIdequipo WHERE idjugadores = @idJugador"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                ' Actualizar tabla 'registro'
                Using cmdRegistro As New SQLiteCommand(queryRegistro, conn)
                    cmdRegistro.Parameters.AddWithValue("@nuevoIdequipo", nuevoIdequipo)
                    cmdRegistro.Parameters.AddWithValue("@idJugador", idJugador)
                    cmdRegistro.ExecuteNonQuery()
                End Using

                ' Actualizar tabla 'jugadores'
                Using cmdJugadores As New SQLiteCommand(queryJugadores, conn)
                    cmdJugadores.Parameters.AddWithValue("@nuevoIdequipo", nuevoIdequipo)
                    cmdJugadores.Parameters.AddWithValue("@idJugador", idJugador)
                    cmdJugadores.ExecuteNonQuery()
                End Using
            End Using

            ' Si todo fue exitoso, devolver True
            Return True

        Catch ex As Exception
            ' Si ocurrió un error, devolver False
            Return False
        End Try
    End Function

    Public Shared Function EliminarRegistrosPorJugador(idJugador As Integer, idequipo As Integer) As Boolean
        Dim queryEliminarRegistro As String = "DELETE FROM registro WHERE idjugador = @idJugador AND idequipo = @idequipo"
        Dim queryEliminarJugadores As String = "DELETE FROM jugadores WHERE idjugadores = @idJugador"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                ' Eliminar de la tabla 'registro'
                Using cmdEliminarRegistro As New SQLiteCommand(queryEliminarRegistro, conn)
                    cmdEliminarRegistro.Parameters.AddWithValue("@idJugador", idJugador)
                    cmdEliminarRegistro.Parameters.AddWithValue("@idequipo", idequipo)
                    cmdEliminarRegistro.ExecuteNonQuery()
                End Using

                ' Eliminar de la tabla 'jugadores'
                Using cmdEliminarJugadores As New SQLiteCommand(queryEliminarJugadores, conn)
                    cmdEliminarJugadores.Parameters.AddWithValue("@idJugador", idJugador)
                    cmdEliminarJugadores.ExecuteNonQuery()
                End Using
            End Using

            ' Si todo fue exitoso, devolver True
            Return True

        Catch ex As Exception
            ' Si ocurrió un error, devolver False
            Return False
        End Try
    End Function


    Public Shared Function ObtenerRegistrosDeTodosLosEquipos(idliga As Integer, Optional idequipo As Integer? = Nothing) As DataTable

        Try
            Dim dt As New DataTable()

            ' Consulta para obtener jugadores junto con el nombre del equipo, filtrando por idliga y, opcionalmente, por idequipo
            Dim queryJugadores As String = "SELECT jugadores.idequipo, equipos.nombre AS nombreEquipo, jugadores.idjugadores, jugadores.jugador, jugadores.posicion " &
                                       "FROM jugadores " &
                                       "INNER JOIN equipos ON jugadores.idequipo = equipos.idequipo " &
                                       "WHERE equipos.idliga = @idliga" &
                                       If(idequipo.HasValue, " AND equipos.idequipo = @idequipo", "")

            ' Consulta para obtener el número máximo de fechas por equipo, filtrando por idliga y, opcionalmente, por idequipo
            Dim queryMaxFechas As String = "SELECT idequipo, MAX(nrofecha) AS maxFecha " &
                                       "FROM registro " &
                                       "WHERE idequipo IN (SELECT idequipo FROM equipos WHERE idliga = @idliga)" &
                                       If(idequipo.HasValue, " AND idequipo = @idequipo", "") &
                                       " GROUP BY idequipo"

            ' Diccionario para almacenar el número máximo de fechas por equipo
            Dim maxFechasPorEquipo As New Dictionary(Of Integer, Integer)()

            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                ' Ejecutar consulta para obtener el máximo de fechas por equipo
                Using cmdMaxFechas As New SQLiteCommand(queryMaxFechas, conn)
                    cmdMaxFechas.Parameters.AddWithValue("@idliga", idliga)
                    If idequipo.HasValue Then
                        cmdMaxFechas.Parameters.AddWithValue("@idequipo", idequipo.Value)
                    End If

                    Using reader As SQLiteDataReader = cmdMaxFechas.ExecuteReader()
                        While reader.Read()
                            maxFechasPorEquipo.Add(reader.GetInt32(0), reader.GetInt32(1))
                        End While
                    End Using
                End Using

                ' Definir columnas del DataTable
                dt.Columns.Add("Equipo")
                dt.Columns.Add("Nombre del Equipo")
                dt.Columns.Add("ID Jugador")
                dt.Columns.Add("Jugador")
                dt.Columns.Add("Posición")

                Dim maxFechasGlobal As Integer = maxFechasPorEquipo.Values.Max()

                ' Añadir columnas para las fechas
                For i As Integer = 1 To maxFechasGlobal
                    dt.Columns.Add($"Fecha {i}", GetType(Decimal))
                Next

                ' Añadir columnas para S, T, B, L
                dt.Columns.Add("S", GetType(Integer))
                dt.Columns.Add("T", GetType(Integer))
                dt.Columns.Add("B", GetType(Integer))
                dt.Columns.Add("L", GetType(Integer))

                ' Añadir columnas para la suma total de puntos y el promedio
                dt.Columns.Add("Total Puntos", GetType(Decimal))
                dt.Columns.Add("Promedio", GetType(Decimal))

                ' Ejecutar consulta para obtener jugadores
                Using cmdJugadores As New SQLiteCommand(queryJugadores, conn)
                    cmdJugadores.Parameters.AddWithValue("@idliga", idliga)
                    If idequipo.HasValue Then
                        cmdJugadores.Parameters.AddWithValue("@idequipo", idequipo.Value)
                    End If

                    Using readerJugadores As SQLiteDataReader = cmdJugadores.ExecuteReader()
                        While readerJugadores.Read()
                            Dim equipoId As Integer = readerJugadores.GetInt32(0)
                            Dim nombreEquipo As String = readerJugadores.GetString(1)
                            Dim idjugador As Integer = readerJugadores.GetInt32(2)
                            Dim jugador As String = readerJugadores.GetString(3)
                            Dim posicion As String = readerJugadores.GetString(4)

                            ' Crear una nueva fila en el DataTable
                            Dim nuevaFila As DataRow = dt.NewRow()
                            nuevaFila("Equipo") = equipoId
                            nuevaFila("Nombre del Equipo") = nombreEquipo
                            nuevaFila("ID Jugador") = idjugador
                            nuevaFila("Jugador") = jugador
                            nuevaFila("Posición") = posicion

                            Dim totalPuntos As Decimal = 0D
                            Dim conteoFechasConPuntos As Integer = 0
                            Dim conteoS As Integer = 0
                            Dim conteoT As Integer = 0
                            Dim conteoB As Integer = 0
                            Dim conteoL As Integer = 0

                            ' Consulta para obtener los registros de puntos, S, T, B, L
                            Dim queryRegistros As String = "SELECT nrofecha, puntosfecha, b, t, s, l FROM registro " &
                                                       "WHERE idequipo = @idequipo AND idjugador = @idjugador"

                            Using cmdRegistros As New SQLiteCommand(queryRegistros, conn)
                                cmdRegistros.Parameters.AddWithValue("@idequipo", equipoId)
                                cmdRegistros.Parameters.AddWithValue("@idjugador", idjugador)

                                Using readerRegistros As SQLiteDataReader = cmdRegistros.ExecuteReader()
                                    While readerRegistros.Read()
                                        Dim nroFecha As Integer = readerRegistros.GetInt32(0)
                                        Dim puntosFechaValor As Decimal = If(IsDBNull(readerRegistros(1)), 0D, Convert.ToDecimal(readerRegistros(1)))
                                        Dim b As Integer = If(IsDBNull(readerRegistros(2)), 0, readerRegistros.GetInt32(2))
                                        Dim t As Integer = If(IsDBNull(readerRegistros(3)), 0, readerRegistros.GetInt32(3))
                                        Dim s As Integer = If(IsDBNull(readerRegistros(4)), 0, readerRegistros.GetInt32(4))
                                        Dim l As Integer = If(IsDBNull(readerRegistros(5)), 0, readerRegistros.GetInt32(5))

                                        ' Asignar los puntos a la columna correspondiente
                                        nuevaFila($"Fecha {nroFecha}") = puntosFechaValor

                                        ' Sumar los puntos y contar las fechas en las que el jugador obtuvo puntos
                                        totalPuntos += puntosFechaValor
                                        If puntosFechaValor > 0 Then conteoFechasConPuntos += 1

                                        ' Contar las ocurrencias de S, T, B, L
                                        conteoS += s
                                        conteoT += t
                                        conteoB += b
                                        conteoL += l
                                    End While
                                End Using
                            End Using

                            ' Asignar los conteos de S, T, B, L a las columnas correspondientes
                            nuevaFila("S") = conteoS
                            nuevaFila("T") = conteoT
                            nuevaFila("B") = conteoB
                            nuevaFila("L") = conteoL

                            ' Asignar la suma total de puntos y calcular el promedio
                            nuevaFila("Total Puntos") = totalPuntos
                            nuevaFila("Promedio") = If(conteoFechasConPuntos > 0, Math.Truncate(totalPuntos / conteoFechasConPuntos), 0)

                            ' Añadir la fila al DataTable
                            dt.Rows.Add(nuevaFila)
                        End While
                    End Using
                End Using
            End Using

            Return dt
        Catch ex As Exception
            Return Nothing
        End Try


    End Function

    Public Shared Function ObtenerValorEnteroConfiguracion() As Integer
        Dim valor As Integer = 0

        Dim query As String = "SELECT datoint FROM configuracion WHERE tipo = 'fechas'"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(query, conn)
                    valor = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

            Return valor
        Catch ex As Exception
            ' Manejar excepciones según sea necesario
            Return -1
        End Try
    End Function

    Public Shared Function ActualizarValorEnteroConfiguracion(nuevoValor As Integer) As Boolean
        Dim query As String = "UPDATE configuracion SET datoint = @valor WHERE tipo = 'fechas'"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@valor", nuevoValor)

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return filasAfectadas > 0
                End Using
            End Using
        Catch ex As Exception
            ' Manejar excepciones según sea necesario
            Return False
        End Try
    End Function

    Public Shared Function EditarNombreEquipo(idequipo As Integer, nuevoNombre As String) As Boolean
        Dim query As String = "UPDATE Equipos SET nombre = @nuevoNombre WHERE idequipo = @idequipo"
        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()
            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre)
                cmd.Parameters.AddWithValue("@idequipo", idequipo)
                Dim result As Integer = cmd.ExecuteNonQuery()
                ' Retorna true si se afectó al menos una fila, es decir, si la actualización fue exitosa
                Return result > 0
            End Using
        End Using
    End Function

    Public Shared Function EliminarEquipoYRegistros(idequipo As Integer) As Boolean
        Dim queryEliminarEquipo As String = "DELETE FROM Equipos WHERE idequipo = @idequipo"
        Dim queryEliminarRegistros As String = "DELETE FROM Registro WHERE idequipo = @idequipo"
        Dim queryEliminarJugadores As String = "DELETE FROM Jugadores WHERE idequipo = @idequipo"

        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()

            Using transaction = conn.BeginTransaction()
                Try
                    ' Eliminar registros de la tabla Registro
                    Using cmdEliminarRegistros As New SQLiteCommand(queryEliminarRegistros, conn)
                        cmdEliminarRegistros.Parameters.AddWithValue("@idequipo", idequipo)
                        cmdEliminarRegistros.ExecuteNonQuery()
                    End Using

                    ' Eliminar registros de la tabla Jugadores
                    Using cmdEliminarJugadores As New SQLiteCommand(queryEliminarJugadores, conn)
                        cmdEliminarJugadores.Parameters.AddWithValue("@idequipo", idequipo)
                        cmdEliminarJugadores.ExecuteNonQuery()
                    End Using

                    ' Eliminar el equipo
                    Using cmdEliminarEquipo As New SQLiteCommand(queryEliminarEquipo, conn)
                        cmdEliminarEquipo.Parameters.AddWithValue("@idequipo", idequipo)
                        Dim result As Integer = cmdEliminarEquipo.ExecuteNonQuery()

                        If result = 0 Then
                            Throw New Exception("No se encontró el equipo a eliminar.")
                        End If
                    End Using

                    ' Confirmar la transacción si todo ha salido bien
                    transaction.Commit()
                    Return True
                Catch ex As Exception
                    ' Deshacer la transacción en caso de error
                    transaction.Rollback()
                    MessageBox.Show("Error al eliminar equipo y registros: " & ex.Message)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Shared Function ActualizarNombreJugador(idJugador As Integer, nuevoNombre As String, nuevaPosicion As String) As Boolean
        Dim query As String = "UPDATE jugadores SET jugador = @nuevoNombre, posicion = @nuevaPosicion WHERE idjugadores = @idJugador"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                ' Actualizar tabla 'jugadores'
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre)
                    cmd.Parameters.AddWithValue("@nuevaPosicion", nuevaPosicion)
                    cmd.Parameters.AddWithValue("@idJugador", idJugador)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' Si todo fue exitoso, devolver True
            Return True

        Catch ex As Exception
            ' Si ocurrió un error, devolver False
            Return False
        End Try
    End Function


    Public Shared Function ObtenerNombresSubligas(ByVal liga As Integer) As List(Of String)
        Dim nombresSubligas As New List(Of String)()
        Dim query As String = "SELECT DISTINCT subliga FROM subliga WHERE liga = @liga"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(query, conn)
                    ' Agregar el parámetro a la consulta SQL
                    cmd.Parameters.AddWithValue("@liga", liga)

                    Using reader As SQLiteDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim nombreSubliga As String = reader("subliga").ToString()
                            nombresSubligas.Add(nombreSubliga)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Manejar excepciones según sea necesario
            ' Puedes registrar el error o mostrar un mensaje al usuario
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Return nombresSubligas
    End Function



    Public Shared Function EliminarDeSubligaPorIdJugador(nombreSubliga As String, idJugador As Integer, liga As Integer) As Boolean
        Dim query As String = "DELETE FROM subliga WHERE idjugador = @idjugador AND subliga = @nombreSubliga AND liga = @liga"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(query, conn)
                    ' Añade los parámetros al comando
                    cmd.Parameters.AddWithValue("@idjugador", idJugador)
                    cmd.Parameters.AddWithValue("@nombreSubliga", nombreSubliga)
                    cmd.Parameters.AddWithValue("@liga", liga)

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                    ' Retorna True si se eliminó al menos una fila, False en caso contrario
                    Return filasAfectadas > 0
                End Using
            End Using
        Catch ex As Exception
            ' Manejo de errores: Puedes registrar el error o manejarlo de acuerdo a tus necesidades
            Return False
        End Try
    End Function


    Public Shared Function ObtenerJugadoresPorSubliga(nombreSubliga As String) As DataTable
        ' Modifica la consulta para eliminar el ordenamiento por el nombre del equipo
        Dim query As String = "SELECT s.idjugador, j.jugador, j.posicion, e.nombre AS equipo " &
                          "FROM subliga s " &
                          "INNER JOIN jugadores j ON s.idjugador = j.idjugadores " &
                          "INNER JOIN equipos e ON j.idequipo = e.idequipo " &
                          "WHERE s.subliga = @nombreSubliga " &
                          "ORDER BY CASE j.posicion " &
                          "             WHEN 'Por' THEN 1 " &
                          "             WHEN 'Def' THEN 2 " &
                          "             WHEN 'Med' THEN 3 " &
                          "             WHEN 'Del' THEN 4 " &
                          "          END"

        Dim dt As New DataTable()

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nombreSubliga", nombreSubliga)

                    Using adapter As New SQLiteDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Manejo de errores (se recomienda registrar el error en un log o mostrar un mensaje)
            Console.WriteLine("Error al obtener jugadores por subliga: " & ex.Message)
        End Try

        Return dt
    End Function


    Public Shared Function AgregarJugadorASubliga(nombreSubliga As String, idJugador As Integer, liga As Integer) As Boolean
        Dim queryVerificarExistencia As String = "SELECT COUNT(*) FROM subliga WHERE idjugador = @idjugador AND subliga = @nombreSubliga AND liga = @liga"
        Dim queryInsertar As String = "INSERT INTO subliga (subliga, idjugador, liga) VALUES (@nombreSubliga, @idjugador, @liga)"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                ' Verificar si el jugador ya está en la subliga y liga
                Using cmdVerificarExistencia As New SQLiteCommand(queryVerificarExistencia, conn)
                    cmdVerificarExistencia.Parameters.AddWithValue("@idjugador", idJugador)
                    cmdVerificarExistencia.Parameters.AddWithValue("@nombreSubliga", nombreSubliga)
                    cmdVerificarExistencia.Parameters.AddWithValue("@liga", liga)
                    Dim count As Integer = Convert.ToInt32(cmdVerificarExistencia.ExecuteScalar())

                    ' Si el jugador ya está en la subliga y liga, no hacer nada
                    If count > 0 Then
                        Return False
                    End If
                End Using

                ' Insertar el jugador en la subliga si no existe
                Using cmdInsertar As New SQLiteCommand(queryInsertar, conn)
                    cmdInsertar.Parameters.AddWithValue("@nombreSubliga", nombreSubliga)
                    cmdInsertar.Parameters.AddWithValue("@idjugador", idJugador)
                    cmdInsertar.Parameters.AddWithValue("@liga", liga)
                    Dim filasAfectadas As Integer = cmdInsertar.ExecuteNonQuery()

                    Return filasAfectadas > 0
                End Using
            End Using
        Catch ex As Exception
            ' Manejo de errores: puedes registrar el error o manejarlo de acuerdo a tus necesidades
            Return False
        End Try
    End Function

    Public Shared Function EliminarSubligaPorNombre(nombreSubliga As String) As Boolean
        Dim queryEliminar As String = "DELETE FROM subliga WHERE subliga = @nombreSubliga"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(queryEliminar, conn)
                    ' Añade el parámetro al comando
                    cmd.Parameters.AddWithValue("@nombreSubliga", nombreSubliga)

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                    ' Retorna True si se eliminaron filas, False en caso contrario
                    Return filasAfectadas > 0
                End Using
            End Using
        Catch ex As Exception
            ' Manejo de errores: puedes registrar el error o manejarlo de acuerdo a tus necesidades
            Return False
        End Try
    End Function


    Public Shared Function ActualizarNombreLiga(idLiga As Integer, nuevoNombre As String) As Boolean
        Dim query As String = "UPDATE liga SET nombreliga = @nuevoNombre WHERE idliga = @idLiga"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre)
                    cmd.Parameters.AddWithValue("@idLiga", idLiga)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception

            Return False
        End Try
    End Function

    Public Shared Function EliminarRegistrosPorFechaYLiga(nrofecha As Integer, idliga As Integer) As Boolean
        Dim queryEliminar As String = "
        DELETE FROM registro
        WHERE nrofecha = @nrofecha 
        AND idjugador IN (
            SELECT j.idjugadores 
            FROM jugadores j
            JOIN equipos e ON j.idequipo = e.idequipo
            WHERE e.idliga = @idliga
        )"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(queryEliminar, conn)
                    ' Añade los parámetros al comando
                    cmd.Parameters.AddWithValue("@nrofecha", nrofecha)
                    cmd.Parameters.AddWithValue("@idliga", idliga)

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                    ' Retorna True si se eliminaron filas, False en caso contrario
                    Return filasAfectadas > 0
                End Using
            End Using

        Catch ex As Exception
            ' Manejo de errores: puedes registrar el error o manejarlo de acuerdo a tus necesidades
            Return False
        End Try
    End Function

    Public Shared Function ActualizarPuntosJugador(idjugador As Integer, nrofecha As Integer, nuevosPuntos As Decimal) As Boolean
        Dim queryActualizar As String = "
    UPDATE registro
    SET puntosfecha = @nuevosPuntos
    WHERE idjugador = @idjugador AND nrofecha = @nrofecha"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()

                Using cmd As New SQLiteCommand(queryActualizar, conn)
                    ' Añade los parámetros al comando
                    cmd.Parameters.AddWithValue("@nuevosPuntos", nuevosPuntos)
                    cmd.Parameters.AddWithValue("@idjugador", idjugador)
                    cmd.Parameters.AddWithValue("@nrofecha", nrofecha)

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                    ' Retorna True si se actualizaron filas, False en caso contrario
                    Return filasAfectadas > 0
                End Using
            End Using

        Catch ex As Exception
            ' Manejo de errores: puedes registrar el error o manejarlo de acuerdo a tus necesidades
            Return False
        End Try
    End Function


    Public Shared Function InsertarEquipoParaTransferirDeLiga(nombreEquipo As String, idLiga As Integer) As Integer
        Dim queryExistencia As String = "SELECT COUNT(*) FROM Equipos WHERE nombre = @nombre AND idliga = @idliga"
        Dim queryInsercion As String = "INSERT INTO Equipos (nombre, idliga) VALUES (@nombre, @idliga); SELECT last_insert_rowid();"

        Try
            Using conn As New SQLiteConnection(ObtenerConexion())
                conn.Open()


                Using cmdExistencia As New SQLiteCommand(queryExistencia, conn)
                    cmdExistencia.Parameters.AddWithValue("@nombre", nombreEquipo)
                    cmdExistencia.Parameters.AddWithValue("@idliga", idLiga)

                    Dim existe As Integer = Convert.ToInt32(cmdExistencia.ExecuteScalar())
                    If existe > 0 Then
                        Return 0 ' 0
                    End If
                End Using

                Using cmdInsercion As New SQLiteCommand(queryInsercion, conn)
                    cmdInsercion.Parameters.AddWithValue("@nombre", nombreEquipo)
                    cmdInsercion.Parameters.AddWithValue("@idliga", idLiga)

                    Dim idEquipo As Integer = Convert.ToInt32(cmdInsercion.ExecuteScalar())
                    Return idEquipo
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error al insertar el equipo: " & ex.Message)
            Return -1
        End Try
    End Function


    Public Shared Function InsertarJugadorPraTransferirdeliga(jugador As String, posicion As String, idequipo As Integer) As Boolean
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

                MessageBox.Show("Error al insertar el jugador: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Shared Sub AgregarLista(nombreLista As String, idJugador As Integer)
        ' Verificar si la tabla existe y crearla si no existe
        VerificarYCrearTabla()

        ' Inserta el nuevo registro directamente sin verificar si la lista ya existe
        Dim queryInsert As String = "INSERT INTO listas (nombre_lista, idjugador) VALUES (@nombreLista, @idJugador)"
        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()
            Using cmdInsert As New SQLiteCommand(queryInsert, conn)
                cmdInsert.Parameters.AddWithValue("@nombreLista", nombreLista)
                cmdInsert.Parameters.AddWithValue("@idJugador", idJugador)
                cmdInsert.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub EliminarLista(nombreLista As String)

        ' Verificar si la tabla existe y crearla si no existe
        VerificarYCrearTabla()

        Dim queryDelete As String = "DELETE FROM listas WHERE nombre_lista = @nombreLista"
        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()
            Using cmdDelete As New SQLiteCommand(queryDelete, conn)
                cmdDelete.Parameters.AddWithValue("@nombreLista", nombreLista)
                cmdDelete.ExecuteNonQuery()
            End Using
        End Using
    End Sub



    Public Shared Function ObtenerNombresListas() As DataTable
        Dim dt As New DataTable()

        ' Verificar si la tabla existe
        VerificarYCrearTabla()

        Dim query As String = "SELECT DISTINCT nombre_lista FROM listas"
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

    Public Shared Function ObtenerJugadoresPorListaYFecha(nombreLista As String, nroFecha As Integer) As DataTable
        Dim dt As New DataTable()

        ' Verificar si la tabla existe
        VerificarYCrearTabla()

        Dim query As String = "
SELECT 
    j.idequipo AS Equipo,
    j.idjugadores AS 'ID Jugador',
    e.nombre AS 'Nombre del Equipo',
    j.jugador AS Jugador,
    j.posicion AS Posicion,
    r.puntosfecha AS PuntosFecha
FROM 
    listas l
JOIN 
    jugadores j ON l.idjugador = j.idjugadores
JOIN 
    registro r ON j.idjugadores = r.idjugador AND j.idequipo = r.idequipo
JOIN 
    equipos e ON j.idequipo = e.idequipo
WHERE 
    l.nombre_lista = @nombreLista 
    AND r.nrofecha = @nroFecha
ORDER BY 
    CASE j.posicion 
        WHEN 'Por' THEN 1
        WHEN 'Def' THEN 2
        WHEN 'Med' THEN 3
        WHEN 'Del' THEN 4
        ELSE 5
    END,
    r.puntosfecha DESC;"

        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()
            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@nombreLista", nombreLista)
                cmd.Parameters.AddWithValue("@nroFecha", nroFecha)
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        ' Cambia el nombre de la columna a "Fecha {nroFecha}" después de que se carga el DataTable
        If dt.Columns.Contains("PuntosFecha") Then
            dt.Columns("PuntosFecha").ColumnName = "Fecha " & nroFecha.ToString()
        End If

        Return dt
    End Function





    Private Shared Sub VerificarYCrearTabla()
        Dim query As String = "CREATE TABLE IF NOT EXISTS listas (id INTEGER PRIMARY KEY AUTOINCREMENT, nombre_lista TEXT, idjugador INTEGER)"
        Using conn As New SQLiteConnection(ObtenerConexion())
            conn.Open()
            Using cmd As New SQLiteCommand(query, conn)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub



End Class
