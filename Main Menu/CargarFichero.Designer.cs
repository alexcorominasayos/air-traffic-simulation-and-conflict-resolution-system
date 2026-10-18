namespace Main_Menu
{
    partial class CargarFichero
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(204, 52);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(169, 20);
            this.txtBoxNombre.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(33, 55);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(148, 13);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "Introduce the name of the file:";
            // 
            // botonCargar
            // 
            this.botonCargar.Location = new System.Drawing.Point(116, 101);
            this.botonCargar.Name = "botonCargar";
            this.botonCargar.Size = new System.Drawing.Size(154, 23);
            this.botonCargar.TabIndex = 2;
            this.botonCargar.Text = "Load";
            this.botonCargar.UseVisualStyleBackColor = true;
            this.botonCargar.Click += new System.EventHandler(this.botonCargar_Click);
            // 
            // timerCerrar
            // 
            this.timerCerrar.Tick += new System.EventHandler(this.timerCerrar_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Files available (for Pablo to know)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "FicheroFlightPlanList";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Prueba";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(377, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Loading one file when one has already been loaded, overwrites it";
            // 
            // CargarFichero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 234);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonCargar);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.txtBoxNombre);
            this.Name = "CargarFichero";
            this.Text = "FileLoadMenu";
            this.Load += new System.EventHandler(this.CargarFichero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button botonCargar;
        private System.Windows.Forms.Timer timerCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}