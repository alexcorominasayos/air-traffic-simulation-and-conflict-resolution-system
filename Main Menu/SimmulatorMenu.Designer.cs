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
            this.SuspendLayout();
            // 
            // buttonGoBack
            // 
            this.buttonGoBack.Location = new System.Drawing.Point(13, 14);
            this.buttonGoBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(100, 28);
            this.buttonGoBack.TabIndex = 7;
            this.buttonGoBack.Text = "Go Back";
            this.buttonGoBack.UseVisualStyleBackColor = true;
            this.buttonGoBack.Click += new System.EventHandler(this.buttonGoBack_Click);
            // 
            // botonUnCiclo
            // 
            this.botonUnCiclo.Location = new System.Drawing.Point(105, 130);
            this.botonUnCiclo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonUnCiclo.Name = "botonUnCiclo";
            this.botonUnCiclo.Size = new System.Drawing.Size(100, 28);
            this.botonUnCiclo.TabIndex = 6;
            this.botonUnCiclo.Text = "Un ciclo";
            this.botonUnCiclo.UseVisualStyleBackColor = true;
            this.botonUnCiclo.Click += new System.EventHandler(this.botonUnCiclo_Click);
            // 
            // labelTituloSimulator
            // 
            this.labelTituloSimulator.AutoSize = true;
            this.labelTituloSimulator.Location = new System.Drawing.Point(165, 97);
            this.labelTituloSimulator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTituloSimulator.Name = "labelTituloSimulator";
            this.labelTituloSimulator.Size = new System.Drawing.Size(99, 16);
            this.labelTituloSimulator.TabIndex = 5;
            this.labelTituloSimulator.Text = "Simulator Menu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.BackgroundImage = global::Main_Menu.Properties.Resources.Captura_de_pantalla_2024_11_11_214931;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(433, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1199, 738);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // botonAutomaticoStart
            // 
            this.botonAutomaticoStart.Location = new System.Drawing.Point(169, 489);
            this.botonAutomaticoStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonAutomaticoStart.Name = "botonAutomaticoStart";
            this.botonAutomaticoStart.Size = new System.Drawing.Size(100, 28);
            this.botonAutomaticoStart.TabIndex = 8;
            this.botonAutomaticoStart.Text = "Start";
            this.botonAutomaticoStart.UseVisualStyleBackColor = true;
            this.botonAutomaticoStart.Click += new System.EventHandler(this.botonAutomatico_Click);
            // 
            // labelAutomatico
            // 
            this.labelAutomatico.AutoSize = true;
            this.labelAutomatico.Location = new System.Drawing.Point(165, 455);
            this.labelAutomatico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAutomatico.Name = "labelAutomatico";
            this.labelAutomatico.Size = new System.Drawing.Size(103, 16);
            this.labelAutomatico.TabIndex = 9;
            this.labelAutomatico.Text = "Automatic Move";
            // 
            // botonAutomaticStop
            // 
            this.botonAutomaticStop.Location = new System.Drawing.Point(169, 524);
            this.botonAutomaticStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonAutomaticStop.Name = "botonAutomaticStop";
            this.botonAutomaticStop.Size = new System.Drawing.Size(100, 28);
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
            this.buttonDatos.Location = new System.Drawing.Point(233, 166);
            this.buttonDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDatos.Name = "buttonDatos";
            this.buttonDatos.Size = new System.Drawing.Size(100, 28);
            this.buttonDatos.TabIndex = 12;
            this.buttonDatos.Text = "Datos ";
            this.buttonDatos.UseVisualStyleBackColor = true;
            this.buttonDatos.Click += new System.EventHandler(this.buttonDatos_Click);
            // 
            // botonRestart
            // 
            this.botonRestart.Location = new System.Drawing.Point(233, 130);
            this.botonRestart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonRestart.Name = "botonRestart";
            this.botonRestart.Size = new System.Drawing.Size(100, 28);
            this.botonRestart.TabIndex = 13;
            this.botonRestart.Text = "Restart";
            this.botonRestart.UseVisualStyleBackColor = true;
            this.botonRestart.Click += new System.EventHandler(this.botonRestart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 316);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(231, 316);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 15;
            // 
            // labelV1
            // 
            this.labelV1.AutoSize = true;
            this.labelV1.Location = new System.Drawing.Point(85, 278);
            this.labelV1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelV1.Name = "labelV1";
            this.labelV1.Size = new System.Drawing.Size(23, 16);
            this.labelV1.TabIndex = 16;
            this.labelV1.Text = "ID:";
            // 
            // labelV2
            // 
            this.labelV2.AutoSize = true;
            this.labelV2.Location = new System.Drawing.Point(227, 278);
            this.labelV2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelV2.Name = "labelV2";
            this.labelV2.Size = new System.Drawing.Size(58, 16);
            this.labelV2.TabIndex = 17;
            this.labelV2.Text = "Velocity:";
            // 
            // botonCambiar
            // 
            this.botonCambiar.Location = new System.Drawing.Point(167, 363);
            this.botonCambiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonCambiar.Name = "botonCambiar";
            this.botonCambiar.Size = new System.Drawing.Size(100, 28);
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
            this.buttonUndo1Ciclo.Location = new System.Drawing.Point(105, 166);
            this.buttonUndo1Ciclo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUndo1Ciclo.Name = "buttonUndo1Ciclo";
            this.buttonUndo1Ciclo.Size = new System.Drawing.Size(100, 28);
            this.buttonUndo1Ciclo.TabIndex = 19;
            this.buttonUndo1Ciclo.Text = "Undo";
            this.buttonUndo1Ciclo.UseVisualStyleBackColor = true;
            this.buttonUndo1Ciclo.Click += new System.EventHandler(this.buttonUndo1Ciclo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 250);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Change Velocity";
            // 
            // labelTextfile
            // 
            this.labelTextfile.AutoSize = true;
            this.labelTextfile.Location = new System.Drawing.Point(157, 628);
            this.labelTextfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTextfile.Name = "labelTextfile";
            this.labelTextfile.Size = new System.Drawing.Size(100, 16);
            this.labelTextfile.TabIndex = 24;
            this.labelTextfile.Text = "Save as text file";
            // 
            // botonSaveTxt
            // 
            this.botonSaveTxt.Location = new System.Drawing.Point(169, 709);
            this.botonSaveTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.botonSaveTxt.Name = "botonSaveTxt";
            this.botonSaveTxt.Size = new System.Drawing.Size(100, 28);
            this.botonSaveTxt.TabIndex = 23;
            this.botonSaveTxt.Text = "Save";
            this.botonSaveTxt.UseVisualStyleBackColor = true;
            this.botonSaveTxt.Click += new System.EventHandler(this.botonSaveTxt_Click);
            // 
            // labelNameTxt
            // 
            this.labelNameTxt.AutoSize = true;
            this.labelNameTxt.Location = new System.Drawing.Point(125, 667);
            this.labelNameTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNameTxt.Name = "labelNameTxt";
            this.labelNameTxt.Size = new System.Drawing.Size(66, 16);
            this.labelNameTxt.TabIndex = 22;
            this.labelNameTxt.Text = "Filename:";
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(207, 663);
            this.textBoxFilename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(132, 22);
            this.textBoxFilename.TabIndex = 21;
            // 
            // simulatorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1663, 801);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "simulatorMenu";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.Form4_Load);
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
    }
}