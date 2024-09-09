<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracion
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
        BtnCambiarCantidad = New Button()
        TxtCantidadFechas = New TextBox()
        LblDescFechas = New Label()
        LblFechas = New Label()
        GpgFechas = New GroupBox()
        Label1 = New Label()
        GpbEquipos = New GroupBox()
        BtnEliminar = New Button()
        BtnModificarNombreEquipo = New Button()
        Label3 = New Label()
        Label2 = New Label()
        TxtNuevoNombre = New TextBox()
        CmbEquipo = New ComboBox()
        LblIdliga = New Label()
        LblNombreLiga = New Label()
        ChkActivarFuncionEliminarEditar = New CheckBox()
        Chkfechas = New CheckBox()
        TxtNombreLiga = New TextBox()
        BtnCambiarNombreLiga = New Button()
        GpgFechas.SuspendLayout()
        GpbEquipos.SuspendLayout()
        SuspendLayout()
        ' 
        ' BtnCambiarCantidad
        ' 
        BtnCambiarCantidad.Location = New Point(145, 74)
        BtnCambiarCantidad.Name = "BtnCambiarCantidad"
        BtnCambiarCantidad.Size = New Size(75, 23)
        BtnCambiarCantidad.TabIndex = 0
        BtnCambiarCantidad.Text = "Cambiar"
        BtnCambiarCantidad.UseVisualStyleBackColor = True
        ' 
        ' TxtCantidadFechas
        ' 
        TxtCantidadFechas.Location = New Point(26, 74)
        TxtCantidadFechas.Name = "TxtCantidadFechas"
        TxtCantidadFechas.Size = New Size(100, 23)
        TxtCantidadFechas.TabIndex = 1
        ' 
        ' LblDescFechas
        ' 
        LblDescFechas.AutoSize = True
        LblDescFechas.Location = New Point(26, 56)
        LblDescFechas.Name = "LblDescFechas"
        LblDescFechas.Size = New Size(41, 15)
        LblDescFechas.TabIndex = 2
        LblDescFechas.Text = "Actual"
        ' 
        ' LblFechas
        ' 
        LblFechas.AutoSize = True
        LblFechas.Location = New Point(85, 56)
        LblFechas.Name = "LblFechas"
        LblFechas.Size = New Size(13, 15)
        LblFechas.TabIndex = 3
        LblFechas.Text = "0"
        ' 
        ' GpgFechas
        ' 
        GpgFechas.Controls.Add(Label1)
        GpgFechas.Controls.Add(TxtCantidadFechas)
        GpgFechas.Controls.Add(LblFechas)
        GpgFechas.Controls.Add(BtnCambiarCantidad)
        GpgFechas.Controls.Add(LblDescFechas)
        GpgFechas.Enabled = False
        GpgFechas.Location = New Point(88, 195)
        GpgFechas.Name = "GpgFechas"
        GpgFechas.Size = New Size(277, 149)
        GpgFechas.TabIndex = 4
        GpgFechas.TabStop = False
        GpgFechas.Text = "Fechas por Liga"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(26, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 15)
        Label1.TabIndex = 4
        ' 
        ' GpbEquipos
        ' 
        GpbEquipos.Controls.Add(BtnEliminar)
        GpbEquipos.Controls.Add(BtnModificarNombreEquipo)
        GpbEquipos.Controls.Add(Label3)
        GpbEquipos.Controls.Add(Label2)
        GpbEquipos.Controls.Add(TxtNuevoNombre)
        GpbEquipos.Controls.Add(CmbEquipo)
        GpbEquipos.Enabled = False
        GpbEquipos.Location = New Point(88, 409)
        GpbEquipos.Name = "GpbEquipos"
        GpbEquipos.Size = New Size(277, 255)
        GpbEquipos.TabIndex = 5
        GpbEquipos.TabStop = False
        GpbEquipos.Text = "Edicion y Eliminacion de Equipos para esta liga"
        ' 
        ' BtnEliminar
        ' 
        BtnEliminar.Location = New Point(10, 206)
        BtnEliminar.Name = "BtnEliminar"
        BtnEliminar.Size = New Size(250, 23)
        BtnEliminar.TabIndex = 5
        BtnEliminar.Text = "Eliminar Equipo y Todos sus registros"
        BtnEliminar.UseVisualStyleBackColor = True
        ' 
        ' BtnModificarNombreEquipo
        ' 
        BtnModificarNombreEquipo.Location = New Point(10, 120)
        BtnModificarNombreEquipo.Name = "BtnModificarNombreEquipo"
        BtnModificarNombreEquipo.Size = New Size(75, 23)
        BtnModificarNombreEquipo.TabIndex = 4
        BtnModificarNombreEquipo.Text = "Modificar"
        BtnModificarNombreEquipo.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 73)
        Label3.Name = "Label3"
        Label3.Size = New Size(149, 15)
        Label3.TabIndex = 3
        Label3.Text = "Coloque el Nuevo Nombre"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 29)
        Label2.Name = "Label2"
        Label2.Size = New Size(235, 15)
        Label2.TabIndex = 2
        Label2.Text = "Seleccione un equipo para editar o eliminar"
        ' 
        ' TxtNuevoNombre
        ' 
        TxtNuevoNombre.Location = New Point(10, 91)
        TxtNuevoNombre.Name = "TxtNuevoNombre"
        TxtNuevoNombre.Size = New Size(250, 23)
        TxtNuevoNombre.TabIndex = 1
        ' 
        ' CmbEquipo
        ' 
        CmbEquipo.FormattingEnabled = True
        CmbEquipo.Location = New Point(10, 47)
        CmbEquipo.Name = "CmbEquipo"
        CmbEquipo.Size = New Size(250, 23)
        CmbEquipo.TabIndex = 0
        ' 
        ' LblIdliga
        ' 
        LblIdliga.AutoSize = True
        LblIdliga.Location = New Point(12, 9)
        LblIdliga.Name = "LblIdliga"
        LblIdliga.Size = New Size(13, 15)
        LblIdliga.TabIndex = 6
        LblIdliga.Text = "0"
        LblIdliga.Visible = False
        ' 
        ' LblNombreLiga
        ' 
        LblNombreLiga.AutoSize = True
        LblNombreLiga.Font = New Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreLiga.ForeColor = Color.DarkRed
        LblNombreLiga.Location = New Point(31, 9)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(250, 45)
        LblNombreLiga.TabIndex = 14
        LblNombreLiga.Text = "Nombre de Liga"
        ' 
        ' ChkActivarFuncionEliminarEditar
        ' 
        ChkActivarFuncionEliminarEditar.AutoSize = True
        ChkActivarFuncionEliminarEditar.Location = New Point(88, 374)
        ChkActivarFuncionEliminarEditar.Name = "ChkActivarFuncionEliminarEditar"
        ChkActivarFuncionEliminarEditar.Size = New Size(227, 19)
        ChkActivarFuncionEliminarEditar.TabIndex = 15
        ChkActivarFuncionEliminarEditar.Text = "Clic Para Activar la Edicion de equipos"
        ChkActivarFuncionEliminarEditar.UseVisualStyleBackColor = True
        ' 
        ' Chkfechas
        ' 
        Chkfechas.AutoSize = True
        Chkfechas.Location = New Point(88, 159)
        Chkfechas.Name = "Chkfechas"
        Chkfechas.Size = New Size(219, 19)
        Chkfechas.TabIndex = 16
        Chkfechas.Text = "Clic Para Activar la Edicion de fechas"
        Chkfechas.UseVisualStyleBackColor = True
        ' 
        ' TxtNombreLiga
        ' 
        TxtNombreLiga.Location = New Point(41, 68)
        TxtNombreLiga.Name = "TxtNombreLiga"
        TxtNombreLiga.Size = New Size(240, 23)
        TxtNombreLiga.TabIndex = 17
        ' 
        ' BtnCambiarNombreLiga
        ' 
        BtnCambiarNombreLiga.Location = New Point(290, 68)
        BtnCambiarNombreLiga.Name = "BtnCambiarNombreLiga"
        BtnCambiarNombreLiga.Size = New Size(158, 23)
        BtnCambiarNombreLiga.TabIndex = 5
        BtnCambiarNombreLiga.Text = "Cambiar Nombre de liga"
        BtnCambiarNombreLiga.UseVisualStyleBackColor = True
        ' 
        ' FrmConfiguracion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(488, 751)
        Controls.Add(BtnCambiarNombreLiga)
        Controls.Add(TxtNombreLiga)
        Controls.Add(Chkfechas)
        Controls.Add(ChkActivarFuncionEliminarEditar)
        Controls.Add(LblNombreLiga)
        Controls.Add(LblIdliga)
        Controls.Add(GpbEquipos)
        Controls.Add(GpgFechas)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FrmConfiguracion"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Configuracion"
        GpgFechas.ResumeLayout(False)
        GpgFechas.PerformLayout()
        GpbEquipos.ResumeLayout(False)
        GpbEquipos.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnCambiarCantidad As Button
    Friend WithEvents TxtCantidadFechas As TextBox
    Friend WithEvents LblDescFechas As Label
    Friend WithEvents LblFechas As Label
    Friend WithEvents GpgFechas As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GpbEquipos As GroupBox
    Friend WithEvents LblIdliga As Label
    Friend WithEvents LblNombreLiga As Label
    Friend WithEvents CmbEquipo As ComboBox
    Friend WithEvents TxtNuevoNombre As TextBox
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnModificarNombreEquipo As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ChkActivarFuncionEliminarEditar As CheckBox
    Friend WithEvents Chkfechas As CheckBox
    Friend WithEvents TxtNombreLiga As TextBox
    Friend WithEvents BtnCambiarNombreLiga As Button
End Class
