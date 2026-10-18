namespace Main_Menu
{
    partial class simulatorMenu
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
            this.buttonGoBack = new System.Windows.Forms.Button();
            this.botonUnCiclo = new System.Windows.Forms.Button();
            this.labelTituloSimulator = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CoordinatesTextBox = new System.Windows.Forms.Label();
            this.botonAutomaticoStart = new System.Windows.Forms.Button();
            this.labelAutomatico = new System.Windows.Forms.Label();
            this.botonAutomaticStop = new System.Windows.Forms.Button();
            this.timerAutomatico = new System.Windows.Forms.Timer(this.components);
            this.buttonDatos = new System.Windows.Forms.Button();
            this.botonRestart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelV1 = new System.Windows.Forms.Label();
            this.labelV2 = new System.Windows.Forms.Label();
            this.botonCambiar = new System.Windows.Forms.Button();
            this.timerBotonesVel = new System.Windows.Forms.Timer(this.components);
            this.buttonUndo1Ciclo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTextfile = new System.Windows.Forms.Label();
            this.botonSaveTxt = new System.Windows.Forms.Button();
            this.labelNameTxt = new System.Windows.Forms.Label();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.ViewGEBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGoBack
            // 
            this.buttonGoBack.Location = new System.Drawing.Point(10, 11);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(75, 23);
            this.buttonGoBack.TabIndex = 7;
            this.buttonGoBack.Text = "Go Back";
            this.buttonGoBack.UseVisualStyleBackColor = true;
            this.buttonGoBack.Visible = false;
            this.buttonGoBack.Click += new System.EventHandler(this.buttonGoBack_Click);
            // 
            // botonUnCiclo
            // 
            this.botonUnCiclo.Location = new System.Drawing.Point(79, 93);
            this.botonUnCiclo.Name = "botonUnCiclo";
            this.botonUnCiclo.Size = new System.Drawing.Size(75, 23);
            this.botonUnCiclo.TabIndex = 6;
            this.botonUnCiclo.Text = "Forward";
            this.botonUnCiclo.UseVisualStyleBackColor = true;
            this.botonUnCiclo.Click += new System.EventHandler(this.botonUnCiclo_Click);
            // 
            // labelTituloSimulator
            // 
            this.labelTituloSimulator.AutoSize = true;
            this.labelTituloSimulator.Location = new System.Drawing.Point(124, 66);
            this.labelTituloSimulator.Name = "labelTituloSimulator";
            this.labelTituloSimulator.Size = new System.Drawing.Size(80, 13);
            this.labelTituloSimulator.TabIndex = 5;
            this.labelTituloSimulator.Text = "Simulator Menu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.BackgroundImage = global::Main_Menu.Properties.Resources.Captura_de_pantalla_2024_11_11_214931;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CoordinatesTextBox);
            this.panel1.Location = new System.Drawing.Point(325, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 600);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // CoordinatesTextBox
            // 
            this.CoordinatesTextBox.AutoSize = true;
            this.CoordinatesTextBox.BackColor = System.Drawing.Color.Transparent;
            this.CoordinatesTextBox.Location = new System.Drawing.Point(3, 578);
            this.CoordinatesTextBox.Name = "CoordinatesTextBox";
            this.CoordinatesTextBox.Size = new System.Drawing.Size(85, 13);
            this.CoordinatesTextBox.TabIndex = 25;
            this.CoordinatesTextBox.Text = "Position X and Y";
            // 
            // botonAutomaticoStart
            // 
            this.botonAutomaticoStart.Location = new System.Drawing.Point(127, 414);
            this.botonAutomaticoStart.Name = "botonAutomaticoStart";
            this.botonAutomaticoStart.Size = new System.Drawing.Size(75, 23);
            this.botonAutomaticoStart.TabIndex = 8;
            this.botonAutomaticoStart.Text = "Start";
            this.botonAutomaticoStart.UseVisualStyleBackColor = true;
            this.botonAutomaticoStart.Click += new System.EventHandler(this.botonAutomatico_Click);
            // 
            // labelAutomatico
            // 
            this.labelAutomatico.AutoSize = true;
            this.labelAutomatico.Location = new System.Drawing.Point(124, 386);
            this.labelAutomatico.Name = "labelAutomatico";
            this.labelAutomatico.Size = new System.Drawing.Size(84, 13);
            this.labelAutomatico.TabIndex = 9;
            this.labelAutomatico.Text = "Automatic Move";
            // 
            // botonAutomaticStop
            // 
            this.botonAutomaticStop.Location = new System.Drawing.Point(127, 442);
            this.botonAutomaticStop.Name = "botonAutomaticStop";
            this.botonAutomaticStop.Size = new System.Drawing.Size(75, 23);
            this.botonAutomaticStop.TabIndex = 10;
            this.botonAutomaticStop.Text = "Stop";
            this.botonAutomaticStop.UseVisualStyleBackColor = true;
            this.botonAutomaticStop.Click += new System.EventHandler(this.botonAutomaticStop_Click);
            // 
            // timerAutomatico
            // 
            this.timerAutomatico.Tick += new System.EventHandler(this.timerAutomatico_Tick);
            // 
            // buttonDatos
            // 
            this.buttonDatos.Location = new System.Drawing.Point(175, 122);
            this.buttonDatos.Name = "buttonDatos";
            this.buttonDatos.Size = new System.Drawing.Size(75, 23);
            this.buttonDatos.TabIndex = 12;
            this.buttonDatos.Text = "Data";
            this.buttonDatos.UseVisualStyleBackColor = true;
            this.buttonDatos.Click += new System.EventHandler(this.buttonDatos_Click);
            // 
            // botonRestart
            // 
            this.botonRestart.Location = new System.Drawing.Point(175, 93);
            this.botonRestart.Name = "botonRestart";
            this.botonRestart.Size = new System.Drawing.Size(75, 23);
            this.botonRestart.TabIndex = 13;
            this.botonRestart.Text = "Restart";
            this.botonRestart.UseVisualStyleBackColor = true;
            this.botonRestart.Click += new System.EventHandler(this.botonRestart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 227);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(173, 227);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 15;
            // 
            // labelV1
            // 
            this.labelV1.AutoSize = true;
            this.labelV1.Location = new System.Drawing.Point(64, 196);
            this.labelV1.Name = "labelV1";
            this.labelV1.Size = new System.Drawing.Size(21, 13);
            this.labelV1.TabIndex = 16;
            this.labelV1.Text = "ID:";
            // 
            // labelV2
            // 
            this.labelV2.AutoSize = true;
            this.labelV2.Location = new System.Drawing.Point(170, 196);
            this.labelV2.Name = "labelV2";
            this.labelV2.Size = new System.Drawing.Size(47, 13);
            this.labelV2.TabIndex = 17;
            this.labelV2.Text = "Velocity:";
            // 
            // botonCambiar
            // 
            this.botonCambiar.Location = new System.Drawing.Point(125, 258);
            this.botonCambiar.Name = "botonCambiar";
            this.botonCambiar.Size = new System.Drawing.Size(75, 23);
            this.botonCambiar.TabIndex = 18;
            this.botonCambiar.Text = "Change";
            this.botonCambiar.UseVisualStyleBackColor = true;
            this.botonCambiar.Click += new System.EventHandler(this.botonCambiar_Click);
            // 
            // timerBotonesVel
            // 
            this.timerBotonesVel.Tick += new System.EventHandler(this.timerBotonesVel_Tick);
            // 
            // buttonUndo1Ciclo
            // 
            this.buttonUndo1Ciclo.Location = new System.Drawing.Point(79, 122);
            this.buttonUndo1Ciclo.Name = "buttonUndo1Ciclo";
            this.buttonUndo1Ciclo.Size = new System.Drawing.Size(75, 23);
            this.buttonUndo1Ciclo.TabIndex = 19;
            this.buttonUndo1Ciclo.Text = "Backward";
            this.buttonUndo1Ciclo.UseVisualStyleBackColor = true;
            this.buttonUndo1Ciclo.Click += new System.EventHandler(this.buttonUndo1Ciclo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Change Specific Velocity";
            // 
            // labelTextfile
            // 
            this.labelTextfile.AutoSize = true;
            this.labelTextfile.Location = new System.Drawing.Point(118, 497);
            this.labelTextfile.Name = "labelTextfile";
            this.labelTextfile.Size = new System.Drawing.Size(82, 13);
            this.labelTextfile.TabIndex = 24;
            this.labelTextfile.Text = "Save as text file";
            // 
            // botonSaveTxt
            // 
            this.botonSaveTxt.Location = new System.Drawing.Point(46, 561);
            this.botonSaveTxt.Name = "botonSaveTxt";
            this.botonSaveTxt.Size = new System.Drawing.Size(75, 23);
            this.botonSaveTxt.TabIndex = 23;
            this.botonSaveTxt.Text = "Save";
            this.botonSaveTxt.UseVisualStyleBackColor = true;
            this.botonSaveTxt.Click += new System.EventHandler(this.botonSaveTxt_Click);
            // 
            // labelNameTxt
            // 
            this.labelNameTxt.AutoSize = true;
            this.labelNameTxt.Location = new System.Drawing.Point(71, 526);
            this.labelNameTxt.Name = "labelNameTxt";
            this.labelNameTxt.Size = new System.Drawing.Size(52, 13);
            this.labelNameTxt.TabIndex = 22;
            this.labelNameTxt.Text = "Filename:";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(127, 524);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilename.TabIndex = 21;
            // 
            // ViewGEBtn
            // 
            this.ViewGEBtn.Location = new System.Drawing.Point(123, 561);
            this.ViewGEBtn.Name = "ViewGEBtn";
            this.ViewGEBtn.Size = new System.Drawing.Size(149, 23);
            this.ViewGEBtn.TabIndex = 25;
            this.ViewGEBtn.Text = "Visualize in Google Earth";
            this.ViewGEBtn.UseVisualStyleBackColor = true;
            this.ViewGEBtn.Click += new System.EventHandler(this.ViewGEBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 606);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "597";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1195, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "897";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(308, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 311);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Change General Velocity";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(79, 334);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBar1.Maximum = 750;
            this.trackBar1.Minimum = -750;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(171, 45);
            this.trackBar1.TabIndex = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // simulatorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1247, 651);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ViewGEBtn);
            this.Controls.Add(this.labelTextfile);
            this.Controls.Add(this.botonSaveTxt);
            this.Controls.Add(this.labelNameTxt);
            this.Controls.Add(this.textBoxFilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUndo1Ciclo);
            this.Controls.Add(this.botonCambiar);
            this.Controls.Add(this.labelV2);
            this.Controls.Add(this.labelV1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.botonRestart);
            this.Controls.Add(this.buttonDatos);
            this.Controls.Add(this.botonAutomaticStop);
            this.Controls.Add(this.labelAutomatico);
            this.Controls.Add(this.botonAutomaticoStart);
            this.Controls.Add(this.buttonGoBack);
            this.Controls.Add(this.botonUnCiclo);
            this.Controls.Add(this.labelTituloSimulator);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "simulatorMenu";
            this.Text = "SimulatorMenu";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGoBack;
        private System.Windows.Forms.Button botonUnCiclo;
        private System.Windows.Forms.Label labelTituloSimulator;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button botonAutomaticoStart;
        private System.Windows.Forms.Label labelAutomatico;
        private System.Windows.Forms.Button botonAutomaticStop;
        private System.Windows.Forms.Timer timerAutomatico;
        private System.Windows.Forms.Button buttonDatos;
        private System.Windows.Forms.Button botonRestart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelV1;
        private System.Windows.Forms.Label labelV2;
        private System.Windows.Forms.Button botonCambiar;
        private System.Windows.Forms.Timer timerBotonesVel;
        private System.Windows.Forms.Button buttonUndo1Ciclo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTextfile;
        private System.Windows.Forms.Button botonSaveTxt;
        private System.Windows.Forms.Label labelNameTxt;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.Label CoordinatesTextBox;
        private System.Windows.Forms.Button ViewGEBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}