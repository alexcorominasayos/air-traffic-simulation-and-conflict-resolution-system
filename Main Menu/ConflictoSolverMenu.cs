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
    public partial class ConflictoSolverMenu : Form
    {
        public bool arreglar {  get; set; }

        public ConflictoSolverMenu()
        {
            InitializeComponent();
        }

        private void botonSolveConfl_Click(object sender, EventArgs e)                     //devuelve true o false dependiendo de si se quiere arreglar el conflicto
        {
            arreglar = true; 
            Close();
        }

        private void botonNoSolveConfl_Click(object sender, EventArgs e)
        {
            arreglar = false;
            Close();
        }
    }
}
