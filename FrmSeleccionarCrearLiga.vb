Imports Ligas.ConexionSqlite


Public Class FrmSeleccionarCrearLiga
    Private Sub BtnCrearLinea_Click(sender As Object, e As EventArgs) Handles BtnCrearLinea.Click
        If Len(TxtNuevaLiga.Text) > 0 Then
            InsertarLiga(TxtNuevaLiga.Text)
            LlenarComboBoxLigas(CmbSeleccionarLiga)
            LlenarComboBoxLigas(CmbEliminarLiga)
            TxtNuevaLiga.Text = ""

        End If
    End Sub

    Private Sub FrmSeleccionarCrearLiga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboBoxLigas(CmbSeleccionarLiga)
        LlenarComboBoxLigas(CmbEliminarLiga)
    End Sub

    Public Sub LlenarComboBoxLigas(combo As ComboBox)
        combo.DataSource = Nothing
        combo.Items.Clear()
        Dim dtLigas As DataTable = ObtenerLigasParaCombo()
        combo.DisplayMember = "nombreliga"
        combo.ValueMember = "idliga"
        combo.DataSource = dtLigas
    End Sub

    Private Sub BtnSeleccionar_Click(sender As Object, e As EventArgs) Handles BtnSeleccionar.Click
        Me.Visible = False
        FrmInicio.LblIdLiga.Text = CmbSeleccionarLiga.SelectedValue
        FrmInicio.LblNombreLiga.Text = CmbSeleccionarLiga.Text
        FrmInicio.Show()

    End Sub

    Private Sub BtnEliminarLiga_Click(sender As Object, e As EventArgs) Handles BtnEliminarLiga.Click
        If CmbEliminarLiga.SelectedIndex >= 0 Then
            Dim idLiga As Integer = Convert.ToInt32(CmbEliminarLiga.SelectedValue)
            Dim resultado As String = EliminarLiga(idLiga)
            MessageBox.Show(resultado)
            LlenarComboBoxLigas(CmbSeleccionarLiga)
            LlenarComboBoxLigas(CmbEliminarLiga)

        Else
            MessageBox.Show("Por favor, seleccione una liga para eliminar.")
        End If
    End Sub

End Class