<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        DgvJugadores = New DataGridView()
        DgvEquipos = New DataGridView()
        CType(DgvJugadores, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvEquipos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvJugadores
        ' 
        DgvJugadores.AllowUserToAddRows = False
        DgvJugadores.AllowUserToDeleteRows = False
        DgvJugadores.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvJugadores.Location = New Point(217, 12)
        DgvJugadores.Name = "DgvJugadores"
        DgvJugadores.RowTemplate.Height = 25
        DgvJugadores.Size = New Size(540, 472)
        DgvJugadores.TabIndex = 0
        ' 
        ' DgvEquipos
        ' 
        DgvEquipos.AllowUserToAddRows = False
        DgvEquipos.AllowUserToDeleteRows = False
        DgvEquipos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvEquipos.Location = New Point(12, 12)
        DgvEquipos.Name = "DgvEquipos"
        DgvEquipos.ReadOnly = True
        DgvEquipos.RowTemplate.Height = 25
        DgvEquipos.Size = New Size(199, 472)
        DgvEquipos.TabIndex = 1
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SlateGray
        ClientSize = New Size(782, 496)
        Controls.Add(DgvEquipos)
        Controls.Add(DgvJugadores)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "Form1"
        Text = "Control de ligas"
        CType(DgvJugadores, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvEquipos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DgvJugadores As DataGridView
    Friend WithEvents DgvEquipos As DataGridView

End Class
