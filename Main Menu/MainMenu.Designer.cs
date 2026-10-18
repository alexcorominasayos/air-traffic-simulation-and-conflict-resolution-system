namespace Main_Menu
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.botonPreSets = new System.Windows.Forms.Button();
            this.buttonSimulacion = new System.Windows.Forms.Button();
            this.botonAuto = new System.Windows.Forms.Button();
            this.botonAutoConf = new System.Windows.Forms.Button();
            this.botonLogOut = new System.Windows.Forms.Button();
            this.botonCerra = new System.Windows.Forms.Button();
            this.labelWelcomeBack = new System.Windows.Forms.Label();
            this.buttonLoadFP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTitulo.Location = new System.Drawing.Point(385, 74);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(238, 52);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Main Menu";
            this.labelTitulo.Click += new System.EventHandler(this.labelTitulo_Click);
            // 
            // botonPreSets
            // 
            this.botonPreSets.Location = new System.Drawing.Point(452, 286);
            this.botonPreSets.Margin = new System.Windows.Forms.Padding(4);
            this.botonPreSets.Name = "botonPreSets";
            this.botonPreSets.Size = new System.Drawing.Size(105, 28);
            this.botonPreSets.TabIndex = 2;
            this.botonPreSets.Text = "Pre-Sets";
            this.botonPreSets.UseVisualStyleBackColor = true;
            this.botonPreSets.Click += new System.EventHandler(this.botonPreSets_Click);
            // 
            // buttonSimulacion
            // 
            this.buttonSimulacion.Location = new System.Drawing.Point(452, 321);
            this.buttonSimulacion.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSimulacion.Name = "buttonSimulacion";
            this.buttonSimulacion.Size = new System.Drawing.Size(105, 28);
            this.buttonSimulacion.TabIndex = 3;
            this.buttonSimulacion.Text = "Simmulate";
            this.buttonSimulacion.UseVisualStyleBackColor = false;
            this.buttonSimulacion.Click += new System.EventHandler(this.buttonSimulacion_Click);
            // 
            // botonAuto
            // 
            this.botonAuto.Location = new System.Drawing.Point(913, 274);
            this.botonAuto.Margin = new System.Windows.Forms.Padding(4);
            this.botonAuto.Name = "botonAuto";
            this.botonAuto.Size = new System.Drawing.Size(100, 28);
            this.botonAuto.TabIndex = 4;
            this.botonAuto.Text = "auto";
            this.botonAuto.UseVisualStyleBackColor = true;
            this.botonAuto.Click += new System.EventHandler(this.botonAuto_Click);
            // 
            // botonAutoConf
            // 
            this.botonAutoConf.Location = new System.Drawing.Point(913, 321);
            this.botonAutoConf.Margin = new System.Windows.Forms.Padding(4);
            this.botonAutoConf.Name = "botonAutoConf";
            this.botonAutoConf.Size = new System.Drawing.Size(100, 28);
            this.botonAutoConf.TabIndex = 5;
            this.botonAutoConf.Text = "autoConf";
            this.botonAutoConf.UseVisualStyleBackColor = true;
            this.botonAutoConf.Click += new System.EventHandler(this.botonAutoConf_Click);
            // 
            // botonLogOut
            // 
            this.botonLogOut.Location = new System.Drawing.Point(16, 474);
            this.botonLogOut.Margin = new System.Windows.Forms.Padding(4);
            this.botonLogOut.Name = "botonLogOut";
            this.botonLogOut.Size = new System.Drawing.Size(105, 28);
            this.botonLogOut.TabIndex = 6;
            this.botonLogOut.Text = "Log out";
            this.botonLogOut.UseVisualStyleBackColor = true;
            this.botonLogOut.Click += new System.EventHandler(this.botonLogOut_Click);
            // 
            // botonCerra
            // 
            this.botonCerra.Location = new System.Drawing.Point(16, 511);
            this.botonCerra.Margin = new System.Windows.Forms.Padding(4);
            this.botonCerra.Name = "botonCerra";
            this.botonCerra.Size = new System.Drawing.Size(105, 28);
            this.botonCerra.TabIndex = 7;
            this.botonCerra.Text = "Close";
            this.botonCerra.UseVisualStyleBackColor = true;
            this.botonCerra.Click += new System.EventHandler(this.botonCerra_Click);
            // 
            // labelWelcomeBack
            // 
            this.labelWelcomeBack.AutoSize = true;
            this.labelWelcomeBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcomeBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelWelcomeBack.Location = new System.Drawing.Point(411, 142);
            this.labelWelcomeBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWelcomeBack.Name = "labelWelcomeBack";
            this.labelWelcomeBack.Size = new System.Drawing.Size(188, 20);
            this.labelWelcomeBack.TabIndex = 9;
            this.labelWelcomeBack.Text = "Welcome back, BRRRR";
            this.labelWelcomeBack.Click += new System.EventHandler(this.labelWelcomeBack_Click);
            // 
            // buttonLoadFP
            // 
            this.buttonLoadFP.Location = new System.Drawing.Point(452, 250);
            this.buttonLoadFP.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadFP.Name = "buttonLoadFP";
            this.buttonLoadFP.Size = new System.Drawing.Size(105, 28);
            this.buttonLoadFP.TabIndex = 10;
            this.buttonLoadFP.Text = "Load Flight Plans";
            this.buttonLoadFP.UseVisualStyleBackColor = true;
            this.buttonLoadFP.Click += new System.EventHandler(this.buttonLoadFP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Main_Menu.Properties.Resources.rgf;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.buttonLoadFP);
            this.Controls.Add(this.labelWelcomeBack);
            this.Controls.Add(this.botonCerra);
            this.Controls.Add(this.botonLogOut);
            this.Controls.Add(this.botonAutoConf);
            this.Controls.Add(this.botonAuto);
            this.Controls.Add(this.buttonSimulacion);
            this.Controls.Add(this.botonPreSets);
            this.Controls.Add(this.labelTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button botonPreSets;
        private System.Windows.Forms.Button buttonSimulacion;
        private System.Windows.Forms.Button botonAuto;
        private System.Windows.Forms.Button botonAutoConf;
        private System.Windows.Forms.Button botonLogOut;
        private System.Windows.Forms.Button botonCerra;
        private System.Windows.Forms.Label labelWelcomeBack;
        private System.Windows.Forms.Button buttonLoadFP;
    }
}

