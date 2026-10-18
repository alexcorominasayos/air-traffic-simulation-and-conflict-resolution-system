namespace Main_Menu
{
    partial class RegistrarUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxConfPaswrd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInformacion = new System.Windows.Forms.Label();
            this.timerUserReg = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(180, 169);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(36, 16);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "User";
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Location = new System.Drawing.Point(180, 310);
            this.labelCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(32, 16);
            this.labelCorreo.TabIndex = 2;
            this.labelCorreo.Text = "Mail";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(148, 219);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(67, 16);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(255, 169);
            this.textBoxUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(132, 22);
            this.textBoxUser.TabIndex = 4;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(255, 310);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(132, 22);
            this.textBoxMail.TabIndex = 5;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(255, 219);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(132, 22);
            this.textBoxPassword.TabIndex = 6;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(196, 428);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(116, 28);
            this.buttonRegister.TabIndex = 7;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxConfPaswrd
            // 
            this.textBoxConfPaswrd.Location = new System.Drawing.Point(255, 251);
            this.textBoxConfPaswrd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxConfPaswrd.Name = "textBoxConfPaswrd";
            this.textBoxConfPaswrd.Size = new System.Drawing.Size(132, 22);
            this.textBoxConfPaswrd.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Confirm Password";
            // 
            // labelInformacion
            // 
            this.labelInformacion.AutoSize = true;
            this.labelInformacion.Location = new System.Drawing.Point(97, 377);
            this.labelInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformacion.Name = "labelInformacion";
            this.labelInformacion.Size = new System.Drawing.Size(16, 16);
            this.labelInformacion.TabIndex = 11;
            this.labelInformacion.Text = "...";
            this.labelInformacion.Visible = false;
            // 
            // timerUserReg
            // 
            this.timerUserReg.Tick += new System.EventHandler(this.timerUserReg_Tick);
            // 
            // RegistrarUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 489);
            this.Controls.Add(this.labelInformacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxConfPaswrd);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelCorreo);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RegistrarUser";
            this.Text = "RegisterMenu";
            this.Load += new System.EventHandler(this.RegistrarUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxConfPaswrd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelInformacion;
        private System.Windows.Forms.Timer timerUserReg;
    }
}