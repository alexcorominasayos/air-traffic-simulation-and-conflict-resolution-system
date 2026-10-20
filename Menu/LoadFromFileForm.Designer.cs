namespace Menu
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
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.closeDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.overwriteWarningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // instructionsLabel
            //
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(33, 30);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(259, 13);
            this.instructionsLabel.TabIndex = 0;
            this.instructionsLabel.Text = "Choose a simulation saved from the simulator (.txt):";
            //
            // loadButton
            //
            this.loadButton.Location = new System.Drawing.Point(116, 60);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(180, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Choose file and load...";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            //
            // closeDelayTimer
            //
            this.closeDelayTimer.Tick += new System.EventHandler(this.closeDelayTimer_Tick);
            //
            // overwriteWarningLabel
            //
            this.overwriteWarningLabel.AutoSize = true;
            this.overwriteWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overwriteWarningLabel.Location = new System.Drawing.Point(21, 100);
            this.overwriteWarningLabel.Name = "overwriteWarningLabel";
            this.overwriteWarningLabel.Size = new System.Drawing.Size(377, 13);
            this.overwriteWarningLabel.TabIndex = 2;
            this.overwriteWarningLabel.Text = "Loading one file when one has already been loaded, overwrites it";
            //
            // LoadFromFileForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 140);
            this.Controls.Add(this.overwriteWarningLabel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.instructionsLabel);
            this.Name = "LoadFromFileForm";
            this.Text = "Load File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Timer closeDelayTimer;
        private System.Windows.Forms.Label overwriteWarningLabel;
    }
}
