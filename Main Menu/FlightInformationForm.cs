using System;
using System.Windows.Forms;
using FlightLib;

namespace Main_Menu
{
    /// <summary>
    /// Shows the details of the flight the user clicked on in the simulator.
    /// </summary>
    public partial class FlightInformationForm : Form
    {
        private readonly FlightPlan flight;

        /// <summary>Creates the window for the given flight.</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="flight"/> is null.</exception>
        public FlightInformationForm(FlightPlan flight)
        {
            InitializeComponent();
            this.flight = flight ?? throw new ArgumentNullException(nameof(flight));
        }

        private void FlightInformationForm_Load(object sender, EventArgs e)
        {
            idTextBox.Text = flight.Id;
            xTextBox.Text = Convert.ToString(Math.Round(flight.CurrentPosition.X, 2));
            yTextBox.Text = Convert.ToString(Math.Round(flight.CurrentPosition.Y, 2));
            speedTextBox.Text = Convert.ToString(Math.Round(flight.Speed, 2));
            fuelTextBox.Text = Convert.ToString(flight.Fuel);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
