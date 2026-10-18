using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Menu
{
    public partial class AbirTXT : Form
    {
        public AbirTXT()
        {
            InitializeComponent();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSi_Click(object sender, EventArgs e)
        {
            string rutaArchivo = "Conflict Log Solutions.txt";

            var psi = new ProcessStartInfo
            {
                FileName = rutaArchivo,
                UseShellExecute = true
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al abrir el archivo: {ex.Message}");
            }
            Close();
        }
    }
}
