using FlightLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Main_Menu
{
    public partial class simulatorMenu : Form
    {
        // Se crean las variables que recibe del menu principal.
        public FlightPlanList ListaData { get; set; }
        public int TiempoCicloSim { get; set; }
        public int DistanciaSeguridadSim { get; set; }

        // Se crean variables propias del Simmulator Menu

        int TimeInterval = 1000;

        int TimeIntervalMod;

        public Image plane = Properties.Resources.Image_Aircraft_Simulator;

        //Se crean listas
        public Stack<FlightPlanList> QposicionesAnterioresVuelos;     //lista para volver atras
        List<PictureBox> Lvuelos = new List<PictureBox>();      //se crean las listas para el canvas y pintar
        List<Position> LPositions = new List<Position>();
        List<PictureBox> Ldistancias = new List<PictureBox>();
        List<bool> TieneConf = new List<bool>();

        // NUEVA FUNCIONALIDAD
        public double XpuntoSim { get; set; }
        public double YpuntoSim { get; set; }
        public float RadiopuntoSim { get; set; }

        double Xpunto = 200;
        double Ypunto = 200;
        float Radiopunto = 50;


        public simulatorMenu()
        {
            InitializeComponent();
        }

        private void botonUnCiclo_Click(object sender, EventArgs e)    //avanza un ciclo
        {
            añadirAnterior();
            ListaData.Mover(TiempoCicloSim);     // Mueve los aviones con la funcion de mover
            pintar();                            //Pinta los aviones y el canvas
            for (int i = 0; i < ListaData.GetNum(); i++)
            {
                ListaData.GetFlightPlan(i).setComb(ListaData.GetFlightPlan(i).getComb() - 20);
            }
            panel1.Invalidate();
        }

        public void AñadirEtiquetas()  //Gracias Xive
        {
            for (int i = 0; i < ListaData.GetNum(); i++)
            {
                FlightPlan flightPlan = ListaData.GetFlightPlan(i);
                Label flightLabel = new Label();

                // Obtener datos necesarios
                string flightID = flightPlan.getId();
                double velocidad = flightPlan.GetVelocidad(); // Método para obtener la velocidad
                Position posicion = flightPlan.GetCurrentPosition(); // Método para obtener la posición actual
                double posX = posicion.GetX(); // Coordenada X
                posX = Math.Round(posX, 2);
                double posY = posicion.GetY(); // Coordenada Y
                posY = Math.Round(posY, 2);

                // Configuración del Label
                flightLabel.BackColor = Color.DimGray;
                flightLabel.Text = flightID + "\nVel: " + velocidad + " GS (x10)\nPos: (" + posX + ", " + posY + ")";
                flightLabel.Font = new Font("Times New Roman", 7);
                flightLabel.AutoSize = true;

                // Posición del Label en relación al PictureBox
                int x = Convert.ToInt32(posX) + (int)Math.Round(Convert.ToDouble(DistanciaSeguridadSim / 2));
                int y = Convert.ToInt32(posY) - 15 - (int)Math.Round(Convert.ToDouble(DistanciaSeguridadSim)); // Ajuste para colocar arriba del avión
                flightLabel.Location = new Point(x, y);

                // Añadir el Label al Panel
                panel1.Controls.Add(flightLabel);
            }
        }

        private void pintar()            //dibuja los aros y lo otro
        {
            //mueve los aviones antes pq sino lo calcula con la posicion antigua
            for (int i = 0; i < ListaData.GetNum(); i++)
            {
                Position X = new Position(ListaData.GetFlightPlan(i).GetCurrentPosition().GetX(),ListaData.GetFlightPlan(i).GetCurrentPosition().GetY());
                Lvuelos[i].Location = new Point(Convert.ToInt32(X.GetX()) - 5, Convert.ToInt32(X.GetY()) - 5);
                LPositions[i] = new Position(Convert.ToInt32(X.GetX()), Convert.ToInt32(X.GetY()));

                Ldistancias[i].Location = new Point(Convert.ToInt32(X.GetX()) - (DistanciaSeguridadSim / 2),Convert.ToInt32(X.GetY()) - (DistanciaSeguridadSim / 2));
                TieneConf[i] = false;
            }
            foreach (Control control in panel1.Controls.OfType<Label>().ToList())
            {
                panel1.Controls.Remove(control);
            }
            // Calcuila las distancias para ver si hay conflictos
            for (int i = 0; i < ListaData.GetNum(); i++)
            {
                for (int k = 0; k < ListaData.GetNum(); k++)
                {
                    if (i != k && LPositions[i].Distancia(LPositions[k]) < DistanciaSeguridadSim)
                    {
                        TieneConf[i] = true;
                        TieneConf[k] = true;
                    }
                }
            }
            //Pinta los circulos 
            for (int i = 0; i < ListaData.GetNum(); i++)
            {
                if (TieneConf[i])
                {
                    Ldistancias[i].BackColor = Color.Transparent;
                }
                else
                {
                    Ldistancias[i].BackColor = Color.Transparent; 
                }
            }
            AñadirEtiquetas();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            crearLineas(e);
            Graphics g = e.Graphics;
            for (int j = 0; j < LPositions.Count; j++)
            {
                bool conflicto = false;

                for (int k = 0; k < Lvuelos.Count; k++)
                {
                    if (j != k && LPositions[j].Distancia(LPositions[k]) <= DistanciaSeguridadSim)
                    {
                        conflicto = true;
                        break;
                    }
                }

                // Dibuja el círculo de seguridad
                Color color = conflicto ? Color.Red : Color.Green;
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, Convert.ToInt32(LPositions[j].GetX()) - (DistanciaSeguridadSim / 2), Convert.ToInt32(LPositions[j].GetY()) - (DistanciaSeguridadSim / 2), DistanciaSeguridadSim, DistanciaSeguridadSim);
                }
            }

            //NUEVA
            Position p = new Position(XpuntoSim, YpuntoSim);
            bool dentro = false;

            for (int j = 0; j < LPositions.Count; j++)
            {
                if (LPositions[j].Distancia(p) <= RadiopuntoSim)
                {
                    dentro = true;
                }
            }
            Color colorcirculo = dentro ? Color.Red : Color.Green;
            using (Brush brush = new SolidBrush(colorcirculo))
            {
                g.FillEllipse(brush, Convert.ToInt32(XpuntoSim) - (RadiopuntoSim), Convert.ToInt32(YpuntoSim) - (RadiopuntoSim), RadiopuntoSim * 2, RadiopuntoSim * 2);
            }

            int i = 0;
            while (i < ListaData.GetNum())
            {
                int x = Convert.ToInt32(ListaData.GetFlightPlan(i).GetCurrentPosition().GetX() - 17);
                int y = Convert.ToInt32(ListaData.GetFlightPlan(i).GetCurrentPosition().GetY() - 17);
                g.DrawImage(plane, x, y, 35, 35);
                i++;
            }
        }

        private void Form4_Load(object sender, EventArgs e)            
        {
            AñadirEtiquetas();
            //estetica
            ToolTip info = new ToolTip();
            info.AutoPopDelay = 5000;
            info.InitialDelay = 800;
            info.ReshowDelay = 100;
            info.ShowAlways = true;
            info.SetToolTip(botonUnCiclo, "Moves the plane one cicle");
            info.SetToolTip(botonAutomaticoStart, "Moves the planes automatically");
            info.SetToolTip(botonCambiar, "Changes the velocity of the plane with the id indicated");
            info.SetToolTip(botonSaveTxt, "Saves the planes trajectory and current position in a .txt file");
            info.SetToolTip(buttonUndo1Ciclo, "Goes back to the previous position");
            info.SetToolTip(buttonDatos, "Shows various information about the planes");
            info.SetToolTip(botonRestart, "Brings the planes to the original position");
            info.SetToolTip(botonAutomaticStop, "Stops the plane from moving alone");

            //configuración del panel
            typeof(Panel).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
            null, panel1, new object[] { true });
            panel1.BackgroundImage = Properties.Resources.Image_Background_Simulator;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;

            //Stack para el retroceder
            if (QposicionesAnterioresVuelos == null)
            {
                QposicionesAnterioresVuelos = new Stack<FlightPlanList>();
            }

            //se cargan las posiciones de los aviones
            int i = 0;
            while (i < ListaData.GetNum())
            {
                Position X = new Position(ListaData.GetFlightPlan(i).GetCurrentPosition().GetX(), ListaData.GetFlightPlan(i).GetCurrentPosition().GetY());
                LPositions.Add(X);
                i = i + 1;
            }
            int g = 0;
            while (g < LPositions.Count)
            {
                TieneConf.Add(false);
                g = g + 1;
            }

            //se configura la caja y los aviones
            i = 0;
            foreach (Position p in LPositions)
            {
                PictureBox pictureX = new PictureBox();

                pictureX.Size = new Size(10, 10);
                pictureX.BackColor = Color.Transparent;
                pictureX.Location = new Point(Convert.ToInt32(p.GetX()) - 5, Convert.ToInt32(p.GetY()) - 5);
                pictureX.Tag = i;
                pictureX.Click += new System.EventHandler(this.InfoFP1);
                panel1.Controls.Add(pictureX);
                Lvuelos.Add(pictureX);
                i++;
            }

            //distancia de seguridad
            int j = 0;
            while (j < LPositions.Count)
            {
                int k = 0;
                bool conflicto = false;
                while (k < (Lvuelos.Count) && conflicto == false)
                {
                    if ((LPositions[j].Distancia(LPositions[k]) <= DistanciaSeguridadSim) && (j != k))
                    {
                        conflicto = true;
                        k++;
                    }
                    else
                    {
                        conflicto = false;
                        k++;
                    }
                }
                PictureBox SDx = new PictureBox();
                crearDS(SDx, Lvuelos[j], DistanciaSeguridadSim, LPositions[j], conflicto);
                Ldistancias.Add(SDx);
                j++;
            }
        }

        private void buttonGoBack_Click(object sender, EventArgs e)       //retrocede uno
        {
            int i = 0;
            while (i < ListaData.GetNum())
            {
                ListaData.GetFlightPlan(i).Restart();
                ListaData.GetFlightPlan(i).setComb(ListaData.GetFlightPlan(i).getComb() + 2000);
                i = i + 1;
            }
            Close();
        }

        private void crearLineas(PaintEventArgs e) //crea las lineas de la trayectoria
        {
            int i = 0;
            while (i < ListaData.GetNum())
            {
                Pen pen = new Pen(Color.Black, 2);
                e.Graphics.DrawLine(pen, Convert.ToInt32(ListaData.GetFlightPlan(i).GetInitialPosition().GetX()), Convert.ToInt32(ListaData.GetFlightPlan(i).GetInitialPosition().GetY()), Convert.ToInt32(ListaData.GetFlightPlan(i).GetfinalPosition().GetX()), Convert.ToInt32(ListaData.GetFlightPlan(i).GetfinalPosition().GetY()));
                i = i + 1;
            }
        }

        public void crearDS(PictureBox SD, PictureBox punto, int distancia, Position A, bool conflicto) //crea las distancias de segurodad
        {
            SD.Location = new Point(Convert.ToInt32(A.GetX()) - (distancia / 2), Convert.ToInt32(A.GetY()) - (distancia / 2));
            SD.Size = new Size(distancia, distancia);
            if (conflicto)
            {
                SD.BackColor = Color.Transparent;
            }
            else
            {
                SD.BackColor = Color.Transparent;
            }
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, SD.Width, SD.Height);
            SD.Region = new Region(path);
            panel1.Controls.Add(SD);
        }

        private void InfoFP1(object sender, EventArgs e)      //abre la informacion 
        {
            PictureBox p = (PictureBox)sender;
            int i = (int)p.Tag;
            Information f = new Information();
            f.listaFPsInfo = ListaData;
            f.myFlight = (ListaData.GetFlightPlan(i));
            f.ShowDialog();
        }

        private void botonAutomatico_Click(object sender, EventArgs e)   //mieve solo los aviones
        {
            if (TimeIntervalMod <= 0)
            { TimeIntervalMod = TimeInterval; }
            timerAutomatico.Interval = TimeIntervalMod;
            timerAutomatico.Start();
        }

        private void timerAutomatico_Tick(object sender, EventArgs e)     //
        {
            añadirAnterior();
            ////------------------------------------------------------------------------------------------
            ListaData.Mover(TiempoCicloSim);     // Mueve los aviones con la funcion de mover
            for (int i = 0; i < ListaData.GetNum(); i++)
            {
                ListaData.GetFlightPlan(i).setComb(ListaData.GetFlightPlan(i).getComb() - 20);
            }
            pintar();                            //Pinta los aviones y el canvas
            panel1.Invalidate();
        }

        private void botonAutomaticStop_Click(object sender, EventArgs e)
        {
            timerAutomatico.Stop();
        }

        private void buttonDatos_Click(object sender, EventArgs e)      //abre los datos 
        {
            CurrentDataMenu dataGrid = new CurrentDataMenu();
            dataGrid.ListaGridData = ListaData;
            dataGrid.Show();
        }
         
        private void botonRestart_Click(object sender, EventArgs e)     //resetea las posiciones
        {
            QposicionesAnterioresVuelos = new Stack<FlightPlanList>();
            timerAutomatico.Stop();
            int i = 0;
            while (i<ListaData.GetNum())
            {
                ListaData.GetFlightPlan(i).Restart();
                i = i + 1;
            }
            ListaData.Mover(0);     
            pintar();                            
            panel1.Invalidate();
        }

        private void botonCambiar_Click(object sender, EventArgs e)        //cambia la velocidad al introducir un 
        {
            try
            {
                double v = Convert.ToDouble(textBox2.Text);
                int i = 0;
                bool encontrado = false;
                while (i<ListaData.GetNum() && !encontrado)
                {
                    string transponder = textBox1.Text;
                    if (transponder == ListaData.GetFlightPlan(i).getId())
                    {
                        encontrado = true;
                        if (v <= 0)
                        {
                            botonCambiar.Text = "Error";
                            botonCambiar.BackColor = Color.LightGoldenrodYellow;
                            timerBotonesVel.Interval = 2500;
                            timerBotonesVel.Start();
                            MessageBox.Show("The velocity must be positive");
                        }
                        else
                        {
                            ListaData.GetFlightPlan(i).SetVelocidad(v);
                            botonCambiar.BackColor = Color.PaleGreen;
                            botonCambiar.Text = "Done";
                            timerBotonesVel.Interval = 2500;
                            timerBotonesVel.Start();
                        }
                    }
                    i = i + 1;
                }
                if (!encontrado)
                {
                    MessageBox.Show("This flight does not exist");
                }
            }
            catch (FormatException)
            { 
                botonCambiar.BackColor = Color.LightCoral;
                botonCambiar.Text = "Format Error";
                timerBotonesVel.Interval = 2500;
                timerBotonesVel.Start();
            }
        }

        private void timerBotonesVel_Tick(object sender, EventArgs e)
        {
            botonCambiar.BackColor = Color.White;
            botonCambiar.Text = "Change";
            timerBotonesVel.Stop();
        }

        private void buttonUndo1Ciclo_Click(object sender, EventArgs e)
        {
            if (QposicionesAnterioresVuelos.Count != 0)
            {
                ListaData.copiarFlightplanList(QposicionesAnterioresVuelos.Pop());
                pintar();
                panel1.Invalidate();
            }
            for (int i = 0; i < ListaData.GetNum(); i++)
            {
                ListaData.GetFlightPlan(i).setComb(ListaData.GetFlightPlan(i).getComb() + 20);
            }
        }

        private void botonSaveTxt_Click(object sender, EventArgs e)
        {
            try
            {
                string Filename = textBoxFilename.Text;
                if (Filename == "")
                {
                    MessageBox.Show("The name can not be empty");
                }
                else
                {
                    using (StreamWriter W = new StreamWriter(Filename + ".txt"))
                    {
                        W.WriteLine("TC DS");
                        W.WriteLine($"{TiempoCicloSim} {DistanciaSeguridadSim}");
                        W.WriteLine("Transponder xi yi cx cy xf yf velocidad combustible");
                        foreach (FlightPlan fp in ListaData.getVector())
                        {
                            W.WriteLine($"{fp.getId()} {fp.GetInitialPosition().GetX()} {fp.GetInitialPosition().GetY()} {fp.GetCurrentPosition().GetX()} {fp.GetCurrentPosition().GetY()} " +
                                       $"{fp.GetfinalPosition().GetX()} {fp.GetfinalPosition().GetY()} {fp.GetVelocidad()} {fp.getComb()}");
                        }
                        W.WriteLine("-");
                        while (QposicionesAnterioresVuelos.Count > 0) 
                        {
                            FlightPlanList TFPL = new FlightPlanList();
                            TFPL.copiarFlightplanList(QposicionesAnterioresVuelos.Pop());
                            foreach (FlightPlan fp in TFPL.getVector())
                            {
                                W.WriteLine($"{fp.getId()} {fp.GetInitialPosition().GetX()} {fp.GetInitialPosition().GetY()} {fp.GetCurrentPosition().GetX()} {fp.GetCurrentPosition().GetY()} " +
                                           $"{fp.GetfinalPosition().GetX()} {fp.GetfinalPosition().GetY()} {fp.GetVelocidad()} {fp.getComb()}");
                            }
                        }
                    }
                    botonSaveTxt.BackColor = Color.PaleGreen;
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Format error");
                botonSaveTxt.BackColor = Color.LightCoral;
            }
        }
        private void añadirAnterior()
        {
            if (!ListaData.hasArrived())
            {
                FlightPlanList temporal = new FlightPlanList();
                temporal.copiarFlightplanList(ListaData);
                QposicionesAnterioresVuelos.Push(temporal);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e) // Devuelve las coordenadas del ratón en el panel cuando lo pasamos por encima de éste
        {
            CoordinatesTextBox.Visible = true;
            Point point = panel1.PointToClient(Cursor.Position);
            CoordinatesTextBox.Text = "X = " + e.X + " ; Y = " + e.Y;
        }

        private void ViewGEBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You need to have Google Earth installed for teh correct working");
            // Trajectories with the initial, current and final points
            try
            {
                string Filename = textBoxFilename.Text;
                if (Filename == "")
                {
                    MessageBox.Show("The name can not be empty");
                }
                else
                {
                    ListaData.GenerateFPKml(Filename);
                    ViewGEBtn.BackColor = Color.PaleGreen;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Format error");
                botonSaveTxt.BackColor = Color.LightCoral;
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e) // Quita las coordenadas cuando salimos del panel con el ratón
        {
            Point point = panel1.PointToClient(Cursor.Position);
            CoordinatesTextBox.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TimeIntervalMod = Convert.ToInt32(TimeInterval - trackBar1.Value);
            timerAutomatico.Interval = TimeIntervalMod;
            timerAutomatico.Start();
        }

        // Añadir labels limites de canvas
        // Añadir limites de canvas codigo
        // Centrar errores flight plans
    }
}


