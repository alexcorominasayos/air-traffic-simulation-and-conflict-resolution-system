using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using FlightLib;

namespace Main_Menu
{
    /// <summary>
    /// Small helpers shared by several forms, so that feedback looks the same everywhere.
    /// </summary>
    internal static class UiHelpers
    {
        /// <summary>Background used to flag an error or an invalid input.</summary>
        public static readonly Color ErrorColor = Color.LightCoral;

        /// <summary>Background used to confirm that an action succeeded.</summary>
        public static readonly Color SuccessColor = Color.PaleGreen;

        /// <summary>Background used for a warning that does not block the user.</summary>
        public static readonly Color WarningColor = Color.LightGoldenrodYellow;

        /// <summary>Background of an input or label in its normal state.</summary>
        public static readonly Color NormalColor = Color.White;

        /// <summary>How long a button keeps its "Done" / "Error" look before going back to normal.</summary>
        public const int ButtonFeedbackMilliseconds = 2500;

        /// <summary>Shows <paramref name="message"/> in <paramref name="label"/>, coloured as an error or as a success.</summary>
        public static void ShowMessage(Label label, string message, bool isError = true)
        {
            label.Text = message;
            label.BackColor = isError ? ErrorColor : SuccessColor;
            label.Visible = true;
        }

        /// <summary>Hides a message label shown with <see cref="ShowMessage"/>.</summary>
        public static void HideMessage(Label label)
        {
            label.BackColor = NormalColor;
            label.Visible = false;
        }

        /// <summary>
        /// Wraps a message in blank space, so it reads like a banner in the large error labels.
        /// </summary>
        public static string AsBanner(string message)
        {
            return "   \n   " + message + "   \n ";
        }

        /// <summary>
        /// Gives a button temporary feedback (colour and text). <paramref name="resetTimer"/> must be
        /// wired to a handler that restores the button's normal look.
        /// </summary>
        public static void FlashButton(Button button, Color color, string text, Timer resetTimer)
        {
            button.BackColor = color;
            button.Text = text;
            resetTimer.Interval = ButtonFeedbackMilliseconds;
            resetTimer.Start();
        }

        /// <summary>
        /// Attaches hover help texts to controls. The same timings are used in every form.
        /// </summary>
        /// <param name="helpTexts">Text to show for each control.</param>
        /// <returns>The tool tip, which must live as long as the form.</returns>
        public static ToolTip AddToolTips(IDictionary<Control, string> helpTexts)
        {
            ToolTip toolTip = new ToolTip
            {
                AutoPopDelay = 5000,
                InitialDelay = 800,
                ReshowDelay = 100,
                ShowAlways = true,
            };
            foreach (KeyValuePair<Control, string> helpText in helpTexts)
                toolTip.SetToolTip(helpText.Key, helpText.Value);
            return toolTip;
        }

        /// <summary>
        /// Parses a decimal number typed by the user, in the computer's regional format.
        /// </summary>
        /// <remarks>
        /// TryParse is used instead of Convert so that invalid input becomes a validation
        /// message rather than an exception.
        /// </remarks>
        public static bool TryParseDouble(string text, out double value)
        {
            return double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value);
        }

        /// <summary>Parses a whole number typed by the user.</summary>
        public static bool TryParseInt(string text, out int value)
        {
            return int.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out value);
        }

        /// <summary>
        /// Short text with a flight's remaining fuel and, when relevant, a warning: whether it will
        /// not last until the destination, or it is already empty.
        /// </summary>
        public static string DescribeFuel(FlightPlan flight)
        {
            string amount = Math.Round(flight.Fuel, 1).ToString(CultureInfo.CurrentCulture);
            if (flight.IsOutOfFuel())
                return amount + " (OUT OF FUEL)";
            if (!flight.HasArrived() && !flight.HasEnoughFuelToArrive())
                return amount + $" (needs {Math.Ceiling(flight.GetFuelNeededToArrive())} to arrive)";
            return amount;
        }

        /// <summary>Shows an unexpected error in a message box, keeping the application running.</summary>
        public static void ShowUnexpectedError(string action, Exception exception)
        {
            MessageBox.Show($"{action} failed: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
