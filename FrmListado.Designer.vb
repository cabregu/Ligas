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
        BtnConfirmar = New Button()
        DgvEquipos = New DataGridView()
        FileSystemWatcher1 = New IO.FileSystemWatcher()
        FormsPlot1 = New ScottPlot.WinForms.FormsPlot()
        LblNombreLiga = New Label()
        LblIdLiga = New Label()
        CType(DgvEquipos, ComponentModel.ISupportInitialize).BeginInit()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnConfirmar
        ' 
        BtnConfirmar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        BtnConfirmar.BackColor = Color.SlateGray
        BtnConfirmar.FlatStyle = FlatStyle.Flat
        BtnConfirmar.Image = My.Resources.Resources.Bar_32x32
        BtnConfirmar.Location = New Point(520, 442)
        BtnConfirmar.Name = "BtnConfirmar"
        BtnConfirmar.Size = New Size(56, 53)
        BtnConfirmar.TabIndex = 10
        BtnConfirmar.UseVisualStyleBackColor = False
        ' 
        ' DgvEquipos
        ' 
        DgvEquipos.AllowUserToAddRows = False
        DgvEquipos.AllowUserToDeleteRows = False
        DgvEquipos.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        DgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvEquipos.Location = New Point(393, 71)
        DgvEquipos.Name = "DgvEquipos"
        DgvEquipos.ReadOnly = True
        DgvEquipos.RowTemplate.Height = 25
        DgvEquipos.Size = New Size(183, 365)
        DgvEquipos.TabIndex = 8
        ' 
        ' FileSystemWatcher1
        ' 
        FileSystemWatcher1.EnableRaisingEvents = True
        FileSystemWatcher1.SynchronizingObject = Me
        ' 
        ' FormsPlot1
        ' 
        FormsPlot1.DisplayScale = 1F
        FormsPlot1.Location = New Point(12, 71)
        FormsPlot1.Name = "FormsPlot1"
        FormsPlot1.Size = New Size(375, 365)
        FormsPlot1.TabIndex = 11
        ' 
        ' LblNombreLiga
        ' 
        LblNombreLiga.AutoSize = True
        LblNombreLiga.Font = New Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreLiga.ForeColor = Color.DarkRed
        LblNombreLiga.Location = New Point(137, 9)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(250, 45)
        LblNombreLiga.TabIndex = 14
        LblNombreLiga.Text = "Nombre de Liga"
        ' 
        ' LblIdLiga
        ' 
        LblIdLiga.AutoSize = True
        LblIdLiga.Location = New Point(13, 9)
        LblIdLiga.Name = "LblIdLiga"
        LblIdLiga.Size = New Size(13, 15)
        LblIdLiga.TabIndex = 13
        LblIdLiga.Text = "0"
        LblIdLiga.Visible = False
        ' 
        ' FrmListado
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(851, 501)
        Controls.Add(LblNombreLiga)
        Controls.Add(LblIdLiga)
        Controls.Add(FormsPlot1)
        Controls.Add(BtnConfirmar)
        Controls.Add(DgvEquipos)
        Name = "FrmListado"
        Text = "Listado"
        CType(DgvEquipos, ComponentModel.ISupportInitialize).EndInit()
        CType(FileSystemWatcher1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnConfirmar As Button
    Friend WithEvents DgvEquipos As DataGridView
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents FormsPlot1 As ScottPlot.WinForms.FormsPlot
    Friend WithEvents LblNombreLiga As Label
    Friend WithEvents LblIdLiga As Label


End Class
