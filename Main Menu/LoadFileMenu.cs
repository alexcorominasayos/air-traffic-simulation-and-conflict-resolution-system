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
    public partial class LoadFileMenu : Form
    {
        public FlightPlanList datosFich {  get; set; }
        public List<string> lista {  get; set; }
        public LoadFileMenu()
        {
            InitializeComponent();
        }

        private void botonCargar_Click(object sender, EventArgs e)
        {
            try
            {
                datosFich = new FlightPlanList();
                lista = datosFich.GetPlanDoc(txtBoxNombre.Text+".txt");
                botonCargar.BackColor = Color.LimeGreen;
                botonCargar.Text = "Load Succesfull";
                timerCerrar.Interval = 1500;
                timerCerrar.Start();
                MessageBox.Show(Convert.ToString(datosFich.GetNum()));
            }
            catch (FileNotFoundException)
            {
                botonCargar.BackColor = Color.Red;
                botonCargar.Text = "File Not Found";
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
