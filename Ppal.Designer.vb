<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPpal
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
        CmbFechas = New ComboBox()
        BtnConfirmar = New Button()
        lblIdequipo = New Label()
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
        DgvJugadores.Location = New Point(198, 59)
        DgvJugadores.Name = "DgvJugadores"
        DgvJugadores.RowTemplate.Height = 25
        DgvJugadores.Size = New Size(522, 483)
        DgvJugadores.TabIndex = 0
        ' 
        ' DgvEquipos
        ' 
        DgvEquipos.AllowUserToAddRows = False
        DgvEquipos.AllowUserToDeleteRows = False
        DgvEquipos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvEquipos.Location = New Point(12, 59)
        DgvEquipos.Name = "DgvEquipos"
        DgvEquipos.ReadOnly = True
        DgvEquipos.RowTemplate.Height = 25
        DgvEquipos.Size = New Size(180, 483)
        DgvEquipos.TabIndex = 1
        ' 
        ' CmbFechas
        ' 
        CmbFechas.FormattingEnabled = True
        CmbFechas.Location = New Point(12, 12)
        CmbFechas.Name = "CmbFechas"
        CmbFechas.Size = New Size(121, 23)
        CmbFechas.TabIndex = 2
        ' 
        ' BtnConfirmar
        ' 
        BtnConfirmar.BackColor = Color.SlateGray
        BtnConfirmar.FlatStyle = FlatStyle.Flat
        BtnConfirmar.Image = My.Resources.Resources.inicial
        BtnConfirmar.Location = New Point(651, 546)
        BtnConfirmar.Name = "BtnConfirmar"
        BtnConfirmar.Size = New Size(63, 61)
        BtnConfirmar.TabIndex = 3
        BtnConfirmar.UseVisualStyleBackColor = False
        ' 
        ' lblIdequipo
        ' 
        lblIdequipo.AutoSize = True
        lblIdequipo.Location = New Point(12, 41)
        lblIdequipo.Name = "lblIdequipo"
        lblIdequipo.Size = New Size(13, 15)
        lblIdequipo.TabIndex = 4
        lblIdequipo.Text = "0"
        ' 
        ' FrmPpal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SlateGray
        ClientSize = New Size(726, 619)
        Controls.Add(lblIdequipo)
        Controls.Add(BtnConfirmar)
        Controls.Add(CmbFechas)
        Controls.Add(DgvEquipos)
        Controls.Add(DgvJugadores)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FrmPpal"
        Text = "Control de ligas"
        CType(DgvJugadores, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvEquipos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvJugadores As DataGridView
    Friend WithEvents DgvEquipos As DataGridView
    Friend WithEvents CmbFechas As ComboBox
    Friend WithEvents BtnConfirmar As Button
    Friend WithEvents lblIdequipo As Label

End Class
