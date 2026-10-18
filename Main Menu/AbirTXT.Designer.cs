namespace Main_Menu
{
    partial class AbirTXT
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonSi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A file with the cahnges has veen created, do you want to open it?";
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(195, 85);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(75, 23);
            this.buttonNo.TabIndex = 1;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonSi
            // 
            this.buttonSi.Location = new System.Drawing.Point(86, 85);
            this.buttonSi.Name = "buttonSi";
            this.buttonSi.Size = new System.Drawing.Size(75, 23);
            this.buttonSi.TabIndex = 2;
            this.buttonSi.Text = "Yes";
            this.buttonSi.UseVisualStyleBackColor = true;
            this.buttonSi.Click += new System.EventHandler(this.buttonSi_Click);
            // 
            // AbirTXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 140);
            this.Controls.Add(this.buttonSi);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.label1);
            this.Name = "AbirTXT";
            this.Text = "Open file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonSi;
    }
}