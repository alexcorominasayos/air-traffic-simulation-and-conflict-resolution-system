using System;
using System.Data.Common;
using System.Windows.Forms;
using BaseDatos;

namespace Main_Menu
{
    /// <summary>
    /// Lets a user set a new password for the account registered with their email.
    /// </summary>
    public partial class PasswordRecoveryForm : Form
    {
        /// <summary>Time the success message stays visible before the form closes itself.</summary>
        private const int CloseDelayMilliseconds = 2500;

        public PasswordRecoveryForm()
        {
            InitializeComponent();
        }

        private void recoverButton_Click(object sender, EventArgs e)
        {
            string email = emailTextBox.Text;
            string newPassword = passwordTextBox.Text;

            string validationError = email == "" || newPassword == ""
                ? "Missing boxes"
                : PasswordRules.Validate(newPassword, confirmPasswordTextBox.Text);
            if (validationError != null)
            {
                UiHelpers.ShowMessage(messageLabel, validationError);
                return;
            }

            bool accountFound;
            try
            {
                using (DatabaseService database = new DatabaseService())
                {
                    database.Open();
                    accountFound = database.UpdatePasswordByEmail(email, newPassword);
                }
            }
            catch (DbException exception)
            {
                UiHelpers.ShowUnexpectedError("Changing the password", exception);
                return;
            }

            if (!accountFound)
            {
                UiHelpers.ShowMessage(messageLabel, "There is no account registered with this mail");
                return;
            }

            string successMessage = "Password changed successfully";
            if (!EmailNotifier.TrySend(email, "Your password has been restablished",
                    "The password has been restablished, if it wasn't you, respond to this email. Someone from our staff will contact with you",
                    out string emailError))
            {
                successMessage += $" (notification email not sent: {emailError})";
            }

            UiHelpers.ShowMessage(messageLabel, successMessage, isError: false);
            closeDelayTimer.Interval = CloseDelayMilliseconds;
            closeDelayTimer.Start();
        }

        private void closeDelayTimer_Tick(object sender, EventArgs e)
        {
            closeDelayTimer.Stop();
            Close();
        }
    }
}
