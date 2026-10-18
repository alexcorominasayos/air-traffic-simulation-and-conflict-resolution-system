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
    public partial class AddPoint : Form
    {
        public double XpuntoAdd { get; set; }                     //Se crean las variables que actualizaran las del menu principal
        public double YpuntoAdd { get; set; }
        public float RadiopuntoAdd { get; set; }
        public AddPoint()
        {
            InitializeComponent();
        }

        private void AddPointBtn_Click(object sender, EventArgs e)
        {
            XpuntoAdd = Convert.ToDouble(Xtextbox.Text);
            YpuntoAdd = Convert.ToDouble(Ytextbox.Text);
            RadiopuntoAdd = Convert.ToSingle(Radiotextbox.Text);
            MessageBox.Show("Added successfully");
            Close();
        }
    }
}
