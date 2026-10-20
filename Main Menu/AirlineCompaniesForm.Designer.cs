namespace Main_Menu
{
    partial class AirlineCompaniesForm
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
            this.companiesGrid = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.companiesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // companiesGrid
            // 
            this.companiesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companiesGrid.Location = new System.Drawing.Point(12, 12);
            this.companiesGrid.Name = "companiesGrid";
            this.companiesGrid.RowHeadersWidth = 51;
            this.companiesGrid.Size = new System.Drawing.Size(1203, 773);
            this.companiesGrid.TabIndex = 0;
            this.companiesGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.companiesGrid_CellClick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(662, 685);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(112, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add Company";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(386, 685);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete Company";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // AirlineCompaniesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 813);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.companiesGrid);
            this.Name = "AirlineCompaniesForm";
            this.Text = "Airline Companies";
            this.Load += new System.EventHandler(this.AirlineCompaniesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.companiesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView companiesGrid;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
    }
}