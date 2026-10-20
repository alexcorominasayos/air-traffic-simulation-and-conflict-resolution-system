using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using FlightLib;

namespace Menu
{
    /// <summary>
    /// Offers to open the conflict log that was just written, with the speed changes made.
    /// </summary>
    public partial class OpenConflictLogPromptForm : Form
    {
        public OpenConflictLogPromptForm()
        {
            InitializeComponent();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // UseShellExecute opens the file with its default program (normally Notepad).
                Process.Start(new ProcessStartInfo { FileName = ConflictResolutionLog.FileName, UseShellExecute = true });
            }
            catch (Win32Exception exception)
            {
                UiHelpers.ShowUnexpectedError("Opening the conflict log", exception);
            }
            Close();
        }
    }
}
