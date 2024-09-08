Imports Ligas.ConexionSqlite

Public Class FrmSubliga
    Private Sub FrmSubliga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarSubligas()
    End Sub


    Private Sub CargarSubligas()
        Dim idLiga As Integer


        If Integer.TryParse(LblIdLiga.Text, idLiga) Then

            Dim nombresSubligas As List(Of String) = ObtenerNombresSubligas(idLiga)


            CmbSubliga.DataSource = nombresSubligas
            CmbSubliga.SelectedIndex = -1
        Else
            MessageBox.Show("El ID de la liga no es válido.")
        End If
    End Sub

    Private Sub BtnSeleccionar_Click(sender As Object, e As EventArgs) Handles BtnSeleccionar.Click
        If CmbSubliga.Text <> "" Then
            ' Obtener los DataTables
            Dim dtSubliga As DataTable = ObtenerJugadoresPorSubliga(CmbSubliga.Text)
            Dim dtTodosLosEquipos As DataTable = ObtenerRegistrosDeTodosLosEquipos(Convert.ToInt32(LblIdLiga.Text))

            ' Crear un nuevo DataTable para almacenar las filas filtradas
            Dim dtFiltrado As DataTable = dtTodosLosEquipos.Clone()

            ' Añadir una columna de ordenación
            Dim colOrden As New DataColumn("Orden", GetType(Integer))
            dtFiltrado.Columns.Add(colOrden)

            ' Crear un HashSet para almacenar los IDs de los jugadores de la subliga
            Dim idJugadoresSubliga As HashSet(Of Integer) = New HashSet(Of Integer)()
            For Each row As DataRow In dtSubliga.Rows
                idJugadoresSubliga.Add(Convert.ToInt32(row("idjugador")))
            Next

            ' Filtrar y asignar valores de ordenación
            For Each row As DataRow In dtTodosLosEquipos.Rows
                Dim idJugador As Integer = Convert.ToInt32(row("ID Jugador"))
                If idJugadoresSubliga.Contains(idJugador) Then
                    ' Copiar la fila y asignar valor de ordenación
                    Dim nuevaFila As DataRow = dtFiltrado.NewRow()
                    nuevaFila.ItemArray = row.ItemArray.Clone()

                    ' Asignar el valor de ordenación según la posición
                    Select Case row("Posición").ToString()
                        Case "Por"
                            nuevaFila("Orden") = 1
                        Case "Def"
                            nuevaFila("Orden") = 2
                        Case "Med"
                            nuevaFila("Orden") = 3
                        Case "Del"
                            nuevaFila("Orden") = 4
                        Case Else
                            nuevaFila("Orden") = 5
                    End Select

                    dtFiltrado.Rows.Add(nuevaFila)
                End If
            Next

            dtFiltrado.DefaultView.Sort = "Orden ASC"
            dtFiltrado = dtFiltrado.DefaultView.ToTable()


            dtFiltrado.Columns.Remove("Orden")

            DgvDatos.DataSource = dtFiltrado
            DgvDatos.Columns("Equipo").Visible = False
            DgvDatos.Columns("ID Jugador").Visible = False

            DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        End If
    End Sub




End Class