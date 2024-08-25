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
        BtnDesactivarEquipo = New Button()
        BtnCrearNuevoEquipo = New Button()
        CmbEquipoParaBorrar = New ComboBox()
        TxtEquipoingresar = New TextBox()
        GpbJugadores = New GroupBox()
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
        CType(DgvJugadores, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnCargarPuntos
        ' 
        BtnCargarPuntos.BackColor = Color.SlateGray
        BtnCargarPuntos.FlatStyle = FlatStyle.Flat
        BtnCargarPuntos.Image = My.Resources.Resources.LongDate_32x32
        BtnCargarPuntos.Location = New Point(96, 131)
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
        BtnReporte.Location = New Point(476, 131)
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
        BtnCrearJugadores.Location = New Point(338, 131)
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
        BtnConfiguracion.Location = New Point(607, 131)
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
        BtnCrearEquipo.Location = New Point(222, 131)
        BtnCrearEquipo.Name = "BtnCrearEquipo"
        BtnCrearEquipo.Size = New Size(63, 61)
        BtnCrearEquipo.TabIndex = 8
        BtnCrearEquipo.UseVisualStyleBackColor = False
        ' 
        ' GpbEquipos
        ' 
        GpbEquipos.Controls.Add(BtnDesactivarEquipo)
        GpbEquipos.Controls.Add(BtnCrearNuevoEquipo)
        GpbEquipos.Controls.Add(CmbEquipoParaBorrar)
        GpbEquipos.Controls.Add(TxtEquipoingresar)
        GpbEquipos.Enabled = False
        GpbEquipos.Location = New Point(12, 221)
        GpbEquipos.Name = "GpbEquipos"
        GpbEquipos.Size = New Size(336, 386)
        GpbEquipos.TabIndex = 9
        GpbEquipos.TabStop = False
        GpbEquipos.Text = "Equipos"
        ' 
        ' BtnDesactivarEquipo
        ' 
        BtnDesactivarEquipo.BackColor = Color.SlateGray
        BtnDesactivarEquipo.FlatStyle = FlatStyle.Flat
        BtnDesactivarEquipo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnDesactivarEquipo.ForeColor = Color.MidnightBlue
        BtnDesactivarEquipo.Location = New Point(224, 128)
        BtnDesactivarEquipo.Name = "BtnDesactivarEquipo"
        BtnDesactivarEquipo.Size = New Size(89, 23)
        BtnDesactivarEquipo.TabIndex = 17
        BtnDesactivarEquipo.Text = "Desactivar"
        BtnDesactivarEquipo.UseVisualStyleBackColor = False
        ' 
        ' BtnCrearNuevoEquipo
        ' 
        BtnCrearNuevoEquipo.BackColor = Color.SlateGray
        BtnCrearNuevoEquipo.FlatStyle = FlatStyle.Flat
        BtnCrearNuevoEquipo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnCrearNuevoEquipo.ForeColor = Color.MidnightBlue
        BtnCrearNuevoEquipo.Location = New Point(225, 51)
        BtnCrearNuevoEquipo.Name = "BtnCrearNuevoEquipo"
        BtnCrearNuevoEquipo.Size = New Size(89, 23)
        BtnCrearNuevoEquipo.TabIndex = 16
        BtnCrearNuevoEquipo.Text = "Crear"
        BtnCrearNuevoEquipo.UseVisualStyleBackColor = False
        ' 
        ' CmbEquipoParaBorrar
        ' 
        CmbEquipoParaBorrar.FormattingEnabled = True
        CmbEquipoParaBorrar.Location = New Point(6, 99)
        CmbEquipoParaBorrar.Name = "CmbEquipoParaBorrar"
        CmbEquipoParaBorrar.Size = New Size(307, 23)
        CmbEquipoParaBorrar.TabIndex = 12
        ' 
        ' TxtEquipoingresar
        ' 
        TxtEquipoingresar.Location = New Point(7, 22)
        TxtEquipoingresar.Name = "TxtEquipoingresar"
        TxtEquipoingresar.Size = New Size(307, 23)
        TxtEquipoingresar.TabIndex = 0
        ' 
        ' GpbJugadores
        ' 
        GpbJugadores.Controls.Add(BtnAñadir)
        GpbJugadores.Controls.Add(CmbPosicionParaAgregar)
        GpbJugadores.Controls.Add(TxtJugadorParaAgregar)
        GpbJugadores.Controls.Add(CmbEquipoParaAgregar)
        GpbJugadores.Controls.Add(BtnGuardarJugadores)
        GpbJugadores.Controls.Add(DgvJugadores)
        GpbJugadores.Enabled = False
        GpbJugadores.Location = New Point(368, 221)
        GpbJugadores.Name = "GpbJugadores"
        GpbJugadores.Size = New Size(487, 386)
        GpbJugadores.TabIndex = 10
        GpbJugadores.TabStop = False
        GpbJugadores.Text = "Jugadores"
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
        BtnGuardarJugadores.Location = New Point(404, 323)
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
        DgvJugadores.Size = New Size(392, 224)
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
    Friend WithEvents CmbEquipoParaBorrar As ComboBox
    Friend WithEvents DgvJugadores As DataGridView
    Friend WithEvents CmbEquipoParaAgregar As ComboBox
    Friend WithEvents BtnGuardarJugadores As Button
    Friend WithEvents BtnAñadir As Button
    Friend WithEvents CmbPosicionParaAgregar As ComboBox
    Friend WithEvents TxtJugadorParaAgregar As TextBox
    Friend WithEvents BtnDesactivarEquipo As Button
    Friend WithEvents BtnCrearNuevoEquipo As Button
    Friend WithEvents LblIdLiga As Label
    Friend WithEvents LblNombreLiga As Label
    Friend WithEvents Equipo As DataGridViewTextBoxColumn
    Friend WithEvents Jugador As DataGridViewTextBoxColumn
    Friend WithEvents Pos As DataGridViewTextBoxColumn
End Class
