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
using Videogame;


namespace Main_Menu
{
    public partial class Form1 : Form
    {
        //Se crean las variables y se inicializan en InitializeComponent()
        public FlightPlanList listaFPs { get; set; }
        public Stack<FlightPlanList> PosAnt { get; set; }
        public int TiempoCiclo { get; set; }
        public int DistanciaSeguridad { get; set; }
        public bool solucionConfl { get; set; }

        public string usuario;
        public void SetUsuario(string u)
        { this.usuario = u; }


        bool FPintro = false;
        bool CicloDistintro = false;

        SoundPlayer simpleSound;

        // NUEVA FUNCIONALIDAD
        double XpuntoMain;
        double YpuntoMain;
        float RadiopuntoMain;

        public Form1()
        {
            InitializeComponent();
            listaFPs = new FlightPlanList();
            TiempoCiclo = 0;
            DistanciaSeguridad = 0;
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

        private void Form1_Load(object sender, EventArgs e)       //carga la estetica y la musica del gtav 
        {

            //estetica
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
            labelguillem.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Center;
            {
                labelWelcomeBack.Text = "Welcome back, " +usuario+" :)";
            }
        }

        private void buttonSimulacion_Click(object sender, EventArgs e)
        {
            if ((CicloDistintro) && (FPintro))                //si se ha añadido un fp y los presets, se abre y mira is va a haber conflicto, sino, salta un aviso
            {
                bool respuesta = false;
                simulatorMenu simMenu = new simulatorMenu();
                int i = 0;
                List<double> Lvelorigs = new List<double>();
                List<double> LvelCamb = new List<double>();
                while (i<listaFPs.GetNum())
                {
                    double velorg = listaFPs.GetFlightPlan(i).GetVelocidad();
                    Lvelorigs.Add(velorg);
                    int j = 0;
                    while (j < listaFPs.GetNum())
                    {
                        if (i != j)
                        {
                            if (listaFPs.GetFlightPlan(i).HayConflicto(DistanciaSeguridad, listaFPs.GetFlightPlan(j)))
                            {
                                if (respuesta == false)
                                {
                                    ConflictoSolverMenu solucionador = new ConflictoSolverMenu();
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
                    LvelCamb.Add(listaFPs.GetFlightPlan(i).GetVelocidad());
                    i = i + 1;
                }
                if (solucionConfl == true)
                {
                    AbirTXT ab = new AbirTXT();
                    ab.ShowDialog();
                }
                listaFPs.TextFPChanged(Lvelorigs, LvelCamb, listaFPs);
                simMenu.ListaData = listaFPs;
                simMenu.QposicionesAnterioresVuelos = PosAnt;
                simMenu.DistanciaSeguridadSim = DistanciaSeguridad;
                simMenu.TiempoCicloSim = TiempoCiclo;
                simMenu.XpuntoSim = XpuntoMain;
                simMenu.YpuntoSim = YpuntoMain;
                simMenu.RadiopuntoSim = RadiopuntoMain;
                simMenu.ShowDialog();
                listaFPs = simMenu.ListaData;
                PosAnt = simMenu.QposicionesAnterioresVuelos;
            }
            else
            {
                if (FPintro == false)
                {
                    if (CicloDistintro == false)
                    { MessageBox.Show("Flight plan and pre-sets missing"); }
                    else
                    { MessageBox.Show("Flight plan missing"); }
                }

                if (CicloDistintro == false && FPintro == true)
                    { MessageBox.Show("Pre-Sets missing"); }
                
            }
        }

        private void botonAuto_Click(object sender, EventArgs e)     //esto se oculta en la version que se entrega
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

        private void botonAutoConf_Click(object sender, EventArgs e)    //esto se oculta en la version que se entrega
        {
            string Transponder1 = "VLG123";                             // Para toda esta funcion se le dan unos valores predeterminados 
            string Transponder2 = "IBE456";                             // Que se autoescriben en las cajas de txt para luego ya poder cargarlas :)

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

        private void botonLogOut_Click(object sender, EventArgs e)      //te saca al memu de la contraseña para iniciar sesion
        {
            MenuContraseña fc = new MenuContraseña();
            fc.Show();
            Close();
        }

        private void botonCerra_Click(object sender, EventArgs e)     //cierra la aplicacion y todo los procesos 
        {
            Application.Exit();
        }

        private void buttonLoadFP_Click(object sender, EventArgs e)       //carga los fp 
        {
            int opt = 0;
            FicheroOManual fom = new FicheroOManual();
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
            if (opt == 2)
            {
                CargarFichero cf = new CargarFichero();
                cf.datosFich = listaFPs;
                cf.listaAnterior = PosAnt;
                cf.ShowDialog();
                listaFPs = cf.datosFich;
                PosAnt = cf.listaAnterior;
                TiempoCiclo = cf.TC;
                DistanciaSeguridad = cf.DS;
                if (listaFPs.GetNum() > 0)
                {
                    CicloDistintro = true;
                    FPintro = true;
                }
            }
        }

        private void botonCompañias_Click(object sender, EventArgs e)
        {
            MenuCompañiasAereas MCA = new MenuCompañiasAereas();
            MCA.ShowDialog();
        }

        private void ClearFPsBtn_Click(object sender, EventArgs e)
        {
            listaFPs.ClearFlightPlanList();
            TiempoCiclo = 0;
            DistanciaSeguridad = 0;
            FPintro = false;
            CicloDistintro = false;
        }

        private void VideogameBtn_Click(object sender, EventArgs e)
        {
            Videogame.MainWindow Game = new Videogame.MainWindow();
            simpleSound.Stop();
            this.Hide();

            Game.ShowDialog();
            //Game.Stop();

            this.Show();
            simpleSound.Play();
        }

        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            AddPoint addPoint = new AddPoint();
            addPoint.XpuntoAdd = XpuntoMain;                 //Repite los pasos que antes, copia los datos en una variable del otro menu 
            addPoint.YpuntoAdd = YpuntoMain;
            addPoint.RadiopuntoAdd = RadiopuntoMain;
            addPoint.ShowDialog();
            XpuntoMain = addPoint.XpuntoAdd;   //Aqui recibe esos datos actualizados
            YpuntoMain = addPoint.YpuntoAdd;
            RadiopuntoMain = addPoint.RadiopuntoAdd;
        }
    }
}
