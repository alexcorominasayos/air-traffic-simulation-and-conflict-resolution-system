namespace Main_Menu
{
    partial class AddCompanyForm
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
            this.addButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.logoPathTextBox = new System.Windows.Forms.TextBox();
            this.logoPathLabel = new System.Windows.Forms.Label();
            this.closeDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.identifierTextBox = new System.Windows.Forms.TextBox();
            this.identifierLabel = new System.Windows.Forms.Label();
            this.logoPathHintLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(148, 291);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add Company";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(109, 127);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(190, 124);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(190, 179);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex = 4;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(109, 182);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(53, 13);
            this.phoneLabel.TabIndex = 3;
            this.phoneLabel.Text = "Phone Nº";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(190, 205);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(100, 20);
            this.emailTextBox.TabIndex = 6;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(109, 208);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(26, 13);
            this.emailLabel.TabIndex = 5;
            this.emailLabel.Text = "Mail";
            // 
            // logoPathTextBox
            // 
            this.logoPathTextBox.Location = new System.Drawing.Point(190, 231);
            this.logoPathTextBox.Name = "logoPathTextBox";
            this.logoPathTextBox.Size = new System.Drawing.Size(100, 20);
            this.logoPathTextBox.TabIndex = 8;
            // 
            // logoPathLabel
            // 
            this.logoPathLabel.AutoSize = true;
            this.logoPathLabel.Location = new System.Drawing.Point(95, 234);
            this.logoPathLabel.Name = "logoPathLabel";
            this.logoPathLabel.Size = new System.Drawing.Size(84, 13);
            this.logoPathLabel.TabIndex = 7;
            this.logoPathLabel.Text = "Logo File Path*";
            // 
            // closeDelayTimer
            // 
            this.closeDelayTimer.Tick += new System.EventHandler(this.closeDelayTimer_Tick);
            // 
            // identifierTextBox
            // 
            this.identifierTextBox.Location = new System.Drawing.Point(190, 150);
            this.identifierTextBox.Name = "identifierTextBox";
            this.identifierTextBox.Size = new System.Drawing.Size(100, 20);
            this.identifierTextBox.TabIndex = 10;
            // 
            // identifierLabel
            // 
            this.identifierLabel.AutoSize = true;
            this.identifierLabel.Location = new System.Drawing.Point(109, 153);
            this.identifierLabel.Name = "identifierLabel";
            this.identifierLabel.Size = new System.Drawing.Size(47, 13);
            this.identifierLabel.TabIndex = 9;
            this.identifierLabel.Text = "Identifier";
            // 
            // logoPathHintLabel
            // 
            this.logoPathHintLabel.AutoSize = true;
            this.logoPathHintLabel.Location = new System.Drawing.Point(109, 351);
            this.logoPathHintLabel.Name = "logoPathHintLabel";
            this.logoPathHintLabel.Size = new System.Drawing.Size(160, 13);
            this.logoPathHintLabel.TabIndex = 11;
            this.logoPathHintLabel.Text = "*Quotes around the path are removed automatically";
            // 
            // AddCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.logoPathHintLabel);
            this.Controls.Add(this.identifierTextBox);
            this.Controls.Add(this.identifierLabel);
            this.Controls.Add(this.logoPathTextBox);
            this.Controls.Add(this.logoPathLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.addButton);
            this.Name = "AddCompanyForm";
            this.Text = "Add Company";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox logoPathTextBox;
        private System.Windows.Forms.Label logoPathLabel;
        private System.Windows.Forms.Timer closeDelayTimer;
        private System.Windows.Forms.TextBox identifierTextBox;
        private System.Windows.Forms.Label identifierLabel;
        private System.Windows.Forms.Label logoPathHintLabel;
    }
}