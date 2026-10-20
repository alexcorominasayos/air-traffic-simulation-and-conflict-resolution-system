using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FlightLib;

namespace Menu
{
    /// <summary>
    /// Hub of the application: holds the current simulation (flights, settings, monitored point
    /// and undo history) and opens every other screen with it.
    /// </summary>
    public partial class MainMenuForm : Form
    {
        private readonly string userName;
        private FlightPlanList flightPlans = new FlightPlanList();
        private Stack<FlightPlanList> history = new Stack<FlightPlanList>();
        private int cycleTime;
        private int safetyDistance;

        // A circular area the simulator watches: it turns red when any aircraft flies inside it.
        private double monitoredPointX;
        private double monitoredPointY;
        private float monitoredPointRadius;

        // Kept as a field so the hover texts live as long as the form.
        private ToolTip toolTips;

        /// <summary>Creates the main menu for the user who just logged in.</summary>
        public MainMenuForm(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            AddTestScenarioButtons();
        }

        /// <summary>True when the form was closed with "Log out" (instead of closing the application).</summary>
        public bool UserLoggedOut { get; private set; }

        /// <summary>True once the cycle time or the safety distance has been set.</summary>
        private bool HasPresets => cycleTime != 0 || safetyDistance != 0;

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            toolTips = UiHelpers.AddToolTips(new Dictionary<Control, string>
            {
                [closeButton] = "Close the program and all processes running",
                [loadFlightPlansButton] = "Load Flight Plans from scratch by entering data manually or by a .txt file",
                [simulateButton] = "Shows the trajectory and possible collisions of the Flight Plans",
                [presetsButton] = "Allows to establish the safe distance between planes and the time of simulation",
                [logOutButton] = "Closes your session",
            });

            titleLabel.BackColor = Color.Transparent;
            welcomeBackLabel.BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Center;
            welcomeBackLabel.Text = "Welcome back, " + userName + " :)";
        }

        private void presetsButton_Click(object sender, EventArgs e)
        {
            using (PresetsForm presetsForm = new PresetsForm { CycleTime = cycleTime, SafetyDistance = safetyDistance })
            {
                presetsForm.ShowDialog();
                cycleTime = presetsForm.CycleTime;
                safetyDistance = presetsForm.SafetyDistance;
            }
        }

        private void loadFlightPlansButton_Click(object sender, EventArgs e)
        {
            LoadSource source;
            using (LoadSourceSelectionForm sourceForm = new LoadSourceSelectionForm())
            {
                sourceForm.ShowDialog();
                source = sourceForm.SelectedSource;
            }

            switch (source)
            {
                case LoadSource.Manual:
                    AddFlightPlansManually();
                    break;
                case LoadSource.File:
                    LoadSimulationFromFile();
                    break;
                default:
                    MessageBox.Show("Nothing has been selected");
                    break;
            }
        }

        private void AddFlightPlansManually()
        {
            using (FlightPlanEntryForm entryForm = new FlightPlanEntryForm(flightPlans))
                entryForm.ShowDialog();
        }

        /// <summary>Replaces the current simulation with one loaded from a text file.</summary>
        private void LoadSimulationFromFile()
        {
            using (LoadFromFileForm loadForm = new LoadFromFileForm())
            {
                loadForm.ShowDialog();
                SimulationSnapshot loaded = loadForm.LoadedSimulation;
                if (loaded == null)
                    return; // The user closed the window without loading anything.

                flightPlans = loaded.FlightPlans;
                history = loaded.History;
                cycleTime = loaded.CycleTime;
                safetyDistance = loaded.SafetyDistance;
            }
        }

        private void simulateButton_Click(object sender, EventArgs e)
        {
            string missingData = GetMissingSimulationData();
            if (missingData != null)
            {
                MessageBox.Show(missingData);
                return;
            }

            OfferToResolveConflicts();
            OpenSimulator();
        }

        /// <summary>Returns what the user still has to enter before simulating, or null if nothing is missing.</summary>
        private string GetMissingSimulationData()
        {
            bool hasFlights = flightPlans.Count > 0;
            if (!hasFlights && !HasPresets)
                return "Flight plan and pre-sets missing";
            if (!hasFlights)
                return "Flight plan missing";
            if (!HasPresets)
                return "Pre-Sets missing";
            return null;
        }

