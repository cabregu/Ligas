
Imports System.IO
Imports Ligas.ConexionSqlite
Imports OfficeOpenXml


Public Class FrmUsadosPorFechas

    Private Sub FrmFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarNombresListasEnCombo()
    End Sub
    Public Sub CargarNombresListasEnCombo()
        Dim dtListas As DataTable = ObtenerNombresListas()

        CmbLista.Items.Clear()

        For Each row As DataRow In dtListas.Rows
            CmbLista.Items.Add(row("nombre_lista").ToString())
        Next
    End Sub


    Private Sub CargarDgvFechas(ByVal dgv As DataGridView)
        Dim CantidadFechas As Integer = ObtenerDatoFechas()
        dgv.Rows.Clear()

        ' Añadir cada fecha como una nueva fila en el DataGridView
        For i As Integer = 1 To CantidadFechas
            dgv.Rows.Add("Fecha " & i)
        Next
    End Sub



    Private Sub BtnLista_Click(sender As Object, e As EventArgs) Handles BtnLista.Click
        FrmCrearLista.LblIdLiga.Text = LblIdLiga.Text
        FrmCrearLista.LblNombreLiga.Text = LblNombreLiga.Text
        FrmCrearLista.Show()
    End Sub

    Private Sub CmbSubliga_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbLista.SelectedValueChanged
        If CmbLista.Text <> "" Then
            CargarDgvFechas(DgvFechas)
        End If
    End Sub

    Private Sub DgvFechas_Click(sender As Object, e As EventArgs) Handles DgvFechas.Click

        If String.IsNullOrWhiteSpace(cmblista.Text) Then
            MessageBox.Show("Seleccione una lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DgvFechas.CurrentRow Is Nothing OrElse DgvFechas.CurrentRow.Cells(0).Value Is Nothing Then
            MessageBox.Show("Seleccione una fecha en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim nombreLista As String = CmbLista.Text
        Dim fechaTexto As String = DgvFechas.CurrentRow.Cells(0).Value.ToString()


        Dim nroFecha As Integer
        If fechaTexto.StartsWith("Fecha ") AndAlso Integer.TryParse(fechaTexto.Substring(6), nroFecha) Then

            Dim dtJugadores As DataTable = ObtenerJugadoresPorListaYFecha(nombreLista, nroFecha)


            If dtJugadores.Rows.Count = 0 Then
                MessageBox.Show("No Hay datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                DgvJugadores.DataSource = Nothing
                DgvJugadores.DataSource = dtJugadores
                DgvJugadores.Columns("equipo").Visible = False
                DgvJugadores.Columns("ID Jugador").Visible = False
            End If
        Else
            MessageBox.Show("Formato de fecha no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminarlista_Click(sender As Object, e As EventArgs) Handles BtnEliminarlista.Click
        Dim nombreLista As String = CmbLista.SelectedItem.ToString()

        ' Verificar que se haya seleccionado una lista
        If String.IsNullOrEmpty(nombreLista) Then
            MessageBox.Show("Por favor, selecciona una lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Advertencia antes de eliminar
        Dim resultado As DialogResult = MessageBox.Show($"¿Estás seguro de que deseas eliminar la lista '{nombreLista}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            ' Llamar a la función para eliminar la lista
            EliminarLista(nombreLista)
            MessageBox.Show($"La lista '{nombreLista}' ha sido eliminada.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Vaciar el DataGridView
            DgvFechas.DataSource = Nothing
            DgvFechas.Rows.Clear()

            DgvJugadores.DataSource = Nothing
            DgvJugadores.Rows.Clear()

            CmbLista.Text = ""


            ' Recargar el ComboBox
            CargarNombresListasEnCombo()
        End If

    End Sub

    Private Sub Btnxls_Click(sender As Object, e As EventArgs) Handles Btnxls.Click
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        ExportarDataGridViewAExcel(DgvJugadores)
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

End Class

