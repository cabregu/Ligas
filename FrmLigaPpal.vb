Imports Ligas.ConexionSqlite


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

        Return True
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
            DgvEditarJugadores.Rows.Clear
            DgvEditarJugadores.Columns.Clear

            ' Obtener los datos según el equipo seleccionado
            Dim idequipo = Convert.ToInt64(CmbEquipoSeleccionado.SelectedValue)
            DgvEditarJugadores.DataSource = ObtenerJugadoresConEquipos(idequipo)
            DgvEditarJugadores.Columns("idjugadores").Visible = False
            LblIdJugadorSeleccionado.Text = 0
            LblJugadorSeleccionado.Text = ""
            LblPosicion.Text = ""
        Catch ex As Exception

        End Try


    End Sub

    Private Sub DgvEditarJugadores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEditarJugadores.CellClick

        If DgvEditarJugadores.RowCount > 0 AndAlso e.RowIndex >= 0 Then
            Dim idJugador = Convert.ToInt32(DgvEditarJugadores.Rows(e.RowIndex).Cells("idjugadores").Value)
            Dim NombreJugador = Convert.ToString(DgvEditarJugadores.Rows(e.RowIndex).Cells("jugador").Value)
            Dim posicion = Convert.ToString(DgvEditarJugadores.Rows(e.RowIndex).Cells("posicion").Value)

            LblJugadorSeleccionado.Text = ""
            LblIdJugadorSeleccionado.Text = ""
            LblJugadorSeleccionado.Text = NombreJugador
            LblIdJugadorSeleccionado.Text = idJugador.ToString
            LblPosicion.Text = posicion

            TxtNuevoNombre.Text = NombreJugador

        End If

    End Sub

    Private Sub BtnTransferir_Click(sender As Object, e As EventArgs) Handles BtnTransferir.Click


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
                DgvEditarJugadores.DataSource = Nothing

            Else
                MessageBox.Show("Ocurrió un error al eliminar el registro.", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ' Si el usuario selecciona "No", no hacer nada
            MessageBox.Show("El registro no ha sido eliminado.", "Eliminación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        FrmReporte.LblIdLiga.Text = LblIdLiga.Text
        FrmReporte.LblNombreLiga.Text = LblNombreLiga.Text
        FrmReporte.Show()

    End Sub

    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs) Handles BtnConfiguracion.Click
        FrmConfiguracion.LblIdliga.Text = LblIdLiga.Text
        FrmConfiguracion.LblNombreLiga.Text = LblNombreLiga.Text
        FrmConfiguracion.Show()

    End Sub

    Private Sub BtnModificar_Click(sender As Object, e As EventArgs) Handles BtnModificar.Click


        Dim idJugador As Integer = Convert.ToInt32(LblIdJugadorSeleccionado.Text)

        If ActualizarNombreJugador(idJugador, TxtNuevoNombre.Text) Then
            TxtNuevoNombre.Text = ""
            DgvEditarJugadores.DataSource = Nothing
            CmbEquipoSeleccionado.SelectedIndex = -1

        End If


    End Sub

    Private Sub BtnSubliga_Click(sender As Object, e As EventArgs) Handles BtnSubliga.Click
        FrmSubliga.LblIdLiga.Text = LblIdLiga.Text
        FrmSubliga.LblNombreLiga.Text = LblNombreLiga.Text
        FrmSubliga.Show()
    End Sub

    Private Sub ChkActivarSubliga_CheckedChanged(sender As Object, e As EventArgs) Handles ChkActivarSubliga.CheckedChanged
        If ChkActivarSubliga.Checked = True Then

            BtnTransferirAl.Visible = False
            CmbEquipoAtransferir.Visible = False
            BtnTransferir.Visible = False
            LblO.Visible = False
            BtnEliminar.Visible = False
            TxtNuevoNombre.Visible = False
            BtnModificar.Visible = False



            LblSeleccionesubliga.Enabled = True
            CmbSubliga.Enabled = True
            LblNombresubliga.Enabled = True
            TxtNommbresubliga.Enabled = True
            DgvSubliga.Enabled = True
            BtnCrearSubliga.Enabled = True
            BtnEliminarSubliga.Enabled = True
            BtnBorrarJugadorDeLigaCreada.Enabled = True
            BtnAgregarASubliga.Visible = True
            LblNombreJugadorSubliga.Enabled = True
            BtnBorrarJugadorDeLigaCreada.Enabled = True


            CargarSubligas()

        Else

            BtnTransferirAl.Visible = True
            CmbEquipoAtransferir.Visible = True
            BtnTransferir.Visible = True
            LblO.Visible = True
            BtnEliminar.Visible = True
            TxtNuevoNombre.Visible = True
            BtnModificar.Visible = True


            LblSeleccionesubliga.Enabled = False
            CmbSubliga.Enabled = False
            LblNombresubliga.Enabled = False
            TxtNommbresubliga.Enabled = False
            DgvSubliga.Enabled = False
            BtnCrearSubliga.Enabled = False
            BtnEliminarSubliga.Enabled = False
            LblNombreJugadorSubliga.Enabled = False
            BtnBorrarJugadorDeLigaCreada.Enabled = False
            BtnAgregarASubliga.Visible = False

        End If
    End Sub



    Private Sub BtnAgregarASubliga_Click(sender As Object, e As EventArgs) Handles BtnAgregarASubliga.Click

        If String.IsNullOrWhiteSpace(CmbSubliga.Text) AndAlso String.IsNullOrWhiteSpace(TxtNommbresubliga.Text) Then

            MsgBox("Debe crear el nombre de la subliga o seleccionar una subliga existente")
        Else

            If Not String.IsNullOrWhiteSpace(LblIdJugadorSeleccionado.Text) AndAlso
               Not String.IsNullOrWhiteSpace(LblJugadorSeleccionado.Text) AndAlso
               Not String.IsNullOrWhiteSpace(LblPosicion.Text) Then

                DgvSubliga.Rows.Add(LblIdJugadorSeleccionado.Text, LblJugadorSeleccionado.Text, LblPosicion.Text)

            Else

                MessageBox.Show("Por favor, asegúrate de que todos los campos estén completos antes de agregar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If



    End Sub




    Private Sub BtnCrearSubliga_Click(sender As Object, e As EventArgs) Handles BtnCrearSubliga.Click


        If TxtNommbresubliga.Text <> "" Then
            If DgvSubliga.RowCount > 0 Then

                For Each drw As DataGridViewRow In DgvSubliga.Rows
                    AgregarJugadorASubliga(TxtNommbresubliga.Text, drw.Cells("idjugador").Value, LblIdLiga.Text)
                Next

                DgvSubliga.Rows.Clear()
                TxtNommbresubliga.Text = ""
                CargarSubligas()
                TxtNommbresubliga.Text = ""

            End If

        Else

            MsgBox("Debe colocar el nombre de la liga o seleccionarlo")

        End If

        If CmbSubliga.Text <> "" Then

            For Each drw As DataGridViewRow In DgvSubliga.Rows
                AgregarJugadorASubliga(CmbSubliga.Text, drw.Cells("idjugador").Value, LblIdLiga.Text)
            Next

        End If

    End Sub


    Private Sub CargarSubligas()

        Dim nombresSubligas As List(Of String) = ObtenerNombresSubligas()

        CmbSubliga.DataSource = nombresSubligas
        CmbSubliga.SelectedIndex = -1

    End Sub

    Private Sub BtnBorrarJugadorDeLigaCreada_Click(sender As Object, e As EventArgs) Handles BtnBorrarJugadorDeLigaCreada.Click
        If DgvSubliga.RowCount > 0 Then


            If LblIdJugadorSubliga.Text <> "0" Then

                Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas borrar el jugador?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                If result = DialogResult.Yes Then

                    Dim idJugador As Integer
                    If Integer.TryParse(LblIdJugadorSubliga.Text, idJugador) Then
                        Dim eliminado As Boolean = EliminarDeSubligaPorIdJugador(CmbSubliga.Text, idJugador, LblIdLiga.Text)

                        If eliminado Then
                            MessageBox.Show("Jugador eliminado con éxito.")

                            If Not String.IsNullOrWhiteSpace(LblIdJugadorSubliga.Text) Then
                                Dim idJugadorEliminar As Integer
                                If Integer.TryParse(LblIdJugadorSubliga.Text, idJugadorEliminar) Then
                                    For Each row As DataGridViewRow In DgvSubliga.Rows
                                        If row.Cells("idjugador").Value IsNot Nothing AndAlso Convert.ToInt32(row.Cells("idjugador").Value) = idJugadorEliminar Then
                                            DgvSubliga.Rows.Remove(row)
                                            Exit Sub
                                        End If
                                    Next
                                End If
                            End If


                        Else

                            If Not String.IsNullOrWhiteSpace(LblIdJugadorSubliga.Text) Then
                                Dim idJugadorEliminar As Integer
                                If Integer.TryParse(LblIdJugadorSubliga.Text, idJugadorEliminar) Then
                                    For Each row As DataGridViewRow In DgvSubliga.Rows
                                        If row.Cells("idjugador").Value IsNot Nothing AndAlso Convert.ToInt32(row.Cells("idjugador").Value) = idJugadorEliminar Then
                                            DgvSubliga.Rows.Remove(row)
                                            Exit Sub
                                        End If
                                    Next
                                End If
                            End If


                        End If

                        LblNombreJugadorSubliga.Text = ""

                    Else
                        MessageBox.Show("ID del jugador no es válido.")
                    End If
                End If
            Else
                MessageBox.Show("ID del jugador no es válido o no está seleccionado.")
            End If
        End If

    End Sub

    Private Sub CmbSubliga_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbSubliga.SelectedValueChanged

        TxtNommbresubliga.Text = CmbSubliga.Text

        Dim dtsubliga As New DataTable
        dtsubliga = ObtenerJugadoresPorSubliga(CmbSubliga.Text)

        DgvSubliga.Rows.Clear()

        For Each drw As DataRow In dtsubliga.Rows
            DgvSubliga.Rows.Add(drw("idjugador").ToString, drw("jugador").ToString, drw("posicion").ToString)
        Next

    End Sub


    Private Sub DgvSubliga_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSubliga.CellClick

        If DgvSubliga.RowCount > 0 AndAlso e.RowIndex >= 0 Then
            Dim idJugador = Convert.ToInt32(DgvSubliga.Rows(e.RowIndex).Cells("idjugador").Value)
            Dim NombreJugador = Convert.ToString(DgvSubliga.Rows(e.RowIndex).Cells("Nombrejugador").Value)

            LblNombreJugadorSubliga.Text = NombreJugador
            LblIdJugadorSubliga.Text = idJugador.ToString


        End If
    End Sub

    Private Sub BtnEliminarSubliga_Click(sender As Object, e As EventArgs) Handles BtnEliminarSubliga.Click
        Dim nombreSubliga As String = CmbSubliga.Text


        If String.IsNullOrWhiteSpace(nombreSubliga) Then
            MessageBox.Show("Por favor, selecciona una subliga para eliminar.", "Subliga no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        Dim result As DialogResult = MessageBox.Show($"¿Estás seguro de que deseas eliminar la subliga '{nombreSubliga}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)


        If result = DialogResult.Yes Then

            Dim eliminado As Boolean = EliminarSubligaPorNombre(nombreSubliga)

            If eliminado Then
                MessageBox.Show("La subliga ha sido eliminada correctamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CargarSubligas()
                DgvSubliga.Rows.Clear()


            Else
                MessageBox.Show("No se pudo eliminar la subliga. Verifica si el nombre es correcto o si hay errores.", "Error en Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


End Class