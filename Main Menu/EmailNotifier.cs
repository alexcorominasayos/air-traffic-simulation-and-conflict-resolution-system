using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Main_Menu
{
    /// <summary>
    /// Sends account notification emails (new account, password changed) through Gmail.
    /// </summary>
    /// <remarks>
    /// The sender account and its app password are read from <c>smtp.secrets.config</c>
    /// (referenced from App.config), which is excluded from git so the password is never
    /// published with the source code. See <c>smtp.secrets.example.config</c>.
    /// </remarks>
    internal static class EmailNotifier
    {
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SenderAddressSetting = "SmtpSenderAddress";
        private const string SenderPasswordSetting = "SmtpSenderPassword";

        /// <summary>
        /// Tries to send a plain-text email.
        /// </summary>
        /// <remarks>
        /// Notifications are informative only, so a failure (no internet, missing credentials)
        /// is reported to the caller instead of throwing and cancelling the account operation.
        /// </remarks>
        /// <param name="recipient">Destination address.</param>
        /// <param name="subject">Email subject.</param>
        /// <param name="body">Email text.</param>
        /// <param name="errorMessage">Why the email could not be sent, or null when it was sent.</param>
        /// <returns>True if the email was sent.</returns>
        public static bool TrySend(string recipient, string subject, string body, out string errorMessage)
        {
            string senderAddress = ConfigurationManager.AppSettings[SenderAddressSetting];
            string senderPassword = ConfigurationManager.AppSettings[SenderPasswordSetting];
            if (string.IsNullOrWhiteSpace(senderAddress) || string.IsNullOrWhiteSpace(senderPassword))
            {
                errorMessage = "the email account is not configured (smtp.secrets.config is missing)";
                return false;
            }

            try
            {
                using (SmtpClient client = new SmtpClient(SmtpHost, SmtpPort))
                using (MailMessage message = new MailMessage(senderAddress, recipient, subject, body))
                {
                    client.Credentials = new NetworkCredential(senderAddress, senderPassword);
                    client.EnableSsl = true;
                    message.IsBodyHtml = false;
                    client.Send(message);
                }
                errorMessage = null;
                return true;
            }
            catch (Exception exception) when (exception is SmtpException || exception is FormatException || exception is ArgumentException)
            {
                // FormatException / ArgumentException: the recipient address is not a valid email.
                errorMessage = exception.Message;
                return false;
            }
        }
    }
}
