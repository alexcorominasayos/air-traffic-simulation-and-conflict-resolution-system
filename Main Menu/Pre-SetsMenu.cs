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
    public partial class preSetsMenu : Form
    {
        public int TiempoCicloPresets { get; set; }                     //Se crean las variables que actualizaran las del menu principal
        public int DistanciaSeguridadPresets { get; set; }
        public preSetsMenu()
        {
            InitializeComponent();
        }

        public int DarIntDeDouble (string i)
        {
            try
            {
                string[] trozos = i.Split('.');
                int entero = Convert.ToInt32(trozos[0]);
                if (entero < 0)
                {
                    MessageBox.Show("El valor introducido es negativo, se han establecido ambos como: 30");
                    return 30; 
                }
                else
                {
                    return entero;
                }
            }
            catch (FormatException)
            {
                int entero = Convert.ToInt32(i);
                if (entero < 0)
                {
                    MessageBox.Show("El valor introducido es negativo, se han establecido ambos como: 30");
                    return 30;
                }
                else
                {
                    return entero;
                }
            }
            
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToDouble(txtBoxSafeDist.Text) > 100 || Convert.ToDouble(txtBoxCicle.Text) > 100)
                {
                    MessageBox.Show("Los numeros son muy grandes");
                }

                else
                {
                    if ((DarIntDeDouble(txtBoxCicle.Text)) <= 0 || DarIntDeDouble(txtBoxSafeDist.Text) <= 0)
                    {
                        MessageBox.Show("Hay valores iguales o menor a 0");
                    }

                    else
                    {
                        TiempoCicloPresets = DarIntDeDouble(txtBoxCicle.Text);
                        DistanciaSeguridadPresets = DarIntDeDouble(txtBoxSafeDist.Text);
                        labelInformacion.Text = "Load succesfull";
                        Close();
                    }
                }

                
            }
            catch (FormatException)
            { MessageBox.Show("Format Error") ; }
        }

        private void buttonAutofill_Click(object sender, EventArgs e)
        {
            txtBoxSafeDist.Text = "30";
            txtBoxCicle.Text = "60";
        }

        private void preSetsMenu_Load(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            labelInformacion.BackColor = Color.Transparent;
            LabelCiclos.BackColor = Color.Transparent;
            labelPreSets.BackColor = Color.Transparent;
            LabelDistanciaSeg.BackColor = Color.Transparent;

        }
    }
}
