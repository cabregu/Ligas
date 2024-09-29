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
        Btnxls = New Button()
        BtnEliminarFecha = New Button()
        TxtFechaNro = New TextBox()
        BtnConfirmar = New Button()
        CmbPosicion = New ComboBox()
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
        DgvDatos.Size = New Size(845, 471)
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
        ' Btnxls
        ' 
        Btnxls.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Btnxls.BackColor = Color.SlateGray
        Btnxls.FlatStyle = FlatStyle.Flat
        Btnxls.Image = My.Resources.Resources.SendXLS_32x32
        Btnxls.Location = New Point(794, 17)
        Btnxls.Name = "Btnxls"
        Btnxls.Size = New Size(63, 44)
        Btnxls.TabIndex = 18
        Btnxls.UseVisualStyleBackColor = False
        ' 
        ' BtnEliminarFecha
        ' 
        BtnEliminarFecha.Location = New Point(366, 38)
        BtnEliminarFecha.Name = "BtnEliminarFecha"
        BtnEliminarFecha.Size = New Size(169, 23)
        BtnEliminarFecha.TabIndex = 19
        BtnEliminarFecha.Text = "Eliminar datos de Fecha"
        BtnEliminarFecha.UseVisualStyleBackColor = True
        ' 
        ' TxtFechaNro
        ' 
        TxtFechaNro.Location = New Point(541, 38)
        TxtFechaNro.Name = "TxtFechaNro"
        TxtFechaNro.Size = New Size(38, 23)
        TxtFechaNro.TabIndex = 20
        ' 
        ' BtnConfirmar
        ' 
        BtnConfirmar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnConfirmar.BackColor = Color.SlateGray
        BtnConfirmar.FlatStyle = FlatStyle.Flat
        BtnConfirmar.Image = My.Resources.Resources.Bar_32x32
        BtnConfirmar.Location = New Point(732, 17)
        BtnConfirmar.Name = "BtnConfirmar"
        BtnConfirmar.Size = New Size(56, 44)
        BtnConfirmar.TabIndex = 21
        BtnConfirmar.UseVisualStyleBackColor = False
        ' 
        ' CmbPosicion
        ' 
        CmbPosicion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        CmbPosicion.FormattingEnabled = True
        CmbPosicion.Items.AddRange(New Object() {"", "Por", "Def", "Med", "Del"})
        CmbPosicion.Location = New Point(633, 38)
        CmbPosicion.Name = "CmbPosicion"
        CmbPosicion.Size = New Size(93, 23)
        CmbPosicion.TabIndex = 22
        ' 
        ' FrmSubliga
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(869, 551)
        Controls.Add(CmbPosicion)
        Controls.Add(BtnConfirmar)
        Controls.Add(TxtFechaNro)
        Controls.Add(BtnEliminarFecha)
        Controls.Add(Btnxls)
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
    Friend WithEvents Btnxls As Button
    Friend WithEvents BtnEliminarFecha As Button
    Friend WithEvents TxtFechaNro As TextBox
    Friend WithEvents BtnConfirmar As Button
    Friend WithEvents CmbPosicion As ComboBox
End Class
