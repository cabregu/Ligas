Imports Ligas.ConexionSqlite


Public Class FrmReporte
    Private Sub BtnObtenerDatos_Click(sender As Object, e As EventArgs) Handles BtnObtenerDatos.Click
        Dim dt As New DataTable
        dt = ObtenerRegistrosDeTodosLosEquipos()

        DgvDatos.DataSource = Nothing
        DgvDatos.DataSource = dt

    End Sub

    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class