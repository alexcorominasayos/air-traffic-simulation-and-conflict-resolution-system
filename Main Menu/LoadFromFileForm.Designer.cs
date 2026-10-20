namespace Main_Menu
{
    partial class LoadFromFileForm
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
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.closeDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.exampleFilesTitleLabel = new System.Windows.Forms.Label();
            this.exampleFile1Label = new System.Windows.Forms.Label();
            this.exampleFile2Label = new System.Windows.Forms.Label();
            this.overwriteWarningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(204, 52);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(169, 20);
            this.fileNameTextBox.TabIndex = 0;
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(33, 55);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(148, 13);
            this.instructionsLabel.TabIndex = 1;
            this.instructionsLabel.Text = "Introduce the name of the file:";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(116, 101);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(154, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // closeDelayTimer
            // 
            this.closeDelayTimer.Tick += new System.EventHandler(this.closeDelayTimer_Tick);
            // 
            // exampleFilesTitleLabel
            // 
            this.exampleFilesTitleLabel.AutoSize = true;
            this.exampleFilesTitleLabel.Location = new System.Drawing.Point(105, 163);
            this.exampleFilesTitleLabel.Name = "exampleFilesTitleLabel";
            this.exampleFilesTitleLabel.Size = new System.Drawing.Size(165, 13);
            this.exampleFilesTitleLabel.TabIndex = 3;
            this.exampleFilesTitleLabel.Text = "Example files available";
            // 
            // exampleFile1Label
            // 
            this.exampleFile1Label.AutoSize = true;
            this.exampleFile1Label.Location = new System.Drawing.Point(105, 176);
            this.exampleFile1Label.Name = "exampleFile1Label";
            this.exampleFile1Label.Size = new System.Drawing.Size(104, 13);
            this.exampleFile1Label.TabIndex = 4;
            this.exampleFile1Label.Text = "FicheroFlightPlanList";
            // 
            // exampleFile2Label
            // 
            this.exampleFile2Label.AutoSize = true;
            this.exampleFile2Label.Location = new System.Drawing.Point(105, 189);
            this.exampleFile2Label.Name = "exampleFile2Label";
            this.exampleFile2Label.Size = new System.Drawing.Size(41, 13);
            this.exampleFile2Label.TabIndex = 6;
            this.exampleFile2Label.Text = "Prueba";
            // 
            // overwriteWarningLabel
            // 
            this.overwriteWarningLabel.AutoSize = true;
            this.overwriteWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overwriteWarningLabel.Location = new System.Drawing.Point(21, 127);
            this.overwriteWarningLabel.Name = "overwriteWarningLabel";
            this.overwriteWarningLabel.Size = new System.Drawing.Size(377, 13);
            this.overwriteWarningLabel.TabIndex = 7;
            this.overwriteWarningLabel.Text = "Loading one file when one has already been loaded, overwrites it";
            // 
            // LoadFromFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 234);
            this.Controls.Add(this.overwriteWarningLabel);
            this.Controls.Add(this.exampleFile2Label);
            this.Controls.Add(this.exampleFile1Label);
            this.Controls.Add(this.exampleFilesTitleLabel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Name = "LoadFromFileForm";
            this.Text = "Load File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Timer closeDelayTimer;
        private System.Windows.Forms.Label exampleFilesTitleLabel;
        private System.Windows.Forms.Label exampleFile1Label;
        private System.Windows.Forms.Label exampleFile2Label;
        private System.Windows.Forms.Label overwriteWarningLabel;
    }
}