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
        DgvDatos.Size = New Size(776, 342)
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
        Btnxls.Location = New Point(725, 29)
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
        LblNombreLiga.Font = New Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreLiga.ForeColor = Color.DarkRed
        LblNombreLiga.Location = New Point(338, 9)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(250, 45)
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
        ' FrmReporte
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(800, 450)
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
End Class
