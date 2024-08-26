<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        BtnCambiarCantidad = New Button()
        TxtCantidadFechas = New TextBox()
        LblDescFechas = New Label()
        LblFechas = New Label()
        SuspendLayout()
        ' 
        ' BtnCambiarCantidad
        ' 
        BtnCambiarCantidad.Location = New Point(182, 75)
        BtnCambiarCantidad.Name = "BtnCambiarCantidad"
        BtnCambiarCantidad.Size = New Size(75, 23)
        BtnCambiarCantidad.TabIndex = 0
        BtnCambiarCantidad.Text = "Cambiar"
        BtnCambiarCantidad.UseVisualStyleBackColor = True
        ' 
        ' TxtCantidadFechas
        ' 
        TxtCantidadFechas.Location = New Point(63, 75)
        TxtCantidadFechas.Name = "TxtCantidadFechas"
        TxtCantidadFechas.Size = New Size(100, 23)
        TxtCantidadFechas.TabIndex = 1
        ' 
        ' LblDescFechas
        ' 
        LblDescFechas.AutoSize = True
        LblDescFechas.Location = New Point(63, 19)
        LblDescFechas.Name = "LblDescFechas"
        LblDescFechas.Size = New Size(41, 15)
        LblDescFechas.TabIndex = 2
        LblDescFechas.Text = "Actual"
        ' 
        ' LblFechas
        ' 
        LblFechas.AutoSize = True
        LblFechas.Location = New Point(122, 19)
        LblFechas.Name = "LblFechas"
        LblFechas.Size = New Size(13, 15)
        LblFechas.TabIndex = 3
        LblFechas.Text = "0"
        ' 
        ' FrmConfiguracion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(339, 161)
        Controls.Add(LblFechas)
        Controls.Add(LblDescFechas)
        Controls.Add(TxtCantidadFechas)
        Controls.Add(BtnCambiarCantidad)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FrmConfiguracion"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Configuracion"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnCambiarCantidad As Button
    Friend WithEvents TxtCantidadFechas As TextBox
    Friend WithEvents LblDescFechas As Label
    Friend WithEvents LblFechas As Label
End Class
