namespace Main_Menu
{
    partial class fpMenu
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
            this.labeLInformacion = new System.Windows.Forms.Label();
            this.botonAceptarFPs = new System.Windows.Forms.Button();
            this.txtboxTransponderFP1 = new System.Windows.Forms.TextBox();
            this.labelNombreFP1 = new System.Windows.Forms.Label();
            this.txtboxCoordFinYFP1 = new System.Windows.Forms.TextBox();
            this.txtboxCoordFinXFP1 = new System.Windows.Forms.TextBox();
            this.labelCoordFinFP1 = new System.Windows.Forms.Label();
            this.txtboxVelocidadFP1 = new System.Windows.Forms.TextBox();
            this.labelVelocidadFP1 = new System.Windows.Forms.Label();
            this.txtboxCoordInicialYFP1 = new System.Windows.Forms.TextBox();
            this.txtboxCoordInicialXFP1 = new System.Windows.Forms.TextBox();
            this.CoordInicialFP1 = new System.Windows.Forms.Label();
            this.labelTituloAddFP = new System.Windows.Forms.Label();
            this.textBoxComb1 = new System.Windows.Forms.TextBox();
            this.labelComb2 = new System.Windows.Forms.Label();
            this.mismasIDsInformacion = new System.Windows.Forms.Label();
            this.buttonGoBack = new System.Windows.Forms.Button();
            this.NegativeVelocityInfo = new System.Windows.Forms.Label();
            this.PositionsOutCanvasInfo = new System.Windows.Forms.Label();
            this.timerBotones = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labeLInformacion
            // 
            this.labeLInformacion.AutoSize = true;
            this.labeLInformacion.Location = new System.Drawing.Point(408, 82);
            this.labeLInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labeLInformacion.Name = "labeLInformacion";
            this.labeLInformacion.Size = new System.Drawing.Size(113, 16);
            this.labeLInformacion.TabIndex = 54;
            this.labeLInformacion.Text = "Introduce the data";
            // 
            // botonAceptarFPs
            // 
            this.botonAceptarFPs.Location = new System.Drawing.Point(376, 479);
            this.botonAceptarFPs.Margin = new System.Windows.Forms.Padding(4);
            this.botonAceptarFPs.Name = "botonAceptarFPs";
            this.botonAceptarFPs.Size = new System.Drawing.Size(208, 28);
            this.botonAceptarFPs.TabIndex = 53;
            this.botonAceptarFPs.Text = "Add FLight Plan";
            this.botonAceptarFPs.UseVisualStyleBackColor = true;
            this.botonAceptarFPs.Click += new System.EventHandler(this.botonAceptarFPs_Click);
            // 
            // txtboxTransponderFP1
            // 
            this.txtboxTransponderFP1.Location = new System.Drawing.Point(400, 132);
            this.txtboxTransponderFP1.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxTransponderFP1.Name = "txtboxTransponderFP1";
            this.txtboxTransponderFP1.Size = new System.Drawing.Size(157, 22);
            this.txtboxTransponderFP1.TabIndex = 51;
            // 
            // labelNombreFP1
            // 
            this.labelNombreFP1.AutoSize = true;
            this.labelNombreFP1.Location = new System.Drawing.Point(310, 135);
            this.labelNombreFP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombreFP1.Name = "labelNombreFP1";
            this.labelNombreFP1.Size = new System.Drawing.Size(85, 16);
            this.labelNombreFP1.TabIndex = 49;
            this.labelNombreFP1.Text = "Transponder";
            // 
            // txtboxCoordFinYFP1
            // 
            this.txtboxCoordFinYFP1.Location = new System.Drawing.Point(503, 308);
            this.txtboxCoordFinYFP1.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxCoordFinYFP1.Name = "txtboxCoordFinYFP1";
            this.txtboxCoordFinYFP1.Size = new System.Drawing.Size(60, 22);
            this.txtboxCoordFinYFP1.TabIndex = 45;
            // 
            // txtboxCoordFinXFP1
            // 
            this.txtboxCoordFinXFP1.Location = new System.Drawing.Point(400, 308);
            this.txtboxCoordFinXFP1.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxCoordFinXFP1.Name = "txtboxCoordFinXFP1";
            this.txtboxCoordFinXFP1.Size = new System.Drawing.Size(60, 22);
            this.txtboxCoordFinXFP1.TabIndex = 44;
            // 
            // labelCoordFinFP1
            // 
            this.labelCoordFinFP1.AutoSize = true;
            this.labelCoordFinFP1.Location = new System.Drawing.Point(303, 311);
            this.labelCoordFinFP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCoordFinFP1.Name = "labelCoordFinFP1";
            this.labelCoordFinFP1.Size = new System.Drawing.Size(224, 16);
            this.labelCoordFinFP1.TabIndex = 43;
            this.labelCoordFinFP1.Text = "Final Position (                     ,                    )";
            // 
            // txtboxVelocidadFP1
            // 
            this.txtboxVelocidadFP1.Location = new System.Drawing.Point(400, 245);
            this.txtboxVelocidadFP1.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxVelocidadFP1.Name = "txtboxVelocidadFP1";
            this.txtboxVelocidadFP1.Size = new System.Drawing.Size(157, 22);
            this.txtboxVelocidadFP1.TabIndex = 41;
            // 
            // labelVelocidadFP1
            // 
            this.labelVelocidadFP1.AutoSize = true;
            this.labelVelocidadFP1.Location = new System.Drawing.Point(340, 248);
            this.labelVelocidadFP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVelocidadFP1.Name = "labelVelocidadFP1";
            this.labelVelocidadFP1.Size = new System.Drawing.Size(55, 16);
            this.labelVelocidadFP1.TabIndex = 39;
            this.labelVelocidadFP1.Text = "Velocity";
            // 
            // txtboxCoordInicialYFP1
            // 
            this.txtboxCoordInicialYFP1.Location = new System.Drawing.Point(503, 185);
            this.txtboxCoordInicialYFP1.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxCoordInicialYFP1.Name = "txtboxCoordInicialYFP1";
            this.txtboxCoordInicialYFP1.Size = new System.Drawing.Size(60, 22);
            this.txtboxCoordInicialYFP1.TabIndex = 35;
            // 
            // txtboxCoordInicialXFP1
            // 
            this.txtboxCoordInicialXFP1.Location = new System.Drawing.Point(400, 185);
            this.txtboxCoordInicialXFP1.Margin = new System.Windows.Forms.Padding(4);
            this.txtboxCoordInicialXFP1.Name = "txtboxCoordInicialXFP1";
            this.txtboxCoordInicialXFP1.Size = new System.Drawing.Size(60, 22);
            this.txtboxCoordInicialXFP1.TabIndex = 34;
            // 
            // CoordInicialFP1
            // 
            this.CoordInicialFP1.AutoSize = true;
            this.CoordInicialFP1.Location = new System.Drawing.Point(305, 188);
            this.CoordInicialFP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CoordInicialFP1.Name = "CoordInicialFP1";
            this.CoordInicialFP1.Size = new System.Drawing.Size(222, 16);
            this.CoordInicialFP1.TabIndex = 32;
            this.CoordInicialFP1.Text = "InitialPosition (                     ,                    )";
            // 
            // labelTituloAddFP
            // 
            this.labelTituloAddFP.AutoSize = true;
            this.labelTituloAddFP.Location = new System.Drawing.Point(429, 47);
            this.labelTituloAddFP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTituloAddFP.Name = "labelTituloAddFP";
            this.labelTituloAddFP.Size = new System.Drawing.Size(97, 16);
            this.labelTituloAddFP.TabIndex = 29;
            this.labelTituloAddFP.Text = "Add Flight Plan";
            this.labelTituloAddFP.Visible = false;
            // 
            // textBoxComb1
            // 
            this.textBoxComb1.Location = new System.Drawing.Point(400, 363);
            this.textBoxComb1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxComb1.Name = "textBoxComb1";
            this.textBoxComb1.Size = new System.Drawing.Size(157, 22);
            this.textBoxComb1.TabIndex = 59;
            // 
            // labelComb2
            // 
            this.labelComb2.AutoSize = true;
            this.labelComb2.Location = new System.Drawing.Point(362, 366);
            this.labelComb2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComb2.Name = "labelComb2";
            this.labelComb2.Size = new System.Drawing.Size(33, 16);
            this.labelComb2.TabIndex = 57;
            this.labelComb2.Text = "Fuel";
            // 
            // mismasIDsInformacion
            // 
            this.mismasIDsInformacion.AutoSize = true;
            this.mismasIDsInformacion.Location = new System.Drawing.Point(231, 412);
            this.mismasIDsInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mismasIDsInformacion.Name = "mismasIDsInformacion";
            this.mismasIDsInformacion.Size = new System.Drawing.Size(134, 16);
            this.mismasIDsInformacion.TabIndex = 60;
            this.mismasIDsInformacion.Text = "Same IDs Information";
            this.mismasIDsInformacion.Visible = false;
            // 
            // buttonGoBack
            // 
            this.buttonGoBack.Location = new System.Drawing.Point(13, 14);
            this.buttonGoBack.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(100, 28);
            this.buttonGoBack.TabIndex = 61;
            this.buttonGoBack.Text = "Go Back";
            this.buttonGoBack.UseVisualStyleBackColor = true;
            this.buttonGoBack.Click += new System.EventHandler(this.buttonGoBack_Click);
            // 
            // NegativeVelocityInfo
            // 
            this.NegativeVelocityInfo.AutoSize = true;
            this.NegativeVelocityInfo.Location = new System.Drawing.Point(362, 412);
            this.NegativeVelocityInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NegativeVelocityInfo.Name = "NegativeVelocityInfo";
            this.NegativeVelocityInfo.Size = new System.Drawing.Size(179, 16);
            this.NegativeVelocityInfo.TabIndex = 62;
            this.NegativeVelocityInfo.Text = "Negative velocity Information";
            this.NegativeVelocityInfo.Visible = false;
            // 
            // PositionsOutCanvasInfo
            // 
            this.PositionsOutCanvasInfo.AutoSize = true;
            this.PositionsOutCanvasInfo.Location = new System.Drawing.Point(183, 412);
            this.PositionsOutCanvasInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PositionsOutCanvasInfo.Name = "PositionsOutCanvasInfo";
            this.PositionsOutCanvasInfo.Size = new System.Drawing.Size(169, 16);
            this.PositionsOutCanvasInfo.TabIndex = 63;
            this.PositionsOutCanvasInfo.Text = "Positions Out of the Canvas";
            this.PositionsOutCanvasInfo.Visible = false;
            // 
            // timerBotones
            // 
            this.timerBotones.Tick += new System.EventHandler(this.timerBotones_Tick);
            // 
            // fpMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 569);
            this.Controls.Add(this.PositionsOutCanvasInfo);
            this.Controls.Add(this.NegativeVelocityInfo);
            this.Controls.Add(this.buttonGoBack);
            this.Controls.Add(this.mismasIDsInformacion);
            this.Controls.Add(this.textBoxComb1);
            this.Controls.Add(this.labelComb2);
            this.Controls.Add(this.labeLInformacion);
            this.Controls.Add(this.botonAceptarFPs);
            this.Controls.Add(this.txtboxTransponderFP1);
            this.Controls.Add(this.labelNombreFP1);
            this.Controls.Add(this.txtboxCoordFinYFP1);
            this.Controls.Add(this.txtboxCoordFinXFP1);
            this.Controls.Add(this.labelCoordFinFP1);
            this.Controls.Add(this.txtboxVelocidadFP1);
            this.Controls.Add(this.labelVelocidadFP1);
            this.Controls.Add(this.txtboxCoordInicialYFP1);
            this.Controls.Add(this.txtboxCoordInicialXFP1);
            this.Controls.Add(this.CoordInicialFP1);
            this.Controls.Add(this.labelTituloAddFP);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fpMenu";
            this.Text = "FlightPlanMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labeLInformacion;
        private System.Windows.Forms.Button botonAceptarFPs;
        private System.Windows.Forms.TextBox txtboxTransponderFP1;
        private System.Windows.Forms.Label labelNombreFP1;
        private System.Windows.Forms.TextBox txtboxCoordFinYFP1;
        private System.Windows.Forms.TextBox txtboxCoordFinXFP1;
        private System.Windows.Forms.Label labelCoordFinFP1;
        private System.Windows.Forms.TextBox txtboxVelocidadFP1;
        private System.Windows.Forms.Label labelVelocidadFP1;
        private System.Windows.Forms.TextBox txtboxCoordInicialYFP1;
        private System.Windows.Forms.TextBox txtboxCoordInicialXFP1;
        private System.Windows.Forms.Label CoordInicialFP1;
        private System.Windows.Forms.Label labelTituloAddFP;
        private System.Windows.Forms.TextBox textBoxComb1;
        private System.Windows.Forms.Label labelComb2;
        private System.Windows.Forms.Label mismasIDsInformacion;
        private System.Windows.Forms.Button buttonGoBack;
        private System.Windows.Forms.Label NegativeVelocityInfo;
        private System.Windows.Forms.Label PositionsOutCanvasInfo;
        private System.Windows.Forms.Timer timerBotones;
    }
}