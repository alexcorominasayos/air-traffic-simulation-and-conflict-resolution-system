using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Menu
{
    public partial class fpMenu : Form
    {
        public fpMenu()
        {
            InitializeComponent();
        }

        public FlightPlanList listaAddFPs { get; set; }                              //Se crea una lista que se usara para actualizar la del menu principal

        private void botonAceptarFPs_Click(object sender, EventArgs e)               //añade el flight plan a la lista, vacia todos los textbox, pone el boton verde si funciona, alguna label rojo si hay algun error y empieza el timer
        {
            try
            {
                SetInitials();
                string transponder1 = txtboxTransponderFP1.Text;                      //No se puede cargar de golpe por algun motivo, pero ahora no da error
                                                                                      //Tocar unicamente si es necesario
                double ipx1 = Convert.ToDouble(txtboxCoordInicialXFP1.Text);
                double ipy1 = Convert.ToDouble(txtboxCoordInicialYFP1.Text);

                double cpx1 = Convert.ToDouble(txtboxCoordInicialXFP1.Text);
                double cpy1 = Convert.ToDouble(txtboxCoordInicialYFP1.Text);

                double fpx1 = Convert.ToDouble(txtboxCoordFinXFP1.Text);
                double fpy1 = Convert.ToDouble(txtboxCoordFinYFP1.Text);

                double v1 = Convert.ToDouble(txtboxVelocidadFP1.Text);

                int comb1 = Convert.ToInt32(textBoxComb1.Text);


                int i = 0;
                bool mismasIDs = false;
                while (i < listaAddFPs.getVector().Count)
                {
                    if ((transponder1 == listaAddFPs.GetFlightPlan(i).getId()))
                    { mismasIDs = true; }
                    i++;
                }

                int j = 0;
                bool algunDatoIncorrecto = false;

                if (mismasIDs == true)
                {
                    j = 1;
                    algunDatoIncorrecto = true;
                }

                if (v1 <= 0)
                { 
                    j = 2;
                    algunDatoIncorrecto = true;
                }

                if (ipx1 > 898 || ipy1 > 598 || fpx1 > 898 || fpy1 > 598 || ipx1 < 0 || ipy1 < 0 || fpx1 < 0 || fpy1 < 0 )
                {
                    j = 3;
                    algunDatoIncorrecto = true;
                }

                if (j == 1)
                {
                    mismasIDsInformacion.Text = "   \n   The identifiers of the aircrafts must be different than the previously added ones   \n ";
                    mismasIDsInformacion.BackColor = Color.LightCoral;
                    mismasIDsInformacion.Visible = true;
                    txtboxTransponderFP1.BackColor = Color.LightCoral;

                }
                if (j == 2)
                {
                    NegativeVelocityInfo.Text = "   \n   The velocities must be positive   \n ";
                    NegativeVelocityInfo.BackColor = Color.LightCoral;
                    NegativeVelocityInfo.Visible = true;
                    txtboxVelocidadFP1.BackColor = Color.LightCoral;

                }
                if (j == 3)
                {
                    PositionsOutCanvasInfo.Text = "   \n   The positions are out of the canvas (x values between 0 and 897, y values between 0 and 597)   \n ";
                    PositionsOutCanvasInfo.BackColor = Color.LightCoral;
                    PositionsOutCanvasInfo.Visible = true;
                    txtboxCoordInicialXFP1.BackColor = Color.LightCoral;
                    txtboxCoordInicialYFP1.BackColor = Color.LightCoral;

                    txtboxCoordFinXFP1.BackColor = Color.LightCoral;
                    txtboxCoordFinYFP1.BackColor = Color.LightCoral;

                }

                if (algunDatoIncorrecto == false)
                {
                    FlightLib.FlightPlan FP1 = new FlightLib.FlightPlan(transponder1, ipx1, ipy1, cpx1, cpy1, fpx1, fpy1, v1, comb1);
                    //labeLInformacion.Text = "Load Correct";
                    listaAddFPs.AddFlightPlan(FP1);
                    textBoxComb1.Text = "";
                    txtboxCoordFinXFP1.Text = "";
                    txtboxCoordFinYFP1.Text = "";
                    txtboxCoordInicialXFP1.Text = "";
                    txtboxCoordInicialYFP1.Text = "";
                    txtboxVelocidadFP1.Text = "";
                    txtboxTransponderFP1.Text = "";

                    botonAceptarFPs.BackColor = Color.PaleGreen;
                    botonAceptarFPs.Text = "FP Added";
                    timerBotones.Interval = 2500;
                    timerBotones.Start();
                }
            }
            catch (FormatException)
            { MessageBox.Show("Format Error, check again"); }

        }

        private void buttonGoBack_Click(object sender, EventArgs e)   //cierra la ventana con los datos 
        {
            Close();
        }
        private void SetInitials()                                //pura estetica, pone los fondos transparentes de las labels transparentes y no visible apra cuando haya algun error
        {
            mismasIDsInformacion.BackColor = Color.White;
            mismasIDsInformacion.Visible = false;
            txtboxTransponderFP1.BackColor = Color.White;


            NegativeVelocityInfo.BackColor = Color.White;
            NegativeVelocityInfo.Visible = false;
            txtboxVelocidadFP1.BackColor = Color.White;


            PositionsOutCanvasInfo.BackColor = Color.White;
            PositionsOutCanvasInfo.Visible = false;
            txtboxCoordInicialXFP1.BackColor = Color.White;
            txtboxCoordInicialYFP1.BackColor = Color.White;

            txtboxCoordFinXFP1.BackColor = Color.White;
            txtboxCoordFinYFP1.BackColor = Color.White;

        }

        private void timerBotones_Tick(object sender, EventArgs e)          //cambia el color de la text box y el texto para que vuelva al estado inicial
        {
            botonAceptarFPs.BackColor = Color.White;
            botonAceptarFPs.Text = "Add Flight Plan";
            timerBotones.Stop();
        }
    }
}
