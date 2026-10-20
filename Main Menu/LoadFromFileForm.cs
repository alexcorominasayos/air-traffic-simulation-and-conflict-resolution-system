using System;
using System.IO;
using System.Windows.Forms;
using FlightLib;

namespace Main_Menu
{
    /// <summary>
    /// Loads a simulation (settings, flights and undo history) from a text file saved by the simulator.
    /// </summary>
    public partial class LoadFromFileForm : Form
    {
        /// <summary>Time the "Load successful" feedback stays visible before the form closes.</summary>
        private const int CloseDelayMilliseconds = 1000;

        public LoadFromFileForm()
        {
            InitializeComponent();
        }

        /// <summary>The loaded simulation, or null if nothing was loaded.</summary>
        public SimulationSnapshot LoadedSimulation { get; private set; }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (!FileDialogs.TryChooseSimulationToOpen(this, out string filePath))
                return; // Cancelled: keep the form open so the user can try again or close it.

            try
            {
                LoadedSimulation = SimulationFile.Load(filePath);
            }
            catch (Exception exception) when (exception is FileNotFoundException || exception is DirectoryNotFoundException)
            {
                ShowFailure("File Not Found");
                return;
            }
            catch (Exception exception) when (exception is FormatException || exception is OverflowException)
            {
                ShowFailure("Not a valid simulation file");
                return;
            }
            catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException)
            {
                ShowFailure("File can not be read");
                return;
            }

            loadButton.BackColor = UiHelpers.SuccessColor;
            loadButton.Text = "Load Successful";
            closeDelayTimer.Interval = CloseDelayMilliseconds;
            closeDelayTimer.Start();
        }

        private void ShowFailure(string message)
        {
            LoadedSimulation = null;
            loadButton.BackColor = UiHelpers.ErrorColor;
            loadButton.Text = message + " - try again";
        }

        private void closeDelayTimer_Tick(object sender, EventArgs e)
        {
            closeDelayTimer.Stop();
            Close();
        }
    }
}
