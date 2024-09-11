<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLigaPpal
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
        Label2 = New Label()
        BtnCrearNuevoEquipo = New Button()
        TxtEquipoingresar = New TextBox()
        GpbJugadores = New GroupBox()
        CmbPosicion = New ComboBox()
        BtnBorrarJugadorDeLigaCreada = New Button()
        LblNombreJugadorSubliga = New Label()
        LblIdJugadorSubliga = New Label()
        LblPosicion = New Label()
        BtnAgregarASubliga = New Button()
        ChkActivarSubliga = New CheckBox()
        LblSeleccionesubliga = New Label()
        CmbSubliga = New ComboBox()
        BtnEliminarSubliga = New Button()
        BtnCrearSubliga = New Button()
        DgvSubliga = New DataGridView()
        IdJugador = New DataGridViewTextBoxColumn()
        NombreJugador = New DataGridViewTextBoxColumn()
        PosicionJugador = New DataGridViewTextBoxColumn()
        LblNombresubliga = New Label()
        TxtNommbresubliga = New TextBox()
        TxtNuevoNombre = New TextBox()
        BtnModificar = New Button()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        LblO = New Label()
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
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        LblSubliga = New Label()
        BtnSubliga = New Button()
        GpbEquipos.SuspendLayout()
        GpbJugadores.SuspendLayout()
        CType(DgvSubliga, ComponentModel.ISupportInitialize).BeginInit()
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
        BtnReporte.Location = New Point(311, 87)
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
        BtnCrearJugadores.Location = New Point(220, 87)
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
        BtnCrearEquipo.Location = New Point(121, 89)
        BtnCrearEquipo.Name = "BtnCrearEquipo"
        BtnCrearEquipo.Size = New Size(63, 61)
        BtnCrearEquipo.TabIndex = 8
        BtnCrearEquipo.UseVisualStyleBackColor = False
        ' 
        ' GpbEquipos
        ' 
        GpbEquipos.BackColor = Color.Teal
        GpbEquipos.Controls.Add(Label2)
        GpbEquipos.Controls.Add(BtnCrearNuevoEquipo)
        GpbEquipos.Controls.Add(TxtEquipoingresar)
        GpbEquipos.Enabled = False
        GpbEquipos.Location = New Point(670, 87)
        GpbEquipos.Name = "GpbEquipos"
        GpbEquipos.Size = New Size(287, 112)
        GpbEquipos.TabIndex = 9
        GpbEquipos.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.Indigo
        Label2.Location = New Point(9, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(147, 25)
        Label2.TabIndex = 13
        Label2.Text = "Crear Nuevo Equipo"
        ' 
        ' BtnCrearNuevoEquipo
        ' 
        BtnCrearNuevoEquipo.BackColor = Color.SlateGray
        BtnCrearNuevoEquipo.FlatStyle = FlatStyle.Flat
        BtnCrearNuevoEquipo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnCrearNuevoEquipo.ForeColor = Color.MidnightBlue
        BtnCrearNuevoEquipo.Location = New Point(175, 83)
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
        TxtEquipoingresar.Size = New Size(258, 23)
        TxtEquipoingresar.TabIndex = 0
        ' 
        ' GpbJugadores
        ' 
        GpbJugadores.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GpbJugadores.BackColor = Color.Teal
        GpbJugadores.Controls.Add(CmbPosicion)
        GpbJugadores.Controls.Add(BtnBorrarJugadorDeLigaCreada)
        GpbJugadores.Controls.Add(LblNombreJugadorSubliga)
        GpbJugadores.Controls.Add(LblIdJugadorSubliga)
        GpbJugadores.Controls.Add(LblPosicion)
        GpbJugadores.Controls.Add(BtnAgregarASubliga)
        GpbJugadores.Controls.Add(ChkActivarSubliga)
        GpbJugadores.Controls.Add(LblSeleccionesubliga)
        GpbJugadores.Controls.Add(CmbSubliga)
        GpbJugadores.Controls.Add(BtnEliminarSubliga)
        GpbJugadores.Controls.Add(BtnCrearSubliga)
        GpbJugadores.Controls.Add(DgvSubliga)
        GpbJugadores.Controls.Add(LblNombresubliga)
        GpbJugadores.Controls.Add(TxtNommbresubliga)
        GpbJugadores.Controls.Add(TxtNuevoNombre)
        GpbJugadores.Controls.Add(BtnModificar)
        GpbJugadores.Controls.Add(Label6)
        GpbJugadores.Controls.Add(Label5)
        GpbJugadores.Controls.Add(Label4)
        GpbJugadores.Controls.Add(Label3)
        GpbJugadores.Controls.Add(LblO)
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
        GpbJugadores.Location = New Point(25, 205)
        GpbJugadores.Name = "GpbJugadores"
        GpbJugadores.Size = New Size(1198, 488)
        GpbJugadores.TabIndex = 10
        GpbJugadores.TabStop = False
        ' 
        ' CmbPosicion
        ' 
        CmbPosicion.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        CmbPosicion.FormattingEnabled = True
        CmbPosicion.Items.AddRange(New Object() {"Por", "Def", "Med", "Del"})
        CmbPosicion.Location = New Point(667, 392)
        CmbPosicion.Name = "CmbPosicion"
        CmbPosicion.Size = New Size(138, 23)
        CmbPosicion.TabIndex = 51
        ' 
        ' BtnBorrarJugadorDeLigaCreada
        ' 
        BtnBorrarJugadorDeLigaCreada.BackColor = Color.SlateGray
        BtnBorrarJugadorDeLigaCreada.Enabled = False
        BtnBorrarJugadorDeLigaCreada.FlatStyle = FlatStyle.Flat
        BtnBorrarJugadorDeLigaCreada.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnBorrarJugadorDeLigaCreada.ForeColor = Color.Indigo
        BtnBorrarJugadorDeLigaCreada.Location = New Point(1076, 200)
        BtnBorrarJugadorDeLigaCreada.Name = "BtnBorrarJugadorDeLigaCreada"
        BtnBorrarJugadorDeLigaCreada.Size = New Size(108, 35)
        BtnBorrarJugadorDeLigaCreada.TabIndex = 50
        BtnBorrarJugadorDeLigaCreada.Text = "Borrar"
        BtnBorrarJugadorDeLigaCreada.UseVisualStyleBackColor = False
        ' 
        ' LblNombreJugadorSubliga
        ' 
        LblNombreJugadorSubliga.AutoSize = True
        LblNombreJugadorSubliga.Enabled = False
        LblNombreJugadorSubliga.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblNombreJugadorSubliga.ForeColor = Color.Indigo
        LblNombreJugadorSubliga.Location = New Point(1076, 123)
        LblNombreJugadorSubliga.Name = "LblNombreJugadorSubliga"
        LblNombreJugadorSubliga.Size = New Size(68, 25)
        LblNombreJugadorSubliga.TabIndex = 48
        LblNombreJugadorSubliga.Text = "Jugador"
        ' 
        ' LblIdJugadorSubliga
        ' 
        LblIdJugadorSubliga.AutoSize = True
        LblIdJugadorSubliga.Location = New Point(1076, 108)
        LblIdJugadorSubliga.Name = "LblIdJugadorSubliga"
        LblIdJugadorSubliga.Size = New Size(13, 15)
        LblIdJugadorSubliga.TabIndex = 47
        LblIdJugadorSubliga.Text = "0"
        LblIdJugadorSubliga.Visible = False
        ' 
        ' LblPosicion
        ' 
        LblPosicion.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        LblPosicion.AutoSize = True
        LblPosicion.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblPosicion.ForeColor = Color.Indigo
        LblPosicion.Location = New Point(675, 79)
        LblPosicion.Name = "LblPosicion"
        LblPosicion.Size = New Size(0, 25)
        LblPosicion.TabIndex = 46
        ' 
        ' BtnAgregarASubliga
        ' 
        BtnAgregarASubliga.BackColor = Color.SlateGray
        BtnAgregarASubliga.FlatStyle = FlatStyle.Flat
        BtnAgregarASubliga.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnAgregarASubliga.ForeColor = Color.Indigo
        BtnAgregarASubliga.Location = New Point(667, 107)
        BtnAgregarASubliga.Name = "BtnAgregarASubliga"
        BtnAgregarASubliga.Size = New Size(135, 35)
        BtnAgregarASubliga.TabIndex = 45
        BtnAgregarASubliga.Text = "Agregar a Subliga"
        BtnAgregarASubliga.UseVisualStyleBackColor = False
        BtnAgregarASubliga.Visible = False
        ' 
        ' ChkActivarSubliga
        ' 
        ChkActivarSubliga.AutoSize = True
        ChkActivarSubliga.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        ChkActivarSubliga.ForeColor = Color.Indigo
        ChkActivarSubliga.Location = New Point(754, 22)
        ChkActivarSubliga.Name = "ChkActivarSubliga"
        ChkActivarSubliga.Size = New Size(87, 25)
        ChkActivarSubliga.TabIndex = 42
        ChkActivarSubliga.Text = "Subliga"
        ChkActivarSubliga.UseVisualStyleBackColor = True
        ' 
        ' LblSeleccionesubliga
        ' 
        LblSeleccionesubliga.AutoSize = True
        LblSeleccionesubliga.Enabled = False
        LblSeleccionesubliga.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblSeleccionesubliga.ForeColor = Color.Indigo
        LblSeleccionesubliga.Location = New Point(847, 13)
        LblSeleccionesubliga.Name = "LblSeleccionesubliga"
        LblSeleccionesubliga.Size = New Size(189, 25)
        LblSeleccionesubliga.TabIndex = 41
        LblSeleccionesubliga.Text = "Seleccione Subliga Editar"
        ' 
        ' CmbSubliga
        ' 
        CmbSubliga.DropDownStyle = ComboBoxStyle.DropDownList
        CmbSubliga.Enabled = False
        CmbSubliga.FormattingEnabled = True
        CmbSubliga.Location = New Point(847, 41)
        CmbSubliga.Name = "CmbSubliga"
        CmbSubliga.Size = New Size(181, 23)
        CmbSubliga.TabIndex = 40
        ' 
        ' BtnEliminarSubliga
        ' 
        BtnEliminarSubliga.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnEliminarSubliga.BackColor = Color.SlateGray
        BtnEliminarSubliga.Enabled = False
        BtnEliminarSubliga.FlatStyle = FlatStyle.Flat
        BtnEliminarSubliga.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnEliminarSubliga.ForeColor = Color.Indigo
        BtnEliminarSubliga.Location = New Point(1076, 429)
        BtnEliminarSubliga.Name = "BtnEliminarSubliga"
        BtnEliminarSubliga.Size = New Size(108, 48)
        BtnEliminarSubliga.TabIndex = 39
        BtnEliminarSubliga.Text = "Eliminar Subliga"
        BtnEliminarSubliga.UseVisualStyleBackColor = False
        ' 
        ' BtnCrearSubliga
        ' 
        BtnCrearSubliga.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnCrearSubliga.BackColor = Color.SlateGray
        BtnCrearSubliga.Enabled = False
        BtnCrearSubliga.FlatStyle = FlatStyle.Flat
        BtnCrearSubliga.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnCrearSubliga.ForeColor = Color.Indigo
        BtnCrearSubliga.Location = New Point(1076, 363)
        BtnCrearSubliga.Name = "BtnCrearSubliga"
        BtnCrearSubliga.Size = New Size(108, 48)
        BtnCrearSubliga.TabIndex = 38
        BtnCrearSubliga.Text = "Confirmar Subliga"
        BtnCrearSubliga.UseVisualStyleBackColor = False
        ' 
        ' DgvSubliga
        ' 
        DgvSubliga.AllowUserToAddRows = False
        DgvSubliga.AllowUserToDeleteRows = False
        DgvSubliga.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DgvSubliga.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvSubliga.Columns.AddRange(New DataGridViewColumn() {IdJugador, NombreJugador, PosicionJugador})
        DgvSubliga.Enabled = False
        DgvSubliga.Location = New Point(847, 118)
        DgvSubliga.Name = "DgvSubliga"
        DgvSubliga.ReadOnly = True
        DgvSubliga.RowHeadersVisible = False
        DgvSubliga.RowTemplate.Height = 25
        DgvSubliga.Size = New Size(214, 364)
        DgvSubliga.TabIndex = 37
        ' 
        ' IdJugador
        ' 
        IdJugador.HeaderText = "IdJugador"
        IdJugador.Name = "IdJugador"
        IdJugador.ReadOnly = True
        IdJugador.Visible = False
        ' 
        ' NombreJugador
        ' 
        NombreJugador.HeaderText = "Nombre"
        NombreJugador.Name = "NombreJugador"
        NombreJugador.ReadOnly = True
        ' 
        ' PosicionJugador
        ' 
        PosicionJugador.HeaderText = "posicion"
        PosicionJugador.Name = "PosicionJugador"
        PosicionJugador.ReadOnly = True
        PosicionJugador.Width = 70
        ' 
        ' LblNombresubliga
        ' 
        LblNombresubliga.AutoSize = True
        LblNombresubliga.Enabled = False
        LblNombresubliga.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblNombresubliga.ForeColor = Color.Indigo
        LblNombresubliga.Location = New Point(847, 67)
        LblNombresubliga.Name = "LblNombresubliga"
        LblNombresubliga.Size = New Size(165, 25)
        LblNombresubliga.TabIndex = 36
        LblNombresubliga.Text = "Nombre Subliga Crear"
        ' 
        ' TxtNommbresubliga
        ' 
        TxtNommbresubliga.Enabled = False
        TxtNommbresubliga.Location = New Point(847, 92)
        TxtNommbresubliga.Name = "TxtNommbresubliga"
        TxtNommbresubliga.Size = New Size(181, 23)
        TxtNommbresubliga.TabIndex = 35
        ' 
        ' TxtNuevoNombre
        ' 
        TxtNuevoNombre.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        TxtNuevoNombre.Location = New Point(667, 363)
        TxtNuevoNombre.Name = "TxtNuevoNombre"
        TxtNuevoNombre.Size = New Size(136, 23)
        TxtNuevoNombre.TabIndex = 17
        ' 
        ' BtnModificar
        ' 
        BtnModificar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnModificar.BackColor = Color.SlateGray
        BtnModificar.FlatStyle = FlatStyle.Flat
        BtnModificar.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnModificar.ForeColor = Color.Indigo
        BtnModificar.Location = New Point(667, 421)
        BtnModificar.Name = "BtnModificar"
        BtnModificar.Size = New Size(108, 60)
        BtnModificar.TabIndex = 34
        BtnModificar.Text = "Modificar Jugador"
        BtnModificar.UseVisualStyleBackColor = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.ForeColor = Color.Indigo
        Label6.Location = New Point(444, 57)
        Label6.Name = "Label6"
        Label6.Size = New Size(163, 25)
        Label6.TabIndex = 33
        Label6.Text = "Equipo Para Modificar"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = Color.Indigo
        Label5.Location = New Point(223, 61)
        Label5.Name = "Label5"
        Label5.Size = New Size(69, 25)
        Label5.TabIndex = 32
        Label5.Text = "Posicion"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.Indigo
        Label4.Location = New Point(6, 64)
        Label4.Name = "Label4"
        Label4.Size = New Size(114, 25)
        Label4.TabIndex = 31
        Label4.Text = "Nuevo Jugador"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.Indigo
        Label3.Location = New Point(6, 13)
        Label3.Name = "Label3"
        Label3.Size = New Size(204, 25)
        Label3.TabIndex = 30
        Label3.Text = "Equipo Para Añadir Jugador"
        ' 
        ' LblO
        ' 
        LblO.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        LblO.AutoSize = True
        LblO.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblO.ForeColor = Color.Indigo
        LblO.Location = New Point(706, 255)
        LblO.Name = "LblO"
        LblO.Size = New Size(20, 25)
        LblO.TabIndex = 29
        LblO.Text = "o"
        ' 
        ' BtnTransferirAl
        ' 
        BtnTransferirAl.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        BtnTransferirAl.AutoSize = True
        BtnTransferirAl.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnTransferirAl.ForeColor = Color.Indigo
        BtnTransferirAl.Location = New Point(675, 143)
        BtnTransferirAl.Name = "BtnTransferirAl"
        BtnTransferirAl.Size = New Size(100, 25)
        BtnTransferirAl.TabIndex = 28
        BtnTransferirAl.Text = "Transferir Al"
        ' 
        ' CmbEquipoAtransferir
        ' 
        CmbEquipoAtransferir.FormattingEnabled = True
        CmbEquipoAtransferir.Location = New Point(667, 172)
        CmbEquipoAtransferir.Name = "CmbEquipoAtransferir"
        CmbEquipoAtransferir.Size = New Size(136, 23)
        CmbEquipoAtransferir.TabIndex = 27
        ' 
        ' LblJugadorSeleccionado
        ' 
        LblJugadorSeleccionado.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        LblJugadorSeleccionado.AutoSize = True
        LblJugadorSeleccionado.Font = New Font("Bahnschrift Condensed", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblJugadorSeleccionado.ForeColor = Color.Indigo
        LblJugadorSeleccionado.Location = New Point(673, 56)
        LblJugadorSeleccionado.Name = "LblJugadorSeleccionado"
        LblJugadorSeleccionado.Size = New Size(68, 25)
        LblJugadorSeleccionado.TabIndex = 26
        LblJugadorSeleccionado.Text = "Jugador"
        ' 
        ' LblIdJugadorSeleccionado
        ' 
        LblIdJugadorSeleccionado.AutoSize = True
        LblIdJugadorSeleccionado.Location = New Point(673, 41)
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
        BtnTransferir.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnTransferir.ForeColor = Color.Indigo
        BtnTransferir.Location = New Point(667, 201)
        BtnTransferir.Name = "BtnTransferir"
        BtnTransferir.Size = New Size(108, 51)
        BtnTransferir.TabIndex = 24
        BtnTransferir.Text = "Concretar transferencia"
        BtnTransferir.UseVisualStyleBackColor = False
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.BackColor = Color.SlateGray
        BtnEliminar.FlatStyle = FlatStyle.Flat
        BtnEliminar.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnEliminar.ForeColor = Color.Indigo
        BtnEliminar.Location = New Point(667, 283)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(108, 40)
        BtnEliminar.TabIndex = 23
        BtnEliminar.Text = "Eliminar"
        BtnEliminar.UseVisualStyleBackColor = False
        ' 
        ' CmbEquipoSeleccionado
        ' 
        CmbEquipoSeleccionado.FormattingEnabled = True
        CmbEquipoSeleccionado.Location = New Point(444, 85)
        CmbEquipoSeleccionado.Name = "CmbEquipoSeleccionado"
        CmbEquipoSeleccionado.Size = New Size(138, 23)
        CmbEquipoSeleccionado.TabIndex = 22
        ' 
        ' DgvEditarJugadores
        ' 
        DgvEditarJugadores.AllowUserToAddRows = False
        DgvEditarJugadores.AllowUserToDeleteRows = False
        DgvEditarJugadores.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DgvEditarJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvEditarJugadores.Location = New Point(444, 118)
        DgvEditarJugadores.Name = "DgvEditarJugadores"
        DgvEditarJugadores.ReadOnly = True
        DgvEditarJugadores.RowTemplate.Height = 25
        DgvEditarJugadores.Size = New Size(217, 364)
        DgvEditarJugadores.TabIndex = 21
        ' 
        ' BtnAñadir
        ' 
        BtnAñadir.BackColor = Color.SlateGray
        BtnAñadir.FlatStyle = FlatStyle.Flat
        BtnAñadir.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnAñadir.ForeColor = Color.Indigo
        BtnAñadir.Location = New Point(6, 118)
        BtnAñadir.Name = "BtnAñadir"
        BtnAñadir.Size = New Size(301, 35)
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
        CmbEquipoParaAgregar.Size = New Size(153, 23)
        CmbEquipoParaAgregar.TabIndex = 14
        ' 
        ' BtnGuardarJugadores
        ' 
        BtnGuardarJugadores.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        BtnGuardarJugadores.BackColor = Color.SlateGray
        BtnGuardarJugadores.FlatStyle = FlatStyle.Flat
        BtnGuardarJugadores.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnGuardarJugadores.ForeColor = Color.Indigo
        BtnGuardarJugadores.Location = New Point(322, 421)
        BtnGuardarJugadores.Name = "BtnGuardarJugadores"
        BtnGuardarJugadores.Size = New Size(107, 60)
        BtnGuardarJugadores.TabIndex = 14
        BtnGuardarJugadores.Text = "Guardar Datos"
        BtnGuardarJugadores.UseVisualStyleBackColor = False
        ' 
        ' DgvJugadores
        ' 
        DgvJugadores.AllowUserToAddRows = False
        DgvJugadores.AllowUserToDeleteRows = False
        DgvJugadores.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvJugadores.Columns.AddRange(New DataGridViewColumn() {Equipo, Jugador, Pos})
        DgvJugadores.Location = New Point(6, 159)
        DgvJugadores.Name = "DgvJugadores"
        DgvJugadores.ReadOnly = True
        DgvJugadores.RowHeadersVisible = False
        DgvJugadores.RowTemplate.Height = 25
        DgvJugadores.Size = New Size(310, 323)
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
        LblNombreLiga.Location = New Point(304, 9)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(250, 45)
        LblNombreLiga.TabIndex = 12
        LblNombreLiga.Text = "Nombre de Liga"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.ForeColor = Color.Indigo
        Label7.Location = New Point(19, 151)
        Label7.Name = "Label7"
        Label7.Size = New Size(84, 15)
        Label7.TabIndex = 13
        Label7.Text = "Cargar Puntos"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.ForeColor = Color.Indigo
        Label8.Location = New Point(112, 151)
        Label8.Name = "Label8"
        Label8.Size = New Size(77, 15)
        Label8.TabIndex = 14
        Label8.Text = "Crear Equipo"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label9.ForeColor = Color.Indigo
        Label9.Location = New Point(202, 154)
        Label9.Name = "Label9"
        Label9.Size = New Size(92, 15)
        Label9.TabIndex = 15
        Label9.Text = "Area Jugadores"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label10.ForeColor = Color.Indigo
        Label10.Location = New Point(311, 153)
        Label10.Name = "Label10"
        Label10.Size = New Size(58, 15)
        Label10.TabIndex = 16
        Label10.Text = "Reportes"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label11.ForeColor = Color.Indigo
        Label11.Location = New Point(482, 152)
        Label11.Name = "Label11"
        Label11.Size = New Size(84, 15)
        Label11.TabIndex = 17
        Label11.Text = "Configuracion"
        ' 
        ' LblSubliga
        ' 
        LblSubliga.AutoSize = True
        LblSubliga.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        LblSubliga.ForeColor = Color.Indigo
        LblSubliga.Location = New Point(408, 151)
        LblSubliga.Name = "LblSubliga"
        LblSubliga.Size = New Size(50, 15)
        LblSubliga.TabIndex = 19
        LblSubliga.Text = "Sub liga"
        ' 
        ' BtnSubliga
        ' 
        BtnSubliga.BackColor = Color.SlateGray
        BtnSubliga.FlatStyle = FlatStyle.Flat
        BtnSubliga.Image = My.Resources.Resources.AddNewDataSource_32x32
        BtnSubliga.Location = New Point(400, 87)
        BtnSubliga.Name = "BtnSubliga"
        BtnSubliga.Size = New Size(63, 61)
        BtnSubliga.TabIndex = 18
        BtnSubliga.UseVisualStyleBackColor = False
        ' 
        ' FrmLigaPpal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(1235, 705)
        Controls.Add(LblSubliga)
        Controls.Add(BtnSubliga)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(LblNombreLiga)
        Controls.Add(LblIdLiga)
        Controls.Add(GpbJugadores)
        Controls.Add(GpbEquipos)
        Controls.Add(BtnCrearEquipo)
        Controls.Add(BtnConfiguracion)
        Controls.Add(BtnCrearJugadores)
        Controls.Add(BtnReporte)
        Controls.Add(BtnCargarPuntos)
        Name = "FrmLigaPpal"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inicio"
        WindowState = FormWindowState.Maximized
        GpbEquipos.ResumeLayout(False)
        GpbEquipos.PerformLayout()
        GpbJugadores.ResumeLayout(False)
        GpbJugadores.PerformLayout()
        CType(DgvSubliga, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LblO As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnModificar As Button
    Friend WithEvents TxtNuevoNombre As TextBox
    Friend WithEvents LblSubliga As Label
    Friend WithEvents BtnSubliga As Button
    Friend WithEvents BtnCrearSubliga As Button
    Friend WithEvents DgvSubliga As DataGridView
    Friend WithEvents LblNombresubliga As Label
    Friend WithEvents TxtNommbresubliga As TextBox
    Friend WithEvents BtnEliminarSubliga As Button
    Friend WithEvents LblSeleccionesubliga As Label
    Friend WithEvents CmbSubliga As ComboBox
    Friend WithEvents ChkActivarSubliga As CheckBox
    Friend WithEvents BtnAgregarASubliga As Button
    Friend WithEvents LblPosicion As Label
    Friend WithEvents LblNombreJugadorSubliga As Label
    Friend WithEvents LblIdJugadorSubliga As Label
    Friend WithEvents BtnBorrarJugadorDeLigaCreada As Button
    Friend WithEvents CmbPosicion As ComboBox
    Friend WithEvents IdJugador As DataGridViewTextBoxColumn
    Friend WithEvents NombreJugador As DataGridViewTextBoxColumn
    Friend WithEvents PosicionJugador As DataGridViewTextBoxColumn
End Class
