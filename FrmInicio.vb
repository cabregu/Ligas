Imports Ligas.ConexionSqlite


Public Class FrmInicio
    Private Sub BtnCargarPuntos_Click(sender As Object, e As EventArgs) Handles BtnCargarPuntos.Click

        FrmCargarPuntos.LblIdLiga.Text = LblIdLiga.Text
        FrmCargarPuntos.LblNombreLiga.Text = LblNombreLiga.Text
        FrmCargarPuntos.Show()

    End Sub

    Private Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmInicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub BtnCrearEquipo_Click(sender As Object, e As EventArgs) Handles BtnCrearEquipo.Click
        GpbEquipos.Enabled = True
        GpbJugadores.Enabled = False

    End Sub

    Private Sub BtnCrearJugadores_Click(sender As Object, e As EventArgs) Handles BtnCrearJugadores.Click
        GpbEquipos.Enabled = False
        GpbJugadores.Enabled = True
        CargarCmbEquiposParaAgregarJugadores()

    End Sub

    Private Sub BtnCrearNuevoEquipo_Click(sender As Object, e As EventArgs) Handles BtnCrearNuevoEquipo.Click

        If InsertarEquipo(TxtEquipoingresar.Text, LblIdLiga.Text) Then
            MessageBox.Show("Equipo " & TxtEquipoingresar.Text & " insertado con éxito.")
            TxtEquipoingresar.Text = ""
        End If


    End Sub

    Private Function CargarCmbEquiposParaAgregarJugadores()
        Dim dtEquipos As DataTable = ObtenerEquiposPorLiga(LblIdLiga.Text)
        With CmbEquipoParaAgregar
            .DataSource = dtEquipos
            .DisplayMember = "nombre"
            .ValueMember = "idequipo"
        End With
    End Function

    Private Sub BtnAñadir_Click(sender As Object, e As EventArgs) Handles BtnAñadir.Click

        If String.IsNullOrWhiteSpace(CmbEquipoParaAgregar.Text) OrElse
           String.IsNullOrWhiteSpace(TxtJugadorParaAgregar.Text) OrElse
           String.IsNullOrWhiteSpace(CmbPosicionParaAgregar.Text) Then

            MessageBox.Show("Por favor, complete todos los campos antes de añadir un jugador.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim nuevaFila As DataGridViewRow = CType(DgvJugadores.Rows(DgvJugadores.Rows.Add()), DataGridViewRow)


        nuevaFila.Cells("Equipo").Value = CmbEquipoParaAgregar.SelectedValue
        nuevaFila.Cells("Jugador").Value = TxtJugadorParaAgregar.Text
        nuevaFila.Cells("Pos").Value = CmbPosicionParaAgregar.Text


        CmbEquipoParaAgregar.SelectedIndex = -1
        TxtJugadorParaAgregar.Clear()
        CmbPosicionParaAgregar.SelectedIndex = -1


        CmbEquipoParaAgregar.Focus()
    End Sub

    Private Sub BtnGuardarJugadores_Click(sender As Object, e As EventArgs) Handles BtnGuardarJugadores.Click

        If DgvJugadores.Rows.Count = 0 Then
            MessageBox.Show("No hay jugadores para guardar.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        For Each fila As DataGridViewRow In DgvJugadores.Rows

            If Not fila.IsNewRow Then

                Dim nombreJugador As String = Convert.ToString(fila.Cells("Jugador").Value)
                Dim posicion As String = Convert.ToString(fila.Cells("Pos").Value)
                Dim idEquipo As Integer = Convert.ToInt32(fila.Cells("Equipo").Value)
                InsertarJugador(nombreJugador, posicion, idEquipo)

            End If
        Next

        DgvJugadores.Rows.Clear()

    End Sub

End Class