Imports Ligas.ConexionSqlite

Public Class Form1

    Dim DtEquipos As New DataTable
    Dim DtJugadores As New DataTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtEquipos = ObtenerEquipos()
        DgvEquipos.DataSource = DtEquipos
        DgvEquipos.Columns("idequipo").Visible = False
        DgvEquipos.Columns("idliga").Visible = False
    End Sub

    Private Sub DgvEquipos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEquipos.CellClick

        If e.RowIndex >= 0 Then
            Dim idequipo As Long = Convert.ToInt64(DgvEquipos.Rows(e.RowIndex).Cells("idequipo").Value)

            DtJugadores = ObtenerJugadoresConEquipos(idequipo)
            DgvJugadores.DataSource = Nothing
            DgvJugadores.DataSource = DtJugadores

            'MessageBox.Show($"ID del equipo seleccionado: {idequipo}")
        End If

    End Sub




End Class
