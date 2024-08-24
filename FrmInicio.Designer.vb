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
        CmbEquipoParaBorrar = New ComboBox()
        TxtEquipo = New TextBox()
        GpbJugadores = New GroupBox()
        CmbEquipoParaAgregar = New ComboBox()
        BtnGuardarJugadores = New Button()
        DataGridView1 = New DataGridView()
        TxtJugador = New TextBox()
        CmbPosicion = New ComboBox()
        BtnAñadir = New Button()
        BtnCrearNuevoEquipo = New Button()
        BtnDesactivarEquipo = New Button()
        GpbEquipos.SuspendLayout()
        GpbJugadores.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtnCargarPuntos
        ' 
        BtnCargarPuntos.BackColor = Color.SlateGray
        BtnCargarPuntos.FlatStyle = FlatStyle.Flat
        BtnCargarPuntos.Image = My.Resources.Resources.EditDataSource_32x32
        BtnCargarPuntos.Location = New Point(56, 43)
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
        BtnReporte.Location = New Point(436, 43)
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
        BtnCrearJugadores.Location = New Point(298, 43)
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
        BtnConfiguracion.Location = New Point(567, 43)
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
        BtnCrearEquipo.Location = New Point(182, 43)
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
        GpbEquipos.Controls.Add(TxtEquipo)
        GpbEquipos.Location = New Point(12, 122)
        GpbEquipos.Name = "GpbEquipos"
        GpbEquipos.Size = New Size(336, 485)
        GpbEquipos.TabIndex = 9
        GpbEquipos.TabStop = False
        GpbEquipos.Text = "Equipos"
        ' 
        ' CmbEquipoParaBorrar
        ' 
        CmbEquipoParaBorrar.FormattingEnabled = True
        CmbEquipoParaBorrar.Location = New Point(7, 225)
        CmbEquipoParaBorrar.Name = "CmbEquipoParaBorrar"
        CmbEquipoParaBorrar.Size = New Size(307, 23)
        CmbEquipoParaBorrar.TabIndex = 12
        ' 
        ' TxtEquipo
        ' 
        TxtEquipo.Location = New Point(7, 45)
        TxtEquipo.Name = "TxtEquipo"
        TxtEquipo.Size = New Size(307, 23)
        TxtEquipo.TabIndex = 0
        ' 
        ' GpbJugadores
        ' 
        GpbJugadores.Controls.Add(BtnAñadir)
        GpbJugadores.Controls.Add(CmbPosicion)
        GpbJugadores.Controls.Add(TxtJugador)
        GpbJugadores.Controls.Add(CmbEquipoParaAgregar)
        GpbJugadores.Controls.Add(BtnGuardarJugadores)
        GpbJugadores.Controls.Add(DataGridView1)
        GpbJugadores.Location = New Point(368, 122)
        GpbJugadores.Name = "GpbJugadores"
        GpbJugadores.Size = New Size(388, 485)
        GpbJugadores.TabIndex = 10
        GpbJugadores.TabStop = False
        GpbJugadores.Text = "Jugadores"
        ' 
        ' CmbEquipoParaAgregar
        ' 
        CmbEquipoParaAgregar.FormattingEnabled = True
        CmbEquipoParaAgregar.Location = New Point(6, 52)
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
        BtnGuardarJugadores.Location = New Point(305, 414)
        BtnGuardarJugadores.Name = "BtnGuardarJugadores"
        BtnGuardarJugadores.Size = New Size(77, 48)
        BtnGuardarJugadores.TabIndex = 14
        BtnGuardarJugadores.Text = "Guardar Datos"
        BtnGuardarJugadores.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(6, 119)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(293, 343)
        DataGridView1.TabIndex = 0
        ' 
        ' TxtJugador
        ' 
        TxtJugador.Location = New Point(6, 90)
        TxtJugador.Name = "TxtJugador"
        TxtJugador.Size = New Size(211, 23)
        TxtJugador.TabIndex = 14
        ' 
        ' CmbPosicion
        ' 
        CmbPosicion.FormattingEnabled = True
        CmbPosicion.Location = New Point(223, 90)
        CmbPosicion.Name = "CmbPosicion"
        CmbPosicion.Size = New Size(93, 23)
        CmbPosicion.TabIndex = 15
        ' 
        ' BtnAñadir
        ' 
        BtnAñadir.BackColor = Color.SlateGray
        BtnAñadir.FlatStyle = FlatStyle.Flat
        BtnAñadir.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnAñadir.ForeColor = Color.MidnightBlue
        BtnAñadir.Location = New Point(322, 90)
        BtnAñadir.Name = "BtnAñadir"
        BtnAñadir.Size = New Size(60, 23)
        BtnAñadir.TabIndex = 11
        BtnAñadir.Text = "Añadir"
        BtnAñadir.UseVisualStyleBackColor = False
        ' 
        ' BtnCrearNuevoEquipo
        ' 
        BtnCrearNuevoEquipo.BackColor = Color.SlateGray
        BtnCrearNuevoEquipo.FlatStyle = FlatStyle.Flat
        BtnCrearNuevoEquipo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnCrearNuevoEquipo.ForeColor = Color.MidnightBlue
        BtnCrearNuevoEquipo.Location = New Point(225, 74)
        BtnCrearNuevoEquipo.Name = "BtnCrearNuevoEquipo"
        BtnCrearNuevoEquipo.Size = New Size(89, 23)
        BtnCrearNuevoEquipo.TabIndex = 16
        BtnCrearNuevoEquipo.Text = "Crear"
        BtnCrearNuevoEquipo.UseVisualStyleBackColor = False
        ' 
        ' BtnDesactivarEquipo
        ' 
        BtnDesactivarEquipo.BackColor = Color.SlateGray
        BtnDesactivarEquipo.FlatStyle = FlatStyle.Flat
        BtnDesactivarEquipo.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        BtnDesactivarEquipo.ForeColor = Color.MidnightBlue
        BtnDesactivarEquipo.Location = New Point(225, 254)
        BtnDesactivarEquipo.Name = "BtnDesactivarEquipo"
        BtnDesactivarEquipo.Size = New Size(89, 23)
        BtnDesactivarEquipo.TabIndex = 17
        BtnDesactivarEquipo.Text = "Desactivar"
        BtnDesactivarEquipo.UseVisualStyleBackColor = False
        ' 
        ' FrmInicio
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SlateGray
        ClientSize = New Size(789, 619)
        Controls.Add(GpbJugadores)
        Controls.Add(GpbEquipos)
        Controls.Add(BtnCrearEquipo)
        Controls.Add(BtnConfiguracion)
        Controls.Add(BtnCrearJugadores)
        Controls.Add(BtnReporte)
        Controls.Add(BtnCargarPuntos)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "FrmInicio"
        Text = "Inicio"
        GpbEquipos.ResumeLayout(False)
        GpbEquipos.PerformLayout()
        GpbJugadores.ResumeLayout(False)
        GpbJugadores.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents BtnCargarPuntos As Button
    Friend WithEvents BtnReporte As Button
    Friend WithEvents BtnCrearJugadores As Button
    Friend WithEvents BtnConfiguracion As Button
    Friend WithEvents BtnCrearEquipo As Button
    Friend WithEvents GpbEquipos As GroupBox
    Friend WithEvents GpbJugadores As GroupBox
    Friend WithEvents TxtEquipo As TextBox
    Friend WithEvents CmbEquipoParaBorrar As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CmbEquipoParaAgregar As ComboBox
    Friend WithEvents BtnGuardarJugadores As Button
    Friend WithEvents BtnAñadir As Button
    Friend WithEvents CmbPosicion As ComboBox
    Friend WithEvents TxtJugador As TextBox
    Friend WithEvents BtnDesactivarEquipo As Button
    Friend WithEvents BtnCrearNuevoEquipo As Button
End Class
