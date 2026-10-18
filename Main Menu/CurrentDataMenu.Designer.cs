namespace Main_Menu
{
    partial class CurrentDataMenu
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
            this.fpdataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fpdataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // fpdataGrid
            // 
            this.fpdataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fpdataGrid.Location = new System.Drawing.Point(57, 25);
            this.fpdataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fpdataGrid.Name = "fpdataGrid";
            this.fpdataGrid.RowHeadersWidth = 51;
            this.fpdataGrid.RowTemplate.Height = 24;
            this.fpdataGrid.Size = new System.Drawing.Size(350, 220);
            this.fpdataGrid.TabIndex = 1;
            this.fpdataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fpdataGrid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click IDs to view distances between aircrafts";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CurrentDataMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 298);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fpdataGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CurrentDataMenu";
            this.Text = "CurrentDataMenu";
            this.Load += new System.EventHandler(this.CurrentDataMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpdataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView fpdataGrid;
        private System.Windows.Forms.Label label1;
    }
}