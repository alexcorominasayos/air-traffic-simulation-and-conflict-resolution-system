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
    public partial class ConflictSolverMenu : Form
    {
        public bool arreglar {  get; set; }

        public ConflictSolverMenu()
        {
            InitializeComponent();
        }

        private void botonSolveConfl_Click(object sender, EventArgs e)
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
