namespace Main_Menu
{
    partial class AddPoint
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
            this.AddPointBtn = new System.Windows.Forms.Button();
            this.Radiotextbox = new System.Windows.Forms.TextBox();
            this.Ytextbox = new System.Windows.Forms.TextBox();
            this.Xtextbox = new System.Windows.Forms.TextBox();
            this.labelV2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddPointBtn
            // 
            this.AddPointBtn.Location = new System.Drawing.Point(363, 329);
            this.AddPointBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AddPointBtn.Name = "AddPointBtn";
            this.AddPointBtn.Size = new System.Drawing.Size(100, 28);
            this.AddPointBtn.TabIndex = 7;
            this.AddPointBtn.Text = "Add Point";
            this.AddPointBtn.UseVisualStyleBackColor = true;
            this.AddPointBtn.Click += new System.EventHandler(this.AddPointBtn_Click);
            // 
            // Radiotextbox
            // 
            this.Radiotextbox.Location = new System.Drawing.Point(399, 240);
            this.Radiotextbox.Margin = new System.Windows.Forms.Padding(4);
            this.Radiotextbox.Name = "Radiotextbox";
            this.Radiotextbox.Size = new System.Drawing.Size(132, 22);
            this.Radiotextbox.TabIndex = 16;
            // 
            // Ytextbox
            // 
            this.Ytextbox.Location = new System.Drawing.Point(399, 190);
            this.Ytextbox.Margin = new System.Windows.Forms.Padding(4);
            this.Ytextbox.Name = "Ytextbox";
            this.Ytextbox.Size = new System.Drawing.Size(132, 22);
            this.Ytextbox.TabIndex = 17;
            // 
            // Xtextbox
            // 
            this.Xtextbox.Location = new System.Drawing.Point(399, 142);
            this.Xtextbox.Margin = new System.Windows.Forms.Padding(4);
            this.Xtextbox.Name = "Xtextbox";
            this.Xtextbox.Size = new System.Drawing.Size(132, 22);
            this.Xtextbox.TabIndex = 18;
            // 
            // labelV2
            // 
            this.labelV2.AutoSize = true;
            this.labelV2.Location = new System.Drawing.Point(331, 246);
            this.labelV2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelV2.Name = "labelV2";
            this.labelV2.Size = new System.Drawing.Size(47, 16);
            this.labelV2.TabIndex = 19;
            this.labelV2.Text = "Radio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 196);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Y:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "X:";
            // 
            // AddPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelV2);
            this.Controls.Add(this.Xtextbox);
            this.Controls.Add(this.Ytextbox);
            this.Controls.Add(this.Radiotextbox);
            this.Controls.Add(this.AddPointBtn);
            this.Name = "AddPoint";
            this.Text = "Add Point";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddPointBtn;
        private System.Windows.Forms.TextBox Radiotextbox;
        private System.Windows.Forms.TextBox Ytextbox;
        private System.Windows.Forms.TextBox Xtextbox;
        private System.Windows.Forms.Label labelV2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}