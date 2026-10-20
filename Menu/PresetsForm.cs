using System;
using System.Drawing;
using System.Windows.Forms;

namespace Menu
{
    /// <summary>
    /// Lets the user set the simulation's cycle time and safety distance.
    /// </summary>
    public partial class PresetsForm : Form
    {
        /// <summary>Largest value accepted for either setting.</summary>
        private const double MaximumValue = 100;

        /// <summary>Values offered by the "Autofill" button.</summary>
        private const string DefaultSafetyDistance = "30";
        private const string DefaultCycleTime = "60";

        public PresetsForm()
        {
            InitializeComponent();
        }

        /// <summary>Simulated seconds per cycle. Read it back after the dialog closes.</summary>
        public int CycleTime { get; set; }

        /// <summary>Minimum separation between aircraft. Read it back after the dialog closes.</summary>
        public int SafetyDistance { get; set; }

        private void PresetsForm_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            instructionsLabel.BackColor = Color.Transparent;
            cycleTimeLabel.BackColor = Color.Transparent;
            titleLabel.BackColor = Color.Transparent;
            safetyDistanceLabel.BackColor = Color.Transparent;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (!UiHelpers.TryParseDouble(cycleTimeTextBox.Text, out double cycleValue) ||
                !UiHelpers.TryParseDouble(safetyDistanceTextBox.Text, out double distanceValue))
            {
                MessageBox.Show("Format Error");
                return;
            }

            if (cycleValue > MaximumValue || distanceValue > MaximumValue)
            {
                MessageBox.Show("Values are too big");
                return;
            }

            // Both settings are whole numbers; decimals are dropped (12.7 becomes 12).
            int cycleTimeValue = (int)Math.Truncate(cycleValue);
            int safetyDistanceValue = (int)Math.Truncate(distanceValue);
            if (cycleTimeValue <= 0 || safetyDistanceValue <= 0)
            {
                MessageBox.Show("There are values lower or equal to 0");
                return;
            }

            CycleTime = cycleTimeValue;
            SafetyDistance = safetyDistanceValue;
            Close();
        }

        private void autofillButton_Click(object sender, EventArgs e)
        {
            safetyDistanceTextBox.Text = DefaultSafetyDistance;
            cycleTimeTextBox.Text = DefaultCycleTime;
        }
    }
}
