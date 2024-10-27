
Imports Ligas.ConexionSqlite


Public Class FrmFechas

    Private Sub FrmFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub cargarDgv(ByVal Dgv As DataGridView, ByVal texto As String)
        If texto.Length > 1 Then
            Dim CantidadFechas As Integer = ObtenerDatoFechas()
            Dim dt As New DataTable
            dt.Columns.Add("Fechas")

            For i As Integer = 1 To CantidadFechas
                dt.Rows.Add("Fecha " & i)
            Next

            Dgv.DataSource = Nothing
            Dgv.DataSource = dt
        Else

            Dgv.DataSource = Nothing
        End If
    End Sub

    Private Sub BtnLista_Click(sender As Object, e As EventArgs) Handles BtnLista.Click
        FrmCrearLista.LblIdLiga.Text = LblIdLiga.Text
        FrmCrearLista.LblNombreLiga.Text = LblNombreLiga.Text
        FrmCrearLista.Show()
    End Sub
End Class

