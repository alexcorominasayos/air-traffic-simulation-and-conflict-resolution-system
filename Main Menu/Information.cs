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
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }
        public FlightPlan myFlight { get; set; }
        public FlightPlanList listaFPsInfo { get; set; }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Information_Load(object sender, EventArgs e) //carga los datos de la lista en el avion que se clica 
        {
            IDBox.Text = myFlight.getId();
            XBox.Text = Convert.ToString(Math.Round(myFlight.GetCurrentPosition().GetX(),2));
            YBox.Text = Convert.ToString(Math.Round(myFlight.GetCurrentPosition().GetY(),2));
            SpeedBox.Text = Convert.ToString(Math.Round(myFlight.GetVelocidad(),2));
            FuelBox.Text = Convert.ToString(myFlight.getComb());
        }
    }
}
