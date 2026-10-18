namespace Main_Menu
{
    partial class ImportDataMenu
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.botonFichero = new System.Windows.Forms.Button();
            this.botonManual = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(49, 44);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(263, 16);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "From where do you want to import the data?";
            // 
            // botonFichero
            // 
            this.botonFichero.Location = new System.Drawing.Point(227, 91);
            this.botonFichero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonFichero.Name = "botonFichero";
            this.botonFichero.Size = new System.Drawing.Size(100, 28);
            this.botonFichero.TabIndex = 1;
            this.botonFichero.Text = "File";
            this.botonFichero.UseVisualStyleBackColor = true;
            this.botonFichero.Click += new System.EventHandler(this.botonFichero_Click);
            // 
            // botonManual
            // 
            this.botonManual.Location = new System.Drawing.Point(53, 91);
            this.botonManual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonManual.Name = "botonManual";
            this.botonManual.Size = new System.Drawing.Size(100, 28);
            this.botonManual.TabIndex = 2;
            this.botonManual.Text = "Manual";
            this.botonManual.UseVisualStyleBackColor = true;
            this.botonManual.Click += new System.EventHandler(this.botonManual_Click);
            // 
            // FicheroOManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 170);
            this.Controls.Add(this.botonManual);
            this.Controls.Add(this.botonFichero);
            this.Controls.Add(this.labelInfo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FicheroOManual";
            this.Text = "ImportDataMenu";
            this.Load += new System.EventHandler(this.FicheroOManual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button botonFichero;
        private System.Windows.Forms.Button botonManual;
    }
}