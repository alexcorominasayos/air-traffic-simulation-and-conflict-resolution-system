namespace Main_Menu
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.presetsButton = new System.Windows.Forms.Button();
            this.simulateButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.welcomeBackLabel = new System.Windows.Forms.Label();
            this.loadFlightPlansButton = new System.Windows.Forms.Button();
            this.companiesButton = new System.Windows.Forms.Button();
            this.clearFlightPlansButton = new System.Windows.Forms.Button();
            this.playGameButton = new System.Windows.Forms.Button();
            this.addPointButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.titleLabel.Location = new System.Drawing.Point(385, 74);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(238, 52);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Main Menu";
            // 
            // presetsButton
            // 
            this.presetsButton.Location = new System.Drawing.Point(452, 286);
            this.presetsButton.Margin = new System.Windows.Forms.Padding(4);
            this.presetsButton.Name = "presetsButton";
            this.presetsButton.Size = new System.Drawing.Size(105, 28);
            this.presetsButton.TabIndex = 2;
            this.presetsButton.Text = "Pre-Sets";
            this.presetsButton.UseVisualStyleBackColor = true;
            this.presetsButton.Click += new System.EventHandler(this.presetsButton_Click);
            // 
            // simulateButton
            // 
            this.simulateButton.Location = new System.Drawing.Point(452, 321);
            this.simulateButton.Margin = new System.Windows.Forms.Padding(4);
            this.simulateButton.Name = "simulateButton";
            this.simulateButton.Size = new System.Drawing.Size(105, 28);
            this.simulateButton.TabIndex = 3;
            this.simulateButton.Text = "Simulate";
            this.simulateButton.UseVisualStyleBackColor = false;
            this.simulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(16, 474);
            this.logOutButton.Margin = new System.Windows.Forms.Padding(4);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(105, 28);
            this.logOutButton.TabIndex = 6;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(16, 511);
            this.closeButton.Margin = new System.Windows.Forms.Padding(4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(105, 28);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // welcomeBackLabel
            // 
            this.welcomeBackLabel.AutoSize = true;
            this.welcomeBackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeBackLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.welcomeBackLabel.Location = new System.Drawing.Point(411, 142);
            this.welcomeBackLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.welcomeBackLabel.Name = "welcomeBackLabel";
            this.welcomeBackLabel.Size = new System.Drawing.Size(188, 20);
            this.welcomeBackLabel.TabIndex = 9;
            this.welcomeBackLabel.Text = "Welcome back";
            // 
            // loadFlightPlansButton
            // 
            this.loadFlightPlansButton.Location = new System.Drawing.Point(452, 214);
            this.loadFlightPlansButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadFlightPlansButton.Name = "loadFlightPlansButton";
            this.loadFlightPlansButton.Size = new System.Drawing.Size(105, 28);
            this.loadFlightPlansButton.TabIndex = 10;
            this.loadFlightPlansButton.Text = "Load Flight Plans";
            this.loadFlightPlansButton.UseVisualStyleBackColor = true;
            this.loadFlightPlansButton.Click += new System.EventHandler(this.loadFlightPlansButton_Click);
            // 
            // companiesButton
            // 
            this.companiesButton.Location = new System.Drawing.Point(452, 357);
            this.companiesButton.Margin = new System.Windows.Forms.Padding(4);
            this.companiesButton.Name = "companiesButton";
            this.companiesButton.Size = new System.Drawing.Size(105, 28);
            this.companiesButton.TabIndex = 12;
            this.companiesButton.Text = "Companies";
            this.companiesButton.UseVisualStyleBackColor = true;
            this.companiesButton.Click += new System.EventHandler(this.companiesButton_Click);
            // 
            // clearFlightPlansButton
            // 
            this.clearFlightPlansButton.Location = new System.Drawing.Point(452, 250);
            this.clearFlightPlansButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearFlightPlansButton.Name = "clearFlightPlansButton";
            this.clearFlightPlansButton.Size = new System.Drawing.Size(105, 28);
            this.clearFlightPlansButton.TabIndex = 13;
            this.clearFlightPlansButton.Text = "Clear Flight Plans";
            this.clearFlightPlansButton.UseVisualStyleBackColor = true;
            this.clearFlightPlansButton.Click += new System.EventHandler(this.clearFlightPlansButton_Click);
            // 
            // playGameButton
            // 
            this.playGameButton.Location = new System.Drawing.Point(452, 393);
            this.playGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.playGameButton.Name = "playGameButton";
            this.playGameButton.Size = new System.Drawing.Size(105, 28);
            this.playGameButton.TabIndex = 14;
            this.playGameButton.Text = "Play a Game";
            this.playGameButton.UseVisualStyleBackColor = true;
            this.playGameButton.Click += new System.EventHandler(this.playGameButton_Click);
            // 
            // addPointButton
            // 
            this.addPointButton.Location = new System.Drawing.Point(452, 429);
            this.addPointButton.Margin = new System.Windows.Forms.Padding(4);
            this.addPointButton.Name = "addPointButton";
            this.addPointButton.Size = new System.Drawing.Size(105, 28);
            this.addPointButton.TabIndex = 15;
            this.addPointButton.Text = "Add Point";
            this.addPointButton.UseVisualStyleBackColor = true;
            this.addPointButton.Click += new System.EventHandler(this.addPointButton_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Main_Menu.Properties.Resources.Image_Background_Runway;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.addPointButton);
            this.Controls.Add(this.playGameButton);
            this.Controls.Add(this.clearFlightPlansButton);
            this.Controls.Add(this.companiesButton);
            this.Controls.Add(this.loadFlightPlansButton);
            this.Controls.Add(this.welcomeBackLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.simulateButton);
            this.Controls.Add(this.presetsButton);
            this.Controls.Add(this.titleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenuForm";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button presetsButton;
        private System.Windows.Forms.Button simulateButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label welcomeBackLabel;
        private System.Windows.Forms.Button loadFlightPlansButton;
        private System.Windows.Forms.Button companiesButton;
        private System.Windows.Forms.Button clearFlightPlansButton;
        private System.Windows.Forms.Button playGameButton;
        private System.Windows.Forms.Button addPointButton;
    }
}

