namespace Electro_Medidor
{
    partial class SerieNoEncontrada
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnAbortar = new System.Windows.Forms.Button();
            this.txtLista = new System.Windows.Forms.TextBox();
            this.btnSeguirProcesando = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.btnAbortar);
            this.GroupBox1.Controls.Add(this.txtLista);
            this.GroupBox1.Controls.Add(this.btnSeguirProcesando);
            this.GroupBox1.Location = new System.Drawing.Point(12, 32);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(296, 260);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "La Serie no existe en la Base de Datos :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(15, 31);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(215, 26);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Los elementos listados a continuación serán\r\n ignorados en el procesamiento de Da" +
    "tos";
            // 
            // btnAbortar
            // 
            this.btnAbortar.Location = new System.Drawing.Point(179, 176);
            this.btnAbortar.Name = "btnAbortar";
            this.btnAbortar.Size = new System.Drawing.Size(108, 37);
            this.btnAbortar.TabIndex = 3;
            this.btnAbortar.Text = "Abortar";
            this.btnAbortar.UseVisualStyleBackColor = true;
            // 
            // txtLista
            // 
            this.txtLista.Location = new System.Drawing.Point(18, 70);
            this.txtLista.Multiline = true;
            this.txtLista.Name = "txtLista";
            this.txtLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLista.Size = new System.Drawing.Size(155, 177);
            this.txtLista.TabIndex = 4;
            this.txtLista.Text = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n11\r\n2\r\n6\r\n8\r\n9\r\n7\r\n1\r\n5\r\n8\r\n8\r\n6\r\n65";
            // 
            // btnSeguirProcesando
            // 
            this.btnSeguirProcesando.Location = new System.Drawing.Point(179, 96);
            this.btnSeguirProcesando.Name = "btnSeguirProcesando";
            this.btnSeguirProcesando.Size = new System.Drawing.Size(108, 37);
            this.btnSeguirProcesando.TabIndex = 2;
            this.btnSeguirProcesando.Text = "Seguir Procesando";
            this.btnSeguirProcesando.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(19, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(218, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Los siguientes ARCHIVOS tienen problemas.\r\n";
            // 
            // SerieNoEncontrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 301);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label1);
            this.Name = "SerieNoEncontrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serie no Encontrada";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnAbortar;
        internal System.Windows.Forms.TextBox txtLista;
        internal System.Windows.Forms.Button btnSeguirProcesando;
        internal System.Windows.Forms.Label Label1;
    }
}