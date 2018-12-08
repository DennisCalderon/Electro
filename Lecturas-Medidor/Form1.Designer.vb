<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnExportUnit = New System.Windows.Forms.Button()
        Me.btnExportMasivo = New System.Windows.Forms.Button()
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblprueba = New System.Windows.Forms.Label()
        Me.cbotipomedidor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtruta = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvcontenido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(267, 19)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(79, 86)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "Buscar "
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(378, 27)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(79, 86)
        Me.btnNuevo.TabIndex = 1
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnExportUnit
        '
        Me.btnExportUnit.Image = CType(resources.GetObject("btnExportUnit.Image"), System.Drawing.Image)
        Me.btnExportUnit.Location = New System.Drawing.Point(483, 27)
        Me.btnExportUnit.Name = "btnExportUnit"
        Me.btnExportUnit.Size = New System.Drawing.Size(106, 86)
        Me.btnExportUnit.TabIndex = 2
        Me.btnExportUnit.Text = "Exportar - Unitario"
        Me.btnExportUnit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportUnit.UseVisualStyleBackColor = True
        '
        'btnExportMasivo
        '
        Me.btnExportMasivo.Image = CType(resources.GetObject("btnExportMasivo.Image"), System.Drawing.Image)
        Me.btnExportMasivo.Location = New System.Drawing.Point(610, 27)
        Me.btnExportMasivo.Name = "btnExportMasivo"
        Me.btnExportMasivo.Size = New System.Drawing.Size(106, 86)
        Me.btnExportMasivo.TabIndex = 3
        Me.btnExportMasivo.Text = "Exportar - Masivo"
        Me.btnExportMasivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportMasivo.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblregistros)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.dgvcontenido)
        Me.GroupBox4.Location = New System.Drawing.Point(230, 140)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(486, 374)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Registros del Medidor"
        '
        'lblregistros
        '
        Me.lblregistros.AutoSize = True
        Me.lblregistros.Location = New System.Drawing.Point(169, 33)
        Me.lblregistros.Name = "lblregistros"
        Me.lblregistros.Size = New System.Drawing.Size(13, 13)
        Me.lblregistros.TabIndex = 13
        Me.lblregistros.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = " Cantidad de Registros: "
        '
        'dgvcontenido
        '
        Me.dgvcontenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcontenido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dgvcontenido.Location = New System.Drawing.Point(5, 63)
        Me.dgvcontenido.Name = "dgvcontenido"
        Me.dgvcontenido.Size = New System.Drawing.Size(475, 301)
        Me.dgvcontenido.TabIndex = 11
        '
        'Column1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Mes"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "Código de Empresa"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 60
        '
        'Column3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "Código de Suministro"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column4.HeaderText = "Código de Barra de Compra"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 73
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column5.HeaderText = "Fecha /Hora"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 85
        '
        'Column6
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle6
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
        Me.GroupBox3.Location = New System.Drawing.Point(10, 140)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 375)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Archivos"
        '
        'lblarchivos
        '
        Me.lblarchivos.AutoSize = True
        Me.lblarchivos.Location = New System.Drawing.Point(139, 25)
        Me.lblarchivos.Name = "lblarchivos"
        Me.lblarchivos.Size = New System.Drawing.Size(13, 13)
        Me.lblarchivos.TabIndex = 11
        Me.lblarchivos.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = " Cantidad de Archivos: "
        '
        'lbArchivos
        '
        Me.lbArchivos.FormattingEnabled = True
        Me.lbArchivos.Location = New System.Drawing.Point(8, 51)
        Me.lbArchivos.Name = "lbArchivos"
        Me.lbArchivos.ScrollAlwaysVisible = True
        Me.lbArchivos.Size = New System.Drawing.Size(191, 316)
        Me.lbArchivos.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblprueba)
        Me.GroupBox1.Controls.Add(Me.cbotipomedidor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtruta)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 121)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Importar Datos"
        '
        'lblprueba
        '
        Me.lblprueba.AutoSize = True
        Me.lblprueba.Location = New System.Drawing.Point(6, 100)
        Me.lblprueba.Name = "lblprueba"
        Me.lblprueba.Size = New System.Drawing.Size(40, 13)
        Me.lblprueba.TabIndex = 14
        Me.lblprueba.Text = "prueba"
        Me.lblprueba.Visible = False
        '
        'cbotipomedidor
        '
        Me.cbotipomedidor.FormattingEnabled = True
        Me.cbotipomedidor.Items.AddRange(New Object() {"S-1440", "A-1800", "MH-TAB"})
        Me.cbotipomedidor.Location = New System.Drawing.Point(118, 50)
        Me.cbotipomedidor.Name = "cbotipomedidor"
        Me.cbotipomedidor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbotipomedidor.Size = New System.Drawing.Size(81, 21)
        Me.cbotipomedidor.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo de Medidor"
        '
        'txtruta
        '
        Me.txtruta.Location = New System.Drawing.Point(52, 97)
        Me.txtruta.Name = "txtruta"
        Me.txtruta.ReadOnly = True
        Me.txtruta.Size = New System.Drawing.Size(168, 20)
        Me.txtruta.TabIndex = 1
        Me.txtruta.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 529)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(706, 23)
        Me.ProgressBar1.TabIndex = 18
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 564)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnExportMasivo)
        Me.Controls.Add(Me.btnExportUnit)
        Me.Controls.Add(Me.btnNuevo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lectura de Registros"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvcontenido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnExportUnit As Button
    Friend WithEvents btnExportMasivo As Button
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
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblprueba As Label
    Friend WithEvents cbotipomedidor As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtruta As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
