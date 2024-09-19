Public Class FrmEditarPuntos

    Private Sub BtnActualizar_Click(sender As Object, e As EventArgs) Handles BtnActualizar.Click

        Dim exito As Boolean = ConexionSqlite.ActualizarPuntosJugador(Convert.ToInt32(LblIdJugador.Text), Convert.ToInt32(LblFecha.Text), Convert.ToDecimal(TxtPuntos.Text))

        If exito Then
            MessageBox.Show("Valor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            FrmReporte.CargarDatosNuevos()

        Else
            MessageBox.Show("Error al actualizar el valor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class