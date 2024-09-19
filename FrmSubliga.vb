Imports System.IO
Imports Ligas.ConexionSqlite
Imports OfficeOpenXml

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
            Dim dtSubliga As DataTable = ObtenerJugadoresPorSubliga(CmbSubliga.Text)
            Dim dtTodosLosEquipos As DataTable = ObtenerRegistrosDeTodosLosEquipos(Convert.ToInt32(LblIdLiga.Text))

            Dim dtFiltrado As DataTable = dtTodosLosEquipos.Clone()

            Dim colOrden As New DataColumn("Orden", GetType(Integer))
            dtFiltrado.Columns.Add(colOrden)

            Dim idJugadoresSubliga As HashSet(Of Integer) = New HashSet(Of Integer)()
            For Each row As DataRow In dtSubliga.Rows
                idJugadoresSubliga.Add(Convert.ToInt32(row("idjugador")))
            Next

            For Each row As DataRow In dtTodosLosEquipos.Rows
                Dim idJugador As Integer = Convert.ToInt32(row("ID Jugador"))
                If idJugadoresSubliga.Contains(idJugador) Then
                    Dim nuevaFila As DataRow = dtFiltrado.NewRow()
                    nuevaFila.ItemArray = row.ItemArray.Clone()

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

            ' Crear una vista del DataTable para ordenar
            Dim dataView As DataView = dtFiltrado.DefaultView
            dataView.Sort = "Orden ASC, Promedio DESC"

            ' Crear un nuevo DataTable ordenado
            Dim sortedDataTable As DataTable = dataView.ToTable()

            ' Eliminar la columna auxiliar
            If sortedDataTable.Columns.Contains("Orden") Then
                sortedDataTable.Columns.Remove("Orden")
            End If

            ' Configurar el DataGridView
            DgvDatos.DataSource = sortedDataTable
            DgvDatos.Columns("Equipo").Visible = False

            'DgvDatos.Columns("ID Jugador").Visible = False

            DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
    End Sub


    Private Sub Btnxls_Click(sender As Object, e As EventArgs) Handles Btnxls.Click
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        ExportarDataGridViewAExcel(DgvDatos)
    End Sub

    Public Sub ExportarDataGridViewAExcel(dgv As DataGridView)
        Try
            ' Crear una instancia del cuadro de diálogo para guardar archivos
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Guardar archivo Excel"
            saveFileDialog.FileName = "Datos.xlsx" ' Nombre predeterminado del archivo

            ' Mostrar el cuadro de diálogo y verificar si el usuario hace clic en "Guardar"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = saveFileDialog.FileName

                ' Crear un nuevo paquete Excel
                Using package As New ExcelPackage()
                    ' Crear una nueva hoja en el paquete
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet1")

                    ' Agregar encabezados de columna
                    For colIndex As Integer = 0 To dgv.Columns.Count - 1
                        worksheet.Cells(1, colIndex + 1).Value = dgv.Columns(colIndex).HeaderText
                    Next

                    ' Agregar datos de filas
                    For rowIndex As Integer = 0 To dgv.Rows.Count - 1
                        Dim row As DataGridViewRow = dgv.Rows(rowIndex)
                        For colIndex As Integer = 0 To dgv.Columns.Count - 1
                            Dim cellValue As Object = row.Cells(colIndex).Value
                            worksheet.Cells(rowIndex + 2, colIndex + 1).Value = If(cellValue IsNot Nothing, cellValue.ToString(), String.Empty)
                        Next
                    Next

                    ' Guardar el archivo Excel
                    Using stream As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                        package.SaveAs(stream)
                    End Using

                    MsgBox("Datos exportados exitosamente a Excel.", MsgBoxStyle.Information, "Exportar a Excel")
                End Using
            End If

        Catch ex As Exception
            MsgBox("Error al exportar a Excel: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BtnEliminarFecha_Click(sender As Object, e As EventArgs) Handles BtnEliminarFecha.Click


        If String.IsNullOrWhiteSpace(TxtFechaNro.Text) Then
            MessageBox.Show("Por favor, ingresa un número en el campo de fecha.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DgvDatos.Rows.Count = 0 Then
            MessageBox.Show("No hay datos disponibles para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar los registros de la fecha " & TxtFechaNro.Text & "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Dim fecha As Integer
            Dim idLiga As Integer

            RealizarCopiaDeSeguridad()

            If Integer.TryParse(TxtFechaNro.Text, fecha) AndAlso Integer.TryParse(LblIdLiga.Text, idLiga) Then

                If EliminarRegistrosPorFechaYLiga(fecha, idLiga) Then
                    MessageBox.Show("Registros eliminados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    MessageBox.Show("No se eliminaron registros o ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Por favor, ingresa un número válido para la fecha y la liga.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub



    Public Function RealizarCopiaDeSeguridad() As String
        Dim rutaArchivoOriginal As String = "C:\baseligas\liga.db"
        Dim rutaArchivoCopia As String = String.Empty


        If System.IO.File.Exists(rutaArchivoOriginal) Then

            Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
            Dim nombreArchivoCopia As String = $"liga_EliminoFecha_{timestamp}.db"
            rutaArchivoCopia = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rutaArchivoOriginal), nombreArchivoCopia)

            Try
                System.IO.File.Copy(rutaArchivoOriginal, rutaArchivoCopia)
                Return rutaArchivoCopia
            Catch ex As Exception
                Return "Error: " & ex.Message
            End Try
        Else
            Return "El archivo original no existe."
        End If
    End Function


    Private Sub TxtFechaNro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFechaNro.KeyPress

        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


End Class