using System;

namespace FlightLib
{
    /// <summary>
    /// A single aircraft flying in a straight line from an initial position to a final position
    /// at a constant speed.
    /// </summary>
    /// <remarks>
    /// Speed is expressed in canvas units per minute, while simulation time is expressed in
    /// seconds. That is why <see cref="Move"/> divides by <see cref="SecondsPerMinute"/>.
    /// </remarks>
    public class FlightPlan
    {
        /// <summary>Converts the elapsed time (seconds) to the speed's time unit (minutes).</summary>
        private const double SecondsPerMinute = 60;

        /// <summary>How much the speed is reduced on every attempt when resolving a conflict.</summary>
        private const double SpeedReductionStep = 0.1;

        /// <summary>Flight identifier (transponder / call sign). The first three letters identify the airline.</summary>
        public string Id { get; }

        /// <summary>Where the flight starts its route.</summary>
        public Position InitialPosition { get; }

        /// <summary>Where the flight is right now.</summary>
        public Position CurrentPosition { get; private set; }

        /// <summary>Where the flight ends its route.</summary>
        public Position FinalPosition { get; }

        /// <summary>Ground speed, in canvas units per minute.</summary>
        public double Speed { get; set; }

        /// <summary>Remaining fuel units.</summary>
        public int Fuel { get; set; }

        /// <summary>
        /// Creates a flight plan.
        /// </summary>
        /// <param name="id">Flight identifier (transponder / call sign).</param>
        /// <param name="initialX">X coordinate where the route starts.</param>
        /// <param name="initialY">Y coordinate where the route starts.</param>
        /// <param name="currentX">X coordinate where the aircraft is now.</param>
        /// <param name="currentY">Y coordinate where the aircraft is now.</param>
        /// <param name="finalX">X coordinate where the route ends.</param>
        /// <param name="finalY">Y coordinate where the route ends.</param>
        /// <param name="speed">Ground speed, in canvas units per minute.</param>
        /// <param name="fuel">Initial fuel units.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is null.</exception>
        public FlightPlan(string id, double initialX, double initialY, double currentX, double currentY,
                          double finalX, double finalY, double speed, int fuel)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            InitialPosition = new Position(initialX, initialY);
            CurrentPosition = new Position(currentX, currentY);
            FinalPosition = new Position(finalX, finalY);
            Speed = speed;
            Fuel = fuel;
        }

        /// <summary>
        /// Returns an independent copy of this flight plan.
        /// </summary>
        /// <remarks>
        /// A shallow copy is enough because <see cref="Position"/> and <see cref="string"/>
        /// are immutable: moving the copy replaces its own <see cref="CurrentPosition"/>
        /// reference and never affects the original.
        /// </remarks>
        public FlightPlan Clone()
        {
            return (FlightPlan)MemberwiseClone();
        }

        /// <summary>
        /// Advances the aircraft along its route for the given amount of time.
        /// The aircraft never overshoots its destination: if it would, it stops on it.
        /// </summary>
        /// <param name="elapsedSeconds">Simulated time to advance, in seconds.</param>
        public void Move(double elapsedSeconds)
        {
            double distanceToTravel = elapsedSeconds * Speed / SecondsPerMinute;
            double remainingDistance = CurrentPosition.DistanceTo(FinalPosition);

            // Also covers the "already at destination" case, where there is no direction to follow.
            if (Math.Abs(distanceToTravel) >= remainingDistance)
            {
                CurrentPosition = FinalPosition;
                return;
            }

            double directionX = (FinalPosition.X - CurrentPosition.X) / remainingDistance;
            double directionY = (FinalPosition.Y - CurrentPosition.Y) / remainingDistance;
            CurrentPosition = new Position(
                CurrentPosition.X + distanceToTravel * directionX,
                CurrentPosition.Y + distanceToTravel * directionY);
        }

        /// <summary>Returns true when the aircraft is on its final position.</summary>
        public bool HasArrived()
        {
            return CurrentPosition.HasSameCoordinatesAs(FinalPosition);
        }

        /// <summary>Puts the aircraft back at the start of its route.</summary>
        public void ResetToInitialPosition()
        {
            CurrentPosition = InitialPosition;
        }

        /// <summary>
        /// Predicts whether this flight and <paramref name="other"/> will, at any moment of their
        /// routes, be closer to each other than <paramref name="safetyDistance"/>.
        /// </summary>
        /// <param name="other">The other flight.</param>
        /// <param name="safetyDistance">Minimum allowed separation, in canvas units.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="other"/> is null.</exception>
        public bool WillConflictWith(FlightPlan other, double safetyDistance)
        {
            return CalculateMinimumSeparation(other) < safetyDistance;
        }

