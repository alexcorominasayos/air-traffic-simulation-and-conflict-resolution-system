namespace Main_Menu
{
    partial class ConflictSolverMenu
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
            this.botonSolveConfl = new System.Windows.Forms.Button();
            this.botonNoSolveConfl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Theres conflict between flights. Do you want to solve them?";
            // 
            // botonSolveConfl
            // 
            this.botonSolveConfl.Location = new System.Drawing.Point(88, 129);
            this.botonSolveConfl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonSolveConfl.Name = "botonSolveConfl";
            this.botonSolveConfl.Size = new System.Drawing.Size(100, 28);
            this.botonSolveConfl.TabIndex = 1;
            this.botonSolveConfl.Text = "Yes";
            this.botonSolveConfl.UseVisualStyleBackColor = true;
            this.botonSolveConfl.Click += new System.EventHandler(this.botonSolveConfl_Click);
            // 
            // botonNoSolveConfl
            // 
            this.botonNoSolveConfl.Location = new System.Drawing.Point(231, 129);
            this.botonNoSolveConfl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonNoSolveConfl.Name = "botonNoSolveConfl";
            this.botonNoSolveConfl.Size = new System.Drawing.Size(100, 28);
            this.botonNoSolveConfl.TabIndex = 2;
            this.botonNoSolveConfl.Text = "No";
            this.botonNoSolveConfl.UseVisualStyleBackColor = true;
            this.botonNoSolveConfl.Click += new System.EventHandler(this.botonNoSolveConfl_Click);
            // 
            // ConflictoSolverMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 222);
            this.Controls.Add(this.botonNoSolveConfl);
            this.Controls.Add(this.botonSolveConfl);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConflictoSolverMenu";
            this.Text = "ConflictSolverMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonSolveConfl;
        private System.Windows.Forms.Button botonNoSolveConfl;
    }
}