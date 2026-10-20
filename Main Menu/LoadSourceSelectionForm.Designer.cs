namespace Main_Menu
{
    partial class LoadSourceSelectionForm
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
            this.questionLabel = new System.Windows.Forms.Label();
            this.fileButton = new System.Windows.Forms.Button();
            this.manualButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.Location = new System.Drawing.Point(49, 44);
            this.questionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(263, 16);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "From where do you want to import the data?";
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(227, 91);
            this.fileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(100, 28);
            this.fileButton.TabIndex = 1;
            this.fileButton.Text = "File";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // manualButton
            // 
            this.manualButton.Location = new System.Drawing.Point(53, 91);
            this.manualButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.manualButton.Name = "manualButton";
            this.manualButton.Size = new System.Drawing.Size(100, 28);
            this.manualButton.TabIndex = 2;
            this.manualButton.Text = "Manual";
            this.manualButton.UseVisualStyleBackColor = true;
            this.manualButton.Click += new System.EventHandler(this.manualButton_Click);
            // 
            // LoadSourceSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 170);
            this.Controls.Add(this.manualButton);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.questionLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoadSourceSelectionForm";
            this.Text = "Import Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Button manualButton;
    }
}