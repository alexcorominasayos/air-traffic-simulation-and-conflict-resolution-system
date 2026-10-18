namespace Main_Menu
{
    partial class LoadFileMenu
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
            this.components = new System.ComponentModel.Container();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.botonCargar = new System.Windows.Forms.Button();
            this.timerCerrar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(272, 64);
            this.txtBoxNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(224, 22);
            this.txtBoxNombre.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(44, 68);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(178, 16);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Introduce the name of the file:";
            // 
            // botonCargar
            // 
            this.botonCargar.Location = new System.Drawing.Point(155, 124);
            this.botonCargar.Margin = new System.Windows.Forms.Padding(4);
            this.botonCargar.Name = "botonCargar";
            this.botonCargar.Size = new System.Drawing.Size(205, 28);
            this.botonCargar.TabIndex = 2;
            this.botonCargar.Text = "Load";
            this.botonCargar.UseVisualStyleBackColor = true;
            this.botonCargar.Click += new System.EventHandler(this.botonCargar_Click);
            // 
            // timerCerrar
            // 
            this.timerCerrar.Tick += new System.EventHandler(this.timerCerrar_Tick);
            // 
            // CargarFichero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 183);
            this.Controls.Add(this.botonCargar);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.txtBoxNombre);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CargarFichero";
            this.Text = "LoadFileMenu";
            this.Load += new System.EventHandler(this.CargarFichero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button botonCargar;
        private System.Windows.Forms.Timer timerCerrar;
    }
}