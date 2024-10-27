<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsadosPorFechas
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
        CmbLista = New ComboBox()
        DgvFechas = New DataGridView()
        Fechas = New DataGridViewTextBoxColumn()
        DgvJugadores = New DataGridView()
        lblIdequipo = New Label()
        BtnLista = New Button()
        BtnEliminarlista = New Button()
        Btnxls = New Button()
        CType(DgvFechas, ComponentModel.ISupportInitialize).BeginInit()
        CType(DgvJugadores, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblNombreLiga
        ' 
        LblNombreLiga.AutoSize = True
        LblNombreLiga.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        LblNombreLiga.ForeColor = Color.Maroon
        LblNombreLiga.Location = New Point(311, 9)
        LblNombreLiga.Name = "LblNombreLiga"
        LblNombreLiga.Size = New Size(127, 30)
        LblNombreLiga.TabIndex = 8
        LblNombreLiga.Text = "NombreLiga"
        ' 
        ' LblIdLiga
        ' 
        LblIdLiga.AutoSize = True
        LblIdLiga.Location = New Point(13, 9)
        LblIdLiga.Name = "LblIdLiga"
        LblIdLiga.Size = New Size(13, 15)
        LblIdLiga.TabIndex = 7
        LblIdLiga.Text = "0"
        LblIdLiga.Visible = False
        ' 
        ' CmbLista
        ' 
        CmbLista.FormattingEnabled = True
        CmbLista.Location = New Point(19, 41)
        CmbLista.Name = "CmbLista"
        CmbLista.Size = New Size(157, 23)
        CmbLista.TabIndex = 11
        ' 
        ' DgvFechas
        ' 
        DgvFechas.AllowUserToAddRows = False
        DgvFechas.AllowUserToDeleteRows = False
        DgvFechas.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DgvFechas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvFechas.Columns.AddRange(New DataGridViewColumn() {Fechas})
        DgvFechas.Location = New Point(19, 85)
        DgvFechas.Name = "DgvFechas"
        DgvFechas.ReadOnly = True
        DgvFechas.RowTemplate.Height = 25
        DgvFechas.Size = New Size(157, 447)
        DgvFechas.TabIndex = 10
        ' 
        ' Fechas
        ' 
        Fechas.HeaderText = "Fechas"
        Fechas.Name = "Fechas"
        Fechas.ReadOnly = True
        ' 
        ' DgvJugadores
        ' 
        DgvJugadores.AllowUserToAddRows = False
        DgvJugadores.AllowUserToDeleteRows = False
        DgvJugadores.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DgvJugadores.Location = New Point(182, 85)
        DgvJugadores.Name = "DgvJugadores"
        DgvJugadores.RowTemplate.Height = 25
        DgvJugadores.Size = New Size(448, 447)
        DgvJugadores.TabIndex = 9
        ' 
        ' lblIdequipo
        ' 
        lblIdequipo.AutoSize = True
        lblIdequipo.Location = New Point(692, 67)
        lblIdequipo.Name = "lblIdequipo"
        lblIdequipo.Size = New Size(13, 15)
        lblIdequipo.TabIndex = 12
        lblIdequipo.Text = "0"
        lblIdequipo.Visible = False
        ' 
        ' BtnLista
        ' 
        BtnLista.Location = New Point(182, 40)
        BtnLista.Name = "BtnLista"
        BtnLista.Size = New Size(107, 23)
        BtnLista.TabIndex = 13
        BtnLista.Text = "Crear Lista"
        BtnLista.UseVisualStyleBackColor = True
        ' 
        ' BtnEliminarlista
        ' 
        BtnEliminarlista.Location = New Point(295, 40)
        BtnEliminarlista.Name = "BtnEliminarlista"
        BtnEliminarlista.Size = New Size(107, 23)
        BtnEliminarlista.TabIndex = 14
        BtnEliminarlista.Text = "Eliminar Lista"
        BtnEliminarlista.UseVisualStyleBackColor = True
        ' 
        ' Btnxls
        ' 
        Btnxls.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Btnxls.BackColor = Color.SlateGray
        Btnxls.FlatStyle = FlatStyle.Flat
        Btnxls.Image = My.Resources.Resources.SendXLS_32x32
        Btnxls.Location = New Point(567, 29)
        Btnxls.Name = "Btnxls"
        Btnxls.Size = New Size(63, 44)
        Btnxls.TabIndex = 19
        Btnxls.UseVisualStyleBackColor = False
        ' 
        ' FrmUsadosPorFechas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Teal
        ClientSize = New Size(642, 544)
        Controls.Add(Btnxls)
        Controls.Add(BtnEliminarlista)
        Controls.Add(BtnLista)
        Controls.Add(lblIdequipo)
        Controls.Add(CmbLista)
        Controls.Add(DgvFechas)
        Controls.Add(DgvJugadores)
        Controls.Add(LblNombreLiga)
        Controls.Add(LblIdLiga)
        Name = "FrmUsadosPorFechas"
        Text = "Usados Por Fecha"
        WindowState = FormWindowState.Maximized
        CType(DgvFechas, ComponentModel.ISupportInitialize).EndInit()
        CType(DgvJugadores, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblNombreLiga As Label
    Friend WithEvents LblIdLiga As Label
    Friend WithEvents CmbLista As ComboBox
    Friend WithEvents DgvFechas As DataGridView
    Friend WithEvents DgvJugadores As DataGridView
    Friend WithEvents lblIdequipo As Label
    Friend WithEvents BtnLista As Button
    Friend WithEvents Fechas As DataGridViewTextBoxColumn
    Friend WithEvents BtnEliminarlista As Button
    Friend WithEvents Btnxls As Button
End Class
