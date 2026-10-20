using System;
using System.Collections.Generic;
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
        /// <summary>Name of the database file, created next to the executable if it does not exist.</summary>
        public const string DatabaseFileName = "BD.db";

        /// <summary>
        /// Full path of the default database file. It is resolved from the executable's folder (not
        /// the current working folder), so starting the program from a shortcut or another folder
        /// still opens the same database instead of silently creating a new empty one.
        /// </summary>
        public static string DefaultDatabasePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DatabaseFileName);

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
        public DatabaseService() : this(ToConnectionString(DefaultDatabasePath))
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

        /// <summary>Builds an SQLite connection string for a database file.</summary>
        public static string ToConnectionString(string databaseFilePath)
        {
            return new SQLiteConnectionStringBuilder { DataSource = databaseFilePath }.ConnectionString;
        }

        /// <summary>
        /// Opens the connection and prepares the database: creates any missing table and converts
        /// passwords that are still stored as plain text into hashes.
        /// </summary>
        /// <remarks>
        /// SQLite creates the file when it does not exist, so together with the table creation a
        /// fresh copy of the project works without shipping a database file. Older copies of BD.db
        /// that lack the companies table, or still hold plain-text passwords, are upgraded in place.
        /// </remarks>
        /// <exception cref="SQLiteException">Thrown when the database cannot be opened.</exception>
        public void Open()
        {
            if (connection != null)
                return;

            connection = new SQLiteConnection(connectionString);
            connection.Open();
            EnsureUsersTableExists();
            EnsureCompaniesTableExists();
            HashPlainTextPasswords();
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

        /// <summary>Returns true when a user with this name exists and <paramref name="password"/> is theirs.</summary>
        public bool AreCredentialsValid(string userName, string password)
        {
            using (SQLiteCommand command = CreateCommand(
                $"SELECT {UserPasswordColumn} FROM {UsersTable} WHERE {UserNameColumn} = @name"))
            {
                command.Parameters.AddWithValue("@name", userName);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // The name column is not enforced as unique by the old schema, so check every match.
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0) && PasswordHasher.Verify(password, reader.GetString(0)))
                            return true;
                    }
                }
            }
            return false;
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
                command.Parameters.AddWithValue("@password", PasswordHasher.Hash(password));
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
                command.Parameters.AddWithValue("@password", PasswordHasher.Hash(newPassword));
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

        private void EnsureUsersTableExists()
        {
            // "primarykey" (without a space) is kept exactly as in the original schema: SQLite reads it
            // as part of the type name, so user names are not enforced as unique by the database.
            // UserNameExists() is what prevents duplicates when registering.
            using (SQLiteCommand command = CreateCommand(
                $"CREATE TABLE IF NOT EXISTS {UsersTable} (" +
                $"{UserNameColumn} varchar primarykey, {UserPasswordColumn} varchar, {UserEmailColumn} varchar, {UserIdColumn} integer)"))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Replaces every plain-text password with its hash. Users keep logging in with the same
        /// password; only what is stored changes. Runs in a transaction so a failure leaves the
        /// database as it was.
        /// </summary>
        private void HashPlainTextPasswords()
        {
            List<(long RowId, string Password)> plainTextPasswords = new List<(long, string)>();
            using (SQLiteCommand command = CreateCommand(
                $"SELECT rowid, {UserPasswordColumn} FROM {UsersTable} " +
                $"WHERE {UserPasswordColumn} IS NOT NULL AND substr({UserPasswordColumn}, 1, @prefixLength) <> @prefix"))
            {
                command.Parameters.AddWithValue("@prefixLength", PasswordHasher.HashPrefix.Length);
                command.Parameters.AddWithValue("@prefix", PasswordHasher.HashPrefix);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        plainTextPasswords.Add((reader.GetInt64(0), Convert.ToString(reader.GetValue(1))));
                }
            }

            if (plainTextPasswords.Count == 0)
                return;

            using (SQLiteTransaction transaction = connection.BeginTransaction())
            {
                foreach ((long rowId, string password) in plainTextPasswords)
                {
                    using (SQLiteCommand update = CreateCommand($"UPDATE {UsersTable} SET {UserPasswordColumn} = @hash WHERE rowid = @rowId"))
                    {
                        update.Transaction = transaction;
                        update.Parameters.AddWithValue("@hash", PasswordHasher.Hash(password));
                        update.Parameters.AddWithValue("@rowId", rowId);
                        update.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
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
