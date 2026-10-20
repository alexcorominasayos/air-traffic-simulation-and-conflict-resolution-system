using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace FlightLib
{
    /// <summary>
    /// Exports flight plans to a KML file that Google Earth can display, with the initial,
    /// current and final position of each flight and a line for its trajectory.
    /// </summary>
    public static class KmlExporter
    {
        private const string DocumentTitle = "Points and trajectories of the Flight Plans";
        private const string Altitude = "0";

        // The simulation canvas is mapped linearly onto a geographic box over the Iberian
        // Peninsula: the canvas' top-left corner is (WestLongitude, NorthLatitude) and its
        // bottom-right corner is (EastLongitude, SouthLatitude).
        private const double WestLongitude = -14.569;
        private const double EastLongitude = 6.026;
        private const double NorthLatitude = 44.849;
        private const double SouthLatitude = 35.318;

        /// <summary>
        /// Writes the KML file for the given flights.
        /// </summary>
        /// <param name="flightPlans">Flights to export.</param>
        /// <param name="filePathWithoutExtension">Destination path; ".kml" is appended.</param>
        /// <returns>The full path of the written file.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="flightPlans"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the path is empty.</exception>
        /// <exception cref="IOException">Thrown when the file cannot be written.</exception>
        public static string Export(FlightPlanList flightPlans, string filePathWithoutExtension)
        {
            if (flightPlans == null)
                throw new ArgumentNullException(nameof(flightPlans));
            if (string.IsNullOrWhiteSpace(filePathWithoutExtension))
                throw new ArgumentException("The file name cannot be empty.", nameof(filePathWithoutExtension));

            string filePath = filePathWithoutExtension + ".kml";
            File.WriteAllText(filePath, BuildDocument(flightPlans), Encoding.UTF8);
            return filePath;
        }

        /// <summary>
        /// Writes the KML file and opens it with the program associated with .kml files (normally Google Earth).
        /// </summary>
        /// <returns>The full path of the written file.</returns>
        /// <exception cref="System.ComponentModel.Win32Exception">Thrown when no program can open .kml files.</exception>
        public static string ExportAndOpen(FlightPlanList flightPlans, string filePathWithoutExtension)
        {
            string filePath = Export(flightPlans, filePathWithoutExtension);
            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
            return filePath;
        }

        private static string BuildDocument(FlightPlanList flightPlans)
        {
            StringBuilder kml = new StringBuilder();
            kml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?> <kml xmlns=\"http://www.opengis.net/kml/2.2\">  ");
            kml.Append("<Document><name> ").Append(DocumentTitle).Append(" </name> <open> 1 </open> ");
            kml.Append(IconStyles);
            kml.Append("<Folder> <name> ").Append(DocumentTitle).Append(" </name> <open> 1 </open> ");

            foreach (FlightPlan flight in flightPlans.FlightPlans)
                AppendFlight(kml, flight);

            kml.Append(" </Folder></Document></kml> ");
            return kml.ToString();
        }

        private static void AppendFlight(StringBuilder kml, FlightPlan flight)
        {
            string initial = ToKmlCoordinates(flight.InitialPosition);
            string current = ToKmlCoordinates(flight.CurrentPosition);
            string final = ToKmlCoordinates(flight.FinalPosition);

            AppendPoint(kml, "Initial Position " + flight.Id, "#default1", initial);
            AppendPoint(kml, "Current Position " + flight.Id, "#msn_airports0", current);
            AppendPoint(kml, "Final Position " + flight.Id, "#msn_F", final);

            kml.Append("<Placemark><name>Trajectory ").Append(flight.Id).Append("</name><styleUrl>#default0</styleUrl>")
               .Append("<LineString><altitudeMode>clampToGround</altitudeMode><extrude>1</extrude><tessellate>1</tessellate>")
               .Append("<coordinates>").Append(initial).Append(' ').Append(final)
               .Append(" </coordinates></LineString> </Placemark> ");
        }

        private static void AppendPoint(StringBuilder kml, string name, string styleUrl, string coordinates)
        {
            kml.Append(" <Placemark><name>").Append(name).Append("</name><styleUrl>").Append(styleUrl)
               .Append("</styleUrl><Point><coordinates>").Append(coordinates)
               .Append(" </coordinates></Point> </Placemark> ");
        }

        /// <summary>
        /// Converts a canvas position into KML "longitude,latitude,altitude" text.
        /// </summary>
        /// <remarks>
        /// Invariant culture guarantees a dot as decimal separator, which KML requires,
        /// even on Windows installations configured with a comma (such as Spanish).
        /// </remarks>
        private static string ToKmlCoordinates(Position position)
        {
            double longitude = WestLongitude + (EastLongitude - WestLongitude) / SimulationCanvas.Width * position.X;
            double latitude = NorthLatitude + (SouthLatitude - NorthLatitude) / SimulationCanvas.Height * position.Y;
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2}", longitude, latitude, Altitude);
        }

        /// <summary>
        /// Custom icon styles, so Google Earth shows "I" (initial), airport (current) and "F" (final)
        /// markers instead of its default pins.
        /// </summary>
        private const string IconStyles =
            "<Style id=\"default\"><IconStyle><scale>1.1</scale><Icon><href>http://maps.google.com/mapfiles/kml/paddle/I.png</href>" +
            "</Icon><hotSpot x=\"32\" y=\"1\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle><ListStyle><ItemIcon><href>" +
            "http://maps.google.com/mapfiles/kml/paddle/I-lv.png</href></ItemIcon></ListStyle></Style><StyleMap id=\"default0\"><Pair>" +
            "<key>normal</key><styleUrl>#default2</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#hl0</styleUrl></Pair></StyleMap>" +
            "<StyleMap id=\"default1\"><Pair><key>normal</key><styleUrl>#default</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#hl</styleUrl>" +
            "</Pair></StyleMap><Style id=\"default2\"><LineStyle><color>ffffff55</color><width>3</width></LineStyle></Style><Style id=\"hl\">" +
            "<IconStyle><scale>1.3</scale><Icon><href>http://maps.google.com/mapfiles/kml/paddle/I.png</href></Icon><hotSpot x=\"32\" y=\"1\" xunits" +
            "=\"pixels\" yunits=\"pixels\"/></IconStyle><ListStyle><ItemIcon><href>http://maps.google.com/mapfiles/kml/paddle/I-lv.png</href>" +
            "</ItemIcon></ListStyle></Style><Style id=\"hl0\"><IconStyle><scale>1.2</scale></IconStyle><LineStyle><color>ffffff55</color><width>3</width>" +
            "</LineStyle></Style><StyleMap id=\"msn_F\"><Pair><key>normal</key><styleUrl>#sn_F</styleUrl></Pair><Pair><key>highlight</key>" +
            "<styleUrl>#sh_F</styleUrl></Pair></StyleMap><StyleMap id=\"msn_airports\"><Pair><key>normal</key><styleUrl>#sn_airports</styleUrl>" +
            "</Pair><Pair><key>highlight</key><styleUrl>#sh_airports</styleUrl></Pair></StyleMap><StyleMap id=\"msn_airports0\"><Pair>" +
            "<key>normal</key><styleUrl>#sn_airports0</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#sh_airports0</styleUrl></Pair>" +
            "</StyleMap><Style id=\"sh_F\"><IconStyle><scale>1.3</scale><Icon><href>http://maps.google.com/mapfiles/kml/paddle/F.png</href></Icon>" +
            "<hotSpot x=\"32\" y=\"1\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle><ListStyle><ItemIcon>" +
            "<href>http://maps.google.com/mapfiles/kml/paddle/F-lv.png</href></ItemIcon></ListStyle></Style><Style id=\"sh_airports\"><IconStyle>" +
            "<scale>1.4</scale><Icon><href>http://maps.google.com/mapfiles/kml/shapes/airports.png</href></Icon><hotSpot x=\"0.5\" y=\"0\" xunits" +
            "=\"fraction\" yunits=\"fraction\"/></IconStyle></Style><Style id=\"sh_airports0\"><IconStyle><scale>1.4</scale><Icon>" +
            "<href>http://maps.google.com/mapfiles/kml/shapes/airports.png</href></Icon><hotSpot x=\"0.5\" y=\"0\" xunits=\"fraction\" yunits=\"fraction\"/>" +
            "</IconStyle></Style><Style id=\"sn_F\"><IconStyle><scale>1.1</scale><Icon><href>http://maps.google.com/mapfiles/kml/paddle/F.png</href>" +
            "</Icon><hotSpot x=\"32\" y=\"1\" xunits=\"pixels\" yunits=\"pixels\"/></IconStyle><ListStyle><ItemIcon>" +
            "<href>http://maps.google.com/mapfiles/kml/paddle/F-lv.png</href></ItemIcon></ListStyle></Style><Style id=\"sn_airports\"><IconStyle>" +
            "<scale>1.2</scale><Icon><href>http://maps.google.com/mapfiles/kml/shapes/airports.png</href></Icon>" +
            "<hotSpot x=\"0.5\" y=\"0\" xunits=\"fraction\" yunits=\"fraction\"/></IconStyle></Style><Style id=\"sn_airports0\"><IconStyle>" +
            "<scale>1.2</scale><Icon><href>http://maps.google.com/mapfiles/kml/shapes/airports.png</href></Icon>" +
            "<hotSpot x=\"0.5\" y=\"0\" xunits=\"fraction\" yunits=\"fraction\"/></IconStyle></Style>";
    }
}
