using System;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using BaseDatos;

namespace Main_Menu
{
    /// <summary>
    /// First screen of the application: checks the user's credentials and opens the main menu.
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            passwordLabel.BackColor = Color.Transparent;
            userLabel.BackColor = Color.Transparent;
            titleLabel.BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Stretch;
            passwordTextBox.PasswordChar = '•';

            // Without the database nobody can log in, so fail early with a clear message.
            if (!CanReachDatabase())
            {
                MessageBox.Show("DATA BASE CAN NOT BE LOADED");
                Close();
            }
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            string userName = userTextBox.Text;
            bool credentialsAreValid;
            try
            {
                using (DatabaseService database = new DatabaseService())
                {
                    database.Open();
                    credentialsAreValid = database.AreCredentialsValid(userName, passwordTextBox.Text);
                }
            }
            catch (DbException exception)
            {
                UiHelpers.ShowUnexpectedError("Logging in", exception);
                return;
            }

            if (!credentialsAreValid)
            {
                UiHelpers.ShowMessage(messageLabel, UiHelpers.AsBanner("User not found or wrong password"));
                return;
            }

            UiHelpers.HideMessage(messageLabel);
            userTextBox.Text = "";
            passwordTextBox.Text = "";
            OpenMainMenu(userName);
        }

        /// <summary>
        /// Shows the main menu and hides this form. This form stays alive (hidden) because it is
        /// the application's main form: when the main menu closes, either the user logged out
        /// and this form is shown again, or the whole application ends.
        /// </summary>
        private void OpenMainMenu(string userName)
        {
            MainMenuForm mainMenu = new MainMenuForm(userName);
            mainMenu.FormClosed += (closedSender, closedArgs) =>
            {
                if (mainMenu.UserLoggedOut)
                    Show();
                else
                    Close();
            };
            mainMenu.Show();
            Hide();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            using (RegisterUserForm registerForm = new RegisterUserForm())
                registerForm.ShowDialog();
        }

        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            using (PasswordRecoveryForm recoveryForm = new PasswordRecoveryForm())
                recoveryForm.ShowDialog();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static bool CanReachDatabase()
        {
            try
            {
                // Opening also creates the tables on first run and hashes any old plain-text passwords.
                using (DatabaseService database = new DatabaseService())
                    database.Open();
                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
    }
}
