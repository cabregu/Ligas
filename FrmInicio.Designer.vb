<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInicio
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
        BtnCargarPuntos = New Button()
        BtnReporte = New Button()
        BtnCrearJugadores = New Button()
        BtnConfiguracion = New Button()
        BtnCrearEquipo = New Button()
        GpbEquipos = New GroupBox()
        BtnCrearNuevoEquipo = New Button()
        TxtEquipoingresar = New TextBox()
        GpbJugadores = New GroupBox()
        Label1 = New Label()
        BtnTransferirAl = New Label()
        CmbEquipoAtransferir = New ComboBox()
        LblJugadorSeleccionado = New Label()
        LblIdJugadorSeleccionado = New Label()
        BtnTransferir = New Button()
        BtnEliminar = New Button()
        CmbEquipoSeleccionado = New ComboBox()
        DgvEditarJugadores = New DataGridView()
        BtnAñadir = New Button()
        CmbPosicionParaAgregar = New ComboBox()
        TxtJugadorParaAgregar = New TextBox()
        CmbEquipoParaAgregar = New ComboBox()
        BtnGuardarJugadores = New Button()
        DgvJugadores = New DataGridView()
        Equipo = New DataGridViewTextBoxColumn()
        Jugador = New DataGridViewTextBoxColumn()
        Pos = New DataGridViewTextBoxColumn()
        LblIdLiga = New Label()
        LblNombreLiga = New Label()
        GpbEquipos.SuspendLayout()
        GpbJugadores.SuspendLayout()
        CType(DgvEditarJugadores, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvJugadores, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnCargarPuntos
        ' 
        BtnCargarPuntos.BackColor = Color.SlateGray
        BtnCargarPuntos.FlatStyle = FlatStyle.Flat
        BtnCargarPuntos.Image = My.Resources.Resources.LongDate_32x32
        BtnCargarPuntos.Location = New Point(31, 87)
        BtnCargarPuntos.Name = "BtnCargarPuntos"
        BtnCargarPuntos.Size = New Size(63, 61)
        BtnCargarPuntos.TabIndex = 4
        BtnCargarPuntos.UseVisualStyleBackColor = False
        ' 
        ' BtnReporte
        ' 
        BtnReporte.BackColor = Color.SlateGray
        BtnReporte.FlatStyle = FlatStyle.Flat
        BtnReporte.Image = My.Resources.Resources.SendXLS_32x32
        BtnReporte.Location = New Point(386, 87)
        BtnReporte.Name = "BtnReporte"
        BtnReporte.Size = New Size(63, 61)
        BtnReporte.TabIndex = 5
        BtnReporte.UseVisualStyleBackColor = False
        ' 
        ' BtnCrearJugadores
        ' 
        BtnCrearJugadores.BackColor = Color.SlateGray
        BtnCrearJugadores.FlatStyle = FlatStyle.Flat
        BtnCrearJugadores.Image = My.Resources.Resources.Reviewers_32x32
        BtnCrearJugadores.Location = New Point(267, 87)
        BtnCrearJugadores.Name = "BtnCrearJugadores"
        BtnCrearJugadores.Size = New Size(63, 61)
        BtnCrearJugadores.TabIndex = 6
        BtnCrearJugadores.UseVisualStyleBackColor = False
        ' 
        ' BtnConfiguracion
        ' 
        BtnConfiguracion.BackColor = Color.SlateGray
        BtnConfiguracion.FlatStyle = FlatStyle.Flat
        BtnConfiguracion.Image = My.Resources.Resources.Properties_32x32
        BtnConfiguracion.Location = New Point(491, 87)
        BtnConfiguracion.Name = "BtnConfiguracion"
        BtnConfiguracion.Size = New Size(63, 61)
        BtnConfiguracion.TabIndex = 7
        BtnConfiguracion.UseVisualStyleBackColor = False
        ' 
        ' BtnCrearEquipo
        ' 
        BtnCrearEquipo.BackColor = Color.SlateGray
        BtnCrearEquipo.FlatStyle = FlatStyle.Flat
        BtnCrearEquipo.Image = My.Resources.Resources.IconSetFlags3_32x32
        BtnCrearEquipo.Location = New Point(145, 89)
        BtnCrearEquipo.Name = "BtnCrearEquipo"
        BtnCrearEquipo.Size = New Size(63, 61)
        BtnCrearEquipo.TabIndex = 8
        BtnCrearEquipo.UseVisualStyleBackColor = False
        ' 
        ' GpbEquipos
        ' 
        GpbEquipos.Controls.Add(BtnCrearNuevoEquipo)
        GpbEquipos.Controls.Add(TxtEquipoingresar)
        GpbEquipos.Enabled = False
        GpbEquipos.Location = New Point(670, 87)
        GpbEquipos.Name = "GpbEquipos"
        GpbEquipos.Size = New Size(197, 112)
        GpbEquipos.TabIndex = 9
        GpbEquipos.TabStop = False
        GpbEquipos.Text = "Equipos"
        ' 
        ' BtnCrearNuevoEquipo
        ' 
        BtnCrearNuevoEquipo.BackColor = Color.SlateGray
        BtnCrearNuevoEquipo.FlatStyle = FlatStyle.Flat
        BtnCrearNuevoEquipo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnCrearNuevoEquipo.ForeColor = Color.MidnightBlue
        BtnCrearNuevoEquipo.Location = New Point(102, 83)
        BtnCrearNuevoEquipo.Name = "BtnCrearNuevoEquipo"
        BtnCrearNuevoEquipo.Size = New Size(89, 23)
        BtnCrearNuevoEquipo.TabIndex = 16
        BtnCrearNuevoEquipo.Text = "Crear"
        BtnCrearNuevoEquipo.UseVisualStyleBackColor = False
        ' 
        ' TxtEquipoingresar
        ' 
        TxtEquipoingresar.Location = New Point(6, 54)
        TxtEquipoingresar.Name = "TxtEquipoingresar"
        TxtEquipoingresar.Size = New Size(185, 23)
        TxtEquipoingresar.TabIndex = 0
        ' 
        ' GpbJugadores
        ' 
        GpbJugadores.Controls.Add(Label1)
        GpbJugadores.Controls.Add(BtnTransferirAl)
        GpbJugadores.Controls.Add(CmbEquipoAtransferir)
        GpbJugadores.Controls.Add(LblJugadorSeleccionado)
        GpbJugadores.Controls.Add(LblIdJugadorSeleccionado)
        GpbJugadores.Controls.Add(BtnTransferir)
        GpbJugadores.Controls.Add(BtnEliminar)
        GpbJugadores.Controls.Add(CmbEquipoSeleccionado)
        GpbJugadores.Controls.Add(DgvEditarJugadores)
        GpbJugadores.Controls.Add(BtnAñadir)
        GpbJugadores.Controls.Add(CmbPosicionParaAgregar)
        GpbJugadores.Controls.Add(TxtJugadorParaAgregar)
        GpbJugadores.Controls.Add(CmbEquipoParaAgregar)
        GpbJugadores.Controls.Add(BtnGuardarJugadores)
        GpbJugadores.Controls.Add(DgvJugadores)
        GpbJugadores.Enabled = False
        GpbJugadores.Location = New Point(25, 221)
        GpbJugadores.Name = "GpbJugadores"
        GpbJugadores.Size = New Size(842, 386)
        GpbJugadores.TabIndex = 10
        GpbJugadores.TabStop = False
        GpbJugadores.Text = "Jugadores"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.Indigo
        Label1.Location = New Point(748, 275)
        Label1.Name = "Label1"
        Label1.Size = New Size(20, 25)
        Label1.TabIndex = 29
        Label1.Text = "o"
        ' 
        ' BtnTransferirAl
        ' 
        BtnTransferirAl.AutoSize = True
        BtnTransferirAl.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnTransferirAl.ForeColor = Color.Indigo
        BtnTransferirAl.Location = New Point(702, 125)
        BtnTransferirAl.Name = "BtnTransferirAl"
        BtnTransferirAl.Size = New Size(100, 25)
        BtnTransferirAl.TabIndex = 28
        BtnTransferirAl.Text = "Transferir Al"
        ' 
        ' CmbEquipoAtransferir
        ' 
        CmbEquipoAtransferir.FormattingEnabled = True
        CmbEquipoAtransferir.Location = New Point(694, 172)
        CmbEquipoAtransferir.Name = "CmbEquipoAtransferir"
        CmbEquipoAtransferir.Size = New Size(136, 23)
        CmbEquipoAtransferir.TabIndex = 27
        ' 
        ' LblJugadorSeleccionado
        ' 
        LblJugadorSeleccionado.AutoSize = True
        LblJugadorSeleccionado.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblJugadorSeleccionado.ForeColor = Color.Indigo
        LblJugadorSeleccionado.Location = New Point(700, 79)
        LblJugadorSeleccionado.Name = "LblJugadorSeleccionado"
        LblJugadorSeleccionado.Size = New Size(68, 25)
        LblJugadorSeleccionado.TabIndex = 26
        LblJugadorSeleccionado.Text = "Jugador"
        ' 
        ' LblIdJugadorSeleccionado
        ' 
        LblIdJugadorSeleccionado.AutoSize = True
        LblIdJugadorSeleccionado.Location = New Point(700, 41)
        LblIdJugadorSeleccionado.Name = "LblIdJugadorSeleccionado"
        LblIdJugadorSeleccionado.Size = New Size(13, 15)
        LblIdJugadorSeleccionado.TabIndex = 25
        LblIdJugadorSeleccionado.Text = "0"
        LblIdJugadorSeleccionado.Visible = False
        ' 
        ' BtnTransferir
        ' 
        BtnTransferir.BackColor = Color.SlateGray
        BtnTransferir.FlatStyle = FlatStyle.Flat
        BtnTransferir.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnTransferir.ForeColor = Color.MidnightBlue
        BtnTransferir.Location = New Point(694, 214)
        BtnTransferir.Name = "BtnTransferir"
        BtnTransferir.Size = New Size(136, 47)
        BtnTransferir.TabIndex = 24
        BtnTransferir.Text = "Concretar transferencia"
        BtnTransferir.UseVisualStyleBackColor = False
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.BackColor = Color.SlateGray
        BtnEliminar.FlatStyle = FlatStyle.Flat
        BtnEliminar.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnEliminar.ForeColor = Color.MidnightBlue
        BtnEliminar.Location = New Point(694, 324)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(136, 48)
        BtnEliminar.TabIndex = 23
        BtnEliminar.Text = "Eliminar"
        BtnEliminar.UseVisualStyleBackColor = False
        ' 
        ' CmbEquipoSeleccionado
        ' 
        CmbEquipoSeleccionado.FormattingEnabled = True
        CmbEquipoSeleccionado.Location = New Point(444, 85)
        CmbEquipoSeleccionado.Name = "CmbEquipoSeleccionado"
        CmbEquipoSeleccionado.Size = New Size(191, 23)
        CmbEquipoSeleccionado.TabIndex = 22
        ' 
        ' DgvEditarJugadores
        ' 
        DgvEditarJugadores.AllowUserToAddRows = False
        DgvEditarJugadores.AllowUserToDeleteRows = False
        DgvEditarJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvEditarJugadores.Location = New Point(444, 118)
        DgvEditarJugadores.Name = "DgvEditarJugadores"
        DgvEditarJugadores.ReadOnly = True
        DgvEditarJugadores.RowTemplate.Height = 25
        DgvEditarJugadores.Size = New Size(247, 253)
        DgvEditarJugadores.TabIndex = 21
        ' 
        ' BtnAñadir
        ' 
        BtnAñadir.BackColor = Color.SlateGray
        BtnAñadir.FlatStyle = FlatStyle.Flat
        BtnAñadir.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnAñadir.ForeColor = Color.MidnightBlue
        BtnAñadir.Location = New Point(6, 118)
        BtnAñadir.Name = "BtnAñadir"
        BtnAñadir.Size = New Size(60, 23)
        BtnAñadir.TabIndex = 11
        BtnAñadir.Text = "Añadir"
        BtnAñadir.UseVisualStyleBackColor = False
        ' 
        ' CmbPosicionParaAgregar
        ' 
        CmbPosicionParaAgregar.FormattingEnabled = True
        CmbPosicionParaAgregar.Items.AddRange(New Object() {"Por", "Def", "Med", "Del"})
        CmbPosicionParaAgregar.Location = New Point(223, 89)
        CmbPosicionParaAgregar.Name = "CmbPosicionParaAgregar"
        CmbPosicionParaAgregar.Size = New Size(93, 23)
        CmbPosicionParaAgregar.TabIndex = 15
        ' 
        ' TxtJugadorParaAgregar
        ' 
        TxtJugadorParaAgregar.Location = New Point(6, 89)
        TxtJugadorParaAgregar.Name = "TxtJugadorParaAgregar"
        TxtJugadorParaAgregar.Size = New Size(211, 23)
        TxtJugadorParaAgregar.TabIndex = 14
        ' 
        ' CmbEquipoParaAgregar
        ' 
        CmbEquipoParaAgregar.FormattingEnabled = True
        CmbEquipoParaAgregar.Location = New Point(6, 41)
        CmbEquipoParaAgregar.Name = "CmbEquipoParaAgregar"
        CmbEquipoParaAgregar.Size = New Size(168, 23)
        CmbEquipoParaAgregar.TabIndex = 14
        ' 
        ' BtnGuardarJugadores
        ' 
        BtnGuardarJugadores.BackColor = Color.SlateGray
        BtnGuardarJugadores.FlatStyle = FlatStyle.Flat
        BtnGuardarJugadores.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point)
        BtnGuardarJugadores.ForeColor = Color.MidnightBlue
        BtnGuardarJugadores.Location = New Point(361, 323)
        BtnGuardarJugadores.Name = "BtnGuardarJugadores"
        BtnGuardarJugadores.Size = New Size(77, 48)
        BtnGuardarJugadores.TabIndex = 14
        BtnGuardarJugadores.Text = "Guardar Datos"
        BtnGuardarJugadores.UseVisualStyleBackColor = False
        ' 
        ' DgvJugadores
        ' 
        DgvJugadores.AllowUserToAddRows = False
        DgvJugadores.AllowUserToDeleteRows = False
        DgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvJugadores.Columns.AddRange(New DataGridViewColumn() {Equipo, Jugador, Pos})
        DgvJugadores.Location = New Point(6, 147)
        DgvJugadores.Name = "DgvJugadores"
        DgvJugadores.ReadOnly = True
        DgvJugadores.RowTemplate.Height = 25
        DgvJugadores.Size = New Size(349, 224)
        DgvJugadores.TabIndex = 0
        ' 
        ' Equipo
        ' 
        Equipo.HeaderText = "Equipo"
        Equipo.Name = "Equipo"
        Equipo.ReadOnly = True
        ' 
        ' Jugador
        ' 
        Jugador.HeaderText = "Jugador"
        Jugador.Name = "Jugador"
        Jugador.ReadOnly = True
        ' 
        ' Pos
        ' 
        Pos.HeaderText = "Pos"
        Pos.Name = "Pos"
        Pos.ReadOnly = True
        ' 
        ' LblIdLiga
        ' 
        LblIdLiga.AutoSize = True
        LblIdLiga.Location = New Point(19, 9)
        LblIdLiga.Name = "LblIdLiga"
        LblIdLiga.Size = New Size(13, 15)
        LblIdLiga.TabIndex = 11
        LblIdLiga.Text = "0"
        LblIdLiga.Visible = False
        ' 
        ' LblNombreLiga
        ' 
        LblNombreLiga.AutoSize = True
        LblNombreLiga.Font = New Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreLiga.ForeColor = Color.DarkRed
        LblNombreLiga.Location = New Point(289, 18)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(250, 45)
        LblNombreLiga.TabIndex = 12
        LblNombreLiga.Text = "Nombre de Liga"
        ' 
        ' FrmInicio
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SlateGray
        ClientSize = New Size(879, 619)
        Controls.Add(LblNombreLiga)
        Controls.Add(LblIdLiga)
        Controls.Add(GpbJugadores)
        Controls.Add(GpbEquipos)
        Controls.Add(BtnCrearEquipo)
        Controls.Add(BtnConfiguracion)
        Controls.Add(BtnCrearJugadores)
        Controls.Add(BtnReporte)
        Controls.Add(BtnCargarPuntos)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "FrmInicio"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inicio"
        GpbEquipos.ResumeLayout(False)
        GpbEquipos.PerformLayout()
        GpbJugadores.ResumeLayout(False)
        GpbJugadores.PerformLayout()
        CType(DgvEditarJugadores, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvJugadores, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnCargarPuntos As Button
    Friend WithEvents BtnReporte As Button
    Friend WithEvents BtnCrearJugadores As Button
    Friend WithEvents BtnConfiguracion As Button
    Friend WithEvents BtnCrearEquipo As Button
    Friend WithEvents GpbEquipos As GroupBox
    Friend WithEvents GpbJugadores As GroupBox
    Friend WithEvents TxtEquipoingresar As TextBox
    Friend WithEvents DgvJugadores As DataGridView
    Friend WithEvents CmbEquipoParaAgregar As ComboBox
    Friend WithEvents BtnGuardarJugadores As Button
    Friend WithEvents BtnAñadir As Button
    Friend WithEvents CmbPosicionParaAgregar As ComboBox
    Friend WithEvents TxtJugadorParaAgregar As TextBox
    Friend WithEvents BtnCrearNuevoEquipo As Button
    Friend WithEvents LblIdLiga As Label
    Friend WithEvents LblNombreLiga As Label
    Friend WithEvents Equipo As DataGridViewTextBoxColumn
    Friend WithEvents Jugador As DataGridViewTextBoxColumn
    Friend WithEvents Pos As DataGridViewTextBoxColumn
    Friend WithEvents BtnTransferir As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents CmbEquipoSeleccionado As ComboBox
    Friend WithEvents DgvEditarJugadores As DataGridView
    Friend WithEvents LblJugadorSeleccionado As Label
    Friend WithEvents LblIdJugadorSeleccionado As Label
    Friend WithEvents CmbEquipoAtransferir As ComboBox
    Friend WithEvents BtnTransferirAl As Label
    Friend WithEvents Label1 As Label
End Class
