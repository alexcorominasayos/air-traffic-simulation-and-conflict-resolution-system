using System;
using System.Data.Common;
using System.Windows.Forms;
using Database;

namespace Menu
{
    /// <summary>
    /// Creates a new user account and emails the user to confirm it.
    /// </summary>
    public partial class RegisterUserForm : Form
    {
        /// <summary>Time the success message stays visible before the form closes itself.</summary>
        private const int CloseDelayMilliseconds = 2500;

        public RegisterUserForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string userName = userTextBox.Text;
            string password = passwordTextBox.Text;
            string email = emailTextBox.Text;

            try
            {
                using (DatabaseService database = new DatabaseService())
                {
                    database.Open();

                    string validationError = Validate(database, userName, password, email);
                    if (validationError != null)
                    {
                        UiHelpers.ShowMessage(messageLabel, validationError);
                        return;
                    }

                    database.AddUser(userName, password, email);
                }
            }
            catch (DbException exception)
            {
                UiHelpers.ShowUnexpectedError("Registering the user", exception);
                return;
            }

            string successMessage = "User registered successfully";
            if (!EmailNotifier.TrySend(email, "A new account has been created",
                    "A new account to the Conflict Solver has been created using this mail, if it wasn't you, respond to this email.",
                    out string emailError))
            {
                successMessage += $" (confirmation email not sent: {emailError})";
            }

            registerButton.Visible = false;
            UiHelpers.ShowMessage(messageLabel, successMessage, isError: false);
            closeDelayTimer.Interval = CloseDelayMilliseconds;
            closeDelayTimer.Start();
        }

        /// <summary>Returns the first problem with the entered data, or null if it can be registered.</summary>
        private string Validate(DatabaseService database, string userName, string password, string email)
        {
            if (userName == "" || password == "" || email == "")
                return "Missing boxes";
            if (database.UserNameExists(userName))
                return "This username is already used";
            return PasswordRules.Validate(password, confirmPasswordTextBox.Text);
        }

        private void closeDelayTimer_Tick(object sender, EventArgs e)
        {
            closeDelayTimer.Stop();
            Close();
        }
    }
}
