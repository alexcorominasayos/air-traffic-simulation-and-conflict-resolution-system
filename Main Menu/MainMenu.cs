using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;
using System.Media;
using System.IO;
using BaseDatos;
using System.Runtime.CompilerServices;


namespace Main_Menu
{
    public partial class Form1 : Form
    {
        //Se crean las variables y se inicializan en InitializeComponent()
        public FlightPlanList listaFPs { get; set; }
        public int TiempoCiclo { get; set; }
        public int DistanciaSeguridad { get; set; }
        public bool solucionConfl { get; set; }
        public string usuario;
        public void SetUsuario(string u)
        { this.usuario = u; }
        

        bool FPintro = false;
        bool CicloDistintro = false;
        
        
        public Form1()
        {
            InitializeComponent();
            listaFPs = new FlightPlanList();
            TiempoCiclo = 0;
            DistanciaSeguridad = 0;
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }
        
        private void botonAddFlightPlan_Click(object sender, EventArgs e)
        {
            fpMenu addFP = new fpMenu();
            addFP.listaAddFPs = listaFPs;       //Pasa la listaFPs a la listaAddFPs que es la que esta en el otro menu
            addFP.ShowDialog();
            listaFPs = addFP.listaAddFPs;       //Recibe la listaAddFPs y la copia en la listaFPs que es la principal
            if (listaFPs.GetNum() > 1)
                { FPintro = true; }
        }

        private void botonPreSets_Click(object sender, EventArgs e)
        {
            preSetsMenu addPS = new preSetsMenu();
            addPS.TiempoCicloPresets = TiempoCiclo;                 //Repite los pasos que antes, copia los datos en una variable del otro menu 
            addPS.DistanciaSeguridadPresets = DistanciaSeguridad;
            addPS.ShowDialog();
            DistanciaSeguridad = addPS.DistanciaSeguridadPresets;   //Aqui recibe esos datos actualizados
            TiempoCiclo = addPS.TiempoCicloPresets;
            if (DistanciaSeguridad != 0 || TiempoCiclo != 0)
                CicloDistintro = true; 

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip info = new ToolTip();
            info.AutoPopDelay = 5000;
            info.InitialDelay = 800;
            info.ReshowDelay = 100;
            info.ShowAlways = true;
            info.SetToolTip(botonCerra, "Close the program and all proceses runing");
            info.SetToolTip(buttonLoadFP, "Load Flight Plans from scratch by entering data manually or by a .txt file");
            info.SetToolTip(buttonSimulacion, "Shows de trajectory and possible collisions of the Flight Plans");
            info.SetToolTip(botonPreSets, "Allows to establish the safe distance between planes and the time of simulation");
            info.SetToolTip(botonLogOut, "Closes your session");
            labelTitulo.BackColor = Color.Transparent;
            labelWelcomeBack.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Center;
            {
                labelWelcomeBack.Text = "Welcome back, " +usuario+" :)";
                try
                {
                    SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.musicaGTA);
                    simpleSound.Play();
                }
                catch (FileNotFoundException)
                { }
            }
        }

        private void buttonSimulacion_Click(object sender, EventArgs e)
        {
            if (CicloDistintro == true && FPintro == true)
            {
                bool respuesta = false;
                simulatorMenu simMenu = new simulatorMenu();
                int i = 0;
                while (i<listaFPs.GetNum())
                {
                    int j = 0;
                    while (j < listaFPs.GetNum())
                    {
                        if (i != j)
                        {
                            if (listaFPs.GetFlightPlan(i).HayConflicto(DistanciaSeguridad, listaFPs.GetFlightPlan(j)))
                            {
                                if (respuesta == false)
                                {
                                    ConflictSolverMenu solucionador = new ConflictSolverMenu();
                                    solucionador.ShowDialog();
                                    solucionConfl = solucionador.arreglar;
                                    respuesta = true;
                                }
                                if (solucionConfl == true)
                                {
                                    listaFPs.GetFlightPlan(i).SolucionadorConflictosCambioVel(DistanciaSeguridad, listaFPs.GetFlightPlan(j));
                                }
                                j = j + 1;
                            }
                            else
                            {
                                j = j + 1;
                            }
                        }
                        else
                        {
                            j = j + 1;
                        }
                    }
                    i = i + 1;
                }
                simMenu.ListaData = listaFPs;
                simMenu.DistanciaSeguridadSim = DistanciaSeguridad;
                simMenu.TiempoCicloSim = TiempoCiclo;
                simMenu.Show();
                listaFPs = simMenu.ListaData;
            }
            else
            {
                if (FPintro == false)
                {
                    if (CicloDistintro == false)
                    { MessageBox.Show("Faltan los Presets y los Flight plans"); }
                    else
                    { MessageBox.Show("Faltan los Flight Plan"); }
                }

                if (CicloDistintro == false && FPintro == true)
                    { MessageBox.Show("Faltan los presets"); }
                
            }
        }

