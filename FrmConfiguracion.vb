Imports Ligas.ConexionSqlite


Public Class FrmConfiguracion
    Private Sub FrmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FechasInt As Integer = ObtenerValorEnteroConfiguracion()
        LblFechas.Text = FechasInt
        CargarEquipos()

        TxtNombreLiga.Text = LblNombreLiga.Text





    End Sub

    Private Sub BtnCambiarCantidad_Click(sender As Object, e As EventArgs) Handles BtnCambiarCantidad.Click
        '
        Dim nuevoValor As String = TxtCantidadFechas.Text.Trim()

        If IsNumeric(nuevoValor) AndAlso nuevoValor.Length = 2 Then

            Dim valorEntero As Integer = Convert.ToInt32(nuevoValor)


            If ActualizarValorEnteroConfiguracion(valorEntero) Then
                MessageBox.Show("Valor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("No se pudo actualizar el valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else

            MessageBox.Show("Por favor, ingrese un valor numérico de dos cifras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Sub CargarEquipos()
        CmbEquipo.DataSource = Nothing
        Dim dtEquipos As DataTable = ObtenerEquiposPorLiga(CInt(LblIdliga.Text))
        With CmbEquipo
            .DataSource = dtEquipos
            .DisplayMember = "nombre"
            .ValueMember = "idequipo"
            .SelectedIndex = -1
        End With
    End Sub


    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim equipoSeleccionado As Integer = CInt(CmbEquipo.SelectedValue)


        Dim resultado As DialogResult = MessageBox.Show(
        "¿Está seguro de que desea eliminar el equipo seleccionado y todos los registros asociados?",
        "Confirmar Eliminación",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    )


        If resultado = DialogResult.Yes Then
            If EliminarEquipoYRegistros(equipoSeleccionado) Then
                MessageBox.Show("El equipo y sus registros asociados fueron eliminados con éxito.")

                CargarEquipos()
            Else
                MessageBox.Show("No se pudo eliminar el equipo y sus registros.")
            End If
        End If
    End Sub
    Private Sub BtnModificarNombreEquipo_Click(sender As Object, e As EventArgs) Handles BtnModificarNombreEquipo.Click
        If TxtNuevoNombre.Text <> "" Then
            Dim equipoSeleccionado As Integer = CInt(CmbEquipo.SelectedValue)
            Dim nuevoNombre As String = TxtNuevoNombre.Text


            Dim resultado As DialogResult = MessageBox.Show(
            $"¿Está seguro de que desea cambiar el nombre del equipo seleccionado a '{nuevoNombre}'?",
            "Confirmar Modificación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )


            If resultado = DialogResult.Yes Then
                If EditarNombreEquipo(equipoSeleccionado, nuevoNombre) Then
                    MessageBox.Show("El nombre del equipo fue actualizado con éxito.")
                Else
                    MessageBox.Show("No se pudo actualizar el nombre del equipo.")
                End If
            End If
        Else
            MessageBox.Show("El campo del nuevo nombre está vacío. Por favor, ingrese un nuevo nombre.")
        End If
    End Sub

    Private Sub ChkActivarFuncionEliminarEditar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkActivarFuncionEliminarEditar.CheckedChanged
        If ChkActivarFuncionEliminarEditar.Checked Then

            GpbEquipos.Enabled = True


            Dim rutaArchivoOriginal As String = "C:\baseligas\liga.db"

            ' Verificar si el archivo original existe
            If System.IO.File.Exists(rutaArchivoOriginal) Then
                ' Crear el nombre del archivo de copia con timestamp
                Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
                Dim nombreArchivoCopia As String = $"liga_{timestamp}.db"
                Dim rutaArchivoCopia As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(rutaArchivoOriginal), nombreArchivoCopia)


                Try
                    System.IO.File.Copy(rutaArchivoOriginal, rutaArchivoCopia)
                    MessageBox.Show("Se realizo una copia de seguridad en: " & rutaArchivoCopia)
                Catch ex As Exception
                    MessageBox.Show("Error al copiar el archivo: " & ex.Message)
                End Try
            Else
                MessageBox.Show("El archivo original no se encuentra en la ruta especificada.")
            End If
        Else

            GpbEquipos.Enabled = False
        End If
    End Sub


    Private Sub Chkfechas_CheckedChanged(sender As Object, e As EventArgs) Handles Chkfechas.CheckedChanged

        If Chkfechas.Checked = True Then

            GpgFechas.Enabled = True
        Else
            GpgFechas.Enabled = False
        End If

    End Sub

    Private Sub BtnCambiarNombreLiga_Click(sender As Object, e As EventArgs) Handles BtnCambiarNombreLiga.Click
        If LblNombreLiga.Text <> TxtNombreLiga.Text Then
            If ConexionSqlite.ActualizarNombreLiga(LblIdliga.Text, TxtNombreLiga.Text) = True Then
                MsgBox("Actualizaste el nombre de la liga deberias salir y volver a entrar")
            End If
        End If
    End Sub
End Class