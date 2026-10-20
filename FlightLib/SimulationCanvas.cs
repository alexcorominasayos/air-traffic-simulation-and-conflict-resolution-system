namespace FlightLib
{
    /// <summary>
    /// Size of the drawing area where flights are simulated. Coordinates go from (0, 0) at the
    /// top-left corner to (<see cref="Width"/>, <see cref="Height"/>) at the bottom-right corner.
    /// </summary>
    public static class SimulationCanvas
    {
        /// <summary>Largest valid X coordinate.</summary>
        public const double Width = 897;

        /// <summary>Largest valid Y coordinate.</summary>
        public const double Height = 597;

        /// <summary>Returns true when the point lies inside the canvas, borders included.</summary>
        public static bool Contains(double x, double y)
        {
            return x >= 0 && x <= Width && y >= 0 && y <= Height;
        }
    }
}
