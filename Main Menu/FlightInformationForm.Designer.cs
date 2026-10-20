namespace Main_Menu
{
    partial class FlightInformationForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.speedUnitLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.fuelLabel = new System.Windows.Forms.Label();
            this.fuelTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(148, 326);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 18;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(167, 160);
            this.xTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(56, 22);
            this.xTextBox.TabIndex = 17;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(229, 160);
            this.yTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(55, 22);
            this.yTextBox.TabIndex = 16;
            // 
            // speedTextBox
            // 
            this.speedTextBox.Location = new System.Drawing.Point(167, 207);
            this.speedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(116, 22);
            this.speedTextBox.TabIndex = 15;
            // 
            // speedUnitLabel
            // 
            this.speedUnitLabel.AutoSize = true;
            this.speedUnitLabel.Location = new System.Drawing.Point(184, 213);
            this.speedUnitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.speedUnitLabel.Name = "speedUnitLabel";
            this.speedUnitLabel.Size = new System.Drawing.Size(0, 16);
            this.speedUnitLabel.TabIndex = 14;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(91, 213);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(58, 16);
            this.speedLabel.TabIndex = 13;
            this.speedLabel.Text = "Velocity:";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Location = new System.Drawing.Point(47, 166);
            this.positionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(102, 16);
            this.positionLabel.TabIndex = 12;
            this.positionLabel.Text = "Current position:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(128, 68);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(107, 16);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "Flight Information";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(125, 123);
            this.idLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(23, 16);
            this.idLabel.TabIndex = 21;
            this.idLabel.Text = "ID:";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(167, 117);
            this.idTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(116, 22);
            this.idTextBox.TabIndex = 22;
            // 
            // fuelLabel
            // 
            this.fuelLabel.AutoSize = true;
            this.fuelLabel.Location = new System.Drawing.Point(112, 258);
            this.fuelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fuelLabel.Name = "fuelLabel";
            this.fuelLabel.Size = new System.Drawing.Size(36, 16);
            this.fuelLabel.TabIndex = 23;
            this.fuelLabel.Text = "Fuel:";
            // 
            // fuelTextBox
            // 
            this.fuelTextBox.Location = new System.Drawing.Point(167, 255);
            this.fuelTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fuelTextBox.Name = "fuelTextBox";
            this.fuelTextBox.Size = new System.Drawing.Size(180, 22);
            this.fuelTextBox.TabIndex = 24;
            // 
            // FlightInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 394);
            this.Controls.Add(this.fuelTextBox);
            this.Controls.Add(this.fuelLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.speedTextBox);
            this.Controls.Add(this.speedUnitLabel);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FlightInformationForm";
            this.Text = "Flight Information";
            this.Load += new System.EventHandler(this.FlightInformationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Label speedUnitLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label fuelLabel;
        private System.Windows.Forms.TextBox fuelTextBox;
    }
}