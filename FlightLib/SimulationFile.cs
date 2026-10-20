using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlightLib
{
    /// <summary>
    /// Everything stored in a saved simulation: settings, flights and the undo history.
    /// </summary>
    public class SimulationSnapshot
    {
        /// <summary>Simulated seconds advanced on every cycle.</summary>
        public int CycleTime { get; set; }

        /// <summary>Minimum allowed separation between aircraft, in canvas units.</summary>
        public int SafetyDistance { get; set; }

        /// <summary>The flights in their current state.</summary>
        public FlightPlanList FlightPlans { get; set; } = new FlightPlanList();

        /// <summary>Previous states of the flights, most recent on top, used by "undo".</summary>
        public Stack<FlightPlanList> History { get; set; } = new Stack<FlightPlanList>();
    }

    /// <summary>
    /// Reads and writes simulations as plain-text files.
    /// </summary>
    /// <remarks>
    /// File layout:
    /// <code>
    /// TC DS
    /// &lt;cycle time&gt; &lt;safety distance&gt;
    /// Transponder xi yi cx cy xf yf velocidad combustible initialFuel
    /// &lt;one line per flight&gt;
    /// -
    /// &lt;history: one block of N flight lines per previous state, most recent first&gt;
    /// </code>
    /// The last value of each flight line (initial fuel) was added later; files without it still
    /// load, and their current fuel is then used as the initial fuel.
    /// Numbers use the computer's regional format (for example "12,5" on a Spanish Windows).
    /// That is kept on purpose so files saved by earlier versions of the program still load.
    /// </remarks>
    public static class SimulationFile
    {
        /// <summary>Usual extension of simulation files.</summary>
        public const string Extension = ".txt";

        private const string SettingsHeader = "TC DS";
        private const string FlightsHeader = "Transponder xi yi cx cy xf yf velocidad combustible initialFuel";
        private const string HistorySeparator = "-";
        private const int MinimumFieldsPerFlight = 9;
        private const int InitialFuelField = 9;

        /// <summary>
        /// Saves the simulation. The history is written without being modified, so the user can
        /// keep undoing after saving.
        /// </summary>
        /// <param name="filePath">Full path of the file to write.</param>
        /// <param name="snapshot">What to save.</param>
        /// <exception cref="ArgumentException">Thrown when the path is empty.</exception>
        /// <exception cref="IOException">Thrown when the file cannot be written.</exception>
        public static void Save(string filePath, SimulationSnapshot snapshot)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("The file path cannot be empty.", nameof(filePath));
            if (snapshot == null)
                throw new ArgumentNullException(nameof(snapshot));

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(SettingsHeader);
                writer.WriteLine($"{snapshot.CycleTime} {snapshot.SafetyDistance}");
                writer.WriteLine(FlightsHeader);
                WriteFlights(writer, snapshot.FlightPlans);
                writer.WriteLine(HistorySeparator);

                // Enumerating a Stack goes from the top (most recent) to the bottom without popping.
                foreach (FlightPlanList previousState in snapshot.History)
                    WriteFlights(writer, previousState);
            }
        }

        /// <summary>
        /// Loads a simulation previously written by <see cref="Save"/>.
        /// </summary>
        /// <param name="filePath">Full path of the file to read.</param>
        /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
        /// <exception cref="FormatException">Thrown when the content does not follow the expected layout.</exception>
        public static SimulationSnapshot Load(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath)
                                 .Where(line => !string.IsNullOrWhiteSpace(line))
                                 .ToArray();
            if (lines.Length < 3)
                throw new FormatException("The file is too short to be a saved simulation.");

            SimulationSnapshot snapshot = new SimulationSnapshot();
            ParseSettings(lines[1], snapshot);

            int lineIndex = 3; // Skip both header lines and the settings line.
            while (lineIndex < lines.Length && lines[lineIndex].Trim() != HistorySeparator)
            {
                snapshot.FlightPlans.Add(ParseFlight(lines[lineIndex]));
                lineIndex++;
            }

            lineIndex++; // Skip the separator.
            snapshot.History = ParseHistory(lines, lineIndex, snapshot.FlightPlans.Count);
            return snapshot;
        }

        private static void WriteFlights(TextWriter writer, FlightPlanList flightPlans)
        {
            foreach (FlightPlan flight in flightPlans.FlightPlans)
            {
                writer.WriteLine($"{flight.Id} {flight.InitialPosition.X} {flight.InitialPosition.Y} " +
                                 $"{flight.CurrentPosition.X} {flight.CurrentPosition.Y} " +
                                 $"{flight.FinalPosition.X} {flight.FinalPosition.Y} {flight.Speed} {flight.Fuel} {flight.InitialFuel}");
            }
        }

        private static void ParseSettings(string line, SimulationSnapshot snapshot)
        {
            string[] fields = line.Split(' ');
            if (fields.Length < 2)
                throw new FormatException("The cycle time and safety distance line is incomplete.");

            snapshot.CycleTime = Convert.ToInt32(fields[0]);
            snapshot.SafetyDistance = Convert.ToInt32(fields[1]);
        }

        /// <summary>
        /// Rebuilds the undo stack. The file lists the most recent state first, so blocks are
        /// collected in file order and then pushed in reverse to leave the most recent on top.
        /// </summary>
        private static Stack<FlightPlanList> ParseHistory(string[] lines, int firstLine, int flightsPerState)
        {
            List<FlightPlanList> statesInFileOrder = new List<FlightPlanList>();
            if (flightsPerState > 0)
            {
                FlightPlanList currentState = null;
                for (int lineIndex = firstLine; lineIndex < lines.Length; lineIndex++)
                {
                    if (currentState == null || currentState.Count == flightsPerState)
                    {
                        currentState = new FlightPlanList();
                        statesInFileOrder.Add(currentState);
                    }
                    currentState.Add(ParseFlight(lines[lineIndex]));
                }
            }

            Stack<FlightPlanList> history = new Stack<FlightPlanList>();
            for (int index = statesInFileOrder.Count - 1; index >= 0; index--)
                history.Push(statesInFileOrder[index]);
            return history;
        }

        private static FlightPlan ParseFlight(string line)
        {
            string[] fields = line.Split(' ');
            if (fields.Length < MinimumFieldsPerFlight)
                throw new FormatException($"Expected at least {MinimumFieldsPerFlight} values in the flight line \"{line}\".");

            double fuel = Convert.ToDouble(fields[8]);
            double? initialFuel = fields.Length > InitialFuelField ? Convert.ToDouble(fields[InitialFuelField]) : (double?)null;
            if (fuel < 0 || initialFuel < 0)
                throw new FormatException($"Negative fuel in the flight line \"{line}\".");

            return new FlightPlan(
                id: fields[0],
                initialX: Convert.ToDouble(fields[1]),
                initialY: Convert.ToDouble(fields[2]),
                currentX: Convert.ToDouble(fields[3]),
                currentY: Convert.ToDouble(fields[4]),
                finalX: Convert.ToDouble(fields[5]),
                finalY: Convert.ToDouble(fields[6]),
                speed: Convert.ToDouble(fields[7]),
                fuel: fuel,
                initialFuel: initialFuel);
        }
    }
}
