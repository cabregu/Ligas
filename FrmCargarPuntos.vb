Imports Ligas.ConexionSqlite


Public Class FrmCargarPuntos

    Dim DtEquipos As New DataTable
    Dim DtJugadores As New DataTable
    Dim JugadoresModificados As New List(Of JugadorModificado)
    Dim numero As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarcmb(CmbFechas)

    End Sub

    Private Sub DgvEquipos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEquipos.CellClick
        If e.RowIndex >= 0 Then
            ' Limpiar todas las columnas y filas del DataGridView
            DgvJugadores.DataSource = Nothing
            DgvJugadores.Rows.Clear()
            DgvJugadores.Columns.Clear()

            ' Obtener los datos según el equipo seleccionado
            Dim idequipo As Long = Convert.ToInt64(DgvEquipos.Rows(e.RowIndex).Cells("idequipo").Value)
            DtJugadores = ObtenerJugadoresConEquipos(idequipo)
            DtJugadores.Columns.Add("Puntos")

            lblIdequipo.Text = idequipo

            ' Establecer la nueva fuente de datos
            DgvJugadores.DataSource = DtJugadores
            DgvJugadores.Columns("idjugadores").Visible = False

            ' Crear y agregar las columnas de CheckBox manualmente
            Dim checkBoxColumn1 As New DataGridViewCheckBoxColumn()
            checkBoxColumn1.HeaderText = "B"
            checkBoxColumn1.Name = "B"
            DgvJugadores.Columns.Add(checkBoxColumn1)

            Dim checkBoxColumn2 As New DataGridViewCheckBoxColumn()
            checkBoxColumn2.HeaderText = "T"
            checkBoxColumn2.Name = "T"
            DgvJugadores.Columns.Add(checkBoxColumn2)

            Dim checkBoxColumn3 As New DataGridViewCheckBoxColumn()
            checkBoxColumn3.HeaderText = "S"
            checkBoxColumn3.Name = "S"
            DgvJugadores.Columns.Add(checkBoxColumn3)

            Dim checkBoxColumn4 As New DataGridViewCheckBoxColumn()
            checkBoxColumn4.HeaderText = "L"
            checkBoxColumn4.Name = "L"
            DgvJugadores.Columns.Add(checkBoxColumn4)

            ' Ajustar las columnas al contenido
            DgvJugadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


            If e.RowIndex >= 0 Then
                Dim nrofecha As Integer = numero
                MarcarRegistrosExistentes(idequipo, nrofecha)
            End If


        End If
    End Sub



    Private Sub DgvJugadores_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvJugadores.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim nombreColumna As String = DgvJugadores.Columns(e.ColumnIndex).Name


            If nombreColumna = "Puntos" Then
                Dim idJugador As Long = Convert.ToInt64(DgvJugadores.Rows(e.RowIndex).Cells("idjugadores").Value)
                Dim nuevoValorPuntos As Object = DgvJugadores.Rows(e.RowIndex).Cells(e.ColumnIndex).Value


                Dim jugadorModificado As New JugadorModificado With {
                    .idjugadores = idJugador,
                    .Puntos = nuevoValorPuntos
                }


                Dim existente = JugadoresModificados.FirstOrDefault(Function(j) j.idjugadores = idJugador)
                If existente IsNot Nothing Then
                    existente.Puntos = nuevoValorPuntos
                Else
                    JugadoresModificados.Add(jugadorModificado)
                End If

                DgvJugadores.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.BlueViolet
            End If
        End If
    End Sub


    Private Sub DgvJugadores_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvJugadores.EditingControlShowing
        Dim nombreColumna As String = DgvJugadores.Columns(DgvJugadores.CurrentCell.ColumnIndex).Name

        If nombreColumna = "Puntos" Then
            Dim txtEdit As TextBox = TryCast(e.Control, TextBox)
            If txtEdit IsNot Nothing Then

                RemoveHandler txtEdit.KeyPress, AddressOf TxtEdit_KeyPress


                AddHandler txtEdit.KeyPress, AddressOf TxtEdit_KeyPress
            End If
        End If
    End Sub

    Private Sub TxtEdit_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "," Then
            e.Handled = True
        End If

        Dim txt As TextBox = CType(sender, TextBox)

        ' Permitir solo una coma
        If e.KeyChar = "," AndAlso txt.Text.Contains(",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub cargarcmb(ByVal cmb As ComboBox)
        Dim CantidadFechas As Integer = ObtenerDatoFechas()
        cmb.Items.Clear()
        cmb.Items.Add("")
        For i As Integer = 1 To CantidadFechas
            cmb.Items.Add("Fecha " & i)
        Next
        If cmb.Items.Count > 0 Then
            cmb.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFechas.SelectedIndexChanged

        If Len(CmbFechas.Text) > 0 Then
            Dim selectedText As String = CmbFechas.SelectedItem.ToString()
            numero = Integer.Parse(selectedText.Replace("Fecha ", ""))

            DtEquipos = ObtenerEquiposPorLiga(LblIdLiga.Text)
            DgvEquipos.DataSource = DtEquipos
            DgvEquipos.Columns("idequipo").Visible = False
            DgvEquipos.Columns("idliga").Visible = False
            DgvJugadores.DataSource = Nothing
            DgvJugadores.Rows.Clear()
            DgvJugadores.Columns.Clear()
        End If


    End Sub

    Private Sub BtnConfirmar_Click(sender As Object, e As EventArgs) Handles BtnConfirmar.Click
        ' Verificar si hay filas en el DataGridView
        If DgvJugadores.Rows.Count = 0 Then
            MessageBox.Show("No hay datos en el DataGridView para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim idequipo As Integer = Convert.ToInt32(lblIdequipo.Text)
        Dim nrofecha As Integer = numero

        ' Iterar sobre cada fila en el DataGridView
        For Each row As DataGridViewRow In DgvJugadores.Rows
            ' Evitar procesar la última fila si es una fila en blanco agregada automáticamente por el DataGridView
            If row.IsNewRow Then Continue For

            Dim idjugador As Integer = Convert.ToInt32(row.Cells("idjugadores").Value)
            Dim puntosfecha As Decimal? = If(IsDBNull(row.Cells("Puntos").Value) OrElse String.IsNullOrEmpty(row.Cells("Puntos").Value?.ToString()), CType(Nothing, Decimal?), Convert.ToDecimal(row.Cells("Puntos").Value))

            Dim b As Integer = If(IsDBNull(row.Cells("B").Value) OrElse Not Convert.ToBoolean(row.Cells("B").Value), 0, 1)
            Dim t As Integer = If(IsDBNull(row.Cells("T").Value) OrElse Not Convert.ToBoolean(row.Cells("T").Value), 0, 1)
            Dim s As Integer = If(IsDBNull(row.Cells("S").Value) OrElse Not Convert.ToBoolean(row.Cells("S").Value), 0, 1)
            Dim l As Integer = If(IsDBNull(row.Cells("L").Value) OrElse Not Convert.ToBoolean(row.Cells("L").Value), 0, 1)

            ' Llamar a la función para guardar el registro
            GuardarRegistro(idequipo, idjugador, nrofecha, puntosfecha, b, t, s, l)
        Next

        ' Limpiar el DataGridView después de guardar los registros
        DgvJugadores.DataSource = Nothing
        DgvJugadores.Rows.Clear()
        DgvJugadores.Columns.Clear()

        ' Mostrar mensaje de confirmación
        'MessageBox.Show("Los registros se han guardado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Private Sub MarcarRegistrosExistentes(idequipo As Long, nrofecha As Integer)

        Dim DtRegistros As DataTable
        DtRegistros = ObtenerRegistrosExistentes(idequipo, nrofecha)

        For Each row As DataGridViewRow In DgvJugadores.Rows
            Dim idjugador As Long = Convert.ToInt64(row.Cells("idjugadores").Value)


            Dim registro As DataRow = DtRegistros.AsEnumerable().FirstOrDefault(Function(r) Convert.ToInt64(r("idjugador")) = idjugador)

            If registro IsNot Nothing Then

                row.Cells("B").Value = Convert.ToBoolean(registro("b"))
                row.Cells("T").Value = Convert.ToBoolean(registro("t"))
                row.Cells("S").Value = Convert.ToBoolean(registro("s"))
                row.Cells("L").Value = Convert.ToBoolean(registro("l"))

                row.Cells("Puntos").Value = registro("puntosfecha")
                row.Cells("Puntos").Style.BackColor = Color.Green
            End If
        Next
    End Sub


End Class

Public Class JugadorModificado
    Public Property idjugadores As Long
    Public Property Puntos As Object
End Class