<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubliga
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
        LblNombreLiga = New Label()
        LblIdLiga = New Label()
        CmbSubliga = New ComboBox()
        DgvDatos = New DataGridView()
        BtnSeleccionar = New Button()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblNombreLiga
        ' 
        LblNombreLiga.AutoSize = True
        LblNombreLiga.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreLiga.ForeColor = Color.DarkRed
        LblNombreLiga.Location = New Point(29, 4)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(122, 21)
        LblNombreLiga.TabIndex = 14
        LblNombreLiga.Text = "Nombre de Liga"
        ' 
        ' LblIdLiga
        ' 
        LblIdLiga.AutoSize = True
        LblIdLiga.Location = New Point(10, 9)
        LblIdLiga.Name = "LblIdLiga"
        LblIdLiga.Size = New Size(13, 15)
        LblIdLiga.TabIndex = 13
        LblIdLiga.Text = "0"
        LblIdLiga.Visible = False
        ' 
        ' CmbSubliga
        ' 
        CmbSubliga.FormattingEnabled = True
        CmbSubliga.Location = New Point(12, 39)
        CmbSubliga.Name = "CmbSubliga"
        CmbSubliga.Size = New Size(201, 23)
        CmbSubliga.TabIndex = 15
        ' 
        ' DgvDatos
        ' 
        DgvDatos.AllowUserToAddRows = False
        DgvDatos.AllowUserToDeleteRows = False
        DgvDatos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDatos.Location = New Point(12, 68)
        DgvDatos.Name = "DgvDatos"
        DgvDatos.ReadOnly = True
        DgvDatos.RowTemplate.Height = 25
        DgvDatos.Size = New Size(797, 471)
        DgvDatos.TabIndex = 16
        ' 
        ' BtnSeleccionar
        ' 
        BtnSeleccionar.Location = New Point(219, 38)
        BtnSeleccionar.Name = "BtnSeleccionar"
        BtnSeleccionar.Size = New Size(75, 23)
        BtnSeleccionar.TabIndex = 17
        BtnSeleccionar.Text = "Seleccionar"
        BtnSeleccionar.UseVisualStyleBackColor = True
        ' 
        ' FrmSubliga
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(821, 551)
        Controls.Add(BtnSeleccionar)
        Controls.Add(DgvDatos)
        Controls.Add(CmbSubliga)
        Controls.Add(LblNombreLiga)
        Controls.Add(LblIdLiga)
        Name = "FrmSubliga"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Sub liga"
        WindowState = FormWindowState.Maximized
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblNombreLiga As Label
    Friend WithEvents LblIdLiga As Label
    Friend WithEvents CmbSubliga As ComboBox
    Friend WithEvents DgvDatos As DataGridView
    Friend WithEvents BtnSeleccionar As Button
End Class
