<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditarPuntos
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
        LblNombreJugador = New Label()
        LblIdJugador = New Label()
        LblFecha = New Label()
        LblPuntos = New Label()
        TxtPuntos = New TextBox()
        BtnActualizar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' LblNombreJugador
        ' 
        LblNombreJugador.AutoSize = True
        LblNombreJugador.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreJugador.ForeColor = Color.DarkRed
        LblNombreJugador.Location = New Point(94, 9)
        LblNombreJugador.Name = "LblNombreJugador"
        LblNombreJugador.Size = New Size(154, 25)
        LblNombreJugador.TabIndex = 15
        LblNombreJugador.Text = "Nombre Jugador"
        ' 
        ' LblIdJugador
        ' 
        LblIdJugador.AutoSize = True
        LblIdJugador.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        LblIdJugador.ForeColor = Color.DarkRed
        LblIdJugador.Location = New Point(345, 9)
        LblIdJugador.Name = "LblIdJugador"
        LblIdJugador.Size = New Size(96, 25)
        LblIdJugador.TabIndex = 16
        LblIdJugador.Text = "IdJugador"
        LblIdJugador.Visible = False
        ' 
        ' LblFecha
        ' 
        LblFecha.AutoSize = True
        LblFecha.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        LblFecha.ForeColor = Color.DarkRed
        LblFecha.Location = New Point(94, 34)
        LblFecha.Name = "LblFecha"
        LblFecha.Size = New Size(61, 25)
        LblFecha.TabIndex = 17
        LblFecha.Text = "Fecha"
        ' 
        ' LblPuntos
        ' 
        LblPuntos.AutoSize = True
        LblPuntos.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        LblPuntos.ForeColor = Color.DarkRed
        LblPuntos.Location = New Point(94, 59)
        LblPuntos.Name = "LblPuntos"
        LblPuntos.Size = New Size(70, 25)
        LblPuntos.TabIndex = 18
        LblPuntos.Text = "Puntos"
        ' 
        ' TxtPuntos
        ' 
        TxtPuntos.Location = New Point(217, 59)
        TxtPuntos.Name = "TxtPuntos"
        TxtPuntos.Size = New Size(100, 23)
        TxtPuntos.TabIndex = 19
        ' 
        ' BtnActualizar
        ' 
        BtnActualizar.Location = New Point(345, 61)
        BtnActualizar.Name = "BtnActualizar"
        BtnActualizar.Size = New Size(75, 23)
        BtnActualizar.TabIndex = 20
        BtnActualizar.Text = "Actualizar"
        BtnActualizar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.DarkRed
        Label1.Location = New Point(1, 59)
        Label1.Name = "Label1"
        Label1.Size = New Size(70, 25)
        Label1.TabIndex = 23
        Label1.Text = "Puntos"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.DarkRed
        Label2.Location = New Point(1, 34)
        Label2.Name = "Label2"
        Label2.Size = New Size(61, 25)
        Label2.TabIndex = 22
        Label2.Text = "Fecha"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.DarkRed
        Label3.Location = New Point(1, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(80, 25)
        Label3.TabIndex = 21
        Label3.Text = "Jugador"
        ' 
        ' FrmEditarPuntos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(453, 107)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(BtnActualizar)
        Controls.Add(TxtPuntos)
        Controls.Add(LblPuntos)
        Controls.Add(LblFecha)
        Controls.Add(LblIdJugador)
        Controls.Add(LblNombreJugador)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FrmEditarPuntos"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Editar Puntos"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblNombreJugador As Label
    Friend WithEvents LblIdJugador As Label
    Friend WithEvents LblFecha As Label
    Friend WithEvents LblPuntos As Label
    Friend WithEvents TxtPuntos As TextBox
    Friend WithEvents BtnActualizar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
