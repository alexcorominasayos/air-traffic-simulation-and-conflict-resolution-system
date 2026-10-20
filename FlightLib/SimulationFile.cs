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
    /// Transponder xi yi cx cy xf yf velocidad combustible
    /// &lt;one line per flight&gt;
    /// -
    /// &lt;history: one block of N flight lines per previous state, most recent first&gt;
    /// </code>
    /// Numbers use the computer's regional format (for example "12,5" on a Spanish Windows).
    /// That is kept on purpose so files saved by earlier versions of the program still load.
    /// </remarks>
    public static class SimulationFile
    {
        /// <summary>Extension appended to the file name typed by the user.</summary>
        public const string Extension = ".txt";

        private const string SettingsHeader = "TC DS";
        private const string FlightsHeader = "Transponder xi yi cx cy xf yf velocidad combustible";
        private const string HistorySeparator = "-";
        private const int FieldsPerFlight = 9;

        /// <summary>
        /// Saves the simulation. The history is written without being modified, so the user can
        /// keep undoing after saving.
        /// </summary>
        /// <param name="filePathWithoutExtension">Destination path; <see cref="Extension"/> is appended.</param>
        /// <param name="snapshot">What to save.</param>
        /// <exception cref="ArgumentException">Thrown when the path is empty.</exception>
        /// <exception cref="IOException">Thrown when the file cannot be written.</exception>
        public static void Save(string filePathWithoutExtension, SimulationSnapshot snapshot)
        {
            if (string.IsNullOrWhiteSpace(filePathWithoutExtension))
                throw new ArgumentException("The file name cannot be empty.", nameof(filePathWithoutExtension));
            if (snapshot == null)
                throw new ArgumentNullException(nameof(snapshot));

            using (StreamWriter writer = new StreamWriter(filePathWithoutExtension + Extension))
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
        /// <param name="filePathWithoutExtension">Source path; <see cref="Extension"/> is appended.</param>
        /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
        /// <exception cref="FormatException">Thrown when the content does not follow the expected layout.</exception>
        public static SimulationSnapshot Load(string filePathWithoutExtension)
        {
            string[] lines = File.ReadAllLines(filePathWithoutExtension + Extension)
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
                                 $"{flight.FinalPosition.X} {flight.FinalPosition.Y} {flight.Speed} {flight.Fuel}");
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
            if (fields.Length < FieldsPerFlight)
                throw new FormatException($"Expected {FieldsPerFlight} values in the flight line \"{line}\".");

            return new FlightPlan(
                id: fields[0],
                initialX: Convert.ToDouble(fields[1]),
                initialY: Convert.ToDouble(fields[2]),
                currentX: Convert.ToDouble(fields[3]),
                currentY: Convert.ToDouble(fields[4]),
                finalX: Convert.ToDouble(fields[5]),
                finalY: Convert.ToDouble(fields[6]),
                speed: Convert.ToDouble(fields[7]),
                fuel: Convert.ToInt32(fields[8]));
        }
    }
}
