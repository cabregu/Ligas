﻿Imports Ligas.ConexionSqlite


Public Class FrmLigaPpal
    Private Sub BtnCargarPuntos_Click(sender As Object, e As EventArgs) Handles BtnCargarPuntos.Click

        FrmCargarPuntos.LblIdLiga.Text = LblIdLiga.Text
        FrmCargarPuntos.LblNombreLiga.Text = LblNombreLiga.Text
        FrmCargarPuntos.Show()

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
        cargarcmb(CmbEquipoSeleccionado)
        cargarcmb(CmbEquipoAtransferir)
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

    Private Sub cargarcmb(ByVal cmb As ComboBox)

        Dim DtNuevo As DataTable = ObtenerEquiposPorLiga(Convert.ToInt32(LblIdLiga.Text))

        cmb.DataSource = Nothing
        cmb.Items.Clear()

        Dim newRow As DataRow = DtNuevo.NewRow()
        newRow("idEquipo") = 0
        newRow("nombre") = ""
        DtNuevo.Rows.InsertAt(newRow, 0)

        cmb.DataSource = DtNuevo


        cmb.DisplayMember = "nombre" '
        cmb.ValueMember = "idEquipo"


        If cmb.Items.Count > 0 Then
            cmb.SelectedIndex = 0
        End If
    End Sub

    Private Sub CmbEquipos_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbEquipoSeleccionado.SelectedValueChanged
        Try
            DgvEditarJugadores.DataSource = Nothing
            DgvEditarJugadores.Rows.Clear()
            DgvEditarJugadores.Columns.Clear()

            ' Obtener los datos según el equipo seleccionado
            Dim idequipo = Convert.ToInt64(CmbEquipoSeleccionado.SelectedValue)
            DgvEditarJugadores.DataSource = ObtenerJugadoresConEquipos(idequipo)
            DgvEditarJugadores.Columns("idjugadores").Visible = False
            LblIdJugadorSeleccionado.Text = 0
            LblJugadorSeleccionado.Text = ""

        Catch ex As Exception

        End Try


    End Sub

    Private Sub DgvEditarJugadores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEditarJugadores.CellClick

        If DgvEditarJugadores.RowCount > 0 AndAlso e.RowIndex >= 0 Then
            Dim idJugador As Integer = Convert.ToInt32(DgvEditarJugadores.Rows(e.RowIndex).Cells("idjugadores").Value)
            Dim NombreJugador As String = Convert.ToString(DgvEditarJugadores.Rows(e.RowIndex).Cells("jugador").Value)
            LblJugadorSeleccionado.Text = ""
            LblIdJugadorSeleccionado.Text = ""
            LblJugadorSeleccionado.Text = NombreJugador
            LblIdJugadorSeleccionado.Text = idJugador.ToString()
        End If

    End Sub

    Private Sub BtnTransferir_Click(sender As Object, e As EventArgs) Handles BtnTransferir.Click

        ' Obtener los valores seleccionados
        Dim idJugador As Integer = Convert.ToInt32(LblIdJugadorSeleccionado.Text)
        Dim nuevoIdequipo As Integer = Convert.ToInt32(CmbEquipoAtransferir.SelectedValue)

        ' Validaciones
        If idJugador <= 0 Then
            MessageBox.Show("Debe seleccionar un jugador válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If CmbEquipoAtransferir.SelectedIndex = -1 OrElse nuevoIdequipo <= 0 Then
            MessageBox.Show("Debe seleccionar un equipo válido para la transferencia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirmación de transferencia
        Dim respuesta As DialogResult = MessageBox.Show("¿Estás seguro de que quieres actualizar el equipo del jugador?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If respuesta = DialogResult.Yes Then
            ' Realizar la transferencia
            Dim resultado As Boolean = TransferirJugadoraequipo(idJugador, nuevoIdequipo)

            If resultado Then
                MessageBox.Show("El equipo se actualizó correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Limpiar el DataGridView y las etiquetas

                DgvEditarJugadores.DataSource = Nothing
                LblIdJugadorSeleccionado.Text = "0"
                LblJugadorSeleccionado.Text = ""

            Else
                MessageBox.Show("Ocurrió un error al actualizar el equipo.", "Error de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("La operación fue cancelada.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        ' Obtener el idJugador y idequipo desde los controles correspondientes
        Dim idJugador As Integer = Convert.ToInt32(LblIdJugadorSeleccionado.Text)
        Dim idequipo As Integer = Convert.ToInt32(CmbEquipoSeleccionado.SelectedValue) ' Asegúrate de tener este label o variable para el idequipo

        ' Preguntar al usuario si desea eliminar el registro
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            ' Si el usuario selecciona "Sí", llamar a la función para eliminar los registros
            If EliminarRegistrosPorJugador(idJugador, idequipo) Then
                MessageBox.Show("El registro fue eliminado correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Ocurrió un error al eliminar el registro.", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ' Si el usuario selecciona "No", no hacer nada
            MessageBox.Show("El registro no ha sido eliminado.", "Eliminación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub


End Class