namespace Main_Menu
{
    partial class Information
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.XBox = new System.Windows.Forms.TextBox();
            this.YBox = new System.Windows.Forms.TextBox();
            this.SpeedBox = new System.Windows.Forms.TextBox();
            this.labelVelocidad = new System.Windows.Forms.Label();
            this.labelVel = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelTituloFP1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.labelFuel = new System.Windows.Forms.Label();
            this.FuelBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(148, 326);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 18;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // XBox
            // 
            this.XBox.Location = new System.Drawing.Point(167, 160);
            this.XBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(56, 22);
            this.XBox.TabIndex = 17;
            // 
            // YBox
            // 
            this.YBox.Location = new System.Drawing.Point(229, 160);
            this.YBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YBox.Name = "YBox";
            this.YBox.Size = new System.Drawing.Size(55, 22);
            this.YBox.TabIndex = 16;
            // 
            // SpeedBox
            // 
            this.SpeedBox.Location = new System.Drawing.Point(167, 207);
            this.SpeedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SpeedBox.Name = "SpeedBox";
            this.SpeedBox.Size = new System.Drawing.Size(116, 22);
            this.SpeedBox.TabIndex = 15;
            // 
            // labelVelocidad
            // 
            this.labelVelocidad.AutoSize = true;
            this.labelVelocidad.Location = new System.Drawing.Point(184, 213);
            this.labelVelocidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVelocidad.Name = "labelVelocidad";
            this.labelVelocidad.Size = new System.Drawing.Size(0, 16);
            this.labelVelocidad.TabIndex = 14;
            // 
            // labelVel
            // 
            this.labelVel.AutoSize = true;
            this.labelVel.Location = new System.Drawing.Point(91, 213);
            this.labelVel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVel.Name = "labelVel";
            this.labelVel.Size = new System.Drawing.Size(58, 16);
            this.labelVel.TabIndex = 13;
            this.labelVel.Text = "Velocity:";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Location = new System.Drawing.Point(47, 166);
            this.labelPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(102, 16);
            this.labelPosition.TabIndex = 12;
            this.labelPosition.Text = "Current position:";
            // 
            // labelTituloFP1
            // 
            this.labelTituloFP1.AutoSize = true;
            this.labelTituloFP1.Location = new System.Drawing.Point(128, 68);
            this.labelTituloFP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTituloFP1.Name = "labelTituloFP1";
            this.labelTituloFP1.Size = new System.Drawing.Size(107, 16);
            this.labelTituloFP1.TabIndex = 11;
            this.labelTituloFP1.Text = "Flight Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "ID:";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(167, 117);
            this.IDBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(116, 22);
            this.IDBox.TabIndex = 22;
            // 
            // labelFuel
            // 
            this.labelFuel.AutoSize = true;
            this.labelFuel.Location = new System.Drawing.Point(112, 258);
            this.labelFuel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFuel.Name = "labelFuel";
            this.labelFuel.Size = new System.Drawing.Size(36, 16);
            this.labelFuel.TabIndex = 23;
            this.labelFuel.Text = "Fuel:";
            // 
            // FuelBox
            // 
            this.FuelBox.Location = new System.Drawing.Point(167, 255);
            this.FuelBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FuelBox.Name = "FuelBox";
            this.FuelBox.Size = new System.Drawing.Size(116, 22);
            this.FuelBox.TabIndex = 24;
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 394);
            this.Controls.Add(this.FuelBox);
            this.Controls.Add(this.labelFuel);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.XBox);
            this.Controls.Add(this.YBox);
            this.Controls.Add(this.SpeedBox);
            this.Controls.Add(this.labelVelocidad);
            this.Controls.Add(this.labelVel);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.labelTituloFP1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Information";
            this.Text = "InformationMenu";
            this.Load += new System.EventHandler(this.Information_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox XBox;
        private System.Windows.Forms.TextBox YBox;
        private System.Windows.Forms.TextBox SpeedBox;
        private System.Windows.Forms.Label labelVelocidad;
        private System.Windows.Forms.Label labelVel;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelTituloFP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Label labelFuel;
        private System.Windows.Forms.TextBox FuelBox;
    }
}