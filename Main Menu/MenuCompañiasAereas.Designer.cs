namespace Main_Menu
{
    partial class MenuCompañiasAereas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.botonAñadir = new System.Windows.Forms.Button();
            this.botonborrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1203, 773);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // botonAñadir
            // 
            this.botonAñadir.Location = new System.Drawing.Point(662, 685);
            this.botonAñadir.Name = "botonAñadir";
            this.botonAñadir.Size = new System.Drawing.Size(112, 23);
            this.botonAñadir.TabIndex = 1;
            this.botonAñadir.Text = "Add Company";
            this.botonAñadir.UseVisualStyleBackColor = true;
            this.botonAñadir.Click += new System.EventHandler(this.botonAñadir_Click);
            // 
            // botonborrar
            // 
            this.botonborrar.Location = new System.Drawing.Point(386, 685);
            this.botonborrar.Name = "botonborrar";
            this.botonborrar.Size = new System.Drawing.Size(112, 23);
            this.botonborrar.TabIndex = 2;
            this.botonborrar.Text = "Delete Company";
            this.botonborrar.UseVisualStyleBackColor = true;
            this.botonborrar.Click += new System.EventHandler(this.botonborrar_Click);
            // 
            // MenuCompañiasAereas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 813);
            this.Controls.Add(this.botonborrar);
            this.Controls.Add(this.botonAñadir);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MenuCompañiasAereas";
            this.Text = "MenuCompañiasAereas";
            this.Load += new System.EventHandler(this.MenuCompañiasAereas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button botonAñadir;
        private System.Windows.Forms.Button botonborrar;
    }
}