using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using Database;

namespace FlightLib
{
    /// <summary>
    /// Writes a plain-text report of the speed changes made to solve conflicts, including the
    /// contact details of each affected airline so the operator knows whom to call.
    /// </summary>
    public static class ConflictResolutionLog
    {
        /// <summary>File the report is written to, in the application's working folder.</summary>
        public const string FileName = "Conflict Log Solutions.txt";

        /// <summary>Flight identifiers start with the airline's three-letter ICAO code.</summary>
        private const int AirlineCodeLength = 3;

        /// <summary>
        /// Writes the report by comparing each flight's current speed with its speed before the conflicts were solved.
        /// </summary>
        /// <param name="flightPlans">Flights after solving conflicts.</param>
        /// <param name="originalSpeeds">Speed of each flight, in the same order, before solving conflicts.</param>
        /// <exception cref="ArgumentNullException">Thrown when an argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the number of speeds does not match the number of flights.</exception>
        /// <exception cref="IOException">Thrown when the report file cannot be written.</exception>
        public static void Write(FlightPlanList flightPlans, IReadOnlyList<double> originalSpeeds)
        {
            if (flightPlans == null)
                throw new ArgumentNullException(nameof(flightPlans));
            if (originalSpeeds == null)
                throw new ArgumentNullException(nameof(originalSpeeds));
            if (originalSpeeds.Count != flightPlans.Count)
                throw new ArgumentException("There must be one original speed per flight.", nameof(originalSpeeds));

            List<FlightPlan> changedFlights = FindFlightsWithChangedSpeed(flightPlans, originalSpeeds);

            using (StreamWriter writer = new StreamWriter(FileName))
            {
                if (changedFlights.Count == 0)
                {
                    writer.WriteLine("There are no conflicts");
                    return;
                }

                foreach (FlightPlan flight in changedFlights)
                    WriteFlightEntry(writer, flight);
            }
        }

        private static List<FlightPlan> FindFlightsWithChangedSpeed(FlightPlanList flightPlans, IReadOnlyList<double> originalSpeeds)
        {
            List<FlightPlan> changedFlights = new List<FlightPlan>();
            for (int index = 0; index < flightPlans.Count; index++)
            {
                FlightPlan flight = flightPlans.GetFlightPlan(index);
                if (flight.Speed != originalSpeeds[index])
                    changedFlights.Add(flight);
            }
            return changedFlights;
        }

        private static void WriteFlightEntry(TextWriter writer, FlightPlan flight)
        {
            DataRow company = TryFindAirline(flight.Id);
            if (company != null)
            {
                writer.WriteLine("Data of the company of the affected flight.");
                writer.WriteLine("Name: " + company[DatabaseService.CompanyNameColumn]);
                writer.WriteLine("Phone: " + company[DatabaseService.CompanyPhoneColumn]);
                writer.WriteLine("Email: " + company[DatabaseService.CompanyEmailColumn]);
            }
            else
            {
                writer.WriteLine("There is no data of the operator.");
            }

            writer.WriteLine("The velocity of the flight: " + flight.Id + " should be changed to: " + flight.Speed);
            writer.WriteLine();
        }

        /// <summary>
        /// Looks up the airline that operates the flight. Returns null when the identifier is too
        /// short, the airline is unknown, or the database is unavailable: the report is still
        /// useful without contact details, so a lookup failure must not stop it.
        /// </summary>
        private static DataRow TryFindAirline(string flightId)
        {
            if (flightId == null || flightId.Length < AirlineCodeLength)
                return null;

            try
            {
                using (DatabaseService database = new DatabaseService())
                {
                    database.Open();
                    return database.FindCompanyByIdentifier(flightId.Substring(0, AirlineCodeLength));
                }
            }
            catch (Exception exception) when (exception is DbException || exception is IOException)
            {
                return null;
            }
        }
    }
}
