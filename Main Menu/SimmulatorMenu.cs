using FlightLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Main_Menu
{
    public partial class simulatorMenu : Form
    {
        // Se crean las variables que recibe del menu principal.
        public FlightPlanList ListaData { get; set; }
        public int TiempoCicloSim { get; set; }
        public int DistanciaSeguridadSim { get; set; }
        public FlightPlan flight { get; set; }

        // Se crean variables propias del Simmulator Menu
        
        int TimeInterval = 1000;

        //Se crean listas
        Stack<List<Position>> QposicionesAnterioresVuelos;    //lista para volver atras
        List<PictureBox> Lvuelos = new List<PictureBox>();      //se crean las listas para el canvas y pintar
        List<Position> LPositions = new List<Position>();
        List<PictureBox> Ldistancias = new List<PictureBox>();
        List<bool> TieneConf = new List<bool>();


        //Inicializamos los arrays con un tamaño fijo (en este caso, 2)
        //PictureBox[] vuelos = new PictureBox[2];
        //PictureBox[] distancias = new PictureBox[2];

        public simulatorMenu()
        {
            InitializeComponent();
        }

        private void botonUnCiclo_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool AllArrived = true;
            bool arrived;
            List<Position> L = new List<Position>();
            while (i < ListaData.GetNum())
            {
                Position p = new Position(ListaData.GetFlightPlan(i).GetCurrentPosition().GetX(), ListaData.GetFlightPlan(i).GetCurrentPosition().GetY());
                L.Add(p);
                arrived = ListaData.GetFlightPlan(i).HasArrived();
                if (arrived != true)
                {
                    AllArrived = false;
                }
                i = i + 1;
            }
            if (AllArrived == false)
                {
                    QposicionesAnterioresVuelos.Push(L);
                }

            ListaData.Mover(TiempoCicloSim);     // Mueve los aviones con la funcion de mover

            pintar();                            //Pinta los aviones y el canvas
            ListaData.GetFlightPlan(0).setComb(ListaData.GetFlightPlan(0).getComb() - 10);
            ListaData.GetFlightPlan(1).setComb(ListaData.GetFlightPlan(1).getComb() - 10);
            panel1.Invalidate();
        }

        private void pintar()
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
                    Ldistancias[i].BackColor = Color.Red;
                }
                else
                {
                    Ldistancias[i].BackColor = Color.Green; 
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            crearLineas(e);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //estetica
            typeof(Panel).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
            null, panel1, new object[] { true });
            panel1.BackgroundImage = Properties.Resources.Captura_de_pantalla_2024_11_11_214931;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;

            //Stack para el retroceder
            QposicionesAnterioresVuelos = new Stack<List<Position>>();

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
                //pictureX.Size = new Size(30, 30);
                //pictureX.BackColor = Color.Transparent;
                //pictureX.SizeMode = PictureBoxSizeMode.StretchImage;
                //pictureX.Image = Properties.Resources.avion_chuleta;
                //pictureX.Location = new Point(Convert.ToInt32(p.GetX()) - 13, Convert.ToInt32(p.GetY()) - 13);
                //pictureX.Tag = i;
                //pictureX.Click += new System.EventHandler(this.InfoFP1);
                //panel1.Controls.Add(pictureX);
                //Lvuelos.Add(pictureX);
                //i++;

                pictureX.Size = new Size(10, 10);
                pictureX.BackColor = Color.Blue;
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
                if (conflicto == false)
                {
                    PictureBox SDx = new PictureBox();
                    crearDS(SDx, Lvuelos[j], DistanciaSeguridadSim, LPositions[j], conflicto);
                    Ldistancias.Add(SDx);
                }
                else
                {
                    PictureBox SDx = new PictureBox();
                    crearDS(SDx, Lvuelos[j], DistanciaSeguridadSim, LPositions[j], conflicto);
                    Ldistancias.Add(SDx);
                }
                j++;
            }
        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < ListaData.GetNum())
            {
                ListaData.GetFlightPlan(i).Restart();
                i = i + 1;
            }
            Close();
        }

        private void crearLineas(PaintEventArgs e)
        {
            int i = 0;
            while (i < ListaData.GetNum())
            {
                Pen pen = new Pen(Color.Black, 2);
                e.Graphics.DrawLine(pen, Convert.ToInt32(ListaData.GetFlightPlan(i).GetInitialPosition().GetX()), Convert.ToInt32(ListaData.GetFlightPlan(i).GetInitialPosition().GetY()), Convert.ToInt32(ListaData.GetFlightPlan(i).GetfinalPosition().GetX()), Convert.ToInt32(ListaData.GetFlightPlan(i).GetfinalPosition().GetY()));
                i = i + 1;
            }
        }

        public void crearDS(PictureBox SD, PictureBox punto, int distancia, Position A, bool conflicto)
        {
            SD.Location = new Point(Convert.ToInt32(A.GetX()) - (distancia / 2), Convert.ToInt32(A.GetY()) - (distancia / 2));
            SD.Size = new Size(distancia, distancia);
            if (conflicto)
            {
                SD.BackColor = Color.Red;
            }
            else
            {
                SD.BackColor = Color.Green;
            }
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, SD.Width, SD.Height);
            SD.Region = new Region(path);
            panel1.Controls.Add(SD);
        }

        private void InfoFP1(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            int i = (int)p.Tag;
            Information f = new Information();
            f.listaFPsInfo = ListaData;
            f.myFlight = (ListaData.GetFlightPlan(i));
            f.ShowDialog();
        }

        private void botonAutomatico_Click(object sender, EventArgs e)
        {
            timerAutomatico.Interval = TimeInterval;
            timerAutomatico.Start();
        }

        private void timerAutomatico_Tick(object sender, EventArgs e)
        {
            int i = 0;
            List<Position> L = new List<Position>();
            while (i < ListaData.GetNum())
            {
                Position p = new Position(ListaData.GetFlightPlan(i).GetCurrentPosition().GetX(), ListaData.GetFlightPlan(i).GetCurrentPosition().GetY());
                L.Add(p);
                i = i + 1;
            }
            QposicionesAnterioresVuelos.Push(L);
            ListaData.Mover(TiempoCicloSim);     // Mueve los aviones con la funcion de mover
            pintar();                            //Pinta los aviones y el canvas
            panel1.Invalidate();
        }

        private void botonAutomaticStop_Click(object sender, EventArgs e)
        {
            timerAutomatico.Stop();
        }

        private void buttonDatos_Click(object sender, EventArgs e)
        {
            CurrentDataMenu dataGrid = new CurrentDataMenu();
            dataGrid.ListaGridData = ListaData;
            dataGrid.Show();
        }

        private void botonRestart_Click(object sender, EventArgs e)
        {
            QposicionesAnterioresVuelos = new Stack<List<Position>>();
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

        private void botonCambiar_Click(object sender, EventArgs e)
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
            if (QposicionesAnterioresVuelos.Count>0)
            {
                List<Position> ListaPositionRetroceder = QposicionesAnterioresVuelos.Pop(); // A partir del primer no s'actualitza
                int i = 0;
                while (i < ListaData.GetNum())
                {
                    ListaData.GetFlightPlan(i).SetCurrentPosition(ListaPositionRetroceder[i].GetX(), ListaPositionRetroceder[i].GetY());
                    i = i + 1;
                }
                pintar();
                ListaData.GetFlightPlan(0).setComb(ListaData.GetFlightPlan(0).getComb() - 10);
                ListaData.GetFlightPlan(1).setComb(ListaData.GetFlightPlan(1).getComb() - 10);
                panel1.Invalidate();
            }
        }

        private void botonSaveTxt_Click(object sender, EventArgs e)
        {
            try
            {
                string Filename = textBoxFilename.Text;
                ListaData.WriteFPDoc(Filename, TiempoCicloSim, DistanciaSeguridadSim);
                botonSaveTxt.BackColor = Color.PaleGreen;
            }
            catch(FormatException)
            {
                MessageBox.Show("Format error");
                botonSaveTxt.BackColor = Color.LightCoral;
            }
        }
    }
}


