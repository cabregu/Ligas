<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCrearLista
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
        lblIdequipo = New Label()
        DgvEquipos = New DataGridView()
        DgvJugadores = New DataGridView()
        BtnCrearLista = New Button()
        DgvLista = New DataGridView()
        TxtNombreLista = New TextBox()
        LblNombre = New Label()
        CType(DgvEquipos, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvJugadores, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvLista, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblNombreLiga
        ' 
        LblNombreLiga.AutoSize = True
        LblNombreLiga.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreLiga.ForeColor = Color.Maroon
        LblNombreLiga.Location = New Point(31, -12)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(127, 30)
        LblNombreLiga.TabIndex = 12
        LblNombreLiga.Text = "NombreLiga"
        LblNombreLiga.Visible = False
        ' 
        ' LblIdLiga
        ' 
        LblIdLiga.AutoSize = True
        LblIdLiga.Location = New Point(12, 3)
        LblIdLiga.Name = "LblIdLiga"
        LblIdLiga.Size = New Size(13, 15)
        LblIdLiga.TabIndex = 11
        LblIdLiga.Text = "0"
        LblIdLiga.Visible = False
        ' 
        ' lblIdequipo
        ' 
        lblIdequipo.AutoSize = True
        lblIdequipo.Location = New Point(172, 3)
        lblIdequipo.Name = "lblIdequipo"
        lblIdequipo.Size = New Size(13, 15)
        lblIdequipo.TabIndex = 10
        lblIdequipo.Text = "0"
        lblIdequipo.Visible = False
        ' 
        ' DgvEquipos
        ' 
        DgvEquipos.AllowUserToAddRows = False
        DgvEquipos.AllowUserToDeleteRows = False
        DgvEquipos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DgvEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvEquipos.Location = New Point(12, 67)
        DgvEquipos.Name = "DgvEquipos"
        DgvEquipos.ReadOnly = True
        DgvEquipos.RowTemplate.Height = 25
        DgvEquipos.Size = New Size(144, 443)
        DgvEquipos.TabIndex = 8
        ' 
        ' DgvJugadores
        ' 
        DgvJugadores.AllowUserToAddRows = False
        DgvJugadores.AllowUserToDeleteRows = False
        DgvJugadores.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvJugadores.Location = New Point(162, 67)
        DgvJugadores.Name = "DgvJugadores"
        DgvJugadores.ReadOnly = True
        DgvJugadores.RowTemplate.Height = 25
        DgvJugadores.Size = New Size(254, 443)
        DgvJugadores.TabIndex = 7
        ' 
        ' BtnCrearLista
        ' 
        BtnCrearLista.Location = New Point(684, 97)
        BtnCrearLista.Name = "BtnCrearLista"
        BtnCrearLista.Size = New Size(155, 23)
        BtnCrearLista.TabIndex = 14
        BtnCrearLista.Text = "Crear una Lista"
        BtnCrearLista.UseVisualStyleBackColor = True
        ' 
        ' DgvLista
        ' 
        DgvLista.AllowUserToAddRows = False
        DgvLista.AllowUserToDeleteRows = False
        DgvLista.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvLista.Location = New Point(422, 67)
        DgvLista.Name = "DgvLista"
        DgvLista.RowTemplate.Height = 25
        DgvLista.Size = New Size(256, 443)
        DgvLista.TabIndex = 15
        ' 
        ' TxtNombreLista
        ' 
        TxtNombreLista.Location = New Point(684, 68)
        TxtNombreLista.Name = "TxtNombreLista"
        TxtNombreLista.Size = New Size(155, 23)
        TxtNombreLista.TabIndex = 16
        ' 
        ' LblNombre
        ' 
        LblNombre.AutoSize = True
        LblNombre.Location = New Point(684, 50)
        LblNombre.Name = "LblNombre"
        LblNombre.Size = New Size(92, 15)
        LblNombre.TabIndex = 17
        LblNombre.Text = "Elija un Nombre"
        ' 
        ' FrmCrearLista
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(851, 551)
        Controls.Add(LblNombre)
        Controls.Add(TxtNombreLista)
        Controls.Add(DgvLista)
        Controls.Add(BtnCrearLista)
        Controls.Add(LblNombreLiga)
        Controls.Add(LblIdLiga)
        Controls.Add(lblIdequipo)
        Controls.Add(DgvEquipos)
        Controls.Add(DgvJugadores)
        Name = "FrmCrearLista"
        Text = "CrearLista"
        CType(DgvEquipos, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvJugadores, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvLista, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblNombreLiga As Label
    Friend WithEvents LblIdLiga As Label
    Friend WithEvents lblIdequipo As Label
    Friend WithEvents DgvEquipos As DataGridView
    Friend WithEvents DgvJugadores As DataGridView
    Friend WithEvents BtnCrearLista As Button
    Friend WithEvents DgvLista As DataGridView
    Friend WithEvents TxtNombreLista As TextBox
    Friend WithEvents LblNombre As Label
End Class
