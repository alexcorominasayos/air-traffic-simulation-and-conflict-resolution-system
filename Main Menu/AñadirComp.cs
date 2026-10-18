using BaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Main_Menu
{
    public partial class AñadirComp : Form
    {
        public AñadirComp()
        {
            InitializeComponent();
        }

        private void AñadirComp_Load(object sender, EventArgs e)
        {

        }

        private void botonAdd_Click(object sender, EventArgs e)
        {
            BD comp = new BD();
            comp.Iniciar();
            string nombre = txtNombre.Text;
            string id = txtID.Text;
            int num = Convert.ToInt32(txtNum.Text);
            try
            {
                string correo = textMail.Text.Replace(@"\", @"\\");
                correo.Remove(0,1);
                correo.Remove(correo.Length - 1,1);
                string foto = textFoto.Text;
                try
                {
                    if (File.Exists(foto))
                    { 
                        comp.AñadirComp(nombre,id, num, correo, foto, @"Data Source= BD.db");
                        botonAdd.BackColor = Color.PaleGreen;
                        botonAdd.Text = "Company added";
                        timerCerrar.Interval = 1750;
                        timerCerrar.Start();
                    }
                    else
                    { MessageBox.Show("This file does not exist or it may be a worng direction"); }
                }

                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
            catch (FormatException)
            { txtNum.BackColor = Color.LightCoral; }
        }

        private void timerCerrar_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