        /// <summary>
        /// If some flights are predicted to conflict, asks the user whether to slow them down,
        /// writes the conflict log and offers to open it.
        /// </summary>
        private void OfferToResolveConflicts()
        {
            List<double> originalSpeeds = flightPlans.GetSpeeds();
            bool resolve = false;

            if (flightPlans.HasAnyConflict(safetyDistance))
            {
                using (ConflictResolutionPromptForm prompt = new ConflictResolutionPromptForm())
                {
                    prompt.ShowDialog();
                    resolve = prompt.UserWantsToResolve;
                }
                if (resolve)
                    flightPlans.ResolveAllConflicts(safetyDistance);
            }

            // The log is written before offering to open it, so the user never sees an old one.
            try
            {
                ConflictResolutionLog.Write(flightPlans, originalSpeeds);
            }
            catch (IOException exception)
            {
                UiHelpers.ShowUnexpectedError("Writing the conflict log", exception);
                return;
            }

            if (resolve)
            {
                using (OpenConflictLogPromptForm logPrompt = new OpenConflictLogPromptForm())
                    logPrompt.ShowDialog();
            }
        }

        private void OpenSimulator()
        {
            using (SimulatorForm simulator = new SimulatorForm
            {
                FlightPlans = flightPlans,
                History = history,
                SafetyDistance = safetyDistance,
                CycleTime = cycleTime,
                MonitoredPointX = monitoredPointX,
                MonitoredPointY = monitoredPointY,
                MonitoredPointRadius = monitoredPointRadius,
            })
            {
                simulator.ShowDialog();
                history = simulator.History; // The simulator may replace it when restarting.
            }
        }

        private void addPointButton_Click(object sender, EventArgs e)
        {
            using (AddPointForm pointForm = new AddPointForm { PointX = monitoredPointX, PointY = monitoredPointY, Radius = monitoredPointRadius })
            {
                pointForm.ShowDialog();
                monitoredPointX = pointForm.PointX;
                monitoredPointY = pointForm.PointY;
                monitoredPointRadius = pointForm.Radius;
            }
        }

        private void companiesButton_Click(object sender, EventArgs e)
        {
            using (AirlineCompaniesForm companiesForm = new AirlineCompaniesForm())
                companiesForm.ShowDialog();
        }

        private void clearFlightPlansButton_Click(object sender, EventArgs e)
        {
            flightPlans.Clear();
            cycleTime = 0;
            safetyDistance = 0;
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            Hide();
            try
            {
                new Videogame.MainWindow().ShowDialog();
            }
            finally
            {
                Show(); // Come back to the menu even if the game fails.
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            UserLoggedOut = true;
            Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

#if DEBUG
        // Test scenarios to try the simulator quickly while developing. They are compiled only
        // in Debug builds, so the Release version delivered to users never contains them.
        // The buttons are created here instead of in the designer because the designer
        // cannot keep code inside #if blocks.

        /// <summary>Adds two buttons that load ready-made test scenarios (Debug builds only).</summary>
        partial void AddTestScenarioButtons()
        {
            AddTestScenarioButton("Test: no conflict", new Point(913, 274), (sender, e) => LoadTestScenario(
                new FlightPlan("VY", 15, 564, 15, 564, 152, 156, speed: 10, fuel: 10000),
                new FlightPlan("IB", 146, 234, 146, 234, 420, 69, speed: 20, fuel: 34000)));

            // Two flights crossing in the middle of their routes at the same speed: a guaranteed conflict.
            AddTestScenarioButton("Test: conflict", new Point(913, 321), (sender, e) => LoadTestScenario(
                new FlightPlan("VLG123", 0, 0, 0, 0, 200, 200, speed: 25, fuel: 10000),
                new FlightPlan("IBE456", 0, 200, 0, 200, 200, 0, speed: 25, fuel: 34000)));
        }

        private void AddTestScenarioButton(string text, Point location, EventHandler onClick)
        {
            Button button = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(100, 28),
                Margin = new Padding(4),
                UseVisualStyleBackColor = true,
            };
            button.Click += onClick;
            Controls.Add(button);
        }

        private void LoadTestScenario(FlightPlan firstFlight, FlightPlan secondFlight)
        {
            flightPlans.Add(firstFlight);
            flightPlans.Add(secondFlight);
            cycleTime = 60;
            safetyDistance = 30;
        }
#endif

        /// <summary>
        /// Implemented only in Debug builds (see above). In Release builds the compiler removes the
        /// call entirely, because a partial method without a body does nothing.
        /// </summary>
        partial void AddTestScenarioButtons();
    }
}
