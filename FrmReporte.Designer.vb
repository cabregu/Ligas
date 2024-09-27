<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporte
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
        DgvDatos = New DataGridView()
        BtnObtenerDatos = New Button()
        Btnxls = New Button()
        CmbEquipos = New ComboBox()
        LblNombreLiga = New Label()
        LblIdLiga = New Label()
        TxtNombreDeEquipo = New TextBox()
        CmbLiga = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        BtnCopiar = New Button()
        PgbCopiando = New ProgressBar()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvDatos
        ' 
        DgvDatos.AllowUserToAddRows = False
        DgvDatos.AllowUserToDeleteRows = False
        DgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDatos.Location = New Point(12, 96)
        DgvDatos.Name = "DgvDatos"
        DgvDatos.ReadOnly = True
        DgvDatos.RowTemplate.Height = 25
        DgvDatos.Size = New Size(971, 342)
        DgvDatos.TabIndex = 0
        ' 
        ' BtnObtenerDatos
        ' 
        BtnObtenerDatos.BackColor = Color.SlateGray
        BtnObtenerDatos.FlatStyle = FlatStyle.Flat
        BtnObtenerDatos.Image = My.Resources.Resources.Reviewers_32x32
        BtnObtenerDatos.Location = New Point(192, 29)
        BtnObtenerDatos.Name = "BtnObtenerDatos"
        BtnObtenerDatos.Size = New Size(63, 61)
        BtnObtenerDatos.TabIndex = 7
        BtnObtenerDatos.UseVisualStyleBackColor = False
        ' 
        ' Btnxls
        ' 
        Btnxls.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Btnxls.BackColor = Color.SlateGray
        Btnxls.FlatStyle = FlatStyle.Flat
        Btnxls.Image = My.Resources.Resources.SendXLS_32x32
        Btnxls.Location = New Point(920, 29)
        Btnxls.Name = "Btnxls"
        Btnxls.Size = New Size(63, 61)
        Btnxls.TabIndex = 8
        Btnxls.UseVisualStyleBackColor = False
        ' 
        ' CmbEquipos
        ' 
        CmbEquipos.FormattingEnabled = True
        CmbEquipos.Location = New Point(12, 49)
        CmbEquipos.Name = "CmbEquipos"
        CmbEquipos.Size = New Size(160, 23)
        CmbEquipos.TabIndex = 9
        ' 
        ' LblNombreLiga
        ' 
        LblNombreLiga.AutoSize = True
        LblNombreLiga.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreLiga.ForeColor = Color.DarkRed
        LblNombreLiga.Location = New Point(279, 9)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(186, 32)
        LblNombreLiga.TabIndex = 13
        LblNombreLiga.Text = "Nombre de Liga"
        ' 
        ' LblIdLiga
        ' 
        LblIdLiga.AutoSize = True
        LblIdLiga.Location = New Point(12, 9)
        LblIdLiga.Name = "LblIdLiga"
        LblIdLiga.Size = New Size(13, 15)
        LblIdLiga.TabIndex = 14
        LblIdLiga.Text = "0"
        LblIdLiga.Visible = False
        ' 
        ' TxtNombreDeEquipo
        ' 
        TxtNombreDeEquipo.Location = New Point(279, 67)
        TxtNombreDeEquipo.Name = "TxtNombreDeEquipo"
        TxtNombreDeEquipo.Size = New Size(139, 23)
        TxtNombreDeEquipo.TabIndex = 15
        ' 
        ' CmbLiga
        ' 
        CmbLiga.FormattingEnabled = True
        CmbLiga.Location = New Point(481, 67)
        CmbLiga.Name = "CmbLiga"
        CmbLiga.Size = New Size(162, 23)
        CmbLiga.TabIndex = 16
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.DarkRed
        Label1.Location = New Point(281, 46)
        Label1.Name = "Label1"
        Label1.Size = New Size(93, 15)
        Label1.TabIndex = 17
        Label1.Text = "Nombre Equipo"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.DarkRed
        Label2.Location = New Point(424, 70)
        Label2.Name = "Label2"
        Label2.Size = New Size(51, 15)
        Label2.TabIndex = 18
        Label2.Text = "Copiar a"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.DarkRed
        Label3.Location = New Point(481, 46)
        Label3.Name = "Label3"
        Label3.Size = New Size(92, 15)
        Label3.TabIndex = 19
        Label3.Text = "Nombre de liga"
        ' 
        ' BtnCopiar
        ' 
        BtnCopiar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnCopiar.ForeColor = Color.DarkRed
        BtnCopiar.Location = New Point(649, 67)
        BtnCopiar.Name = "BtnCopiar"
        BtnCopiar.Size = New Size(70, 23)
        BtnCopiar.TabIndex = 20
        BtnCopiar.Text = "Copiar"
        BtnCopiar.UseVisualStyleBackColor = True
        ' 
        ' PgbCopiando
        ' 
        PgbCopiando.Location = New Point(725, 80)
        PgbCopiando.Name = "PgbCopiando"
        PgbCopiando.Size = New Size(189, 10)
        PgbCopiando.TabIndex = 21
        ' 
        ' FrmReporte
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(995, 450)
        Controls.Add(PgbCopiando)
        Controls.Add(BtnCopiar)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(CmbLiga)
        Controls.Add(TxtNombreDeEquipo)
        Controls.Add(LblIdLiga)
        Controls.Add(LblNombreLiga)
        Controls.Add(CmbEquipos)
        Controls.Add(Btnxls)
        Controls.Add(BtnObtenerDatos)
        Controls.Add(DgvDatos)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "FrmReporte"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reporte"
        WindowState = FormWindowState.Maximized
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DgvDatos As DataGridView
    Friend WithEvents BtnObtenerDatos As Button
    Friend WithEvents Btnxls As Button
    Friend WithEvents CmbEquipos As ComboBox
    Friend WithEvents LblNombreLiga As Label
    Friend WithEvents LblIdLiga As Label
    Friend WithEvents TxtNombreDeEquipo As TextBox
    Friend WithEvents CmbLiga As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnCopiar As Button
    Friend WithEvents PgbCopiando As ProgressBar
End Class
