using System;
using System.Windows.Forms;

namespace Main_Menu
{
    /// <summary>
    /// Tells the user that some flights will conflict and asks whether to solve it by slowing them down.
    /// </summary>
    public partial class ConflictResolutionPromptForm : Form
    {
        public ConflictResolutionPromptForm()
        {
            InitializeComponent();
        }

        /// <summary>True if the user answered "Yes". Read it after the dialog closes.</summary>
        public bool UserWantsToResolve { get; private set; }

        private void yesButton_Click(object sender, EventArgs e)
        {
            UserWantsToResolve = true;
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            UserWantsToResolve = false;
            Close();
        }
    }
}
