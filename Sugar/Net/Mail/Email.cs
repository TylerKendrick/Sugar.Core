using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Sugar.Linq;

namespace Sugar.Net.Mail
{
    /// <summary>
    /// Simplifies common operations with emails.
    /// </summary>
    public static class Email
    {
        /// <summary>
        /// Uses regex to parse a string for a built-in match with an email address.
        /// </summary>
        /// <param name="target">The string expected as a match to an email address.</param>
        public static bool IsMatch(string target)
        {
            const string initialMatch =
                @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))";
            const string suffixMatch =
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,24}))$";
            const string matcher = initialMatch + suffixMatch;

            return Regex.IsMatch(target, matcher, RegexOptions.IgnoreCase, Regex.InfiniteMatchTimeout);
        }

        /// <summary>
        /// Constructs an email without recipients.
        /// </summary>
        public static MailMessage Compose(MailAddress sender, string subject, string body)
        {
            return new MailMessage
            {
                From = sender,
                Subject = subject,
                Body = body
            };
        }

        /// <summary>
        /// Constructs an email without recipients.
        /// </summary>
        public static MailMessage Compose(string sender, string subject, string body)
        {
            return Compose(new MailAddress(sender), subject, body);
        }

        /// <summary>
        /// Composes an email from provided values and attempts to send it to a specified server address.
        /// </summary>
        public static bool TrySend(SmtpClient client, MailMessage message, params MailAddress[] addresses)
        {
            try
            {
                addresses.ForEach(x => message.To.Add(x));
                client.Send(message);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}