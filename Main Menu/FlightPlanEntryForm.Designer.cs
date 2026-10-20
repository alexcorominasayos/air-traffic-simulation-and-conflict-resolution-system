namespace Main_Menu
{
    partial class FlightPlanEntryForm
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
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.addFlightPlanButton = new System.Windows.Forms.Button();
            this.transponderTextBox = new System.Windows.Forms.TextBox();
            this.transponderLabel = new System.Windows.Forms.Label();
            this.finalYTextBox = new System.Windows.Forms.TextBox();
            this.finalXTextBox = new System.Windows.Forms.TextBox();
            this.finalPositionLabel = new System.Windows.Forms.Label();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.speedLabel = new System.Windows.Forms.Label();
            this.initialYTextBox = new System.Windows.Forms.TextBox();
            this.initialXTextBox = new System.Windows.Forms.TextBox();
            this.initialPositionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.fuelTextBox = new System.Windows.Forms.TextBox();
            this.fuelLabel = new System.Windows.Forms.Label();
            this.duplicateIdErrorLabel = new System.Windows.Forms.Label();
            this.goBackButton = new System.Windows.Forms.Button();
            this.invalidSpeedErrorLabel = new System.Windows.Forms.Label();
            this.outOfCanvasErrorLabel = new System.Windows.Forms.Label();
            this.buttonResetTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(408, 82);
            this.instructionsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(113, 16);
            this.instructionsLabel.TabIndex = 54;
            this.instructionsLabel.Text = "Introduce the data";
            // 
            // addFlightPlanButton
            // 
            this.addFlightPlanButton.Location = new System.Drawing.Point(376, 479);
            this.addFlightPlanButton.Margin = new System.Windows.Forms.Padding(4);
            this.addFlightPlanButton.Name = "addFlightPlanButton";
            this.addFlightPlanButton.Size = new System.Drawing.Size(208, 28);
            this.addFlightPlanButton.TabIndex = 53;
            this.addFlightPlanButton.Text = "Add Flight Plan";
            this.addFlightPlanButton.UseVisualStyleBackColor = true;
            this.addFlightPlanButton.Click += new System.EventHandler(this.addFlightPlanButton_Click);
            // 
            // transponderTextBox
            // 
            this.transponderTextBox.Location = new System.Drawing.Point(400, 132);
            this.transponderTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.transponderTextBox.Name = "transponderTextBox";
            this.transponderTextBox.Size = new System.Drawing.Size(157, 22);
            this.transponderTextBox.TabIndex = 51;
            // 
            // transponderLabel
            // 
            this.transponderLabel.AutoSize = true;
            this.transponderLabel.Location = new System.Drawing.Point(310, 135);
            this.transponderLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.transponderLabel.Name = "transponderLabel";
            this.transponderLabel.Size = new System.Drawing.Size(85, 16);
            this.transponderLabel.TabIndex = 49;
            this.transponderLabel.Text = "Transponder";
            // 
            // finalYTextBox
            // 
            this.finalYTextBox.Location = new System.Drawing.Point(503, 308);
            this.finalYTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.finalYTextBox.Name = "finalYTextBox";
            this.finalYTextBox.Size = new System.Drawing.Size(60, 22);
            this.finalYTextBox.TabIndex = 45;
            // 
            // finalXTextBox
            // 
            this.finalXTextBox.Location = new System.Drawing.Point(400, 308);
            this.finalXTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.finalXTextBox.Name = "finalXTextBox";
            this.finalXTextBox.Size = new System.Drawing.Size(60, 22);
            this.finalXTextBox.TabIndex = 44;
            // 
            // finalPositionLabel
            // 
            this.finalPositionLabel.AutoSize = true;
            this.finalPositionLabel.Location = new System.Drawing.Point(303, 311);
            this.finalPositionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.finalPositionLabel.Name = "finalPositionLabel";
            this.finalPositionLabel.Size = new System.Drawing.Size(224, 16);
            this.finalPositionLabel.TabIndex = 43;
            this.finalPositionLabel.Text = "Final Position (                     ,                    )";
            // 
            // speedTextBox
            // 
            this.speedTextBox.Location = new System.Drawing.Point(400, 245);
            this.speedTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(157, 22);
            this.speedTextBox.TabIndex = 41;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(340, 248);
            this.speedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(55, 16);
            this.speedLabel.TabIndex = 39;
            this.speedLabel.Text = "Velocity";
            // 
            // initialYTextBox
            // 
            this.initialYTextBox.Location = new System.Drawing.Point(503, 185);
            this.initialYTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.initialYTextBox.Name = "initialYTextBox";
            this.initialYTextBox.Size = new System.Drawing.Size(60, 22);
            this.initialYTextBox.TabIndex = 35;
            // 
            // initialXTextBox
            // 
            this.initialXTextBox.Location = new System.Drawing.Point(400, 185);
            this.initialXTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.initialXTextBox.Name = "initialXTextBox";
            this.initialXTextBox.Size = new System.Drawing.Size(60, 22);
            this.initialXTextBox.TabIndex = 34;
            // 
            // initialPositionLabel
            // 
            this.initialPositionLabel.AutoSize = true;
            this.initialPositionLabel.Location = new System.Drawing.Point(305, 188);
            this.initialPositionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.initialPositionLabel.Name = "initialPositionLabel";
            this.initialPositionLabel.Size = new System.Drawing.Size(222, 16);
            this.initialPositionLabel.TabIndex = 32;
            this.initialPositionLabel.Text = "InitialPosition (                     ,                    )";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(429, 47);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(97, 16);
            this.titleLabel.TabIndex = 29;
            this.titleLabel.Text = "Add Flight Plan";
            this.titleLabel.Visible = false;
            // 
            // fuelTextBox
            // 
            this.fuelTextBox.Location = new System.Drawing.Point(400, 363);
            this.fuelTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.fuelTextBox.Name = "fuelTextBox";
            this.fuelTextBox.Size = new System.Drawing.Size(157, 22);
            this.fuelTextBox.TabIndex = 59;
            // 
            // fuelLabel
            // 
            this.fuelLabel.AutoSize = true;
            this.fuelLabel.Location = new System.Drawing.Point(362, 366);
            this.fuelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fuelLabel.Name = "fuelLabel";
            this.fuelLabel.Size = new System.Drawing.Size(33, 16);
            this.fuelLabel.TabIndex = 57;
            this.fuelLabel.Text = "Fuel";
            // 
            // duplicateIdErrorLabel
            // 
            this.duplicateIdErrorLabel.AutoSize = true;
            this.duplicateIdErrorLabel.Location = new System.Drawing.Point(231, 412);
            this.duplicateIdErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.duplicateIdErrorLabel.Name = "duplicateIdErrorLabel";
            this.duplicateIdErrorLabel.Size = new System.Drawing.Size(134, 16);
            this.duplicateIdErrorLabel.TabIndex = 60;
            this.duplicateIdErrorLabel.Text = "Same IDs Information";
            this.duplicateIdErrorLabel.Visible = false;
            // 
            // goBackButton
            // 
            this.goBackButton.Location = new System.Drawing.Point(13, 14);
            this.goBackButton.Margin = new System.Windows.Forms.Padding(4);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(100, 28);
            this.goBackButton.TabIndex = 61;
            this.goBackButton.Text = "Go Back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // invalidSpeedErrorLabel
            // 
            this.invalidSpeedErrorLabel.AutoSize = true;
            this.invalidSpeedErrorLabel.Location = new System.Drawing.Point(362, 412);
            this.invalidSpeedErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.invalidSpeedErrorLabel.Name = "invalidSpeedErrorLabel";
            this.invalidSpeedErrorLabel.Size = new System.Drawing.Size(179, 16);
            this.invalidSpeedErrorLabel.TabIndex = 62;
            this.invalidSpeedErrorLabel.Text = "Negative velocity Information";
            this.invalidSpeedErrorLabel.Visible = false;
            // 
            // outOfCanvasErrorLabel
            // 
            this.outOfCanvasErrorLabel.AutoSize = true;
            this.outOfCanvasErrorLabel.Location = new System.Drawing.Point(183, 412);
            this.outOfCanvasErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outOfCanvasErrorLabel.Name = "outOfCanvasErrorLabel";
            this.outOfCanvasErrorLabel.Size = new System.Drawing.Size(169, 16);
            this.outOfCanvasErrorLabel.TabIndex = 63;
            this.outOfCanvasErrorLabel.Text = "Positions Out of the Canvas";
            this.outOfCanvasErrorLabel.Visible = false;
            // 
            // buttonResetTimer
            // 
            this.buttonResetTimer.Tick += new System.EventHandler(this.buttonResetTimer_Tick);
            // 
            // FlightPlanEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 569);
            this.Controls.Add(this.outOfCanvasErrorLabel);
            this.Controls.Add(this.invalidSpeedErrorLabel);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.duplicateIdErrorLabel);
            this.Controls.Add(this.fuelTextBox);
            this.Controls.Add(this.fuelLabel);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.addFlightPlanButton);
            this.Controls.Add(this.transponderTextBox);
            this.Controls.Add(this.transponderLabel);
            this.Controls.Add(this.finalYTextBox);
            this.Controls.Add(this.finalXTextBox);
            this.Controls.Add(this.finalPositionLabel);
            this.Controls.Add(this.speedTextBox);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.initialYTextBox);
            this.Controls.Add(this.initialXTextBox);
            this.Controls.Add(this.initialPositionLabel);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FlightPlanEntryForm";
            this.Text = "Add Flight Plan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button addFlightPlanButton;
        private System.Windows.Forms.TextBox transponderTextBox;
        private System.Windows.Forms.Label transponderLabel;
        private System.Windows.Forms.TextBox finalYTextBox;
        private System.Windows.Forms.TextBox finalXTextBox;
        private System.Windows.Forms.Label finalPositionLabel;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TextBox initialYTextBox;
        private System.Windows.Forms.TextBox initialXTextBox;
        private System.Windows.Forms.Label initialPositionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox fuelTextBox;
        private System.Windows.Forms.Label fuelLabel;
        private System.Windows.Forms.Label duplicateIdErrorLabel;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Label invalidSpeedErrorLabel;
        private System.Windows.Forms.Label outOfCanvasErrorLabel;
        private System.Windows.Forms.Timer buttonResetTimer;
    }
}