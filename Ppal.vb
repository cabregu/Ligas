Imports Ligas.ConexionSqlite



Public Class Form1

    Dim DtEquipos As New DataTable
    Dim DtJugadores As New DataTable
    Dim JugadoresModificados As New List(Of JugadorModificado)

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
            DtJugadores.Columns.Add("Puntos")
            DgvJugadores.DataSource = Nothing
            DgvJugadores.DataSource = DtJugadores
        End If
    End Sub

    Private Sub DgvJugadores_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvJugadores.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim nombreColumna As String = DgvJugadores.Columns(e.ColumnIndex).Name

            ' Verificar si la columna modificada es "Puntos"
            If nombreColumna = "Puntos" Then
                Dim idJugador As Long = Convert.ToInt64(DgvJugadores.Rows(e.RowIndex).Cells("idjugadores").Value)
                Dim nuevoValorPuntos As Object = DgvJugadores.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

                ' Añadir a la lista de Jugadores Modificados
                Dim jugadorModificado As New JugadorModificado With {
                    .idjugadores = idJugador,
                    .Puntos = nuevoValorPuntos
                }

                ' Si el jugador ya está en la lista, actualiza su valor de Puntos
                Dim existente = JugadoresModificados.FirstOrDefault(Function(j) j.idjugadores = idJugador)
                If existente IsNot Nothing Then
                    existente.Puntos = nuevoValorPuntos
                Else
                    JugadoresModificados.Add(jugadorModificado)
                End If

                ' Cambiar color de la celda a rojo
                DgvJugadores.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.Red
            End If
        End If
    End Sub


End Class

Public Class JugadorModificado
    Public Property idjugadores As Long
    Public Property Puntos As Object
End Class



