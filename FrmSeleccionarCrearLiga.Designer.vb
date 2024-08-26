<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleccionarCrearLiga
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
        BtnCrearLinea = New Button()
        BtnSeleccionar = New Button()
        CmbSeleccionarLiga = New ComboBox()
        TxtNuevaLiga = New TextBox()
        CmbEliminarLiga = New ComboBox()
        BtnEliminarLiga = New Button()
        SuspendLayout()
        ' 
        ' BtnCrearLinea
        ' 
        BtnCrearLinea.BackColor = Color.SlateGray
        BtnCrearLinea.FlatStyle = FlatStyle.Flat
        BtnCrearLinea.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        BtnCrearLinea.ForeColor = Color.MidnightBlue
        BtnCrearLinea.Location = New Point(320, 37)
        BtnCrearLinea.Name = "BtnCrearLinea"
        BtnCrearLinea.Size = New Size(113, 50)
        BtnCrearLinea.TabIndex = 12
        BtnCrearLinea.Text = "Crear Liga"
        BtnCrearLinea.UseVisualStyleBackColor = False
        ' 
        ' BtnSeleccionar
        ' 
        BtnSeleccionar.BackColor = Color.SlateGray
        BtnSeleccionar.FlatStyle = FlatStyle.Flat
        BtnSeleccionar.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        BtnSeleccionar.ForeColor = Color.MidnightBlue
        BtnSeleccionar.Location = New Point(320, 115)
        BtnSeleccionar.Name = "BtnSeleccionar"
        BtnSeleccionar.Size = New Size(113, 50)
        BtnSeleccionar.TabIndex = 13
        BtnSeleccionar.Text = "Seleccionar"
        BtnSeleccionar.UseVisualStyleBackColor = False
        ' 
        ' CmbSeleccionarLiga
        ' 
        CmbSeleccionarLiga.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        CmbSeleccionarLiga.FormattingEnabled = True
        CmbSeleccionarLiga.Location = New Point(55, 120)
        CmbSeleccionarLiga.Name = "CmbSeleccionarLiga"
        CmbSeleccionarLiga.Size = New Size(238, 38)
        CmbSeleccionarLiga.TabIndex = 14
        ' 
        ' TxtNuevaLiga
        ' 
        TxtNuevaLiga.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        TxtNuevaLiga.Location = New Point(55, 42)
        TxtNuevaLiga.Name = "TxtNuevaLiga"
        TxtNuevaLiga.Size = New Size(238, 35)
        TxtNuevaLiga.TabIndex = 15
        ' 
        ' CmbEliminarLiga
        ' 
        CmbEliminarLiga.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        CmbEliminarLiga.FormattingEnabled = True
        CmbEliminarLiga.Location = New Point(55, 199)
        CmbEliminarLiga.Name = "CmbEliminarLiga"
        CmbEliminarLiga.Size = New Size(238, 38)
        CmbEliminarLiga.TabIndex = 16
        ' 
        ' BtnEliminarLiga
        ' 
        BtnEliminarLiga.BackColor = Color.SlateGray
        BtnEliminarLiga.FlatStyle = FlatStyle.Flat
        BtnEliminarLiga.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        BtnEliminarLiga.ForeColor = Color.MidnightBlue
        BtnEliminarLiga.Location = New Point(320, 194)
        BtnEliminarLiga.Name = "BtnEliminarLiga"
        BtnEliminarLiga.Size = New Size(113, 50)
        BtnEliminarLiga.TabIndex = 17
        BtnEliminarLiga.Text = "Eliminar"
        BtnEliminarLiga.UseVisualStyleBackColor = False
        ' 
        ' FrmSeleccionarCrearLiga
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(464, 279)
        Controls.Add(BtnEliminarLiga)
        Controls.Add(CmbEliminarLiga)
        Controls.Add(TxtNuevaLiga)
        Controls.Add(CmbSeleccionarLiga)
        Controls.Add(BtnSeleccionar)
        Controls.Add(BtnCrearLinea)
        Name = "FrmSeleccionarCrearLiga"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Seleccionar Crear Liga"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BtnCrearLinea As Button
    Friend WithEvents BtnSeleccionar As Button
    Friend WithEvents CmbSeleccionarLiga As ComboBox
    Friend WithEvents TxtNuevaLiga As TextBox
    Friend WithEvents CmbEliminarLiga As ComboBox
    Friend WithEvents BtnEliminarLiga As Button
End Class
