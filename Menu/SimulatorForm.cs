using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using FlightLib;

namespace Menu
{
    /// <summary>
    /// Draws the flights on the canvas and lets the user move them cycle by cycle (or automatically),
    /// undo cycles, change speeds, save the simulation and export it to Google Earth.
    /// </summary>
    public partial class SimulatorForm : Form
    {
        /// <summary>Automatic mode's default delay between cycles; the speed bar adds or removes time from it.</summary>
        private const int BaseAutomaticIntervalMilliseconds = 1000;

        private const int AircraftIconSize = 35;
        private const int FlightHotspotSize = 10;
        private const int FlightLabelVerticalOffset = 26;

        // Background of each flight's label, so fuel problems are visible at a glance.
        private static readonly Color NormalLabelColor = Color.DimGray;
        private static readonly Color LowFuelLabelColor = Color.DarkOrange;
        private static readonly Color OutOfFuelLabelColor = Color.Firebrick;

        /// <summary>
        /// Flights whose "out of fuel" alert was already shown, so the message appears once per
        /// flight instead of on every cycle.
        /// </summary>
        private readonly HashSet<string> outOfFuelAlertsShown = new HashSet<string>();

        private readonly Image aircraftIcon = Properties.Resources.Image_Aircraft_Simulator;

        /// <summary>
        /// One invisible clickable square per flight, kept on top of the aircraft so the user can
        /// click it to open the flight's details.
        /// </summary>
        private readonly List<PictureBox> flightHotspots = new List<PictureBox>();

        /// <summary>
        /// Labels created for the flights. Tracked separately so refreshing them never removes the
        /// panel's own labels (such as the mouse coordinates).
        /// </summary>
        private readonly List<Label> flightLabels = new List<Label>();

        private int automaticIntervalMilliseconds = BaseAutomaticIntervalMilliseconds;
        private ToolTip toolTips;

        public SimulatorForm()
        {
            InitializeComponent();
        }

        /// <summary>Flights to simulate. The list is modified in place, so the caller sees the changes.</summary>
        public FlightPlanList FlightPlans { get; set; }

        /// <summary>Previous states of the flights, most recent on top. Read it back after the dialog closes.</summary>
        public Stack<FlightPlanList> History { get; set; }

        /// <summary>Simulated seconds advanced on every cycle.</summary>
        public int CycleTime { get; set; }

        /// <summary>Minimum separation between aircraft; also the diameter of each safety circle.</summary>
        public int SafetyDistance { get; set; }

        /// <summary>X coordinate of the monitored point's centre.</summary>
        public double MonitoredPointX { get; set; }

        /// <summary>Y coordinate of the monitored point's centre.</summary>
        public double MonitoredPointY { get; set; }

        /// <summary>Radius of the monitored point's circle.</summary>
        public float MonitoredPointRadius { get; set; }

        private void SimulatorForm_Load(object sender, EventArgs e)
        {
            if (FlightPlans == null)
                throw new InvalidOperationException("Set FlightPlans before showing the simulator.");
            if (History == null)
                History = new Stack<FlightPlanList>();

            toolTips = UiHelpers.AddToolTips(new Dictionary<Control, string>
            {
                [forwardButton] = "Moves the plane one cycle",
                [automaticStartButton] = "Moves the planes automatically",
                [changeSpeedButton] = "Changes the velocity of the plane with the id indicated",
                [saveButton] = "Saves the planes trajectory and current position in a .txt file",
                [backwardButton] = "Goes back to the previous position",
                [dataButton] = "Shows various information about the planes",
                [restartButton] = "Brings the planes to the original position",
                [automaticStopButton] = "Stops the plane from moving alone",
            });

            ConfigureCanvas();
            CreateFlightHotspots();
            RefreshFlightsView();
        }

