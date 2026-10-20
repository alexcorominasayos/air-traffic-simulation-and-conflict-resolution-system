using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace BaseDatos
{
    /// <summary>
    /// Access to the application's SQLite database (users and airline companies).
    /// </summary>
    /// <remarks>
    /// Call <see cref="Open"/> before any query and dispose the instance when finished,
    /// ideally with a <c>using</c> block so the connection is released even if a query fails.
    /// </remarks>
    public sealed class DatabaseService : IDisposable
    {
        /// <summary>
        /// The database file is looked up next to the executable (it is copied to the output folder).
        /// </summary>
        public const string DefaultConnectionString = "Data Source=BD.db";

        // Table and column names are part of the existing BD.db schema. Some of them are in
        // Spanish because renaming them would require migrating every existing database file.
        private const string UsersTable = "usersV2";
        private const string UserNameColumn = "nombre";
        private const string UserPasswordColumn = "contraseña";
        private const string UserEmailColumn = "correo";
        private const string UserIdColumn = "id";

        private const string CompaniesTable = "compsV2";

        /// <summary>Column with the airline's display name.</summary>
        public const string CompanyNameColumn = "Name";

        /// <summary>Column with the airline's ICAO code (first three letters of its flight identifiers).</summary>
        public const string CompanyIdentifierColumn = "Identificator";

        /// <summary>Column with the airline's phone number.</summary>
        public const string CompanyPhoneColumn = "Phone";

        /// <summary>Column with the airline's contact email.</summary>
        public const string CompanyEmailColumn = "Email";

        /// <summary>Column with the airline's logo image, stored as raw bytes.</summary>
        public const string CompanyLogoColumn = "Logo";

        private readonly string connectionString;
        private SQLiteConnection connection;

        /// <summary>Creates a service that uses the default <c>BD.db</c> file.</summary>
        public DatabaseService() : this(DefaultConnectionString)
        {
        }

        /// <summary>Creates a service for a specific SQLite connection string.</summary>
        /// <exception cref="ArgumentException">Thrown when the connection string is empty.</exception>
        public DatabaseService(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("The connection string cannot be empty.", nameof(connectionString));
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Opens the connection and makes sure the companies table exists.
        /// </summary>
        /// <remarks>
        /// Some copies of BD.db were created before the companies feature existed. Creating the
        /// table on demand keeps those databases working instead of failing on the first query.
        /// </remarks>
        /// <exception cref="SQLiteException">Thrown when the database cannot be opened.</exception>
        public void Open()
        {
            if (connection != null)
                return;

            connection = new SQLiteConnection(connectionString);
            connection.Open();
            EnsureCompaniesTableExists();
        }

        /// <summary>Closes the connection. Safe to call more than once.</summary>
        public void Close()
        {
            connection?.Close();
            connection?.Dispose();
            connection = null;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Close();
        }

        /// <summary>Returns every registered user.</summary>
        public DataTable GetUsers()
        {
            return Query($"SELECT * FROM {UsersTable}");
        }

        /// <summary>Returns true when a user with this name and password exists.</summary>
        public bool AreCredentialsValid(string userName, string password)
        {
            using (SQLiteCommand command = CreateCommand(
                $"SELECT COUNT(*) FROM {UsersTable} WHERE {UserNameColumn} = @name AND {UserPasswordColumn} = @password"))
            {
                command.Parameters.AddWithValue("@name", userName);
                command.Parameters.AddWithValue("@password", password);
                return Convert.ToInt64(command.ExecuteScalar()) > 0;
            }
        }

        /// <summary>Returns true when the user name is already taken.</summary>
        public bool UserNameExists(string userName)
        {
            using (SQLiteCommand command = CreateCommand(
                $"SELECT COUNT(*) FROM {UsersTable} WHERE {UserNameColumn} = @name"))
            {
                command.Parameters.AddWithValue("@name", userName);
                return Convert.ToInt64(command.ExecuteScalar()) > 0;
            }
        }

        /// <summary>
        /// Registers a new user. The numeric id is assigned automatically as the next free number.
        /// </summary>
        public void AddUser(string userName, string password, string email)
        {
            using (SQLiteCommand command = CreateCommand(
                $"INSERT INTO {UsersTable} ({UserNameColumn}, {UserPasswordColumn}, {UserEmailColumn}, {UserIdColumn}) " +
                $"VALUES (@name, @password, @email, (SELECT COALESCE(MAX({UserIdColumn}), 0) + 1 FROM {UsersTable}))"))
            {
                command.Parameters.AddWithValue("@name", userName);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>Changes the password of the user registered with the given email.</summary>
        /// <returns>True if a user with that email was found and updated.</returns>
        public bool UpdatePasswordByEmail(string email, string newPassword)
        {
            using (SQLiteCommand command = CreateCommand(
                $"UPDATE {UsersTable} SET {UserPasswordColumn} = @password WHERE {UserEmailColumn} = @email"))
            {
                command.Parameters.AddWithValue("@password", newPassword);
                command.Parameters.AddWithValue("@email", email);
                return command.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>Returns every airline company, including its logo bytes.</summary>
        public DataTable GetCompanies()
        {
            return Query($"SELECT * FROM {CompaniesTable}");
        }

        /// <summary>
        /// Returns the company whose identifier matches, or null if there is none.
        /// </summary>
        /// <param name="identifier">ICAO airline code, e.g. "IBE".</param>
        public DataRow FindCompanyByIdentifier(string identifier)
        {
            using (SQLiteCommand command = CreateCommand(
                $"SELECT * FROM {CompaniesTable} WHERE {CompanyIdentifierColumn} = @identifier LIMIT 1"))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                command.Parameters.AddWithValue("@identifier", identifier);
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result.Rows.Count > 0 ? result.Rows[0] : null;
            }
        }

        /// <summary>Stores a new airline company together with its logo.</summary>
        /// <param name="name">Display name.</param>
        /// <param name="identifier">ICAO airline code.</param>
        /// <param name="phone">Contact phone number.</param>
        /// <param name="email">Contact email.</param>
        /// <param name="logoFilePath">Path to an image file that is read and stored in the database.</param>
        /// <exception cref="FileNotFoundException">Thrown when the logo file does not exist.</exception>
        public void AddCompany(string name, string identifier, int phone, string email, string logoFilePath)
        {
            if (!File.Exists(logoFilePath))
                throw new FileNotFoundException("The logo file does not exist.", logoFilePath);

            byte[] logoBytes = File.ReadAllBytes(logoFilePath);

            using (SQLiteCommand command = CreateCommand(
                $"INSERT INTO {CompaniesTable} ({CompanyNameColumn}, {CompanyIdentifierColumn}, {CompanyPhoneColumn}, {CompanyEmailColumn}, {CompanyLogoColumn}) " +
                "VALUES (@name, @identifier, @phone, @email, @logo)"))
            {
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@identifier", identifier);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.Add("@logo", DbType.Binary).Value = logoBytes;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>Deletes every company with the given name.</summary>
        /// <returns>True if at least one company was deleted.</returns>
        public bool DeleteCompanyByName(string name)
        {
            using (SQLiteCommand command = CreateCommand($"DELETE FROM {CompaniesTable} WHERE {CompanyNameColumn} = @name"))
            {
                command.Parameters.AddWithValue("@name", name);
                return command.ExecuteNonQuery() > 0;
            }
        }

        private void EnsureCompaniesTableExists()
        {
            using (SQLiteCommand command = CreateCommand(
                $"CREATE TABLE IF NOT EXISTS {CompaniesTable} (" +
                $"{CompanyNameColumn} varchar, {CompanyIdentifierColumn} varchar, {CompanyPhoneColumn} integer, " +
                $"{CompanyEmailColumn} varchar, {CompanyLogoColumn} blob)"))
            {
                command.ExecuteNonQuery();
            }
        }

        private DataTable Query(string sql)
        {
            using (SQLiteCommand command = CreateCommand(sql))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }

        private SQLiteCommand CreateCommand(string sql)
        {
            if (connection == null)
                throw new InvalidOperationException("Call Open() before running database queries.");
            return new SQLiteCommand(sql, connection);
        }
    }
}