        private void botonAuto_Click(object sender, EventArgs e)
        {
            string Transponder1 = "VY";                             // Para toda esta funcion se le dan unos valores predeterminados 
            string Transponder2 = "IB";                             // Que se autoescriben en las cajas de txt para luego ya poder cargarlas :)

            double ixc1 = 15;
            double iyc1 = 564;
            double ixc2 = 146;
            double iyc2 = 234;

            double fxc1 = 152;
            double fyc1 = 156;
            double fxc2 = 420;
            double fyc2 = 69;

            double vel1 = 10;
            double vel2 = 20;

            int combustible1 = 10000;
            int combusitble2 = 34000;

            FlightLib.FlightPlan FP1 = new FlightLib.FlightPlan(Transponder1, ixc1, iyc1, ixc1, iyc1, fxc1, fyc1, vel1, combustible1);
            FlightLib.FlightPlan FP2 = new FlightLib.FlightPlan(Transponder2, ixc2, iyc2, ixc2, iyc2, fxc2, fyc2, vel2, combusitble2);

            listaFPs.AddFlightPlan(FP1);
            listaFPs.AddFlightPlan(FP2);

            TiempoCiclo = 60;
            DistanciaSeguridad = 30;

            CicloDistintro = true;
            FPintro = true;
        }

        private void botonAutoConf_Click(object sender, EventArgs e)
        {
            string Transponder1 = "VY";                             // Para toda esta funcion se le dan unos valores predeterminados 
            string Transponder2 = "IB";                             // Que se autoescriben en las cajas de txt para luego ya poder cargarlas :)

            double ixc1 = 0;
            double iyc1 = 0;
            double ixc2 = 0;
            double iyc2 = 200;

            double fxc1 = 200;
            double fyc1 = 200;
            double fxc2 = 200;
            double fyc2 = 0;

            double vel1 = 25;
            double vel2 = 25;

            int combustible1 = 10000;
            int combusitble2 = 34000;

            FlightLib.FlightPlan FP1 = new FlightLib.FlightPlan(Transponder1, ixc1, iyc1, ixc1, iyc1, fxc1, fyc1, vel1, combustible1);
            FlightLib.FlightPlan FP2 = new FlightLib.FlightPlan(Transponder2, ixc2, iyc2, ixc2, iyc2, fxc2, fyc2, vel2, combusitble2);

            listaFPs.AddFlightPlan(FP1);
            listaFPs.AddFlightPlan(FP2);

            TiempoCiclo = 60;
            DistanciaSeguridad = 30;

            CicloDistintro = true;
            FPintro = true;
        }

        private void botonLogOut_Click(object sender, EventArgs e)
        {
            LogInMenu fc = new LogInMenu();
            fc.Show();
            Close();
        }

        private void botonCerra_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void botonLoadFile_Click(object sender, EventArgs e)
        {
            LoadFileMenu cf = new LoadFileMenu();
            cf.datosFich = listaFPs;
            cf.ShowDialog();
            listaFPs = cf.datosFich;
            TiempoCiclo = Convert.ToInt32(cf.lista[0]);
            DistanciaSeguridad = Convert.ToInt32(cf.lista[1]);
            if (listaFPs.GetNum() > 0)
            {
                CicloDistintro = true;
                FPintro = true;
            }
        }

        private void buttonLoadFP_Click(object sender, EventArgs e)
        {
            int opt = 0;
            ImportDataMenu fom = new ImportDataMenu();
            fom.opt = opt;
            fom.ShowDialog();
            opt = fom.opt;
            if (opt == 0)
            { MessageBox.Show("Nothing has been selected"); }
            if (opt == 1)
            {
                fpMenu addFP = new fpMenu();
                addFP.listaAddFPs = listaFPs;       //Pasa la listaFPs a la listaAddFPs que es la que esta en el otro menu
                addFP.ShowDialog();
                listaFPs = addFP.listaAddFPs;       //Recibe la listaAddFPs y la copia en la listaFPs que es la principal
                if (listaFPs.GetNum() > 1)
                { FPintro = true; }
            }
            if (opt==2)
            {
                LoadFileMenu cf = new LoadFileMenu();
                cf.datosFich = listaFPs;
                cf.ShowDialog();
                listaFPs = cf.datosFich;
                TiempoCiclo = Convert.ToInt32(cf.lista[0]);
                DistanciaSeguridad = Convert.ToInt32(cf.lista[1]);
                if (listaFPs.GetNum() > 0)
                {
                    CicloDistintro = true;
                    FPintro = true;
                }
            }
        }

        private void labelWelcomeBack_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer brrr = new SoundPlayer(Properties.Resources.Brrr_bebesitaa_Sonido_Anuel__Efecto_de_sonido_______ezmp3_cc__);
                brrr.Play();
            }
            catch (FileNotFoundException)
            { }
        }
    }
}
