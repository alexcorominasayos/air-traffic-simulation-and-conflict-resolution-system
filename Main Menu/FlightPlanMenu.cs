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

        private void botonAceptarFPs_Click(object sender, EventArgs e)
        {
            try
            {
                SetInitials();
                string transponder1 = txtboxTransponderFP1.Text;                      //No se puede cargar de golpe por algun motivo, pero ahora no da error
                string transponder2 = txtboxTransponderFP2.Text;                      //Tocar unicamente si es necesario
                double ipx1 = Convert.ToDouble(txtboxCoordInicialXFP1.Text);
                double ipy1 = Convert.ToDouble(txtboxCoordInicialYFP1.Text);
                double ipx2 = Convert.ToDouble(txtboxCoordInicialXFP2.Text);
                double ipy2 = Convert.ToDouble(txtboxCoordInicialYFP2.Text);
                double cpx1 = Convert.ToDouble(txtboxCoordInicialXFP1.Text);
                double cpy1 = Convert.ToDouble(txtboxCoordInicialYFP1.Text);
                double cpx2 = Convert.ToDouble(txtboxCoordInicialXFP2.Text);
                double cpy2 = Convert.ToDouble(txtboxCoordInicialYFP2.Text);
                double fpx1 = Convert.ToDouble(txtboxCoordFinXFP1.Text);
                double fpy1 = Convert.ToDouble(txtboxCoordFinYFP1.Text);
                double fpx2 = Convert.ToDouble(txtboxCoordFinXFP2.Text);
                double fpy2 = Convert.ToDouble(txtboxCoordFinYFP2.Text);
                double v1 = Convert.ToDouble(txtboxVelocidadFP1.Text);
                double v2 = Convert.ToDouble(txtboxVelocidadFP2.Text);
                int comb1 = Convert.ToInt32(textBoxComb1.Text);
                int comb2 = Convert.ToInt32(textBoxComb2.Text);

                int i = 0;
                bool mismasIDs = false;
                while (i < listaAddFPs.GetCount())
                {
                    if ((transponder1 == listaAddFPs.GetFlightPlan(i).getId()) || (transponder2 == listaAddFPs.GetFlightPlan(i).getId()))
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

                if (v1 <= 0 || v2 <= 0)
                { 
                    j = 2;
                    algunDatoIncorrecto = true;
                }

                if (ipx1 > 601 || ipy1 > 601 || ipx2 > 601 || ipy2 > 601 || fpx1 > 601 || fpy1 > 601 || fpx2 > 601 || fpy2 > 601 || ipx1 < 0 || ipy1 < 0 || ipx2 < 0 || ipy2 < 0 || fpx1 < 0 || fpy1 < 0 || fpx2 < 0 || fpy2 < 0)
                {
                    j = 3;
                    algunDatoIncorrecto = true;
                }

                if (j == 1)
                {
                    mismasIDsInformacion.Text = "   \n   Los identificadores de los aviones deben ser diferentes a los añadidos anteriormente   \n ";
                    mismasIDsInformacion.BackColor = Color.LightCoral;
                    mismasIDsInformacion.Visible = true;
                    txtboxTransponderFP1.BackColor = Color.LightCoral;
                    txtboxTransponderFP2.BackColor = Color.LightCoral;
                }
                if (j == 2)
                {
                    NegativeVelocityInfo.Text = "   \n   Las velocidades tienen que ser positivas   \n ";
                    NegativeVelocityInfo.BackColor = Color.LightCoral;
                    NegativeVelocityInfo.Visible = true;
                    txtboxVelocidadFP1.BackColor = Color.LightCoral;
                    txtboxVelocidadFP2.BackColor = Color.LightCoral;
                }
                if (j == 3)
                {
                    PositionsOutCanvasInfo.Text = "   \n   Las posiciones se salen del canvas   \n ";
                    PositionsOutCanvasInfo.BackColor = Color.LightCoral;
                    PositionsOutCanvasInfo.Visible = true;
                    txtboxCoordInicialXFP1.BackColor = Color.LightCoral;
                    txtboxCoordInicialYFP1.BackColor = Color.LightCoral;
                    txtboxCoordInicialXFP2.BackColor = Color.LightCoral;
                    txtboxCoordInicialYFP2.BackColor = Color.LightCoral;
                    txtboxCoordFinXFP1.BackColor = Color.LightCoral;
                    txtboxCoordFinYFP1.BackColor = Color.LightCoral;
                    txtboxCoordFinXFP2.BackColor = Color.LightCoral;
                    txtboxCoordFinYFP2.BackColor = Color.LightCoral;
                }

                if (algunDatoIncorrecto == false)
                {
                    FlightLib.FlightPlan FP1 = new FlightLib.FlightPlan(transponder1, ipx1, ipy1, cpx1, cpy1, fpx1, fpy1, v1, comb1);
                    FlightLib.FlightPlan FP2 = new FlightLib.FlightPlan(transponder2, ipx2, ipy2, cpx2, cpy2, fpx2, fpy2, v2, comb2);

                    labeLInformacion.Text = "Load Correct";

                    listaAddFPs.AddFlightPlan(FP1);
                    listaAddFPs.AddFlightPlan(FP2);

                    Close();
                }
            }
            catch (FormatException)
            { MessageBox.Show("Format Error, check again"); }

        }

        private void botonAutoFillFPs_Click(object sender, EventArgs e)
        {
            string Transponder1 = "VY";                             // Para toda esta funcion se le dan unos valores predeterminados 
            string Transponder2 = "IB";                             // Que se autoescriben en las cajas de txt para luego ya poder cargarlas :)
            txtboxTransponderFP1.Text = Transponder1;               // NO TOCAR ESTA FUNCION, funciona.
            txtboxTransponderFP2.Text = Transponder2;

            double ixc1 = 15;
            double iyc1 = 564;
            double ixc2 = 146;
            double iyc2 = 234;
            txtboxCoordInicialXFP1.Text = Convert.ToString(ixc1);
            txtboxCoordInicialYFP1.Text = Convert.ToString(iyc1);
            txtboxCoordInicialXFP2.Text = Convert.ToString(ixc2);
            txtboxCoordInicialYFP2.Text = Convert.ToString(iyc2);

            double fxc1 = 152;
            double fyc1 = 156;
            double fxc2 = 420;
            double fyc2 = 69;
            txtboxCoordFinXFP1.Text = Convert.ToString(fxc1);
            txtboxCoordFinYFP1.Text = Convert.ToString(fyc1);
            txtboxCoordFinXFP2.Text = Convert.ToString(fxc2);
            txtboxCoordFinYFP2.Text = Convert.ToString(fyc2);

            double vel1 = 10;
            double vel2 = 20;
            txtboxVelocidadFP1.Text = Convert.ToString(vel1);
            txtboxVelocidadFP2.Text = Convert.ToString(vel2);

            int comb1 = 30000;
            int comb2 = 32000;
            textBoxComb1.Text = Convert.ToString(comb1);
            textBoxComb2.Text = Convert.ToString(comb2);
        }

        private void botonRellenarConConflicto_Click(object sender, EventArgs e)
        {
            string Transponder1 = "VY";                             // Para toda esta funcion se le dan unos valores predeterminados 
            string Transponder2 = "IB";                             // Que se autoescriben en las cajas de txt para luego ya poder cargarlas :)
            txtboxTransponderFP1.Text = Transponder1;               // NO TOCAR ESTA FUNCION, funciona.
            txtboxTransponderFP2.Text = Transponder2;

            double ixc1 = 0;
            double iyc1 = 0;
            double ixc2 = 0;
            double iyc2 = 200;
            txtboxCoordInicialXFP1.Text = Convert.ToString(ixc1);
            txtboxCoordInicialYFP1.Text = Convert.ToString(iyc1);
            txtboxCoordInicialXFP2.Text = Convert.ToString(ixc2);
            txtboxCoordInicialYFP2.Text = Convert.ToString(iyc2);

            double fxc1 = 200;
            double fyc1 = 200;
            double fxc2 = 200;
            double fyc2 = 0;
            txtboxCoordFinXFP1.Text = Convert.ToString(fxc1);
            txtboxCoordFinYFP1.Text = Convert.ToString(fyc1);
            txtboxCoordFinXFP2.Text = Convert.ToString(fxc2);
            txtboxCoordFinYFP2.Text = Convert.ToString(fyc2);

            double vel1 = 25;
            double vel2 = 25;
            txtboxVelocidadFP1.Text = Convert.ToString(vel1);
            txtboxVelocidadFP2.Text = Convert.ToString(vel2);

            int comb1 = 30000;
            int comb2 = 32000;
            textBoxComb1.Text = Convert.ToString(comb1);
            textBoxComb2.Text = Convert.ToString(comb2);
        }

        private void fpMenu_Load(object sender, EventArgs e)
        {

        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SetInitials()
        {
            mismasIDsInformacion.BackColor = Color.White;
            mismasIDsInformacion.Visible = false;
            txtboxTransponderFP1.BackColor = Color.White;
            txtboxTransponderFP2.BackColor = Color.White;

            NegativeVelocityInfo.BackColor = Color.White;
            NegativeVelocityInfo.Visible = false;
            txtboxVelocidadFP1.BackColor = Color.White;
            txtboxVelocidadFP2.BackColor = Color.White;

            PositionsOutCanvasInfo.BackColor = Color.White;
            PositionsOutCanvasInfo.Visible = false;
            txtboxCoordInicialXFP1.BackColor = Color.White;
            txtboxCoordInicialYFP1.BackColor = Color.White;
            txtboxCoordInicialXFP2.BackColor = Color.White;
            txtboxCoordInicialYFP2.BackColor = Color.White;
            txtboxCoordFinXFP1.BackColor = Color.White;
            txtboxCoordFinYFP1.BackColor = Color.White;
            txtboxCoordFinXFP2.BackColor = Color.White;
            txtboxCoordFinYFP2.BackColor = Color.White;
        }
    }
}
