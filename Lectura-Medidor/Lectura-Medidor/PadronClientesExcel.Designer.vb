<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PadronClientesExcel
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
        Me.chkLibres = New System.Windows.Forms.CheckBox()
        Me.chkIlo = New System.Windows.Forms.CheckBox()
        Me.chkMoquegua = New System.Windows.Forms.CheckBox()
        Me.chkTacna = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.dgvpadron = New System.Windows.Forms.DataGridView()
        CType(Me.dgvpadron, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkLibres
        '
        Me.chkLibres.AutoSize = True
        Me.chkLibres.Location = New System.Drawing.Point(138, 66)
        Me.chkLibres.Name = "chkLibres"
        Me.chkLibres.Size = New System.Drawing.Size(54, 17)
        Me.chkLibres.TabIndex = 16
        Me.chkLibres.Text = "Libres"
        Me.chkLibres.UseVisualStyleBackColor = True
        '
        'chkIlo
        '
        Me.chkIlo.AutoSize = True
        Me.chkIlo.Location = New System.Drawing.Point(138, 43)
        Me.chkIlo.Name = "chkIlo"
        Me.chkIlo.Size = New System.Drawing.Size(37, 17)
        Me.chkIlo.TabIndex = 15
        Me.chkIlo.Text = "Ilo"
        Me.chkIlo.UseVisualStyleBackColor = True
        '
        'chkMoquegua
        '
        Me.chkMoquegua.AutoSize = True
        Me.chkMoquegua.Location = New System.Drawing.Point(52, 66)
        Me.chkMoquegua.Name = "chkMoquegua"
        Me.chkMoquegua.Size = New System.Drawing.Size(77, 17)
        Me.chkMoquegua.TabIndex = 14
        Me.chkMoquegua.Text = "Moquegua"
        Me.chkMoquegua.UseVisualStyleBackColor = True
        '
        'chkTacna
        '
        Me.chkTacna.AutoSize = True
        Me.chkTacna.Location = New System.Drawing.Point(53, 43)
        Me.chkTacna.Name = "chkTacna"
        Me.chkTacna.Size = New System.Drawing.Size(57, 17)
        Me.chkTacna.TabIndex = 13
        Me.chkTacna.Text = "Tacna"
        Me.chkTacna.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Elija los Padrones :"
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(44, 89)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 17
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Location = New System.Drawing.Point(138, 89)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(75, 23)
        Me.btnCancela.TabIndex = 18
        Me.btnCancela.Text = "Cancelar"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'dgvpadron
        '
        Me.dgvpadron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvpadron.Location = New System.Drawing.Point(23, 132)
        Me.dgvpadron.Name = "dgvpadron"
        Me.dgvpadron.Size = New System.Drawing.Size(199, 38)
        Me.dgvpadron.TabIndex = 19
        '
        'PadronClientesExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(241, 125)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvpadron)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.chkLibres)
        Me.Controls.Add(Me.chkIlo)
        Me.Controls.Add(Me.chkMoquegua)
        Me.Controls.Add(Me.chkTacna)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "PadronClientesExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Padrón de Clientes a Excel"
        CType(Me.dgvpadron, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkLibres As CheckBox
    Friend WithEvents chkIlo As CheckBox
    Friend WithEvents chkMoquegua As CheckBox
    Friend WithEvents chkTacna As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents btnCancela As Button
    Friend WithEvents dgvpadron As DataGridView
End Class
