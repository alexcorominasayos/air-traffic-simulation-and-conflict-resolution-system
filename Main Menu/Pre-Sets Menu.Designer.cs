namespace Main_Menu
{
    partial class preSetsMenu
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
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonAutofill = new System.Windows.Forms.Button();
            this.txtBoxCicle = new System.Windows.Forms.TextBox();
            this.txtBoxSafeDist = new System.Windows.Forms.TextBox();
            this.labelInformacion = new System.Windows.Forms.Label();
            this.LabelCiclos = new System.Windows.Forms.Label();
            this.LabelDistanciaSeg = new System.Windows.Forms.Label();
            this.labelPreSets = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(271, 354);
            this.buttonAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(100, 28);
            this.buttonAceptar.TabIndex = 15;
            this.buttonAceptar.Text = "Accept";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonAutofill
            // 
            this.buttonAutofill.Location = new System.Drawing.Point(88, 354);
            this.buttonAutofill.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAutofill.Name = "buttonAutofill";
            this.buttonAutofill.Size = new System.Drawing.Size(100, 28);
            this.buttonAutofill.TabIndex = 14;
            this.buttonAutofill.Text = "Autofill";
            this.buttonAutofill.UseVisualStyleBackColor = true;
            this.buttonAutofill.Click += new System.EventHandler(this.buttonAutofill_Click);
            // 
            // txtBoxCicle
            // 
            this.txtBoxCicle.Location = new System.Drawing.Point(204, 245);
            this.txtBoxCicle.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxCicle.Name = "txtBoxCicle";
            this.txtBoxCicle.Size = new System.Drawing.Size(132, 22);
            this.txtBoxCicle.TabIndex = 13;
            // 
            // txtBoxSafeDist
            // 
            this.txtBoxSafeDist.Location = new System.Drawing.Point(204, 185);
            this.txtBoxSafeDist.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxSafeDist.Name = "txtBoxSafeDist";
            this.txtBoxSafeDist.Size = new System.Drawing.Size(132, 22);
            this.txtBoxSafeDist.TabIndex = 12;
            // 
            // labelInformacion
            // 
            this.labelInformacion.AutoSize = true;
            this.labelInformacion.Location = new System.Drawing.Point(131, 123);
            this.labelInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformacion.Name = "labelInformacion";
            this.labelInformacion.Size = new System.Drawing.Size(151, 16);
            this.labelInformacion.TabIndex = 11;
            this.labelInformacion.Text = "Introduce the Information";
            // 
            // LabelCiclos
            // 
            this.LabelCiclos.AutoSize = true;
            this.LabelCiclos.Location = new System.Drawing.Point(79, 251);
            this.LabelCiclos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelCiclos.Name = "LabelCiclos";
            this.LabelCiclos.Size = new System.Drawing.Size(44, 16);
            this.LabelCiclos.TabIndex = 10;
            this.LabelCiclos.Text = "Cicles";
            // 
            // LabelDistanciaSeg
            // 
            this.LabelDistanciaSeg.AutoSize = true;
            this.LabelDistanciaSeg.Location = new System.Drawing.Point(32, 191);
            this.LabelDistanciaSeg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelDistanciaSeg.Name = "LabelDistanciaSeg";
            this.LabelDistanciaSeg.Size = new System.Drawing.Size(91, 16);
            this.LabelDistanciaSeg.TabIndex = 9;
            this.LabelDistanciaSeg.Text = "Safe Distance";
            // 
            // labelPreSets
            // 
            this.labelPreSets.AutoSize = true;
            this.labelPreSets.Location = new System.Drawing.Point(183, 81);
            this.labelPreSets.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPreSets.Name = "labelPreSets";
            this.labelPreSets.Size = new System.Drawing.Size(59, 16);
            this.labelPreSets.TabIndex = 8;
            this.labelPreSets.Text = "Pre-Sets";
            // 
            // preSetsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::Main_Menu.Properties.Resources.Image_Background_Tower;
            this.ClientSize = new System.Drawing.Size(951, 450);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.buttonAutofill);
            this.Controls.Add(this.txtBoxCicle);
            this.Controls.Add(this.txtBoxSafeDist);
            this.Controls.Add(this.labelInformacion);
            this.Controls.Add(this.LabelCiclos);
            this.Controls.Add(this.LabelDistanciaSeg);
            this.Controls.Add(this.labelPreSets);
            this.Name = "preSetsMenu";
            this.Text = "Pre-SetsMenu";
            this.Load += new System.EventHandler(this.preSetsMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonAutofill;
        private System.Windows.Forms.TextBox txtBoxCicle;
        private System.Windows.Forms.TextBox txtBoxSafeDist;
        private System.Windows.Forms.Label labelInformacion;
        private System.Windows.Forms.Label LabelCiclos;
        private System.Windows.Forms.Label LabelDistanciaSeg;
        private System.Windows.Forms.Label labelPreSets;
    }
}