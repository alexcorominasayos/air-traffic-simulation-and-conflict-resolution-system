namespace Menu
{
    partial class SimulatorForm
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
            this.goBackButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.simulationPanel = new System.Windows.Forms.Panel();
            this.mouseCoordinatesLabel = new System.Windows.Forms.Label();
            this.automaticStartButton = new System.Windows.Forms.Button();
            this.automaticMoveLabel = new System.Windows.Forms.Label();
            this.automaticStopButton = new System.Windows.Forms.Button();
            this.automaticMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.dataButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.flightIdTextBox = new System.Windows.Forms.TextBox();
            this.newSpeedTextBox = new System.Windows.Forms.TextBox();
            this.flightIdLabel = new System.Windows.Forms.Label();
            this.newSpeedLabel = new System.Windows.Forms.Label();
            this.changeSpeedButton = new System.Windows.Forms.Button();
            this.changeSpeedResetTimer = new System.Windows.Forms.Timer(this.components);
            this.backwardButton = new System.Windows.Forms.Button();
            this.changeSpeedLabel = new System.Windows.Forms.Label();
            this.saveTextFileLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.viewInGoogleEarthButton = new System.Windows.Forms.Button();
            this.canvasMaxYLabel = new System.Windows.Forms.Label();
            this.canvasMaxXLabel = new System.Windows.Forms.Label();
            this.canvasOriginYLabel = new System.Windows.Forms.Label();
            this.canvasOriginXLabel = new System.Windows.Forms.Label();
            this.simulationSpeedLabel = new System.Windows.Forms.Label();
            this.simulationSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.simulationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationSpeedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // goBackButton
            // 
            this.goBackButton.Location = new System.Drawing.Point(10, 11);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(75, 23);
            this.goBackButton.TabIndex = 7;
            this.goBackButton.Text = "Go Back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Visible = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(79, 93);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 6;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(124, 66);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(80, 13);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Simulator Menu";
            // 
            // simulationPanel
            // 
            this.simulationPanel.BackColor = System.Drawing.Color.LightBlue;
            this.simulationPanel.BackgroundImage = global::Menu.Properties.Resources.Image_Background_Simulator;
            this.simulationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.simulationPanel.Controls.Add(this.mouseCoordinatesLabel);
            this.simulationPanel.Location = new System.Drawing.Point(325, 23);
            this.simulationPanel.Name = "simulationPanel";
            this.simulationPanel.Size = new System.Drawing.Size(900, 600);
            this.simulationPanel.TabIndex = 4;
            this.simulationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.simulationPanel_Paint);
            this.simulationPanel.MouseLeave += new System.EventHandler(this.simulationPanel_MouseLeave);
            this.simulationPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.simulationPanel_MouseMove);
            // 
            // mouseCoordinatesLabel
            // 
            this.mouseCoordinatesLabel.AutoSize = true;
            this.mouseCoordinatesLabel.BackColor = System.Drawing.Color.Transparent;
            this.mouseCoordinatesLabel.Location = new System.Drawing.Point(3, 578);
            this.mouseCoordinatesLabel.Name = "mouseCoordinatesLabel";
            this.mouseCoordinatesLabel.Size = new System.Drawing.Size(85, 13);
            this.mouseCoordinatesLabel.TabIndex = 25;
            this.mouseCoordinatesLabel.Text = "Position X and Y";
            // 
            // automaticStartButton
            // 
            this.automaticStartButton.Location = new System.Drawing.Point(127, 414);
            this.automaticStartButton.Name = "automaticStartButton";
            this.automaticStartButton.Size = new System.Drawing.Size(75, 23);
            this.automaticStartButton.TabIndex = 8;
            this.automaticStartButton.Text = "Start";
            this.automaticStartButton.UseVisualStyleBackColor = true;
            this.automaticStartButton.Click += new System.EventHandler(this.automaticStartButton_Click);
            // 
            // automaticMoveLabel
            // 
            this.automaticMoveLabel.AutoSize = true;
            this.automaticMoveLabel.Location = new System.Drawing.Point(124, 386);
            this.automaticMoveLabel.Name = "automaticMoveLabel";
            this.automaticMoveLabel.Size = new System.Drawing.Size(84, 13);
            this.automaticMoveLabel.TabIndex = 9;
            this.automaticMoveLabel.Text = "Automatic Move";
            // 
            // automaticStopButton
            // 
            this.automaticStopButton.Location = new System.Drawing.Point(127, 442);
            this.automaticStopButton.Name = "automaticStopButton";
            this.automaticStopButton.Size = new System.Drawing.Size(75, 23);
            this.automaticStopButton.TabIndex = 10;
            this.automaticStopButton.Text = "Stop";
            this.automaticStopButton.UseVisualStyleBackColor = true;
            this.automaticStopButton.Click += new System.EventHandler(this.automaticStopButton_Click);
            // 
            // automaticMoveTimer
            // 
            this.automaticMoveTimer.Tick += new System.EventHandler(this.automaticMoveTimer_Tick);
            // 
            // dataButton
            // 
            this.dataButton.Location = new System.Drawing.Point(175, 122);
            this.dataButton.Name = "dataButton";
            this.dataButton.Size = new System.Drawing.Size(75, 23);
            this.dataButton.TabIndex = 12;
            this.dataButton.Text = "Data";
            this.dataButton.UseVisualStyleBackColor = true;
            this.dataButton.Click += new System.EventHandler(this.dataButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(175, 93);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 23);
            this.restartButton.TabIndex = 13;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // flightIdTextBox
            // 
            this.flightIdTextBox.Location = new System.Drawing.Point(67, 227);
            this.flightIdTextBox.Name = "flightIdTextBox";
            this.flightIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.flightIdTextBox.TabIndex = 14;
            // 
            // newSpeedTextBox
            // 
            this.newSpeedTextBox.Location = new System.Drawing.Point(173, 227);
            this.newSpeedTextBox.Name = "newSpeedTextBox";
            this.newSpeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.newSpeedTextBox.TabIndex = 15;
            // 
            // flightIdLabel
            // 
            this.flightIdLabel.AutoSize = true;
            this.flightIdLabel.Location = new System.Drawing.Point(64, 196);
            this.flightIdLabel.Name = "flightIdLabel";
            this.flightIdLabel.Size = new System.Drawing.Size(21, 13);
            this.flightIdLabel.TabIndex = 16;
            this.flightIdLabel.Text = "ID:";
            // 
            // newSpeedLabel
            // 
            this.newSpeedLabel.AutoSize = true;
            this.newSpeedLabel.Location = new System.Drawing.Point(170, 196);
            this.newSpeedLabel.Name = "newSpeedLabel";
            this.newSpeedLabel.Size = new System.Drawing.Size(47, 13);
            this.newSpeedLabel.TabIndex = 17;
            this.newSpeedLabel.Text = "Velocity:";
            // 
            // changeSpeedButton
            // 
            this.changeSpeedButton.Location = new System.Drawing.Point(125, 258);
            this.changeSpeedButton.Name = "changeSpeedButton";
            this.changeSpeedButton.Size = new System.Drawing.Size(75, 23);
            this.changeSpeedButton.TabIndex = 18;
            this.changeSpeedButton.Text = "Change";
            this.changeSpeedButton.UseVisualStyleBackColor = true;
            this.changeSpeedButton.Click += new System.EventHandler(this.changeSpeedButton_Click);
            // 
            // changeSpeedResetTimer
            // 
            this.changeSpeedResetTimer.Tick += new System.EventHandler(this.changeSpeedResetTimer_Tick);
            // 
            // backwardButton
            // 
            this.backwardButton.Location = new System.Drawing.Point(79, 122);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(75, 23);
            this.backwardButton.TabIndex = 19;
            this.backwardButton.Text = "Backward";
            this.backwardButton.UseVisualStyleBackColor = true;
            this.backwardButton.Click += new System.EventHandler(this.backwardButton_Click);
            // 
            // changeSpeedLabel
            // 
            this.changeSpeedLabel.AutoSize = true;
            this.changeSpeedLabel.Location = new System.Drawing.Point(104, 174);
            this.changeSpeedLabel.Name = "changeSpeedLabel";
            this.changeSpeedLabel.Size = new System.Drawing.Size(125, 13);
            this.changeSpeedLabel.TabIndex = 20;
            this.changeSpeedLabel.Text = "Change Specific Velocity";
            // 
            // saveTextFileLabel
            // 
            this.saveTextFileLabel.AutoSize = true;
            this.saveTextFileLabel.Location = new System.Drawing.Point(90, 530);
            this.saveTextFileLabel.Name = "saveTextFileLabel";
            this.saveTextFileLabel.Size = new System.Drawing.Size(150, 13);
            this.saveTextFileLabel.TabIndex = 24;
            this.saveTextFileLabel.Text = "Save or export the simulation";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(46, 561);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 23;
            this.saveButton.Text = "Save...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // viewInGoogleEarthButton
            // 
            this.viewInGoogleEarthButton.Location = new System.Drawing.Point(123, 561);
            this.viewInGoogleEarthButton.Name = "viewInGoogleEarthButton";
            this.viewInGoogleEarthButton.Size = new System.Drawing.Size(149, 23);
            this.viewInGoogleEarthButton.TabIndex = 25;
            this.viewInGoogleEarthButton.Text = "Visualize in Google Earth...";
            this.viewInGoogleEarthButton.UseVisualStyleBackColor = true;
            this.viewInGoogleEarthButton.Click += new System.EventHandler(this.viewInGoogleEarthButton_Click);
            // 
            // canvasMaxYLabel
            // 
            this.canvasMaxYLabel.AutoSize = true;
            this.canvasMaxYLabel.BackColor = System.Drawing.Color.Transparent;
            this.canvasMaxYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canvasMaxYLabel.Location = new System.Drawing.Point(290, 606);
            this.canvasMaxYLabel.Name = "canvasMaxYLabel";
            this.canvasMaxYLabel.Size = new System.Drawing.Size(35, 17);
            this.canvasMaxYLabel.TabIndex = 26;
            this.canvasMaxYLabel.Text = "597";
            // 
            // canvasMaxXLabel
            // 
            this.canvasMaxXLabel.AutoSize = true;
            this.canvasMaxXLabel.BackColor = System.Drawing.Color.Transparent;
            this.canvasMaxXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canvasMaxXLabel.Location = new System.Drawing.Point(1195, 3);
            this.canvasMaxXLabel.Name = "canvasMaxXLabel";
            this.canvasMaxXLabel.Size = new System.Drawing.Size(35, 17);
            this.canvasMaxXLabel.TabIndex = 27;
            this.canvasMaxXLabel.Text = "897";
            // 
            // canvasOriginYLabel
            // 
            this.canvasOriginYLabel.AutoSize = true;
            this.canvasOriginYLabel.BackColor = System.Drawing.Color.Transparent;
            this.canvasOriginYLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canvasOriginYLabel.Location = new System.Drawing.Point(308, 23);
            this.canvasOriginYLabel.Name = "canvasOriginYLabel";
            this.canvasOriginYLabel.Size = new System.Drawing.Size(17, 17);
            this.canvasOriginYLabel.TabIndex = 28;
            this.canvasOriginYLabel.Text = "0";
            // 
            // canvasOriginXLabel
            // 
            this.canvasOriginXLabel.AutoSize = true;
            this.canvasOriginXLabel.BackColor = System.Drawing.Color.Transparent;
            this.canvasOriginXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canvasOriginXLabel.Location = new System.Drawing.Point(328, 3);
            this.canvasOriginXLabel.Name = "canvasOriginXLabel";
            this.canvasOriginXLabel.Size = new System.Drawing.Size(17, 17);
            this.canvasOriginXLabel.TabIndex = 29;
            this.canvasOriginXLabel.Text = "0";
            // 
            // simulationSpeedLabel
            // 
            this.simulationSpeedLabel.AutoSize = true;
            this.simulationSpeedLabel.Location = new System.Drawing.Point(104, 311);
            this.simulationSpeedLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.simulationSpeedLabel.Name = "simulationSpeedLabel";
            this.simulationSpeedLabel.Size = new System.Drawing.Size(124, 13);
            this.simulationSpeedLabel.TabIndex = 33;
            this.simulationSpeedLabel.Text = "Change General Velocity";
            // 
            // simulationSpeedTrackBar
            // 
            this.simulationSpeedTrackBar.Location = new System.Drawing.Point(79, 334);
            this.simulationSpeedTrackBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simulationSpeedTrackBar.Maximum = 750;
            this.simulationSpeedTrackBar.Minimum = -750;
            this.simulationSpeedTrackBar.Name = "simulationSpeedTrackBar";
            this.simulationSpeedTrackBar.Size = new System.Drawing.Size(171, 45);
            this.simulationSpeedTrackBar.TabIndex = 100;
            this.simulationSpeedTrackBar.Scroll += new System.EventHandler(this.simulationSpeedTrackBar_Scroll);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1247, 651);
            this.Controls.Add(this.simulationSpeedLabel);
            this.Controls.Add(this.simulationSpeedTrackBar);
            this.Controls.Add(this.canvasOriginXLabel);
            this.Controls.Add(this.canvasOriginYLabel);
            this.Controls.Add(this.canvasMaxXLabel);
            this.Controls.Add(this.canvasMaxYLabel);
            this.Controls.Add(this.viewInGoogleEarthButton);
            this.Controls.Add(this.saveTextFileLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.changeSpeedLabel);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.changeSpeedButton);
            this.Controls.Add(this.newSpeedLabel);
            this.Controls.Add(this.flightIdLabel);
            this.Controls.Add(this.newSpeedTextBox);
            this.Controls.Add(this.flightIdTextBox);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.dataButton);
            this.Controls.Add(this.automaticStopButton);
            this.Controls.Add(this.automaticMoveLabel);
            this.Controls.Add(this.automaticStartButton);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.simulationPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SimulatorForm";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.SimulatorForm_Load);
            this.simulationPanel.ResumeLayout(false);
            this.simulationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationSpeedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel simulationPanel;
        private System.Windows.Forms.Button automaticStartButton;
        private System.Windows.Forms.Label automaticMoveLabel;
        private System.Windows.Forms.Button automaticStopButton;
        private System.Windows.Forms.Timer automaticMoveTimer;
        private System.Windows.Forms.Button dataButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.TextBox flightIdTextBox;
        private System.Windows.Forms.TextBox newSpeedTextBox;
        private System.Windows.Forms.Label flightIdLabel;
        private System.Windows.Forms.Label newSpeedLabel;
        private System.Windows.Forms.Button changeSpeedButton;
        private System.Windows.Forms.Timer changeSpeedResetTimer;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Label changeSpeedLabel;
        private System.Windows.Forms.Label saveTextFileLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label mouseCoordinatesLabel;
        private System.Windows.Forms.Button viewInGoogleEarthButton;
        private System.Windows.Forms.Label canvasMaxYLabel;
        private System.Windows.Forms.Label canvasMaxXLabel;
        private System.Windows.Forms.Label canvasOriginYLabel;
        private System.Windows.Forms.Label canvasOriginXLabel;
        private System.Windows.Forms.Label simulationSpeedLabel;
        private System.Windows.Forms.TrackBar simulationSpeedTrackBar;
    }
}