using System;
using System.Windows.Forms;
using FlightLib;

namespace Main_Menu
{
    /// <summary>
    /// Lets the user type flight plans one by one and adds them to the simulation's flight list.
    /// </summary>
    public partial class FlightPlanEntryForm : Form
    {
        private readonly FlightPlanList flightPlans;

        /// <summary>Creates the form. Valid flight plans are added straight to <paramref name="flightPlans"/>.</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="flightPlans"/> is null.</exception>
        public FlightPlanEntryForm(FlightPlanList flightPlans)
        {
            InitializeComponent();
            this.flightPlans = flightPlans ?? throw new ArgumentNullException(nameof(flightPlans));
        }

        private void addFlightPlanButton_Click(object sender, EventArgs e)
        {
            ClearValidationErrors();

            if (!TryReadFlightPlan(out FlightPlan flightPlan, out string readError))
            {
                MessageBox.Show(readError);
                return;
            }

            if (!ValidateFlightPlan(flightPlan))
                return;

            flightPlans.Add(flightPlan);
            ClearInputs();
            UiHelpers.FlashButton(addFlightPlanButton, UiHelpers.SuccessColor, "FP Added", buttonResetTimer);
            WarnIfFuelIsNotEnough(flightPlan);
        }

        /// <summary>
        /// Reads the text boxes into a flight plan. A new flight always starts at its initial position.
        /// </summary>
        /// <param name="flightPlan">The flight plan read, or null.</param>
        /// <param name="error">Why it could not be read, or null.</param>
        /// <returns>False if any number cannot be parsed or the fuel is not positive.</returns>
        private bool TryReadFlightPlan(out FlightPlan flightPlan, out string error)
        {
            flightPlan = null;
            if (!UiHelpers.TryParseDouble(initialXTextBox.Text, out double initialX) ||
                !UiHelpers.TryParseDouble(initialYTextBox.Text, out double initialY) ||
                !UiHelpers.TryParseDouble(finalXTextBox.Text, out double finalX) ||
                !UiHelpers.TryParseDouble(finalYTextBox.Text, out double finalY) ||
                !UiHelpers.TryParseDouble(speedTextBox.Text, out double speed) ||
                !UiHelpers.TryParseDouble(fuelTextBox.Text, out double fuel))
            {
                error = "Format Error, check again";
                return false;
            }

            if (fuel <= 0)
            {
                // Checked here because a flight plan can not even be created with negative fuel.
                fuelTextBox.BackColor = UiHelpers.ErrorColor;
                error = "The fuel must be positive";
                return false;
            }

            flightPlan = new FlightPlan(transponderTextBox.Text, initialX, initialY, initialX, initialY, finalX, finalY, speed, fuel);
            error = null;
            return true;
        }

        /// <summary>
        /// Warns, without blocking, when the fuel will not last the whole route: the flight is still
        /// added, because simulating a fuel emergency can be exactly what the user wants to test.
        /// </summary>
        private static void WarnIfFuelIsNotEnough(FlightPlan flightPlan)
        {
            if (flightPlan.HasEnoughFuelToArrive())
                return;

            MessageBox.Show(
                $"Flight {flightPlan.Id} has {flightPlan.Fuel} fuel, but its route needs {Math.Ceiling(flightPlan.GetFuelNeededToArrive())} " +
                $"({FlightPlan.FuelPerDistanceUnit} per unit of distance). It was added, but it will run out of fuel before arriving.",
                "Not enough fuel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>Highlights every rule the flight plan breaks.</summary>
        /// <returns>True if the flight plan can be added.</returns>
        private bool ValidateFlightPlan(FlightPlan flightPlan)
        {
            bool isValid = true;

            if (flightPlans.ContainsId(flightPlan.Id))
            {
                ShowFieldError(duplicateIdErrorLabel, "The identifiers of the aircrafts must be different than the previously added ones", transponderTextBox);
                isValid = false;
            }

            if (flightPlan.Speed <= 0)
            {
                ShowFieldError(invalidSpeedErrorLabel, "The velocities must be positive", speedTextBox);
                isValid = false;
            }

            if (!SimulationCanvas.Contains(flightPlan.InitialPosition.X, flightPlan.InitialPosition.Y) ||
                !SimulationCanvas.Contains(flightPlan.FinalPosition.X, flightPlan.FinalPosition.Y))
            {
                ShowFieldError(outOfCanvasErrorLabel,
                    $"The positions are out of the canvas (x values between 0 and {SimulationCanvas.Width}, y values between 0 and {SimulationCanvas.Height})",
                    initialXTextBox, initialYTextBox, finalXTextBox, finalYTextBox);
                isValid = false;
            }

            return isValid;
        }

        private static void ShowFieldError(Label errorLabel, string message, params TextBox[] invalidFields)
        {
            UiHelpers.ShowMessage(errorLabel, UiHelpers.AsBanner(message));
            foreach (TextBox field in invalidFields)
                field.BackColor = UiHelpers.ErrorColor;
        }

        private void ClearValidationErrors()
        {
            UiHelpers.HideMessage(duplicateIdErrorLabel);
            UiHelpers.HideMessage(invalidSpeedErrorLabel);
            UiHelpers.HideMessage(outOfCanvasErrorLabel);
            foreach (TextBox field in new[] { transponderTextBox, speedTextBox, initialXTextBox, initialYTextBox, finalXTextBox, finalYTextBox, fuelTextBox })
                field.BackColor = UiHelpers.NormalColor;
        }

        private void ClearInputs()
        {
            foreach (TextBox field in new[] { transponderTextBox, initialXTextBox, initialYTextBox, finalXTextBox, finalYTextBox, speedTextBox, fuelTextBox })
                field.Text = "";
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonResetTimer_Tick(object sender, EventArgs e)
        {
            addFlightPlanButton.BackColor = UiHelpers.NormalColor;
            addFlightPlanButton.Text = "Add Flight Plan";
            buttonResetTimer.Stop();
        }
    }
}
