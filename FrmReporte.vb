Imports Ligas.ConexionSqlite
Imports OfficeOpenXml
Imports System.IO

Public Class FrmReporte
    Private Sub BtnObtenerDatos_Click(sender As Object, e As EventArgs) Handles BtnObtenerDatos.Click
        Dim dt As New DataTable
        dt = ObtenerRegistrosDeTodosLosEquipos()

        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = dt
        DgvDatos.Columns("Equipo").Visible = False
        DgvDatos.Columns("ID Jugador").Visible = False
        DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub
    Private Sub Btnxls_Click(sender As Object, e As EventArgs) Handles Btnxls.Click
        ' Establece el contexto de la licencia de EPPlus
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

        ' Llama a la función que exporta el DataGridView a Excel
        Dim filePath As String = ExportarAExcel(DgvDatos, "Reporte.xlsx") ' Cambia "DgvDatos" al nombre real de tu DataGridView

        ' Intenta abrir el archivo Excel
        If Not String.IsNullOrEmpty(filePath) AndAlso System.IO.File.Exists(filePath) Then
            Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
        Else
            MessageBox.Show("El archivo no se pudo crear o no se encuentra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function ExportarAExcel(dataGrid As DataGridView, fileName As String) As String
        Try
            ' Crear el paquete Excel
            Using package As New ExcelPackage()
                Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Datos")

                ' Exportar encabezados
                For col As Integer = 1 To dataGrid.Columns.Count
                    worksheet.Cells(1, col).Value = dataGrid.Columns(col - 1).HeaderText
                Next

                ' Exportar datos
                For row As Integer = 1 To dataGrid.Rows.Count
                    For col As Integer = 1 To dataGrid.Columns.Count
                        worksheet.Cells(row + 1, col).Value = dataGrid.Rows(row - 1).Cells(col - 1).Value
                    Next
                Next

                ' Guardar el archivo en la ubicación deseada
                Dim filePath As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)
                package.SaveAs(New System.IO.FileInfo(filePath))

                ' Retornar la ruta del archivo
                Return filePath
            End Using
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al exportar a Excel: " & ex.Message)
            Return String.Empty
        End Try
    End Function


End Class