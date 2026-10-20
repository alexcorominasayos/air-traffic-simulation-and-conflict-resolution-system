using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms;
using Database;

namespace Menu
{
    /// <summary>
    /// Lists the airline companies with their logos, and lets the user add or delete them.
    /// Clicking a company name searches it on Google.
    /// </summary>
    public partial class AirlineCompaniesForm : Form
    {
        private const int LogoRowHeight = 200;
        private const int LogoColumnWidth = 600;

        public AirlineCompaniesForm()
        {
            InitializeComponent();
        }

        private void AirlineCompaniesForm_Load(object sender, EventArgs e)
        {
            Width = 1121;
            Height = 796;
            companiesGrid.Width = 1075;
            companiesGrid.Height = 615;
            companiesGrid.AllowUserToAddRows = false;

            // A logo that is not a valid image would otherwise pop up an error dialog for every
            // repaint; the grid shows its "broken image" icon in that cell instead.
            companiesGrid.DataError += (gridSender, errorArgs) => errorArgs.ThrowException = false;
            RefreshCompanies();
        }

        /// <summary>Reloads the grid from the database.</summary>
        private void RefreshCompanies()
        {
            DataTable companies;
            try
            {
                using (DatabaseService database = new DatabaseService())
                {
                    database.Open();
                    companies = database.GetCompanies();
                }
            }
            catch (DbException exception)
            {
                UiHelpers.ShowUnexpectedError("Loading the companies", exception);
                return;
            }

            companiesGrid.DataSource = companies;
            ConfigureLogoColumn();
        }

        /// <summary>
        /// The grid already turns the logo bytes into images by itself (it creates an image column
        /// for binary data); this only makes the images readable by enlarging and zooming them.
        /// </summary>
        private void ConfigureLogoColumn()
        {
            if (!(companiesGrid.Columns[DatabaseService.CompanyLogoColumn] is DataGridViewImageColumn logoColumn))
                return;

            logoColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            logoColumn.HeaderText = "Logo";
            logoColumn.Width = LogoColumnWidth;
            foreach (DataGridViewRow row in companiesGrid.Rows)
                row.Height = LogoRowHeight;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (AddCompanyForm addForm = new AddCompanyForm())
            {
                addForm.ShowDialog();
                if (addForm.CompanyAdded)
                    RefreshCompanies();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (companiesGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Choose a row to delete its company");
                return;
            }

            string companyName = companiesGrid.SelectedRows[0].Cells[DatabaseService.CompanyNameColumn].Value?.ToString();
            try
            {
                using (DatabaseService database = new DatabaseService())
                {
                    database.Open();
                    database.DeleteCompanyByName(companyName);
                }
            }
            catch (DbException exception)
            {
                UiHelpers.ShowUnexpectedError("Deleting the company", exception);
                return;
            }

            MessageBox.Show("Company deleted successfully");
            RefreshCompanies();
        }

        private void companiesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            const int NameColumnIndex = 0;
            if (e.RowIndex < 0 || e.ColumnIndex != NameColumnIndex)
                return;

            string companyName = companiesGrid[e.ColumnIndex, e.RowIndex].Value?.ToString();
            if (string.IsNullOrEmpty(companyName))
                return;

            try
            {
                string searchUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(companyName)}";
                Process.Start(new ProcessStartInfo { FileName = searchUrl, UseShellExecute = true });
            }
            catch (Win32Exception exception)
            {
                UiHelpers.ShowUnexpectedError("Opening the web browser", exception);
            }
        }
    }
}
