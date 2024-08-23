Imports Ligas.ConexionSqlite


Public Class FrmPpal

    Dim DtEquipos As New DataTable
    Dim DtJugadores As New DataTable
    Dim JugadoresModificados As New List(Of JugadorModificado)
    Dim numero As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarcmb(CmbFechas)

    End Sub

    Private Sub DgvEquipos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEquipos.CellClick
        If e.RowIndex >= 0 Then
            Dim idequipo As Long = Convert.ToInt64(DgvEquipos.Rows(e.RowIndex).Cells("idequipo").Value)
            DtJugadores = ObtenerJugadoresConEquipos(idequipo)
            DtJugadores.Columns.Add("Puntos")
            DgvJugadores.DataSource = Nothing
            DgvJugadores.DataSource = DtJugadores
            DgvJugadores.Columns("idjugadores").Visible = False
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

                DgvJugadores.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
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
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." Then
            e.Handled = True
        End If

        ' Permitir solo un punto decimal
        Dim txt As TextBox = CType(sender, TextBox)
        If e.KeyChar = "." AndAlso txt.Text.IndexOf(".") > -1 Then
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

            DtEquipos = ObtenerEquipos()
            DgvEquipos.DataSource = DtEquipos
            DgvEquipos.Columns("idequipo").Visible = False
            DgvEquipos.Columns("idliga").Visible = False
        End If


    End Sub


End Class

Public Class JugadorModificado
    Public Property idjugadores As Long
    Public Property Puntos As Object
End Class