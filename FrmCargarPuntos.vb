Imports Ligas.ConexionSqlite


Public Class FrmCargarPuntos

    Dim DtEquipos As New DataTable
    Dim DtJugadores As New DataTable
    Dim JugadoresModificados As New List(Of JugadorModificado)
    Dim numero As Integer = 0


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarcmb(CmbFechas)
    End Sub

    Private Sub cargarcmb(ByVal cmb As ComboBox)

        RemoveHandler cmb.DrawItem, AddressOf cmb_DrawItem


        Dim fechasCargadas As List(Of String) = ObtenerFechasCargadas(LblIdLiga.Text)
        Dim CantidadFechas As Integer = ObtenerDatoFechas()

        ' Configurar el ComboBox para dibujar los elementos
        cmb.DrawMode = DrawMode.OwnerDrawFixed
        cmb.Items.Clear()
        cmb.Items.Add("")

        ' Agregar los elementos al ComboBox
        For i As Integer = 1 To CantidadFechas
            cmb.Items.Add("Fecha " & i)
        Next

        ' Seleccionar el primer ítem
        If cmb.Items.Count > 0 Then
            cmb.SelectedIndex = 0
        End If

        ' Evento para dibujar cada elemento
        AddHandler cmb.DrawItem, AddressOf cmb_DrawItem
    End Sub

    ' Evento que dibuja cada elemento del ComboBox
    Private Sub cmb_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)

        ' Verificar que el índice es válido
        If e.Index < 0 Then Return

        ' Extraer el número de la fecha de cada elemento
        Dim itemText As String = cmb.Items(e.Index).ToString()
        Dim fechaNumero As String = itemText.Replace("Fecha ", "")

        ' Obtener la lista de fechas cargadas cada vez que se dibuja (por si cambian)
        Dim fechasCargadas As List(Of String) = ObtenerFechasCargadas(LblIdLiga.Text)
        Dim esFechaCargada As Boolean = fechasCargadas.Contains(fechaNumero)

        ' Establecer los colores de fondo y de texto
        If esFechaCargada Then
            e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds) ' Fondo verde claro para fechas cargadas
        Else
            e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds) ' Fondo normal
        End If

        ' Dibujar el texto
        TextRenderer.DrawText(e.Graphics, itemText, cmb.Font, e.Bounds, cmb.ForeColor, TextFormatFlags.Left)
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
            DtJugadores.Columns.Add("Puntos", GetType(Integer))


            lblIdequipo.Text = idequipo

            ' Establecer la nueva fuente de datos
            DgvJugadores.DataSource = DtJugadores
            DgvJugadores.Columns("idjugadores").Visible = False

            ' Crear y agregar las columnas de CheckBox manualmente
            Dim checkBoxColumn1 As New DataGridViewCheckBoxColumn()
            checkBoxColumn1.HeaderText = "S"
            checkBoxColumn1.Name = "S"
            DgvJugadores.Columns.Add(checkBoxColumn1)

            Dim checkBoxColumn2 As New DataGridViewCheckBoxColumn()
            checkBoxColumn2.HeaderText = "T"
            checkBoxColumn2.Name = "T"
            DgvJugadores.Columns.Add(checkBoxColumn2)

            Dim checkBoxColumn3 As New DataGridViewCheckBoxColumn()
            checkBoxColumn3.HeaderText = "B"
            checkBoxColumn3.Name = "B"
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

        If DgvJugadores.Rows.Count = 0 Then
            MessageBox.Show("No hay datos en el DataGridView para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim idequipo As Integer = Convert.ToInt32(lblIdequipo.Text)
        Dim nrofecha As Integer = numero

        Dim necesitaVerificacion As Boolean = False
        Dim mensaje As String = "Para los puntos cargados, debes seleccionar al menos una opción de los 'Check'."

        For Each row As DataGridViewRow In DgvJugadores.Rows

            If row.IsNewRow Then Continue For

            Dim idjugador As Integer = Convert.ToInt32(row.Cells("idjugadores").Value)
            Dim puntosfecha As Decimal? = If(IsDBNull(row.Cells("Puntos").Value) OrElse String.IsNullOrEmpty(row.Cells("Puntos").Value?.ToString()), CType(Nothing, Decimal?), Convert.ToDecimal(row.Cells("Puntos").Value))

            Dim b As Integer = If(IsDBNull(row.Cells("B").Value) OrElse Not Convert.ToBoolean(row.Cells("B").Value), 0, 1)
            Dim t As Integer = If(IsDBNull(row.Cells("T").Value) OrElse Not Convert.ToBoolean(row.Cells("T").Value), 0, 1)
            Dim s As Integer = If(IsDBNull(row.Cells("S").Value) OrElse Not Convert.ToBoolean(row.Cells("S").Value), 0, 1)
            Dim l As Integer = If(IsDBNull(row.Cells("L").Value) OrElse Not Convert.ToBoolean(row.Cells("L").Value), 0, 1)

            ' Verificar si hay puntos cargados y ninguna opción seleccionada
            If puntosfecha.HasValue AndAlso (b = 0 AndAlso t = 0 AndAlso s = 0 AndAlso l = 0) Then
                necesitaVerificacion = True
                Exit For
            End If

            ' Guardar el registro
            GuardarRegistro(idequipo, idjugador, nrofecha, puntosfecha, b, t, s, l)
        Next

        If necesitaVerificacion Then
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Limpiar el DataGridView después de guardar
        DgvJugadores.DataSource = Nothing
        DgvJugadores.Rows.Clear()
        DgvJugadores.Columns.Clear()

    End Sub

    Private Sub MarcarRegistrosExistentes(idequipo As Long, nrofecha As Integer)
        Dim DtRegistros As DataTable
        DtRegistros = ObtenerRegistrosExistentes(idequipo, nrofecha)

        ' Configurar la columna "Puntos" como numérica y formato
        DgvJugadores.Columns("Puntos").ValueType = GetType(Integer)
        DgvJugadores.Columns("Puntos").DefaultCellStyle.Format = "N0"

        For Each row As DataGridViewRow In DgvJugadores.Rows
            Dim idjugador As Long = Convert.ToInt64(row.Cells("idjugadores").Value)

            Dim registro As DataRow = DtRegistros.AsEnumerable().FirstOrDefault(Function(r) Convert.ToInt64(r("idjugador")) = idjugador)

            If registro IsNot Nothing Then
                row.Cells("B").Value = Convert.ToBoolean(registro("b"))
                row.Cells("T").Value = Convert.ToBoolean(registro("t"))
                row.Cells("S").Value = Convert.ToBoolean(registro("s"))
                row.Cells("L").Value = Convert.ToBoolean(registro("l"))

                Try
                    row.Cells("Puntos").Value = Convert.ToInt32(registro("puntosfecha"))
                Catch ex As Exception

                End Try




                If row.Cells("Puntos").Value Is Nothing OrElse IsDBNull(row.Cells("Puntos").Value) OrElse String.IsNullOrEmpty(row.Cells("Puntos").Value?.ToString()) Then
                    ' Aquí manejas el caso cuando el valor es nulo, vacío, o no es un número
                    'row.Cells("Puntos").Style.BackColor = Color.Red ' Por ejemplo, lo pintas de rojo
                Else
                    ' Aquí manejas el caso cuando el valor no es nulo o vacío
                    row.Cells("Puntos").Style.BackColor = Color.Green
                End If

            End If
        Next
    End Sub


    Private Sub DgvJugadores_Sorted(sender As Object, e As EventArgs) Handles DgvJugadores.Sorted


        Dim idequipo As Long = Convert.ToInt64(lblIdequipo.Text)
        Dim nrofecha As Integer = Convert.ToInt64(CmbFechas.SelectedValue)
        MarcarRegistrosExistentes(idequipo, numero)

        DgvJugadores.Columns("Puntos").ValueType = GetType(Integer)
        DgvJugadores.Columns("Puntos").DefaultCellStyle.Format = "N0"
        DgvJugadores.Columns("Puntos").SortMode = DataGridViewColumnSortMode.Automatic


    End Sub

    Private Sub BtnLimpiarFecha_Click(sender As Object, e As EventArgs)

    End Sub
End Class

Public Class JugadorModificado
    Public Property idjugadores As Long
    Public Property Puntos As Object
End Class