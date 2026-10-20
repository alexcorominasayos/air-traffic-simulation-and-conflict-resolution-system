namespace Menu
{
    /// <summary>
    /// Password requirements shared by user registration and password recovery.
    /// </summary>
    internal static class PasswordRules
    {
        /// <summary>Minimum number of characters a password must have.</summary>
        public const int MinimumLength = 8;

        /// <summary>
        /// Character that passwords may not contain. It is kept from earlier versions of the program,
        /// which built SQL queries by joining text, so existing users never have it in their passwords.
        /// </summary>
        public const char ForbiddenCharacter = '\'';

        /// <summary>
        /// Checks a new password and its confirmation.
        /// </summary>
        /// <returns>A message describing the first problem found, or null if the password is valid.</returns>
        public static string Validate(string password, string confirmation)
        {
            if (password != confirmation)
                return "The passwords must be the same";
            if (password.Length < MinimumLength)
                return $"The password must be at least {MinimumLength} characters long";
            if (password.IndexOf(ForbiddenCharacter) >= 0)
                return $"You can not use {ForbiddenCharacter} in your password";
            return null;
        }
    }
}
