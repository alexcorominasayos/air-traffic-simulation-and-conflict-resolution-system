using System;

namespace FlightLib
{
    /// <summary>
    /// An immutable point on the 2D simulation canvas.
    /// </summary>
    /// <remarks>
    /// Positions are immutable so that several flight plans (or snapshots of the same
    /// flight plan kept for the undo history) can safely share the same instance
    /// without one of them accidentally moving the others.
    /// </remarks>
    public sealed class Position
    {
        /// <summary>Horizontal coordinate, in canvas units (pixels).</summary>
        public double X { get; }

        /// <summary>Vertical coordinate, in canvas units (pixels). Grows downwards, as on screen.</summary>
        public double Y { get; }

        /// <summary>
        /// Creates a position at the given canvas coordinates.
        /// </summary>
        /// <param name="x">Horizontal coordinate.</param>
        /// <param name="y">Vertical coordinate.</param>
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns the straight-line (Euclidean) distance to another position.
        /// </summary>
        /// <param name="other">The position to measure the distance to.</param>
        /// <returns>The distance in canvas units.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="other"/> is null.</exception>
        public double DistanceTo(Position other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            double deltaX = X - other.X;
            double deltaY = Y - other.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        /// <summary>
        /// Returns true when both positions have exactly the same coordinates.
        /// </summary>
        /// <remarks>
        /// Value comparison is used (instead of comparing object references) so that a
        /// flight restored from the undo history or loaded from a file is still
        /// recognised as "arrived" when it sits on its destination.
        /// </remarks>
        /// <param name="other">The position to compare with.</param>
        public bool HasSameCoordinatesAs(Position other)
        {
            return other != null && X == other.X && Y == other.Y;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
