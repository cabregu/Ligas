Imports OfficeOpenXml
Imports System.IO
Imports System.Windows.Forms
Imports Ligas.ConexionSqlite


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

    Private Sub Btnxls_Click(sender As Object, e As EventArgs) Handles Btnxls.Click
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        ExportarDataGridViewAExcel(DgvDatos)
    End Sub
End Class
