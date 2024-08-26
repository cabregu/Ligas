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
        Button1 = New Button()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvDatos
        ' 
        DgvDatos.AllowUserToAddRows = False
        DgvDatos.AllowUserToDeleteRows = False
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
        BtnObtenerDatos.Location = New Point(12, 29)
        BtnObtenerDatos.Name = "BtnObtenerDatos"
        BtnObtenerDatos.Size = New Size(63, 61)
        BtnObtenerDatos.TabIndex = 7
        BtnObtenerDatos.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.SlateGray
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Image = My.Resources.Resources.SendXLS_32x32
        Button1.Location = New Point(725, 29)
        Button1.Name = "Button1"
        Button1.Size = New Size(63, 61)
        Button1.TabIndex = 8
        Button1.UseVisualStyleBackColor = False
        ' 
        ' FrmReporte
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(BtnObtenerDatos)
        Controls.Add(DgvDatos)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "FrmReporte"
        Text = "Reporte"
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DgvDatos As DataGridView
    Friend WithEvents BtnObtenerDatos As Button
    Friend WithEvents Button1 As Button
End Class
