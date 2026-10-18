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
    public partial class FicheroOManual : Form
    {
        public int opt {  get; set; }
        public FicheroOManual()
        {
            InitializeComponent();
        }

        private void botonManual_Click(object sender, EventArgs e)   //elige de donde quieres cargar los datos, 1 si es manual, 2 si es de un fichero
        {
            opt = 1;
            Close();
        }

        private void botonFichero_Click(object sender, EventArgs e)
        {
            opt = 2;
            Close();
        }

        private void FicheroOManual_Load(object sender, EventArgs e)
        {

        }
    }
}
