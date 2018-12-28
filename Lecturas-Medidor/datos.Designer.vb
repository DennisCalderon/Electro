<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class datos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(datos))
        Me.dgvmedidor = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cboSector = New System.Windows.Forms.ComboBox()
        CType(Me.dgvmedidor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvmedidor
        '
        Me.dgvmedidor.AllowUserToAddRows = False
        Me.dgvmedidor.AllowUserToDeleteRows = False
        Me.dgvmedidor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvmedidor.Location = New System.Drawing.Point(12, 54)
        Me.dgvmedidor.Name = "dgvmedidor"
        Me.dgvmedidor.Size = New System.Drawing.Size(783, 369)
        Me.dgvmedidor.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(419, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 31)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cargar Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(527, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(114, 31)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Procesar y Guardar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 429)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(783, 23)
        Me.ProgressBar1.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(163, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 31)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Mostrar Padrón Actual"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cboSector
        '
        Me.cboSector.FormattingEnabled = True
        Me.cboSector.Location = New System.Drawing.Point(36, 18)
        Me.cboSector.Name = "cboSector"
        Me.cboSector.Size = New System.Drawing.Size(121, 21)
        Me.cboSector.TabIndex = 6
        '
        'datos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 459)
        Me.Controls.Add(Me.cboSector)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvmedidor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "datos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cargar lista de clientes"
        CType(Me.dgvmedidor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvmedidor As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button3 As Button
    Friend WithEvents cboSector As ComboBox
End Class
