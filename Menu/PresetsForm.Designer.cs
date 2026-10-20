namespace Menu
{
    partial class PresetsForm
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
            this.acceptButton = new System.Windows.Forms.Button();
            this.autofillButton = new System.Windows.Forms.Button();
            this.cycleTimeTextBox = new System.Windows.Forms.TextBox();
            this.safetyDistanceTextBox = new System.Windows.Forms.TextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.cycleTimeLabel = new System.Windows.Forms.Label();
            this.safetyDistanceLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(271, 354);
            this.acceptButton.Margin = new System.Windows.Forms.Padding(4);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(100, 28);
            this.acceptButton.TabIndex = 15;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // autofillButton
            // 
            this.autofillButton.Location = new System.Drawing.Point(88, 354);
            this.autofillButton.Margin = new System.Windows.Forms.Padding(4);
            this.autofillButton.Name = "autofillButton";
            this.autofillButton.Size = new System.Drawing.Size(100, 28);
            this.autofillButton.TabIndex = 14;
            this.autofillButton.Text = "Autofill";
            this.autofillButton.UseVisualStyleBackColor = true;
            this.autofillButton.Click += new System.EventHandler(this.autofillButton_Click);
            // 
            // cycleTimeTextBox
            // 
            this.cycleTimeTextBox.Location = new System.Drawing.Point(204, 245);
            this.cycleTimeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.cycleTimeTextBox.Name = "cycleTimeTextBox";
            this.cycleTimeTextBox.Size = new System.Drawing.Size(132, 22);
            this.cycleTimeTextBox.TabIndex = 13;
            // 
            // safetyDistanceTextBox
            // 
            this.safetyDistanceTextBox.Location = new System.Drawing.Point(204, 185);
            this.safetyDistanceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.safetyDistanceTextBox.Name = "safetyDistanceTextBox";
            this.safetyDistanceTextBox.Size = new System.Drawing.Size(132, 22);
            this.safetyDistanceTextBox.TabIndex = 12;
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(131, 123);
            this.instructionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(151, 16);
            this.instructionsLabel.TabIndex = 11;
            this.instructionsLabel.Text = "Introduce the Information";
            // 
            // cycleTimeLabel
            // 
            this.cycleTimeLabel.AutoSize = true;
            this.cycleTimeLabel.Location = new System.Drawing.Point(79, 251);
            this.cycleTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cycleTimeLabel.Name = "cycleTimeLabel";
            this.cycleTimeLabel.Size = new System.Drawing.Size(44, 16);
            this.cycleTimeLabel.TabIndex = 10;
            this.cycleTimeLabel.Text = "Cycles";
            // 
            // safetyDistanceLabel
            // 
            this.safetyDistanceLabel.AutoSize = true;
            this.safetyDistanceLabel.Location = new System.Drawing.Point(32, 191);
            this.safetyDistanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.safetyDistanceLabel.Name = "safetyDistanceLabel";
            this.safetyDistanceLabel.Size = new System.Drawing.Size(91, 16);
            this.safetyDistanceLabel.TabIndex = 9;
            this.safetyDistanceLabel.Text = "Safe Distance";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(183, 81);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(59, 16);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Pre-Sets";
            // 
            // PresetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::Menu.Properties.Resources.Image_Background_Tower;
            this.ClientSize = new System.Drawing.Size(951, 450);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.autofillButton);
            this.Controls.Add(this.cycleTimeTextBox);
            this.Controls.Add(this.safetyDistanceTextBox);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.cycleTimeLabel);
            this.Controls.Add(this.safetyDistanceLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "PresetsForm";
            this.Text = "Pre-Sets";
            this.Load += new System.EventHandler(this.PresetsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button autofillButton;
        private System.Windows.Forms.TextBox cycleTimeTextBox;
        private System.Windows.Forms.TextBox safetyDistanceTextBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label cycleTimeLabel;
        private System.Windows.Forms.Label safetyDistanceLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}