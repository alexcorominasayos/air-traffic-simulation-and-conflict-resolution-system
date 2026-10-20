using System;
using System.Windows.Forms;
using FlightLib;

namespace Main_Menu
{
    /// <summary>
    /// The Open and Save windows used across the application, configured the same way everywhere.
    /// </summary>
    /// <remarks>
    /// Choosing a file from a window (instead of typing its name) avoids typos, files saved in an
    /// unexpected folder, and invalid characters in names. Every window starts in the program's own
    /// folder, which is where earlier versions saved and loaded files, so old files are easy to find.
    /// </remarks>
    internal static class FileDialogs
    {
        private const string SimulationFilter = "Simulation files (*.txt)|*.txt|All files (*.*)|*.*";
        private const string KmlFilter = "Google Earth files (*.kml)|*.kml";
        private const string ImageFilter = "Images (*.png;*.jpg;*.jpeg;*.bmp;*.gif)|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files (*.*)|*.*";

        private static string ProgramFolder => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>Asks for a saved simulation to load.</summary>
        /// <param name="owner">Window the dialog belongs to.</param>
        /// <param name="filePath">The chosen file, or null if the user cancelled.</param>
        /// <returns>True if a file was chosen.</returns>
        public static bool TryChooseSimulationToOpen(IWin32Window owner, out string filePath)
        {
            return TryOpen(owner, "Load simulation", SimulationFilter, out filePath);
        }

        /// <summary>Asks where to save the simulation as a text file.</summary>
        public static bool TryChooseSimulationSaveLocation(IWin32Window owner, out string filePath)
        {
            return TrySave(owner, "Save simulation", SimulationFilter, SimulationFile.Extension, out filePath);
        }

        /// <summary>Asks where to save the Google Earth (.kml) export.</summary>
        public static bool TryChooseKmlSaveLocation(IWin32Window owner, out string filePath)
        {
            return TrySave(owner, "Export to Google Earth", KmlFilter, KmlExporter.Extension, out filePath);
        }

        /// <summary>Asks for an image file (used for airline logos).</summary>
        public static bool TryChooseImage(IWin32Window owner, out string filePath)
        {
            return TryOpen(owner, "Choose the company logo", ImageFilter, out filePath);
        }

        private static bool TryOpen(IWin32Window owner, string title, string filter, out string filePath)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter,
                InitialDirectory = ProgramFolder,
                CheckFileExists = true,
                RestoreDirectory = true,
            })
            {
                bool chosen = dialog.ShowDialog(owner) == DialogResult.OK;
                filePath = chosen ? dialog.FileName : null;
                return chosen;
            }
        }

        private static bool TrySave(IWin32Window owner, string title, string filter, string extension, out string filePath)
        {
            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Title = title,
                Filter = filter,
                DefaultExt = extension.TrimStart('.'),
                AddExtension = true,
                InitialDirectory = ProgramFolder,
                OverwritePrompt = true, // Asks before replacing an existing file.
                RestoreDirectory = true,
            })
            {
                bool chosen = dialog.ShowDialog(owner) == DialogResult.OK;
                filePath = chosen ? dialog.FileName : null;
                return chosen;
            }
        }
    }
}
