<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        DgvDatos = New DataGridView()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        Btnxls = New Button()
        CType(DgvDatos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DgvDatos
        ' 
        DgvDatos.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvDatos.Location = New Point(12, 72)
        DgvDatos.Name = "DgvDatos"
        DgvDatos.RowTemplate.Height = 25
        DgvDatos.Size = New Size(722, 309)
        DgvDatos.TabIndex = 0
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(12, 25)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(191, 23)
        ComboBox1.TabIndex = 1
        ' 
        ' ComboBox2
        ' 
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(209, 25)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(191, 23)
        ComboBox2.TabIndex = 2
        ' 
        ' Btnxls
        ' 
        Btnxls.Location = New Point(659, 25)
        Btnxls.Name = "Btnxls"
        Btnxls.Size = New Size(75, 23)
        Btnxls.TabIndex = 3
        Btnxls.Text = "Xls"
        Btnxls.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SlateGray
        ClientSize = New Size(746, 393)
        Controls.Add(Btnxls)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(DgvDatos)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "Form1"
        Text = "Control de ligas"
        CType(DgvDatos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DgvDatos As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Btnxls As Button

End Class
