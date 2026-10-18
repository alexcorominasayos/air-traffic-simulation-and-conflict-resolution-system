namespace Main_Menu
{
    partial class RecuperarContraseña
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxConfPaswrd = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.botonRecuperar = new System.Windows.Forms.Button();
            this.labelInformacion = new System.Windows.Forms.Label();
            this.timerCerrar = new System.Windows.Forms.Timer(this.components);
            this.labelTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Confirm Password";
            // 
            // textBoxConfPaswrd
            // 
            this.textBoxConfPaswrd.Location = new System.Drawing.Point(233, 225);
            this.textBoxConfPaswrd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxConfPaswrd.Name = "textBoxConfPaswrd";
            this.textBoxConfPaswrd.Size = new System.Drawing.Size(132, 22);
            this.textBoxConfPaswrd.TabIndex = 14;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(233, 193);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(132, 22);
            this.textBoxPassword.TabIndex = 13;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(233, 143);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(132, 22);
            this.textBoxMail.TabIndex = 12;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(127, 193);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(67, 16);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "Password";
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Location = new System.Drawing.Point(159, 143);
            this.labelCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(32, 16);
            this.labelCorreo.TabIndex = 10;
            this.labelCorreo.Text = "Mail";
            // 
            // botonRecuperar
            // 
            this.botonRecuperar.Location = new System.Drawing.Point(176, 342);
            this.botonRecuperar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonRecuperar.Name = "botonRecuperar";
            this.botonRecuperar.Size = new System.Drawing.Size(100, 28);
            this.botonRecuperar.TabIndex = 16;
            this.botonRecuperar.Text = "Recover";
            this.botonRecuperar.UseVisualStyleBackColor = true;
            this.botonRecuperar.Click += new System.EventHandler(this.botonRecuperar_Click);
            // 
            // labelInformacion
            // 
            this.labelInformacion.AutoSize = true;
            this.labelInformacion.Location = new System.Drawing.Point(147, 292);
            this.labelInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformacion.Name = "labelInformacion";
            this.labelInformacion.Size = new System.Drawing.Size(16, 16);
            this.labelInformacion.TabIndex = 17;
            this.labelInformacion.Text = "...";
            this.labelInformacion.Visible = false;
            // 
            // timerCerrar
            // 
            this.timerCerrar.Tick += new System.EventHandler(this.timerCerrar_Tick);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(108, 70);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(257, 31);
            this.labelTitulo.TabIndex = 18;
            this.labelTitulo.Text = "Password Recovery";
            // 
            // RecuperarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 415);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelInformacion);
            this.Controls.Add(this.botonRecuperar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxConfPaswrd);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelCorreo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RecuperarContraseña";
            this.Text = "PasswordRecoveryMenu";
            this.Load += new System.EventHandler(this.RecuperarContraseña_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxConfPaswrd;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.Button botonRecuperar;
        private System.Windows.Forms.Label labelInformacion;
        private System.Windows.Forms.Timer timerCerrar;
        private System.Windows.Forms.Label labelTitulo;
    }
}