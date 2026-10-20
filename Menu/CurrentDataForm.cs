using System;
using System.Drawing;
using System.Windows.Forms;
using FlightLib;

namespace Menu
{
    /// <summary>
    /// Table with every flight's position and speed. Clicking a flight's ID fills the last
    /// column with the distance from that flight to each of the others.
    /// </summary>
    public partial class CurrentDataForm : Form
    {
        // The first grid row is used as a header, so flight number i is shown on row i + 1.
        private const int HeaderRowCount = 1;
        private const int IdColumn = 0;
        private const int XColumn = 1;
        private const int YColumn = 2;
        private const int SpeedColumn = 3;
        private const int DistanceColumn = 4;

        private readonly FlightPlanList flightPlans;

        /// <summary>Creates the table for the given flights.</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="flightPlans"/> is null.</exception>
        public CurrentDataForm(FlightPlanList flightPlans)
        {
            InitializeComponent();
            this.flightPlans = flightPlans ?? throw new ArgumentNullException(nameof(flightPlans));
        }

        private void CurrentDataForm_Load(object sender, EventArgs e)
        {
            flightDataGrid.ColumnCount = 5;
            flightDataGrid.RowCount = flightPlans.Count + HeaderRowCount;
            flightDataGrid.ColumnHeadersVisible = false;
            flightDataGrid.RowHeadersVisible = false;
            flightDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            DataGridViewRow headerRow = flightDataGrid.Rows[0];
            headerRow.DefaultCellStyle.BackColor = Color.LightGray;
            headerRow.Cells[IdColumn].Value = "ID";
            headerRow.Cells[XColumn].Value = "X";
            headerRow.Cells[YColumn].Value = "Y";
            headerRow.Cells[SpeedColumn].Value = "Velocity";
            headerRow.Cells[DistanceColumn].Value = "Distances";

            for (int flightIndex = 0; flightIndex < flightPlans.Count; flightIndex++)
            {
                FlightPlan flight = flightPlans.GetFlightPlan(flightIndex);
                DataGridViewRow row = flightDataGrid.Rows[flightIndex + HeaderRowCount];
                row.Cells[IdColumn].Value = flight.Id;
                row.Cells[XColumn].Value = Math.Round(flight.CurrentPosition.X, 2);
                row.Cells[YColumn].Value = Math.Round(flight.CurrentPosition.Y, 2);
                row.Cells[SpeedColumn].Value = Math.Round(flight.Speed, 2);
                row.Cells[DistanceColumn].Value = "-";
            }
        }

        private void flightDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedFlightIndex = e.RowIndex - HeaderRowCount;
            if (e.ColumnIndex != IdColumn || selectedFlightIndex < 0 || selectedFlightIndex >= flightPlans.Count)
            {
                MessageBox.Show("Click an ID to view the distances between aircrafts");
                return;
            }

            Position selectedPosition = flightPlans.GetFlightPlan(selectedFlightIndex).CurrentPosition;
            for (int flightIndex = 0; flightIndex < flightPlans.Count; flightIndex++)
            {
                double distance = selectedPosition.DistanceTo(flightPlans.GetFlightPlan(flightIndex).CurrentPosition);
                flightDataGrid.Rows[flightIndex + HeaderRowCount].Cells[DistanceColumn].Value = Math.Round(distance, 2);
            }
        }
    }
}
