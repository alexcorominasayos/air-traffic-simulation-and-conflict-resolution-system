using System;
using System.Data.Common;
using System.IO;
using System.Windows.Forms;
using BaseDatos;

namespace Main_Menu
{
    /// <summary>
    /// Registers a new airline company, with its contact details and logo.
    /// </summary>
    public partial class AddCompanyForm : Form
    {
        /// <summary>Time the "Company added" feedback stays visible before the form closes.</summary>
        private const int CloseDelayMilliseconds = 1750;

        public AddCompanyForm()
        {
            InitializeComponent();
        }

        /// <summary>True if a company was stored, so the caller knows it must refresh its list.</summary>
        public bool CompanyAdded { get; private set; }

        private void addButton_Click(object sender, EventArgs e)
        {
            phoneTextBox.BackColor = UiHelpers.NormalColor;
            if (!UiHelpers.TryParseInt(phoneTextBox.Text, out int phone))
            {
                phoneTextBox.BackColor = UiHelpers.ErrorColor;
                return;
            }

            // "Copy as path" in Windows Explorer wraps the path in quotes, so they are removed here.
            string logoPath = logoPathTextBox.Text.Trim().Trim('"');
            if (!File.Exists(logoPath))
            {
                MessageBox.Show("This file does not exist or it may be a wrong direction");
                return;
            }

            try
            {
                using (DatabaseService database = new DatabaseService())
                {
                    database.Open();
                    database.AddCompany(nameTextBox.Text, identifierTextBox.Text, phone, emailTextBox.Text.Trim(), logoPath);
                }
            }
            catch (Exception exception) when (exception is DbException || exception is IOException || exception is UnauthorizedAccessException)
            {
                UiHelpers.ShowUnexpectedError("Adding the company", exception);
                return;
            }

            CompanyAdded = true;
            addButton.BackColor = UiHelpers.SuccessColor;
            addButton.Text = "Company added";
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
