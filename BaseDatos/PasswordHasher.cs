using System;
using System.Globalization;
using System.Security.Cryptography;

namespace BaseDatos
{
    /// <summary>
    /// Turns passwords into salted PBKDF2 hashes and checks passwords against them.
    /// </summary>
    /// <remarks>
    /// Only the hash is stored, so whoever reads the database file cannot recover the passwords.
    /// <list type="bullet">
    /// <item>A random <b>salt</b> per password means two users with the same password get different
    /// hashes, and precomputed tables of common passwords are useless.</item>
    /// <item>Many <b>iterations</b> make each guess deliberately slow (a fraction of a second), which
    /// is unnoticeable when logging in but makes trying millions of passwords impractical.</item>
    /// </list>
    /// Stored format: <c>PBKDF2$SHA256$&lt;iterations&gt;$&lt;salt base64&gt;$&lt;hash base64&gt;</c>.
    /// Keeping the algorithm and iteration count inside the value lets them be raised in the future
    /// without breaking passwords that were hashed with the old settings.
    /// </remarks>
    public static class PasswordHasher
    {
        /// <summary>Every stored hash starts with this, which tells hashes apart from old plain-text passwords.</summary>
        public const string HashPrefix = "PBKDF2$";

        private const string AlgorithmName = "SHA256";
        private const int Iterations = 100000;
        private const int SaltSizeBytes = 16;
        private const int HashSizeBytes = 32;
        private const char Separator = '$';

        /// <summary>Returns a new salted hash for <paramref name="password"/>, ready to be stored.</summary>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="password"/> is null.</exception>
        public static string Hash(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            byte[] salt = new byte[SaltSizeBytes];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
                random.GetBytes(salt);

            byte[] hash = DeriveHash(password, salt, Iterations, HashSizeBytes);
            return string.Join(Separator.ToString(),
                "PBKDF2", AlgorithmName, Iterations.ToString(CultureInfo.InvariantCulture),
                Convert.ToBase64String(salt), Convert.ToBase64String(hash));
        }

        /// <summary>
        /// Returns true when <paramref name="password"/> produces <paramref name="storedHash"/>.
        /// A value that is not a valid hash never matches.
        /// </summary>
        public static bool Verify(string password, string storedHash)
        {
            if (password == null || !IsHash(storedHash))
                return false;

            string[] parts = storedHash.Split(Separator);
            if (parts.Length != 5 || parts[1] != AlgorithmName ||
                !int.TryParse(parts[2], NumberStyles.None, CultureInfo.InvariantCulture, out int iterations) || iterations <= 0)
            {
                return false;
            }

            byte[] salt;
            byte[] expectedHash;
            try
            {
                salt = Convert.FromBase64String(parts[3]);
                expectedHash = Convert.FromBase64String(parts[4]);
            }
            catch (FormatException)
            {
                return false;
            }

            byte[] actualHash = DeriveHash(password, salt, iterations, expectedHash.Length);
            return AreEqualInConstantTime(actualHash, expectedHash);
        }

        /// <summary>Returns true if the stored value is a hash (and not an old plain-text password).</summary>
        public static bool IsHash(string storedValue)
        {
            return storedValue != null && storedValue.StartsWith(HashPrefix, StringComparison.Ordinal);
        }

        private static byte[] DeriveHash(string password, byte[] salt, int iterations, int sizeBytes)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
                return pbkdf2.GetBytes(sizeBytes);
        }

        /// <summary>
        /// Compares every byte even after finding a difference, so the time taken does not reveal
        /// how many leading bytes of a guess were right.
        /// </summary>
        private static bool AreEqualInConstantTime(byte[] first, byte[] second)
        {
            if (first.Length != second.Length)
                return false;

            int difference = 0;
            for (int index = 0; index < first.Length; index++)
                difference |= first[index] ^ second[index];
            return difference == 0;
        }
    }
}
