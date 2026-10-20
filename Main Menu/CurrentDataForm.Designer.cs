namespace Main_Menu
{
    partial class CurrentDataForm
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
            this.flightDataGrid = new System.Windows.Forms.DataGridView();
            this.instructionsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flightDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // flightDataGrid
            // 
            this.flightDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightDataGrid.Location = new System.Drawing.Point(57, 25);
            this.flightDataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flightDataGrid.Name = "flightDataGrid";
            this.flightDataGrid.RowHeadersWidth = 51;
            this.flightDataGrid.RowTemplate.Height = 24;
            this.flightDataGrid.Size = new System.Drawing.Size(350, 220);
            this.flightDataGrid.TabIndex = 1;
            this.flightDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightDataGrid_CellContentClick);
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(54, 259);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(268, 16);
            this.instructionsLabel.TabIndex = 2;
            this.instructionsLabel.Text = "Click IDs to view distances between aircrafts";
            // 
            // CurrentDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 298);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.flightDataGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CurrentDataForm";
            this.Text = "Current Data";
            this.Load += new System.EventHandler(this.CurrentDataForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView flightDataGrid;
        private System.Windows.Forms.Label instructionsLabel;
    }
}