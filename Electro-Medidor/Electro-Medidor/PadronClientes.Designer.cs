namespace Electro_Medidor
{
    partial class PadronClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PadronClientes));
            this.cboSector = new System.Windows.Forms.ComboBox();
            this.btnMostrarPadron = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnCargarExcel = new System.Windows.Forms.Button();
            this.dgvpadron = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpadron)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSector
            // 
            this.cboSector.FormattingEnabled = true;
            this.cboSector.Location = new System.Drawing.Point(29, 14);
            this.cboSector.Name = "cboSector";
            this.cboSector.Size = new System.Drawing.Size(121, 21);
            this.cboSector.TabIndex = 12;
            // 
            // btnMostrarPadron
            // 
            this.btnMostrarPadron.Location = new System.Drawing.Point(156, 8);
            this.btnMostrarPadron.Name = "btnMostrarPadron";
            this.btnMostrarPadron.Size = new System.Drawing.Size(141, 31);
            this.btnMostrarPadron.TabIndex = 11;
            this.btnMostrarPadron.Text = "Mostrar Padrón Actual";
            this.btnMostrarPadron.UseVisualStyleBackColor = true;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(9, 422);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(783, 23);
            this.ProgressBar1.TabIndex = 10;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(485, 8);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(114, 31);
            this.btnProcesar.TabIndex = 9;
            this.btnProcesar.Text = "Procesar y Guardar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.Location = new System.Drawing.Point(377, 8);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.Size = new System.Drawing.Size(75, 31);
            this.btnCargarExcel.TabIndex = 8;
            this.btnCargarExcel.Text = "Cargar Excel";
            this.btnCargarExcel.UseVisualStyleBackColor = true;
            // 
            // dgvpadron
            // 
            this.dgvpadron.AllowUserToAddRows = false;
            this.dgvpadron.AllowUserToDeleteRows = false;
            this.dgvpadron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpadron.Location = new System.Drawing.Point(9, 47);
            this.dgvpadron.Name = "dgvpadron";
            this.dgvpadron.Size = new System.Drawing.Size(783, 369);
            this.dgvpadron.TabIndex = 7;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(674, 8);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(97, 31);
            this.btnExportar.TabIndex = 13;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // PadronClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.cboSector);
            this.Controls.Add(this.btnMostrarPadron);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnCargarExcel);
            this.Controls.Add(this.dgvpadron);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PadronClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PadronClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvpadron)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboSector;
        internal System.Windows.Forms.Button btnMostrarPadron;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.Button btnProcesar;
        internal System.Windows.Forms.Button btnCargarExcel;
        internal System.Windows.Forms.DataGridView dgvpadron;
        internal System.Windows.Forms.Button btnExportar;
    }
}