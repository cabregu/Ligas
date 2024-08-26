Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Ligas.ConexionSqlite


Public Class FrmConfiguracion
    Private Sub FrmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FechasInt As Integer = ObtenerValorEnteroConfiguracion()
        LblFechas.Text = FechasInt

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

End Class