using System;
using System.Windows.Forms;

namespace Main_Menu
{
    /// <summary>Where the user wants to take flight plans from.</summary>
    public enum LoadSource
    {
        /// <summary>The window was closed without choosing.</summary>
        None,

        /// <summary>Typing each flight plan by hand.</summary>
        Manual,

        /// <summary>Loading a simulation saved in a text file.</summary>
        File,
    }

    /// <summary>
    /// Asks whether flight plans are entered manually or loaded from a file.
    /// </summary>
    public partial class LoadSourceSelectionForm : Form
    {
        public LoadSourceSelectionForm()
        {
            InitializeComponent();
        }

        /// <summary>The user's choice. Read it after the dialog closes.</summary>
        public LoadSource SelectedSource { get; private set; } = LoadSource.None;

        private void manualButton_Click(object sender, EventArgs e)
        {
            SelectedSource = LoadSource.Manual;
            Close();
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            SelectedSource = LoadSource.File;
            Close();
        }
    }
}
