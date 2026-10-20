using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightLib
{
    /// <summary>
    /// The set of flights taking part in a simulation.
    /// </summary>
    public class FlightPlanList
    {
        private readonly List<FlightPlan> flightPlans = new List<FlightPlan>();

        /// <summary>Read-only view of the flights, in the order they were added.</summary>
        public IReadOnlyList<FlightPlan> FlightPlans => flightPlans;

        /// <summary>Number of flights in the list.</summary>
        public int Count => flightPlans.Count;

        /// <summary>Adds a flight to the end of the list.</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="flightPlan"/> is null.</exception>
        public void Add(FlightPlan flightPlan)
        {
            if (flightPlan == null)
                throw new ArgumentNullException(nameof(flightPlan));
            flightPlans.Add(flightPlan);
        }

        /// <summary>Removes every flight from the list.</summary>
        public void Clear()
        {
            flightPlans.Clear();
        }

        /// <summary>
        /// Returns the flight at the given position, or null when the index is out of range.
        /// </summary>
        /// <param name="index">Zero-based position in the list.</param>
        public FlightPlan GetFlightPlan(int index)
        {
            return index >= 0 && index < flightPlans.Count ? flightPlans[index] : null;
        }

        /// <summary>Returns the flight with the given identifier, or null if there is none.</summary>
        public FlightPlan FindById(string id)
        {
            return flightPlans.FirstOrDefault(flightPlan => flightPlan.Id == id);
        }

        /// <summary>Returns true if a flight with the given identifier is already in the list.</summary>
        public bool ContainsId(string id)
        {
            return FindById(id) != null;
        }

        /// <summary>Returns the current speed of every flight, in list order.</summary>
        public List<double> GetSpeeds()
        {
            return flightPlans.Select(flightPlan => flightPlan.Speed).ToList();
        }

        /// <summary>Returns true when every flight is on its destination (also true for an empty list).</summary>
        public bool AllHaveArrived()
        {
            return flightPlans.All(flightPlan => flightPlan.HasArrived());
        }

        /// <summary>
        /// Advances every flight for the given amount of time. Does nothing once all flights have arrived.
        /// </summary>
        /// <param name="elapsedSeconds">Simulated time to advance, in seconds.</param>
        public void Move(double elapsedSeconds)
        {
            if (AllHaveArrived())
                return;

            foreach (FlightPlan flightPlan in flightPlans)
                flightPlan.Move(elapsedSeconds);
        }

        /// <summary>Adds (or removes, when negative) the same amount of fuel to every flight.</summary>
        /// <param name="fuelDelta">Fuel units to add to each flight.</param>
        public void AdjustFuel(int fuelDelta)
        {
            foreach (FlightPlan flightPlan in flightPlans)
                flightPlan.Fuel += fuelDelta;
        }

        /// <summary>Puts every flight back at the start of its route.</summary>
        public void ResetToInitialPositions()
        {
            foreach (FlightPlan flightPlan in flightPlans)
                flightPlan.ResetToInitialPosition();
        }

        /// <summary>
        /// Returns true if at least one pair of flights is predicted to come closer than
        /// <paramref name="safetyDistance"/> at some point of their routes.
        /// </summary>
        public bool HasAnyConflict(double safetyDistance)
        {
            for (int first = 0; first < flightPlans.Count; first++)
            {
                for (int second = 0; second < flightPlans.Count; second++)
                {
                    if (first != second && flightPlans[first].WillConflictWith(flightPlans[second], safetyDistance))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Slows down flights until no pair is predicted to violate <paramref name="safetyDistance"/>,
        /// whenever that is possible by reducing speed.
        /// </summary>
        /// <remarks>
        /// Every ordered pair is visited, so in each conflicting pair the flight that appears
        /// first in the list is the one slowed down first.
        /// </remarks>
        public void ResolveAllConflicts(double safetyDistance)
        {
            for (int first = 0; first < flightPlans.Count; first++)
            {
                for (int second = 0; second < flightPlans.Count; second++)
                {
                    if (first != second && flightPlans[first].WillConflictWith(flightPlans[second], safetyDistance))
                        flightPlans[first].ResolveConflictBySlowingDown(flightPlans[second], safetyDistance);
                }
            }
        }

        /// <summary>Returns an independent copy of the list and of every flight in it.</summary>
        public FlightPlanList Clone()
        {
            FlightPlanList copy = new FlightPlanList();
            copy.CopyFrom(this);
            return copy;
        }

        /// <summary>
        /// Replaces the contents of this list with independent copies of the flights in <paramref name="source"/>.
        /// </summary>
        /// <remarks>
        /// Copying in place (instead of returning a new list) keeps this object's identity, which
        /// matters because several forms hold a reference to the same list.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public void CopyFrom(FlightPlanList source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            // Take a snapshot first so that copying a list onto itself does not wipe it.
            List<FlightPlan> copies = source.flightPlans.Select(flightPlan => flightPlan.Clone()).ToList();
            flightPlans.Clear();
            flightPlans.AddRange(copies);
        }
    }
}
