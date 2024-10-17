<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListado
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


    Private components As System.ComponentModel.IContainer


    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        FileSystemWatcher1 = New IO.FileSystemWatcher()
        Panel = New Panel()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' FileSystemWatcher1
        ' 
        FileSystemWatcher1.EnableRaisingEvents = True
        FileSystemWatcher1.SynchronizingObject = Me
        ' 
        ' Panel
        ' 
        Panel.AutoScroll = True
        Panel.BackColor = SystemColors.Control
        Panel.Dock = DockStyle.Fill
        Panel.Location = New Point(0, 0)
        Panel.Name = "Panel"
        Panel.Size = New Size(1184, 411)
        Panel.TabIndex = 0
        ' 
        ' FrmListado
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1184, 411)
        Controls.Add(Panel)
        Name = "FrmListado"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Listado"
        WindowState = FormWindowState.Maximized
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents Panel As Panel


End Class
