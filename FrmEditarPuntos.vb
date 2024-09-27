Public Class FrmEditarPuntos

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click
        ' Validar si el TextBox TxtPuntos está vacío
        If String.IsNullOrWhiteSpace(TxtPuntos.Text) Then
            MessageBox.Show("Por favor, ingrese un valor en los puntos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtPuntos.Focus() ' Opcional: enfocar el TextBox para que el usuario lo complete
            Return ' Salir del método si no hay valor
        End If

        ' Intentar convertir el texto a Decimal
        Dim puntos As Decimal
        If Not Decimal.TryParse(TxtPuntos.Text, puntos) Then
            MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtPuntos.Focus()
            Return
        End If

        ' Realizar la actualización
        Dim exito As Boolean = ConexionSqlite.ActualizarPuntosJugador(Convert.ToInt32(LblIdJugador.Text), Convert.ToInt32(LblFecha.Text), puntos)

        If exito Then
            MessageBox.Show("Valor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            FrmReporte.CargarDatosNuevos()
        Else
            MessageBox.Show("Error al actualizar el valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


End Class