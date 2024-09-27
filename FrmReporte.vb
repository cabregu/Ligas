Imports OfficeOpenXml
Imports System.IO
Imports System.Windows.Forms
Imports Ligas.ConexionSqlite


Public Class FrmReporte

    Private Sub BtnObtenerDatos_Click(sender As Object, e As EventArgs) Handles BtnObtenerDatos.Click
        CargarDatosNuevos()
    End Sub

    Public Sub CargarDatosNuevos()
        Dim idEquipo As Integer
        If CmbEquipos.Text = "Todos los equipos" Then
            idEquipo = -1
        Else
            idEquipo = Convert.ToInt32(CmbEquipos.SelectedValue)
        End If

        Dim dt As DataTable
        If idEquipo = -1 Then

            dt = ObtenerRegistrosDeTodosLosEquipos(LblIdLiga.Text)
        Else

            dt = ObtenerRegistrosDeTodosLosEquipos(LblIdLiga.Text, idEquipo)
        End If

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            dt.Columns.Add("OrdenPosicion", GetType(Integer))

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
                        row("OrdenPosicion") = 5
                End Select
            Next

            Dim dataView As DataView = dt.DefaultView
            dataView.Sort = "Equipo ASC, OrdenPosicion ASC, Promedio DESC"


            Dim sortedDataTable As DataTable = dataView.ToTable()


            If sortedDataTable.Columns.Contains("OrdenPosicion") Then
                sortedDataTable.Columns.Remove("OrdenPosicion")
            End If


            DgvDatos.DataSource = Nothing
            DgvDatos.DataSource = sortedDataTable
            DgvDatos.Columns("Equipo").Visible = False
            DgvDatos.Columns("ID Jugador").Visible = False
            DgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            TxtNombreDeEquipo.Text = CmbEquipos.Text

        Else
            DgvDatos.DataSource = Nothing
        End If
    End Sub


    Public Sub ExportarDataGridViewAExcel(dgv As DataGridView)
        Try

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Guardar archivo Excel"
            saveFileDialog.FileName = "Datos.xlsx"


            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim filePath As String = saveFileDialog.FileName


                Using package As New ExcelPackage()

                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Sheet1")

                    For colIndex As Integer = 0 To dgv.Columns.Count - 1
                        worksheet.Cells(1, colIndex + 1).Value = dgv.Columns(colIndex).HeaderText
                    Next

                    For rowIndex As Integer = 0 To dgv.Rows.Count - 1
                        Dim row As DataGridViewRow = dgv.Rows(rowIndex)
                        For colIndex As Integer = 0 To dgv.Columns.Count - 1
                            Dim cellValue As Object = row.Cells(colIndex).Value
                            worksheet.Cells(rowIndex + 2, colIndex + 1).Value = If(cellValue IsNot Nothing, cellValue.ToString(), String.Empty)
                        Next
                    Next

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
        LlenarComboBoxLigas(CmbLiga)
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


    Private Sub DgvDatos_DoubleClick(sender As Object, e As EventArgs) Handles DgvDatos.DoubleClick
        If DgvDatos.CurrentCell IsNot Nothing Then
            Dim filaSeleccionada As Integer = DgvDatos.CurrentCell.RowIndex
            Dim columnaSeleccionada As Integer = DgvDatos.CurrentCell.ColumnIndex

            Dim idJugador As Integer = Convert.ToInt32(DgvDatos.Rows(filaSeleccionada).Cells("ID Jugador").Value)
            Dim jugador As String = DgvDatos.Rows(filaSeleccionada).Cells("Jugador").Value.ToString()

            Dim puntos As String = Nothing
            Dim nombreColumna As String = DgvDatos.Columns(columnaSeleccionada).Name

            If nombreColumna.StartsWith("Fecha") Then
                puntos = DgvDatos.Rows(filaSeleccionada).Cells(columnaSeleccionada).Value.ToString()
                Dim numeroFecha As String = nombreColumna.Substring(6)

                Dim otroFormulario As New FrmEditarPuntos()
                otroFormulario.LblIdJugador.Text = idJugador.ToString()
                otroFormulario.LblNombreJugador.Text = jugador
                otroFormulario.LblFecha.Text = numeroFecha
                otroFormulario.LblPuntos.Text = puntos

                otroFormulario.ShowDialog()
            End If
        End If
    End Sub

    Public Sub LlenarComboBoxLigas(combo As ComboBox)
        combo.DataSource = Nothing
        combo.Items.Clear()
        Dim dtLigas As DataTable = ObtenerLigasParaCombo()
        combo.DisplayMember = "nombreliga"
        combo.ValueMember = "idliga"
        combo.DataSource = dtLigas
    End Sub

    Private Sub BtnCopiar_Click(sender As Object, e As EventArgs) Handles BtnCopiar.Click
        If TxtNombreDeEquipo.Text <> "" Then
            Dim NroLigaNueva As Integer = CmbLiga.SelectedValue
            Dim NombreEquipo As String = TxtNombreDeEquipo.Text

            ' Llamar a la función para insertar el equipo y obtener el id
            Dim idEquipo As Integer = InsertarEquipoParaTransferirDeLiga(NombreEquipo, NroLigaNueva)

            ' Comprobar el resultado de la inserción
            If idEquipo = 0 Then
                MessageBox.Show("El equipo ya existe en esta liga.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return ' Cancela la operación
            ElseIf idEquipo < 0 Then
                MessageBox.Show("Error al insertar el equipo. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Cancela la operación
            End If

            ' Inicializar y mostrar el ProgressBar
            PgbCopiando.Minimum = 0
            PgbCopiando.Maximum = DgvDatos.Rows.Count
            PgbCopiando.Value = 0
            PgbCopiando.Visible = True

            ' Insertar los jugadores en el DataGridView
            For Each fila As DataGridViewRow In DgvDatos.Rows
                If Not fila.IsNewRow Then ' Asegúrate de no intentar insertar la fila nueva
                    Dim jugador As String = fila.Cells("Jugador").Value.ToString()
                    Dim posicion As String = fila.Cells("Posición").Value.ToString()


                    Dim resultado As Boolean = InsertarJugadorPraTransferirdeliga(jugador, posicion, idEquipo)

                    If Not resultado Then
                        MessageBox.Show("Error al insertar el jugador: " & jugador, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If


                    PgbCopiando.Value += 1
                End If
            Next

            MessageBox.Show("Todos los jugadores han sido insertados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reiniciar el ProgressBar
            PgbCopiando.Value = 0
            PgbCopiando.Visible = False

            ' Ajustar ComboBox a -1
            CmbLiga.SelectedIndex = -1
            TxtNombreDeEquipo.Text = ""


        Else
            MessageBox.Show("Por favor, ingrese un nombre para el equipo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub



End Class
