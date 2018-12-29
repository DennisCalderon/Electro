namespace Electro_Medidor
{
    partial class GuardarDGVDB
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
            this.pbDB = new System.Windows.Forms.ProgressBar();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbDB
            // 
            this.pbDB.Location = new System.Drawing.Point(8, 41);
            this.pbDB.Name = "pbDB";
            this.pbDB.Size = new System.Drawing.Size(406, 23);
            this.pbDB.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(102, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(230, 26);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Guardando Registros almacenados en memoria\r\n por favor no cierre la ventana....\r\n" +
    "";
            // 
            // GuardarDGVDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 77);
            this.ControlBox = false;
            this.Controls.Add(this.pbDB);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GuardarDGVDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conectando con la Base de Datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ProgressBar pbDB;
        internal System.Windows.Forms.Label Label1;
    }
}