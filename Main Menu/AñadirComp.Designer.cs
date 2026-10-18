namespace Main_Menu
{
    partial class AñadirComp
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
            this.botonAdd = new System.Windows.Forms.Button();
            this.labelNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.textMail = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.textFoto = new System.Windows.Forms.TextBox();
            this.labelDirF = new System.Windows.Forms.Label();
            this.timerCerrar = new System.Windows.Forms.Timer(this.components);
            this.txtID = new System.Windows.Forms.TextBox();
            this.Identificator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botonAdd
            // 
            this.botonAdd.Location = new System.Drawing.Point(148, 291);
            this.botonAdd.Name = "botonAdd";
            this.botonAdd.Size = new System.Drawing.Size(75, 23);
            this.botonAdd.TabIndex = 0;
            this.botonAdd.Text = "m ";
            this.botonAdd.UseVisualStyleBackColor = true;
            this.botonAdd.Click += new System.EventHandler(this.botonAdd_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(109, 127);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(35, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Name";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(190, 124);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(190, 179);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 20);
            this.txtNum.TabIndex = 4;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Location = new System.Drawing.Point(109, 182);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(53, 13);
            this.labelNumero.TabIndex = 3;
            this.labelNumero.Text = "Phone Nº";
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(190, 205);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(100, 20);
            this.textMail.TabIndex = 6;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(109, 208);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(26, 13);
            this.labelMail.TabIndex = 5;
            this.labelMail.Text = "Mail";
            // 
            // textFoto
            // 
            this.textFoto.Location = new System.Drawing.Point(190, 231);
            this.textFoto.Name = "textFoto";
            this.textFoto.Size = new System.Drawing.Size(100, 20);
            this.textFoto.TabIndex = 8;
            // 
            // labelDirF
            // 
            this.labelDirF.AutoSize = true;
            this.labelDirF.Location = new System.Drawing.Point(95, 234);
            this.labelDirF.Name = "labelDirF";
            this.labelDirF.Size = new System.Drawing.Size(84, 13);
            this.labelDirF.TabIndex = 7;
            this.labelDirF.Text = "Photo Direction*";
            // 
            // timerCerrar
            // 
            this.timerCerrar.Tick += new System.EventHandler(this.timerCerrar_Tick);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(190, 150);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 10;
            // 
            // Identificator
            // 
            this.Identificator.AutoSize = true;
            this.Identificator.Location = new System.Drawing.Point(109, 153);
            this.Identificator.Name = "Identificator";
            this.Identificator.Size = new System.Drawing.Size(47, 13);
            this.Identificator.TabIndex = 9;
            this.Identificator.Text = "Identifier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "*Delete the \" \" from the directory";
            // 
            // AñadirComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.Identificator);
            this.Controls.Add(this.textFoto);
            this.Controls.Add(this.labelDirF);
            this.Controls.Add(this.textMail);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.botonAdd);
            this.Name = "AñadirComp";
            this.Text = "AñadirComp";
            this.Load += new System.EventHandler(this.AñadirComp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonAdd;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.TextBox textFoto;
        private System.Windows.Forms.Label labelDirF;
        private System.Windows.Forms.Timer timerCerrar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label Identificator;
        private System.Windows.Forms.Label label1;
    }
}