        /// <summary>
        /// Calculates the smallest distance between this flight and <paramref name="other"/>
        /// over their whole routes, assuming both take off at the same time from their initial
        /// positions and each one stops when it reaches its destination.
        /// </summary>
        /// <remarks>
        /// The flights' motion is split in two phases:
        /// <list type="number">
        /// <item>Both aircraft are flying. Their relative position changes linearly, so the
        /// closest approach has a closed-form time. If that time falls outside this phase, the
        /// minimum of the phase is at one of its ends (both at the start, or both at the end).</item>
        /// <item>The faster aircraft has landed and only the slower one keeps flying. The closest
        /// approach is then the perpendicular projection of the parked aircraft on the moving
        /// aircraft's route, but only if it happens inside this phase.</item>
        /// </list>
        /// The result is the smallest distance found in either phase.
        /// </remarks>
        /// <param name="other">The other flight.</param>
        /// <returns>The minimum separation, in canvas units.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="other"/> is null.</exception>
        public double CalculateMinimumSeparation(FlightPlan other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            (double X, double Y) thisVelocity = GetVelocityVector();
            (double X, double Y) otherVelocity = other.GetVelocityVector();

            double offsetX = InitialPosition.X - other.InitialPosition.X;
            double offsetY = InitialPosition.Y - other.InitialPosition.Y;
            double relativeVelocityX = thisVelocity.X - otherVelocity.X;
            double relativeVelocityY = thisVelocity.Y - otherVelocity.Y;

            // Same direction and same speed: the separation never changes.
            if (relativeVelocityX == 0 && relativeVelocityY == 0)
                return InitialPosition.DistanceTo(other.InitialPosition);

            double thisFlightTime = GetTimeToCompleteRoute();
            double otherFlightTime = other.GetTimeToCompleteRoute();
            bool thisArrivesFirst = thisFlightTime <= otherFlightTime;
            double firstArrivalTime = Math.Min(thisFlightTime, otherFlightTime);
            double lastArrivalTime = Math.Max(thisFlightTime, otherFlightTime);

            double separationWhileBothFly = CalculateMinimumSeparationWhileBothFly(
                other, offsetX, offsetY, relativeVelocityX, relativeVelocityY, firstArrivalTime);

            double? separationAfterFirstLanding = thisArrivesFirst
                ? other.CalculateClosestApproachTo(FinalPosition, firstArrivalTime, lastArrivalTime)
                : CalculateClosestApproachTo(other.FinalPosition, firstArrivalTime, lastArrivalTime);

            return separationAfterFirstLanding.HasValue
                ? Math.Min(separationWhileBothFly, separationAfterFirstLanding.Value)
                : separationWhileBothFly;
        }

        /// <summary>
        /// Slows this flight down, step by step, until it no longer conflicts with <paramref name="other"/>.
        /// </summary>
        /// <remarks>
        /// If the speed would drop to zero (or below) the conflict cannot be solved by slowing
        /// down, so the original speed is restored instead of leaving the aircraft stopped.
        /// </remarks>
        /// <param name="other">The flight this one conflicts with.</param>
        /// <param name="safetyDistance">Minimum allowed separation, in canvas units.</param>
        /// <returns>True if the conflict was solved; false if the original speed had to be restored.</returns>
        public bool ResolveConflictBySlowingDown(FlightPlan other, double safetyDistance)
        {
            double originalSpeed = Speed;
            while (WillConflictWith(other, safetyDistance))
            {
                // Rounding avoids accumulating floating point noise such as 24.900000000000002.
                Speed = Math.Round(Speed - SpeedReductionStep, 2);
                if (Speed <= 0)
                {
                    Speed = originalSpeed;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Minimum separation during the phase in which both aircraft are still flying.
        /// </summary>
        private double CalculateMinimumSeparationWhileBothFly(FlightPlan other, double offsetX, double offsetY,
                                                              double relativeVelocityX, double relativeVelocityY,
                                                              double firstArrivalTime)
        {
            double closestApproachTime = -(offsetX * relativeVelocityX + offsetY * relativeVelocityY)
                                         / (relativeVelocityX * relativeVelocityX + relativeVelocityY * relativeVelocityY);

            if (closestApproachTime < 0 || closestApproachTime > firstArrivalTime)
            {
                // The relative distance only grows or only shrinks in this phase,
                // so its minimum is at one of the two ends of the phase.
                double separationAtStart = InitialPosition.DistanceTo(other.InitialPosition);
                double separationAtEnd = FinalPosition.DistanceTo(other.FinalPosition);
                return Math.Min(separationAtStart, separationAtEnd);
            }

            double closestX = offsetX + relativeVelocityX * closestApproachTime;
            double closestY = offsetY + relativeVelocityY * closestApproachTime;
            return Math.Sqrt(closestX * closestX + closestY * closestY);
        }

        /// <summary>
        /// Closest distance between this (still flying) aircraft and a fixed point, considering only
        /// the time window [<paramref name="fromTime"/>, <paramref name="toTime"/>].
        /// </summary>
        /// <param name="fixedPoint">Where the other, already landed, aircraft is parked.</param>
        /// <param name="fromTime">Start of the window (when the other aircraft landed).</param>
        /// <param name="toTime">End of the window (when this aircraft lands).</param>
        /// <returns>The distance, or null when the closest point is reached outside the window.</returns>
        private double? CalculateClosestApproachTo(Position fixedPoint, double fromTime, double toTime)
        {
            (double X, double Y) velocity = GetVelocityVector();
            double toPointX = fixedPoint.X - InitialPosition.X;
            double toPointY = fixedPoint.Y - InitialPosition.Y;

            double closestTime = (toPointX * velocity.X + toPointY * velocity.Y)
                                 / (velocity.X * velocity.X + velocity.Y * velocity.Y);

            // A NaN time (aircraft not moving) fails both comparisons, so it is also rejected here.
            if (!(closestTime >= fromTime && closestTime <= toTime))
                return null;

            double gapX = toPointX - velocity.X * closestTime;
            double gapY = toPointY - velocity.Y * closestTime;
            return Math.Sqrt(gapX * gapX + gapY * gapY);
        }

        /// <summary>Velocity vector (speed times unit direction of the route).</summary>
        private (double X, double Y) GetVelocityVector()
        {
            double routeLength = InitialPosition.DistanceTo(FinalPosition);
            if (routeLength == 0)
                return (0, 0); // A zero-length route has no direction: the aircraft stays still.

            return (Speed * (FinalPosition.X - InitialPosition.X) / routeLength,
                    Speed * (FinalPosition.Y - InitialPosition.Y) / routeLength);
        }

        /// <summary>Time needed to fly the whole route, in the speed's time unit.</summary>
        private double GetTimeToCompleteRoute()
        {
            return InitialPosition.DistanceTo(FinalPosition) / Speed;
        }
    }
}
