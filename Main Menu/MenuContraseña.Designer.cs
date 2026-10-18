namespace Main_Menu
{
    partial class MenuContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuContraseña));
            this.LabelUser = new System.Windows.Forms.Label();
            this.labelContraseña = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.botonRegistrar = new System.Windows.Forms.Button();
            this.botonIniciarSesion = new System.Windows.Forms.Button();
            this.labelInformacion = new System.Windows.Forms.Label();
            this.botonCerrar = new System.Windows.Forms.Button();
            this.botonOlvCont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelUser
            // 
            this.LabelUser.AutoSize = true;
            this.LabelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUser.Location = new System.Drawing.Point(721, 242);
            this.LabelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelUser.Name = "LabelUser";
            this.LabelUser.Size = new System.Drawing.Size(53, 25);
            this.LabelUser.TabIndex = 0;
            this.LabelUser.Text = "User";
            this.LabelUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelContraseña
            // 
            this.labelContraseña.AutoSize = true;
            this.labelContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseña.Location = new System.Drawing.Point(675, 290);
            this.labelContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContraseña.Name = "labelContraseña";
            this.labelContraseña.Size = new System.Drawing.Size(98, 25);
            this.labelContraseña.TabIndex = 1;
            this.labelContraseña.Text = "Password";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.BackColor = System.Drawing.SystemColors.Control;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(625, 154);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(279, 46);
            this.labelTitulo.TabIndex = 2;
            this.labelTitulo.Text = "Conflict Solver";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(832, 242);
            this.textBoxUser.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(132, 22);
            this.textBoxUser.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(832, 290);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(132, 22);
            this.textBoxPassword.TabIndex = 4;
            // 
            // botonRegistrar
            // 
            this.botonRegistrar.Location = new System.Drawing.Point(695, 438);
            this.botonRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.botonRegistrar.Name = "botonRegistrar";
            this.botonRegistrar.Size = new System.Drawing.Size(113, 39);
            this.botonRegistrar.TabIndex = 5;
            this.botonRegistrar.Text = "Register";
            this.botonRegistrar.UseVisualStyleBackColor = true;
            this.botonRegistrar.Click += new System.EventHandler(this.botonRegistrar_Click);
            // 
            // botonIniciarSesion
            // 
            this.botonIniciarSesion.Location = new System.Drawing.Point(832, 438);
            this.botonIniciarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.botonIniciarSesion.Name = "botonIniciarSesion";
            this.botonIniciarSesion.Size = new System.Drawing.Size(113, 39);
            this.botonIniciarSesion.TabIndex = 6;
            this.botonIniciarSesion.Text = "Log-in";
            this.botonIniciarSesion.UseVisualStyleBackColor = true;
            this.botonIniciarSesion.Click += new System.EventHandler(this.botonIniciarSesion_Click);
            // 
            // labelInformacion
            // 
            this.labelInformacion.AutoSize = true;
            this.labelInformacion.Location = new System.Drawing.Point(695, 372);
            this.labelInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformacion.Name = "labelInformacion";
            this.labelInformacion.Size = new System.Drawing.Size(209, 16);
            this.labelInformacion.TabIndex = 7;
            this.labelInformacion.Text = "User not found or wrong password";
            this.labelInformacion.Visible = false;
            // 
            // botonCerrar
            // 
            this.botonCerrar.Location = new System.Drawing.Point(16, 510);
            this.botonCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(79, 30);
            this.botonCerrar.TabIndex = 8;
            this.botonCerrar.Text = "Close";
            this.botonCerrar.UseVisualStyleBackColor = true;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // botonOlvCont
            // 
            this.botonOlvCont.Location = new System.Drawing.Point(695, 485);
            this.botonOlvCont.Margin = new System.Windows.Forms.Padding(4);
            this.botonOlvCont.Name = "botonOlvCont";
            this.botonOlvCont.Size = new System.Drawing.Size(251, 30);
            this.botonOlvCont.TabIndex = 9;
            this.botonOlvCont.Text = "Forgot your password?";
            this.botonOlvCont.UseVisualStyleBackColor = true;
            this.botonOlvCont.Click += new System.EventHandler(this.botonOlvCont_Click);
            // 
            // MenuContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.botonOlvCont);
            this.Controls.Add(this.botonCerrar);
            this.Controls.Add(this.labelInformacion);
            this.Controls.Add(this.botonIniciarSesion);
            this.Controls.Add(this.botonRegistrar);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelContraseña);
            this.Controls.Add(this.LabelUser);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuContraseña";
            this.Text = "LogInMenu";
            this.Load += new System.EventHandler(this.MenuContraseña_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelUser;
        private System.Windows.Forms.Label labelContraseña;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button botonRegistrar;
        private System.Windows.Forms.Button botonIniciarSesion;
        private System.Windows.Forms.Label labelInformacion;
        private System.Windows.Forms.Button botonCerrar;
        private System.Windows.Forms.Button botonOlvCont;
    }
}