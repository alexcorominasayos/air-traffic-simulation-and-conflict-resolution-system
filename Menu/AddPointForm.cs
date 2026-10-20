using System;
using System.Windows.Forms;

namespace Menu
{
    /// <summary>
    /// Defines the monitored point: a circle on the canvas that the simulator paints red
    /// whenever an aircraft is inside it.
    /// </summary>
    public partial class AddPointForm : Form
    {
        public AddPointForm()
        {
            InitializeComponent();
        }

        /// <summary>X coordinate of the circle's centre.</summary>
        public double PointX { get; set; }

        /// <summary>Y coordinate of the circle's centre.</summary>
        public double PointY { get; set; }

        /// <summary>Radius of the circle, in canvas units.</summary>
        public float Radius { get; set; }

        private void addPointButton_Click(object sender, EventArgs e)
        {
            if (!UiHelpers.TryParseDouble(xTextBox.Text, out double x) ||
                !UiHelpers.TryParseDouble(yTextBox.Text, out double y) ||
                !float.TryParse(radiusTextBox.Text, out float radius))
            {
                MessageBox.Show("Format Error, check again");
                return;
            }

            if (radius < 0)
            {
                MessageBox.Show("The radius can not be negative");
                return;
            }

            PointX = x;
            PointY = y;
            Radius = radius;
            MessageBox.Show("Added successfully");
            Close();
        }
    }
}
