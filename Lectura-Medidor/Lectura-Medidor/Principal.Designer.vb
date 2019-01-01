<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkLibres = New System.Windows.Forms.CheckBox()
        Me.chkIlo = New System.Windows.Forms.CheckBox()
        Me.chkMoquegua = New System.Windows.Forms.CheckBox()
        Me.chkTacna = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkMHTAB = New System.Windows.Forms.CheckBox()
        Me.chkA1800 = New System.Windows.Forms.CheckBox()
        Me.chkS1440 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtruta = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblregistros = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvcontenido = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblarchivos = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbArchivos = New System.Windows.Forms.ListBox()
        Me.btnExportMasivo = New System.Windows.Forms.Button()
        Me.btnExportUnit = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ActualizarMedidoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvcontenido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 520)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(706, 23)
        Me.ProgressBar1.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkLibres)
        Me.GroupBox1.Controls.Add(Me.chkIlo)
        Me.GroupBox1.Controls.Add(Me.chkMoquegua)
        Me.GroupBox1.Controls.Add(Me.chkTacna)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkMHTAB)
        Me.GroupBox1.Controls.Add(Me.chkA1800)
        Me.GroupBox1.Controls.Add(Me.chkS1440)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtruta)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(416, 121)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Importar Datos"
        '
        'chkLibres
        '
        Me.chkLibres.AutoSize = True
        Me.chkLibres.Location = New System.Drawing.Point(250, 58)
        Me.chkLibres.Name = "chkLibres"
        Me.chkLibres.Size = New System.Drawing.Size(54, 17)
        Me.chkLibres.TabIndex = 11
        Me.chkLibres.Text = "Libres"
        Me.chkLibres.UseVisualStyleBackColor = True
        '
        'chkIlo
        '
        Me.chkIlo.AutoSize = True
        Me.chkIlo.Location = New System.Drawing.Point(250, 35)
        Me.chkIlo.Name = "chkIlo"
        Me.chkIlo.Size = New System.Drawing.Size(37, 17)
        Me.chkIlo.TabIndex = 10
        Me.chkIlo.Text = "Ilo"
        Me.chkIlo.UseVisualStyleBackColor = True
        '
        'chkMoquegua
        '
        Me.chkMoquegua.AutoSize = True
        Me.chkMoquegua.Location = New System.Drawing.Point(164, 58)
        Me.chkMoquegua.Name = "chkMoquegua"
        Me.chkMoquegua.Size = New System.Drawing.Size(77, 17)
        Me.chkMoquegua.TabIndex = 9
        Me.chkMoquegua.Text = "Moquegua"
        Me.chkMoquegua.UseVisualStyleBackColor = True
        '
        'chkTacna
        '
        Me.chkTacna.AutoSize = True
        Me.chkTacna.Location = New System.Drawing.Point(165, 35)
        Me.chkTacna.Name = "chkTacna"
        Me.chkTacna.Size = New System.Drawing.Size(57, 17)
        Me.chkTacna.TabIndex = 8
        Me.chkTacna.Text = "Tacna"
        Me.chkTacna.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Lista de Padrón :"
        '
        'chkMHTAB
        '
        Me.chkMHTAB.AutoSize = True
        Me.chkMHTAB.Location = New System.Drawing.Point(46, 81)
        Me.chkMHTAB.Name = "chkMHTAB"
        Me.chkMHTAB.Size = New System.Drawing.Size(67, 17)
        Me.chkMHTAB.TabIndex = 6
        Me.chkMHTAB.Text = "MH-TAB"
        Me.chkMHTAB.UseVisualStyleBackColor = True
        '
        'chkA1800
        '
        Me.chkA1800.AutoSize = True
        Me.chkA1800.Location = New System.Drawing.Point(46, 58)
        Me.chkA1800.Name = "chkA1800"
        Me.chkA1800.Size = New System.Drawing.Size(60, 17)
        Me.chkA1800.TabIndex = 5
        Me.chkA1800.Text = "A-1800"
        Me.chkA1800.UseVisualStyleBackColor = True
        '
        'chkS1440
        '
        Me.chkS1440.AutoSize = True
        Me.chkS1440.Location = New System.Drawing.Point(46, 35)
        Me.chkS1440.Name = "chkS1440"
        Me.chkS1440.Size = New System.Drawing.Size(60, 17)
        Me.chkS1440.TabIndex = 4
        Me.chkS1440.Text = "S-1440"
        Me.chkS1440.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo de Medidor :"
        '
        'txtruta
        '
        Me.txtruta.Location = New System.Drawing.Point(144, 95)
        Me.txtruta.Name = "txtruta"
        Me.txtruta.ReadOnly = True
        Me.txtruta.Size = New System.Drawing.Size(174, 20)
        Me.txtruta.TabIndex = 1
        Me.txtruta.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(331, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(79, 86)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "Buscar "
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblregistros)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.dgvcontenido)
        Me.GroupBox4.Location = New System.Drawing.Point(230, 164)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(486, 352)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Registros del Medidor"
        '
        'lblregistros
        '
        Me.lblregistros.AutoSize = True
        Me.lblregistros.Location = New System.Drawing.Point(198, 20)
        Me.lblregistros.Name = "lblregistros"
        Me.lblregistros.Size = New System.Drawing.Size(13, 13)
        Me.lblregistros.TabIndex = 13
        Me.lblregistros.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(73, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = " Cantidad de Registros: "
        '
        'dgvcontenido
        '
        Me.dgvcontenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcontenido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dgvcontenido.Location = New System.Drawing.Point(5, 41)
        Me.dgvcontenido.Name = "dgvcontenido"
        Me.dgvcontenido.Size = New System.Drawing.Size(475, 301)
        Me.dgvcontenido.TabIndex = 11
        '
        'Column1
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle19
        Me.Column1.HeaderText = "Mes"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle20
        Me.Column2.HeaderText = "Código de Empresa"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 60
        '
        'Column3
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle21
        Me.Column3.HeaderText = "Código de Suministro"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle22
        Me.Column4.HeaderText = "Código de Barra de Compra"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 73
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle23
        Me.Column5.HeaderText = "Fecha /Hora"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 85
        '
        'Column6
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle24
        Me.Column6.HeaderText = "EA"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 65
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblarchivos)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.lbArchivos)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 164)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 353)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Archivos"
        '
        'lblarchivos
        '
        Me.lblarchivos.AutoSize = True
        Me.lblarchivos.Location = New System.Drawing.Point(139, 18)
        Me.lblarchivos.Name = "lblarchivos"
        Me.lblarchivos.Size = New System.Drawing.Size(13, 13)
        Me.lblarchivos.TabIndex = 11
        Me.lblarchivos.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = " Cantidad de Archivos: "
        '
        'lbArchivos
        '
        Me.lbArchivos.FormattingEnabled = True
        Me.lbArchivos.Location = New System.Drawing.Point(8, 39)
        Me.lbArchivos.Name = "lbArchivos"
        Me.lbArchivos.ScrollAlwaysVisible = True
        Me.lbArchivos.Size = New System.Drawing.Size(191, 303)
        Me.lbArchivos.TabIndex = 7
        '
        'btnExportMasivo
        '
        Me.btnExportMasivo.Image = CType(resources.GetObject("btnExportMasivo.Image"), System.Drawing.Image)
        Me.btnExportMasivo.Location = New System.Drawing.Point(622, 51)
        Me.btnExportMasivo.Name = "btnExportMasivo"
        Me.btnExportMasivo.Size = New System.Drawing.Size(99, 86)
        Me.btnExportMasivo.TabIndex = 23
        Me.btnExportMasivo.Text = "Exportar - Masivo"
        Me.btnExportMasivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportMasivo.UseVisualStyleBackColor = True
        '
        'btnExportUnit
        '
        Me.btnExportUnit.Image = CType(resources.GetObject("btnExportUnit.Image"), System.Drawing.Image)
        Me.btnExportUnit.Location = New System.Drawing.Point(517, 51)
        Me.btnExportUnit.Name = "btnExportUnit"
        Me.btnExportUnit.Size = New System.Drawing.Size(99, 86)
        Me.btnExportUnit.TabIndex = 22
        Me.btnExportUnit.Text = "Exportar - Unitario"
        Me.btnExportUnit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportUnit.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(432, 51)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(79, 86)
        Me.btnNuevo.TabIndex = 21
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Silver
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarMedidoresToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(729, 24)
        Me.MenuStrip1.TabIndex = 29
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ActualizarMedidoresToolStripMenuItem
        '
        Me.ActualizarMedidoresToolStripMenuItem.Name = "ActualizarMedidoresToolStripMenuItem"
        Me.ActualizarMedidoresToolStripMenuItem.Size = New System.Drawing.Size(115, 20)
        Me.ActualizarMedidoresToolStripMenuItem.Text = "Actualizar  Padrón"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 551)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnExportMasivo)
        Me.Controls.Add(Me.btnExportUnit)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lectura de Registros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvcontenido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkMHTAB As CheckBox
    Friend WithEvents chkA1800 As CheckBox
    Friend WithEvents chkS1440 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtruta As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblregistros As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvcontenido As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblarchivos As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbArchivos As ListBox
    Friend WithEvents btnExportMasivo As Button
    Friend WithEvents btnExportUnit As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ActualizarMedidoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents chkLibres As CheckBox
    Friend WithEvents chkIlo As CheckBox
    Friend WithEvents chkMoquegua As CheckBox
    Friend WithEvents chkTacna As CheckBox
    Friend WithEvents Label2 As Label
End Class
