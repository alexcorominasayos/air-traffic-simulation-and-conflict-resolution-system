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
                    MessageBox.Show("The value introduced is negative, both have been stablished at 30");
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
                    MessageBox.Show("The value introduced is negative, both have been stablished at 30");
                    return 30;
                }
                else
                {
                    return entero;
                }
            }
            
        }

        private void buttonAceptar_Click(object sender, EventArgs e)          //carga los presets con los numeros de las text box
        {
            try
            {

                if (Convert.ToDouble(txtBoxSafeDist.Text) > 100 || Convert.ToDouble(txtBoxCicle.Text) > 100)
                {
                    MessageBox.Show("Values are too big");
                }

                else
                {
                    if ((DarIntDeDouble(txtBoxCicle.Text)) <= 0 || DarIntDeDouble(txtBoxSafeDist.Text) <= 0)
                    {
                        MessageBox.Show("There are values lower or equal to 0");
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

        private void buttonAutofill_Click(object sender, EventArgs e)      //autofill 
        {
            txtBoxSafeDist.Text = "30";
            txtBoxCicle.Text = "60";
        }

        private void preSetsMenu_Load(object sender, EventArgs e)   //estetica
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            labelInformacion.BackColor = Color.Transparent;
            LabelCiclos.BackColor = Color.Transparent;
            labelPreSets.BackColor = Color.Transparent;
            LabelDistanciaSeg.BackColor = Color.Transparent;

        }
    }
}
