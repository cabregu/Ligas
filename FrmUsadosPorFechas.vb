
Imports Ligas.ConexionSqlite


Public Class FrmUsadosPorFechas

    Private Sub FrmFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarNombresListasEnCombo()
    End Sub
    Public Sub CargarNombresListasEnCombo()
        Dim dtListas As DataTable = ObtenerNombresListas()

        CmbLista.Items.Clear()

        For Each row As DataRow In dtListas.Rows
            CmbLista.Items.Add(row("nombre_lista").ToString())
        Next
    End Sub


    Private Sub CargarDgvFechas(ByVal dgv As DataGridView)
        Dim CantidadFechas As Integer = ObtenerDatoFechas()
        dgv.Rows.Clear()

        ' Añadir cada fecha como una nueva fila en el DataGridView
        For i As Integer = 1 To CantidadFechas
            dgv.Rows.Add("Fecha " & i)
        Next
    End Sub



    Private Sub BtnLista_Click(sender As Object, e As EventArgs) Handles BtnLista.Click
        FrmCrearLista.LblIdLiga.Text = LblIdLiga.Text
        FrmCrearLista.LblNombreLiga.Text = LblNombreLiga.Text
        FrmCrearLista.Show()
    End Sub

    Private Sub CmbSubliga_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbLista.SelectedValueChanged
        If CmbLista.Text <> "" Then
            CargarDgvFechas(DgvFechas)
        End If
    End Sub

    Private Sub DgvFechas_Click(sender As Object, e As EventArgs) Handles DgvFechas.Click

        If String.IsNullOrWhiteSpace(cmblista.Text) Then
            MessageBox.Show("Seleccione una lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DgvFechas.CurrentRow Is Nothing OrElse DgvFechas.CurrentRow.Cells(0).Value Is Nothing Then
            MessageBox.Show("Seleccione una fecha en el DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim nombreLista As String = CmbLista.Text
        Dim fechaTexto As String = DgvFechas.CurrentRow.Cells(0).Value.ToString()


        Dim nroFecha As Integer
        If fechaTexto.StartsWith("Fecha ") AndAlso Integer.TryParse(fechaTexto.Substring(6), nroFecha) Then

            Dim dtJugadores As DataTable = ObtenerJugadoresPorListaYFecha(nombreLista, nroFecha)


            If dtJugadores.Rows.Count = 0 Then
                MessageBox.Show("No Hay datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                DgvJugadores.DataSource = Nothing
                DgvJugadores.DataSource = dtJugadores
                DgvJugadores.Columns("equipo").Visible = False
                DgvJugadores.Columns("ID Jugador").Visible = False
            End If
        Else
            MessageBox.Show("Formato de fecha no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub BtnEliminarlista_Click(sender As Object, e As EventArgs) Handles BtnEliminarlista.Click
        Dim nombreLista As String = CmbLista.SelectedItem.ToString()

        ' Verificar que se haya seleccionado una lista
        If String.IsNullOrEmpty(nombreLista) Then
            MessageBox.Show("Por favor, selecciona una lista para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Advertencia antes de eliminar
        Dim resultado As DialogResult = MessageBox.Show($"¿Estás seguro de que deseas eliminar la lista '{nombreLista}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            ' Llamar a la función para eliminar la lista
            EliminarLista(nombreLista)
            MessageBox.Show($"La lista '{nombreLista}' ha sido eliminada.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Vaciar el DataGridView
            DgvFechas.DataSource = Nothing
            DgvFechas.Rows.Clear()

            DgvJugadores.DataSource = Nothing
            DgvJugadores.Rows.Clear()

            CmbLista.Text = ""


            ' Recargar el ComboBox
            CargarNombresListasEnCombo()
        End If

    End Sub



End Class

