using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Menu
{
    public partial class CargarFichero : Form
    {
        public FlightPlanList datosFich {  get; set; }
        public Stack<FlightPlanList> listaAnterior { get; set; }
        public int TC {  get; set; }
        public int DS { get; set; }
        public CargarFichero()
        {
            InitializeComponent();
        }

        private void botonCargar_Click(object sender, EventArgs e)
        {
            try   //Intenta cargar el fichero con el nombre introducido en el text box
            {
                StreamReader R = new StreamReader(txtBoxNombre.Text + ".txt");
                listaAnterior = new Stack<FlightPlanList>();
                string linea = R.ReadLine();
                linea = R.ReadLine();
                string[] tcds = linea.Split(' ');
                TC = Convert.ToInt32(tcds[0]);
                DS = Convert.ToInt32(tcds[1]);
                linea = R.ReadLine();
                linea = R.ReadLine();
                bool load = false;
                int i = 0;
                int FPsize = 0;
                FlightPlanList Ltemp = new FlightPlanList();
                Stack<FlightPlanList> FPL = new Stack<FlightPlanList>();
                while (linea != null)
                {
                    string[] trozos = linea.Split(' ');
                    if (trozos[0] != "-" && !load)
                    {
                        Console.WriteLine(trozos);
                        string id = trozos[0];
                        double xi = Convert.ToDouble(trozos[1]);
                        double yi = Convert.ToDouble(trozos[2]);
                        double cx = Convert.ToDouble(trozos[3]);
                        double cy = Convert.ToDouble(trozos[4]);
                        double xf = Convert.ToDouble(trozos[5]);
                        double yf = Convert.ToDouble(trozos[6]);
                        double velocidad = Convert.ToDouble(trozos[7]);
                        int combustible = Convert.ToInt32(trozos[8]);
                        FlightPlan FP = new FlightPlan(id, xi, yi, cx, cy, xf, yf, velocidad, combustible);
                        datosFich.AddFlightPlan(FP);
                        FPsize += 1;
                        linea = R.ReadLine();
                    }
                    else if (load)
                    {
                        if (i == FPsize)
                        {
                            FPL.Push(Ltemp);
                            Ltemp = new FlightPlanList();
                            i = 0;
                        }
                        i += 1;
                        string id = trozos[0];
                        double xi = Convert.ToDouble(trozos[1]);
                        double yi = Convert.ToDouble(trozos[2]);
                        double cx = Convert.ToDouble(trozos[3]);
                        double cy = Convert.ToDouble(trozos[4]);
                        double xf = Convert.ToDouble(trozos[5]);
                        double yf = Convert.ToDouble(trozos[6]);
                        double velocidad = Convert.ToDouble(trozos[7]);
                        int combustible = Convert.ToInt32(trozos[8]);
                        FlightPlan Ptemp = new FlightPlan(id, xi, yi, cx, cy, xf, yf, velocidad, combustible);
                        Ltemp.AddFlightPlan(Ptemp);
                        linea = R.ReadLine();
                    }
                    else if (trozos[0] == "-")
                    {
                        load = true;
                        linea = R.ReadLine();
                        i = 0;
                    }
                }
                while (FPL.Count != 0) 
                {
                    listaAnterior.Push(FPL.Pop());
                }
                botonCargar.BackColor = Color.PaleGreen;
                botonCargar.Text = "Load Succesfull";
                timerCerrar.Interval = 1000;
                timerCerrar.Start();
            }
            catch (FileNotFoundException)        //Si el fichero no existe el boton se pone rojo
            {
                botonCargar.BackColor = Color.LightCoral;
                botonCargar.Text = "File Not Found";
            }
            catch(FormatException)
            {
                botonCargar.BackColor= Color.LightCoral;
                botonCargar.Text = "Format error";
            }
            
        }

        private void timerCerrar_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarFichero_Load(object sender, EventArgs e)
        {

        }
    }
}
