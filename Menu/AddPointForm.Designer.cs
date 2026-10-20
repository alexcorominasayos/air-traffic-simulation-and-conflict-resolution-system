namespace Menu
{
    partial class AddPointForm
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
            this.addPointButton = new System.Windows.Forms.Button();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addPointButton
            // 
            this.addPointButton.Location = new System.Drawing.Point(363, 329);
            this.addPointButton.Margin = new System.Windows.Forms.Padding(4);
            this.addPointButton.Name = "addPointButton";
            this.addPointButton.Size = new System.Drawing.Size(100, 28);
            this.addPointButton.TabIndex = 7;
            this.addPointButton.Text = "Add Point";
            this.addPointButton.UseVisualStyleBackColor = true;
            this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Location = new System.Drawing.Point(399, 240);
            this.radiusTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.Size = new System.Drawing.Size(132, 22);
            this.radiusTextBox.TabIndex = 16;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(399, 190);
            this.yTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(132, 22);
            this.yTextBox.TabIndex = 17;
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(399, 142);
            this.xTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(132, 22);
            this.xTextBox.TabIndex = 18;
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(331, 246);
            this.radiusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(47, 16);
            this.radiusLabel.TabIndex = 19;
            this.radiusLabel.Text = "Radio:";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(331, 196);
            this.yLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(19, 16);
            this.yLabel.TabIndex = 20;
            this.yLabel.Text = "Y:";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(331, 145);
            this.xLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(18, 16);
            this.xLabel.TabIndex = 21;
            this.xLabel.Text = "X:";
            // 
            // AddPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.radiusLabel);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.radiusTextBox);
            this.Controls.Add(this.addPointButton);
            this.Name = "AddPointForm";
            this.Text = "Add Point";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addPointButton;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
    }
}