        /// <summary>
        /// Panel has no public DoubleBuffered property, so it is set through reflection. Without it the
        /// canvas flickers every time it is repainted.
        /// </summary>
        private void ConfigureCanvas()
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, simulationPanel, new object[] { true });
            simulationPanel.BackgroundImage = Properties.Resources.Image_Background_Simulator;
            simulationPanel.BackgroundImageLayout = ImageLayout.Stretch;
            DoubleBuffered = true;
        }

        private void CreateFlightHotspots()
        {
            for (int flightIndex = 0; flightIndex < FlightPlans.Count; flightIndex++)
            {
                PictureBox hotspot = new PictureBox
                {
                    Size = new Size(FlightHotspotSize, FlightHotspotSize),
                    BackColor = Color.Transparent,
                    Tag = flightIndex,
                };
                hotspot.Click += FlightHotspot_Click;
                simulationPanel.Controls.Add(hotspot);
                flightHotspots.Add(hotspot);
            }
        }

        // ---------------------------------------------------------------- Simulation steps

        private void forwardButton_Click(object sender, EventArgs e)
        {
            AdvanceOneCycle();
        }

        private void automaticMoveTimer_Tick(object sender, EventArgs e)
        {
            AdvanceOneCycle();
        }

        /// <summary>
        /// Saves the current state for undo, moves every flight one cycle and burns its fuel.
        /// Nothing happens once every flight has arrived, so undo and fuel stay consistent.
        /// </summary>
        private void AdvanceOneCycle()
        {
            // Nothing can change once every flight has arrived or run out of fuel, so no undo
            // step is recorded either.
            if (!FlightPlans.AnyCanKeepFlying())
                return;

            History.Push(FlightPlans.Clone());
            FlightPlans.Move(CycleTime); // Each flight burns fuel for the distance it actually flew.
            RefreshFlightsView();
            AlertFlightsThatRanOutOfFuel();
        }

        /// <summary>
        /// Tells the user, once per flight, that an aircraft ran out of fuel before its destination.
        /// Automatic mode is stopped first: a timer keeps ticking behind a message box, which would
        /// otherwise keep advancing the simulation while the user reads the message.
        /// </summary>
        private void AlertFlightsThatRanOutOfFuel()
        {
            List<FlightPlan> newlyOutOfFuel = FlightPlans.FlightPlans
                .Where(flight => flight.IsOutOfFuel() && !outOfFuelAlertsShown.Contains(flight.Id))
                .ToList();
            if (newlyOutOfFuel.Count == 0)
                return;

            bool wasAutomatic = automaticMoveTimer.Enabled;
            automaticMoveTimer.Stop();
            foreach (FlightPlan flight in newlyOutOfFuel)
                outOfFuelAlertsShown.Add(flight.Id);

            string flightList = string.Join("\n", newlyOutOfFuel.Select(flight =>
                $"{flight.Id} at ({Math.Round(flight.CurrentPosition.X, 1)}, {Math.Round(flight.CurrentPosition.Y, 1)}), " +
                $"{Math.Round(flight.GetRemainingDistance(), 1)} units before its destination"));
            MessageBox.Show(
                "These flights have run out of fuel and can not continue:\n\n" + flightList +
                (wasAutomatic ? "\n\nAutomatic mode has been stopped." : ""),
                "Out of fuel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void backwardButton_Click(object sender, EventArgs e)
        {
            if (History.Count == 0)
                return;

            // The saved state already contains the fuel the flights had before that cycle.
            FlightPlans.CopyFrom(History.Pop());
            RefreshFlightsView();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            automaticMoveTimer.Stop();
            History = new Stack<FlightPlanList>();
            FlightPlans.ResetToInitialPositions();
            RefreshFlightsView();
        }

        private void automaticStartButton_Click(object sender, EventArgs e)
        {
            automaticMoveTimer.Interval = automaticIntervalMilliseconds;
            automaticMoveTimer.Start();
        }

        private void automaticStopButton_Click(object sender, EventArgs e)
        {
            automaticMoveTimer.Stop();
        }

        /// <summary>Moving the bar to the right shortens the delay between automatic cycles (faster simulation).</summary>
        private void simulationSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            // The bar goes from -750 to 750, so the interval always stays positive (250 to 1750 ms).
            automaticIntervalMilliseconds = Math.Max(1, BaseAutomaticIntervalMilliseconds - simulationSpeedTrackBar.Value);
            automaticMoveTimer.Interval = automaticIntervalMilliseconds;
            automaticMoveTimer.Start();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            automaticMoveTimer.Stop();
            FlightPlans.ResetToInitialPositions(); // Also refuels every flight to its initial fuel.
            Close();
        }

        // ---------------------------------------------------------------- Drawing

        /// <summary>Moves the click areas and the text labels to the flights' current positions and repaints.</summary>
        private void RefreshFlightsView()
        {
            for (int flightIndex = 0; flightIndex < FlightPlans.Count && flightIndex < flightHotspots.Count; flightIndex++)
            {
                Position position = FlightPlans.GetFlightPlan(flightIndex).CurrentPosition;
                int halfHotspot = FlightHotspotSize / 2;
                flightHotspots[flightIndex].Location = new Point(Convert.ToInt32(position.X) - halfHotspot, Convert.ToInt32(position.Y) - halfHotspot);
            }

            // After an undo or a restart a flight may have fuel again; alert again if it runs out later.
            outOfFuelAlertsShown.RemoveWhere(id => FlightPlans.FindById(id)?.IsOutOfFuel() != true);

            RefreshFlightLabels();
            simulationPanel.Invalidate();
        }

        /// <summary>Replaces the label next to each aircraft (ID, speed and position).</summary>
        private void RefreshFlightLabels()
        {
            foreach (Label oldLabel in flightLabels)
            {
                simulationPanel.Controls.Remove(oldLabel);
                oldLabel.Dispose();
            }
            flightLabels.Clear();

            foreach (FlightPlan flight in FlightPlans.FlightPlans)
            {
                Label label = CreateFlightLabel(flight);
                flightLabels.Add(label);
                simulationPanel.Controls.Add(label);
            }
        }

        private Label CreateFlightLabel(FlightPlan flight)
        {
            double x = Math.Round(flight.CurrentPosition.X, 2);
            double y = Math.Round(flight.CurrentPosition.Y, 2);

            // Placed above and to the right of the aircraft, outside its safety circle.
            return new Label
            {
                BackColor = GetFuelStatusColor(flight),
                Text = flight.Id + "\nVel: " + flight.Speed + " GS (x10)\nPos: (" + x + ", " + y + ")\n" + DescribeFuel(flight),
                Font = new Font("Times New Roman", 7),
                AutoSize = true,
                Location = new Point(
                    Convert.ToInt32(x) + SafetyDistance / 2,
                    Convert.ToInt32(y) - FlightLabelVerticalOffset - SafetyDistance),
            };
        }

        private static string DescribeFuel(FlightPlan flight)
        {
            return "Fuel: " + UiHelpers.DescribeFuel(flight);
        }

        /// <summary>Grey when fuel is fine, orange when it will not last to the destination, red when empty.</summary>
        private static Color GetFuelStatusColor(FlightPlan flight)
        {
            if (flight.IsOutOfFuel())
                return OutOfFuelLabelColor;
            if (!flight.HasArrived() && !flight.HasEnoughFuelToArrive())
                return LowFuelLabelColor;
            return NormalLabelColor;
        }

        private void simulationPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            DrawTrajectories(graphics);
            DrawSafetyCircles(graphics);
            DrawMonitoredPoint(graphics);
            DrawAircraft(graphics);
        }

        private void DrawTrajectories(Graphics graphics)
        {
            using (Pen trajectoryPen = new Pen(Color.Black, 2))
            {
                foreach (FlightPlan flight in FlightPlans.FlightPlans)
                {
                    graphics.DrawLine(trajectoryPen,
                        Convert.ToInt32(flight.InitialPosition.X), Convert.ToInt32(flight.InitialPosition.Y),
                        Convert.ToInt32(flight.FinalPosition.X), Convert.ToInt32(flight.FinalPosition.Y));
                }
            }
        }

        /// <summary>Green circle around each aircraft, red when another aircraft is inside the safety distance.</summary>
        private void DrawSafetyCircles(Graphics graphics)
        {
            int radius = SafetyDistance / 2;
            for (int flightIndex = 0; flightIndex < FlightPlans.Count; flightIndex++)
            {
                Position position = FlightPlans.GetFlightPlan(flightIndex).CurrentPosition;
                using (Brush brush = new SolidBrush(IsTooCloseToAnotherFlight(flightIndex) ? Color.Red : Color.Green))
                {
                    graphics.FillEllipse(brush, Convert.ToInt32(position.X) - radius, Convert.ToInt32(position.Y) - radius,
                                         SafetyDistance, SafetyDistance);
                }
            }
        }

        private void DrawMonitoredPoint(Graphics graphics)
        {
            Position centre = new Position(MonitoredPointX, MonitoredPointY);
            bool anyFlightInside = FlightPlans.FlightPlans.Any(flight => flight.CurrentPosition.DistanceTo(centre) <= MonitoredPointRadius);

            using (Brush brush = new SolidBrush(anyFlightInside ? Color.Red : Color.Green))
            {
                graphics.FillEllipse(brush,
                    Convert.ToInt32(MonitoredPointX) - MonitoredPointRadius, Convert.ToInt32(MonitoredPointY) - MonitoredPointRadius,
                    MonitoredPointRadius * 2, MonitoredPointRadius * 2);
            }
        }

        private void DrawAircraft(Graphics graphics)
        {
            int halfIcon = AircraftIconSize / 2;
            foreach (FlightPlan flight in FlightPlans.FlightPlans)
            {
                graphics.DrawImage(aircraftIcon,
                    Convert.ToInt32(flight.CurrentPosition.X - halfIcon), Convert.ToInt32(flight.CurrentPosition.Y - halfIcon),
                    AircraftIconSize, AircraftIconSize);
            }
        }

        /// <summary>Returns true when some other flight is currently within the safety distance of this one.</summary>
        private bool IsTooCloseToAnotherFlight(int flightIndex)
        {
            Position position = FlightPlans.GetFlightPlan(flightIndex).CurrentPosition;
            for (int otherIndex = 0; otherIndex < FlightPlans.Count; otherIndex++)
            {
                if (otherIndex != flightIndex &&
                    position.DistanceTo(FlightPlans.GetFlightPlan(otherIndex).CurrentPosition) <= SafetyDistance)
                {
                    return true;
                }
            }
            return false;
        }

        private void simulationPanel_MouseMove(object sender, MouseEventArgs e)
        {
            mouseCoordinatesLabel.Visible = true;
            mouseCoordinatesLabel.Text = "X = " + e.X + " ; Y = " + e.Y;
        }

        private void simulationPanel_MouseLeave(object sender, EventArgs e)
        {
            mouseCoordinatesLabel.Visible = false;
        }

        // ---------------------------------------------------------------- Other windows and actions

        private void FlightHotspot_Click(object sender, EventArgs e)
        {
            int flightIndex = (int)((PictureBox)sender).Tag;
            using (FlightInformationForm informationForm = new FlightInformationForm(FlightPlans.GetFlightPlan(flightIndex)))
                informationForm.ShowDialog();
        }

        private void dataButton_Click(object sender, EventArgs e)
        {
            // Not modal on purpose, so the table can stay open next to the simulator.
            new CurrentDataForm(FlightPlans).Show();
        }

        private void changeSpeedButton_Click(object sender, EventArgs e)
        {
            if (!UiHelpers.TryParseDouble(newSpeedTextBox.Text, out double newSpeed))
            {
                UiHelpers.FlashButton(changeSpeedButton, UiHelpers.ErrorColor, "Format Error", changeSpeedResetTimer);
                return;
            }

            FlightPlan flight = FlightPlans.FindById(flightIdTextBox.Text);
            if (flight == null)
            {
                MessageBox.Show("This flight does not exist");
                return;
            }

            if (newSpeed <= 0)
            {
                UiHelpers.FlashButton(changeSpeedButton, UiHelpers.WarningColor, "Error", changeSpeedResetTimer);
                MessageBox.Show("The velocity must be positive");
                return;
            }

            flight.Speed = newSpeed;
            UiHelpers.FlashButton(changeSpeedButton, UiHelpers.SuccessColor, "Done", changeSpeedResetTimer);
        }

        private void changeSpeedResetTimer_Tick(object sender, EventArgs e)
        {
            changeSpeedButton.BackColor = UiHelpers.NormalColor;
            changeSpeedButton.Text = "Change";
            changeSpeedResetTimer.Stop();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Stop automatic mode so the saved state is the one on screen when the user clicked.
            automaticMoveTimer.Stop();
            if (!FileDialogs.TryChooseSimulationSaveLocation(this, out string filePath))
                return;

            try
            {
                SimulationFile.Save(filePath, new SimulationSnapshot
                {
                    CycleTime = CycleTime,
                    SafetyDistance = SafetyDistance,
                    FlightPlans = FlightPlans,
                    History = History,
                });
                saveButton.BackColor = UiHelpers.SuccessColor;
            }
            catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException || exception is ArgumentException)
            {
                saveButton.BackColor = UiHelpers.ErrorColor;
                UiHelpers.ShowUnexpectedError("Saving the file", exception);
            }
        }

        private void viewInGoogleEarthButton_Click(object sender, EventArgs e)
        {
            automaticMoveTimer.Stop();
            MessageBox.Show("You need to have Google Earth installed for the correct working");
            if (!FileDialogs.TryChooseKmlSaveLocation(this, out string filePath))
                return;

            try
            {
                KmlExporter.ExportAndOpen(FlightPlans, filePath);
                viewInGoogleEarthButton.BackColor = UiHelpers.SuccessColor;
            }
            catch (Exception exception) when (exception is IOException || exception is UnauthorizedAccessException ||
                                              exception is ArgumentException || exception is Win32Exception)
            {
                // Win32Exception: the file was written but no program is associated with .kml files.
                viewInGoogleEarthButton.BackColor = UiHelpers.ErrorColor;
                UiHelpers.ShowUnexpectedError("Exporting to Google Earth", exception);
            }
        }
    }
}
