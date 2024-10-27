Imports Ligas.ConexionSqlite


Public Class FrmCrearLista


    Dim DtEquipos As New DataTable
    Dim numero As Integer = 0

    Private Sub FrmCrearLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtEquipos = ObtenerEquiposPorLiga(LblIdLiga.Text)
        DgvEquipos.DataSource = DtEquipos
        DgvEquipos.Columns("idequipo").Visible = False
        DgvEquipos.Columns("idliga").Visible = False

    End Sub

    Private Sub BtnCrearLista_Click(sender As Object, e As EventArgs) Handles BtnCrearLista.Click

    End Sub

    Private Sub DgvEquipos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEquipos.CellClick

        Dim DtJugadores As New DataTable

        If e.RowIndex >= 0 Then

            DgvJugadores.DataSource = Nothing
            Dim idequipo As Long = Convert.ToInt64(DgvEquipos.Rows(e.RowIndex).Cells("idequipo").Value)
            DtJugadores = ObtenerJugadoresConEquipos(idequipo)
            DgvJugadores.DataSource = DtJugadores
            DgvJugadores.Columns("idjugadores").Visible = False

        End If

    End Sub


End Class