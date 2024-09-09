Imports OfficeOpenXml
Imports System.IO
Imports System.Windows.Forms
Imports Ligas.ConexionSqlite


Public Class FrmReporte
    'Private Sub BtnObtenerDatos_Click(sender As Object, e As EventArgs) Handles BtnObtenerDatos.Click
    '    Dim idEquipo As Integer = Convert.ToInt32(CmbEquipos.SelectedValue)

    '    If CmbEquipos.Text = "Todos los equipos" Then
    '        Dim dt As New DataTable
    '        dt = ObtenerRegistrosDeTodosLosEquipos(LblIdLiga.Text)
    '        DgvDatos.DataSource = Nothing
    '        DgvDatos.DataSource = dt
    '        DgvDatos.Columns("Equipo").Visible = False
    '        DgvDatos.Columns("ID Jugador").Visible = False
    '        DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '    Else

    '        Dim dt As DataTable = ObtenerRegistrosDeTodosLosEquipos(LblIdLiga.Text, idEquipo)
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            ' Solo asigna la fuente de datos y configura el DataGridView si hay datos
    '            DgvDatos.DataSource = Nothing
    '            DgvDatos.DataSource = dt
    '            DgvDatos.Columns("Equipo").Visible = False
    '            DgvDatos.Columns("ID Jugador").Visible = False
    '            DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    '        Else
    '            dt = Nothing
    '            DgvDatos.DataSource = dt
    '        End If

    '    End If

    'End Sub
    Private Sub BtnObtenerDatos_Click(sender As Object, e As EventArgs) Handles BtnObtenerDatos.Click
        Dim idEquipo As Integer
        If CmbEquipos.Text = "Todos los equipos" Then
            idEquipo = -1 ' O un valor que indique que no se filtra por equipo específico
        Else
            idEquipo = Convert.ToInt32(CmbEquipos.SelectedValue)
        End If

        Dim dt As DataTable
        If idEquipo = -1 Then
            ' Obtener registros de todos los equipos
            dt = ObtenerRegistrosDeTodosLosEquipos(LblIdLiga.Text)
        Else
            ' Obtener registros para un equipo específico
            dt = ObtenerRegistrosDeTodosLosEquipos(LblIdLiga.Text, idEquipo)
        End If

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ' Agregar una columna auxiliar para el orden de la posición
            dt.Columns.Add("OrdenPosicion", GetType(Integer))

            ' Asignar valores a la columna auxiliar basados en la posición
            For Each row As DataRow In dt.Rows
                Select Case row("Posición").ToString()
                    Case "Por"
                        row("OrdenPosicion") = 1
                    Case "Def"
                        row("OrdenPosicion") = 2
                    Case "Med"
                        row("OrdenPosicion") = 3
                    Case "Del"
                        row("OrdenPosicion") = 4
                    Case Else
                        row("OrdenPosicion") = 5 ' Para manejar casos inesperados
                End Select
            Next

            ' Crear una vista del DataTable ordenado
            Dim dataView As DataView = dt.DefaultView
            dataView.Sort = "Equipo ASC, OrdenPosicion ASC, Promedio DESC"

            ' Crear un nuevo DataTable ordenado
            Dim sortedDataTable As DataTable = dataView.ToTable()

            ' Eliminar la columna auxiliar
            If sortedDataTable.Columns.Contains("OrdenPosicion") Then
                sortedDataTable.Columns.Remove("OrdenPosicion")
            End If

            ' Configurar el DataGridView
            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = sortedDataTable
            DgvDatos.Columns("Equipo").Visible = False
            DgvDatos.Columns("ID Jugador").Visible = False
            DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Else
            ' Si no hay datos, limpiar el DataGridView
            DgvDatos.DataSource = Nothing
        End If
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

    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarcmb(CmbEquipos)
    End Sub
    Private Sub cargarcmb(ByVal cmb As ComboBox)

        Dim DtNuevo As DataTable = ObtenerEquiposPorLiga(Convert.ToInt64(LblIdLiga.Text))

        cmb.DataSource = Nothing
        cmb.Items.Clear()


        Dim newRow As DataRow = DtNuevo.NewRow()
        newRow("idEquipo") = 0
        newRow("nombre") = "Todos los equipos"
        DtNuevo.Rows.InsertAt(newRow, 0)

        cmb.DataSource = DtNuevo
        cmb.DisplayMember = "nombre"
        cmb.ValueMember = "idEquipo"

        If cmb.Items.Count > 0 Then
            cmb.SelectedIndex = 0
        End If
    End Sub

End Class
