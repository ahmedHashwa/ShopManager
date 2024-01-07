#region using directives

using System.Web.Mail;

#endregion

namespace ShopManager
{
    /// <summary>
    /// Provides a message object that sends the email through gmail. 
    /// GmailMessage is inherited from <c>System.Web.Mail.MailMessage</c>, so all the mail message features are available.
    /// </summary>
#pragma warning disable 618,612
    public class GmailMessage : MailMessage

    {
        #region CDO Configuration Constants

        private const string SendPassword = "http://schemas.microsoft.com/cdo/configuration/sendpassword";
        private const string SendUsername = "http://schemas.microsoft.com/cdo/configuration/sendusername";
        private const string SendUsing = "http://schemas.microsoft.com/cdo/configuration/sendusing";
        private const string SmtpAuthenticate = "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate";
        private const string SmtpServer = "http://schemas.microsoft.com/cdo/configuration/smtpserver";
        private const string SmtpServerPort = "http://schemas.microsoft.com/cdo/configuration/smtpserverport";
        private const string SmtpUseSsl = "http://schemas.microsoft.com/cdo/configuration/smtpusessl";

        #endregion

        #region Private Variables

        private static long _gmailPort = 465;
        private static string _gmailServer = "smtp.gmail.com";
        private string _gmailPassword = string.Empty;
        private string _gmailUserName = string.Empty;

        #endregion

        /// <summary>
        ///   Constructor, creates the GmailMessage object
        /// </summary>
        /// <param name = "gmailUserName">The username of the gmail account that the message will be sent through</param>
        /// <param name = "gmailPassword">The password of the gmail account that the message will be sent through</param>
        private GmailMessage(string gmailUserName, string gmailPassword)
        {
            Fields[SmtpServer] = GmailServer;
            Fields[SmtpServerPort] = GmailServerPort;
            Fields[SendUsing] = 2;
            Fields[SmtpUseSsl] = true;
            Fields[SmtpAuthenticate] = 1;
            Fields[SendUsername] = gmailUserName;
            Fields[SendPassword] = gmailPassword;

            _gmailUserName = gmailUserName;
            _gmailPassword = gmailPassword;
        }

        /// <summary>
        ///   The username of the gmail account that the message will be sent through
        /// </summary>
        public string GmailUserName
        {
            get { return _gmailUserName; }
            set { _gmailUserName = value; }
        }

        /// <summary>
        ///   The password of the gmail account that the message will be sent through
        /// </summary>
        public string GmailPassword
        {
            get { return _gmailPassword; }
            set { _gmailPassword = value; }
        }

        /// <summary>
        ///   The name of the gmail server, the default is "smtp.gmail.com"
        /// </summary>
        public static string GmailServer
        {
            get { return _gmailServer; }
            set { _gmailServer = value; }
        }

        /// <summary>
        ///   The port to use when sending the email, the default is 465
        /// </summary>
        public static long GmailServerPort
        {
            get { return _gmailPort; }
            set { _gmailPort = value; }
        }

        /// <summary>
        ///   Sends the message. If no from address is given the message will be from <c>GmailUserName</c>@Gmail.com
        /// </summary>
        public void Send()
        {
            if (From == string.Empty)
            {
                From = GmailUserName;
                if (GmailUserName.IndexOf('@') == -1) From += "@Gmail.com";
            }

            SmtpMail.Send(this);
        }

        /// <summary>
        ///   Send a <c>System.Web.Mail.MailMessage</c> through the specified gmail account
        /// </summary>
        /// <param name = "gmailUserName">The username of the gmail account that the message will be sent through</param>
        /// <param name = "gmailPassword">The password of the gmail account that the message will be sent through</param>
        /// <param name = "message"><c>System.Web.Mail.MailMessage</c> object to send</param>
        public static void SendMailMessageFromGmail(string gmailUserName, string gmailPassword, MailMessage message)
        {
            message.Fields[SmtpServer] = GmailServer;
            message.Fields[SmtpServerPort] = GmailServerPort;
            message.Fields[SendUsing] = 2;
            message.Fields[SmtpUseSsl] = true;
            message.Fields[SmtpAuthenticate] = 1;
            message.Fields[SendUsername] = gmailUserName;
            message.Fields[SendPassword] = gmailPassword;

            SmtpMail.Send(message);
        }

        /// <summary>
        ///   Sends an email through the specified gmail account
        /// </summary>
        /// <param name = "gmailUserName">The username of the gmail account that the message will be sent through</param>
        /// <param name = "gmailPassword">The password of the gmail account that the message will be sent through</param>
        /// <param name = "toAddress">Recipients email address</param>
        /// <param name = "subject">Message subject</param>
        /// <param name = "messageBody">Message body</param>
        public static void SendFromGmail(string gmailUserName, string gmailPassword, string toAddress, string subject,
                                         string messageBody)
        {
            var gMessage = new GmailMessage(gmailUserName, gmailPassword)
                               {
                                   To = toAddress,
                                   Subject = subject,
                                   Body = messageBody,
                                   From = gmailUserName
                               };

            if (gmailUserName.IndexOf('@') == -1) gMessage.From += "@Gmail.com";

            SmtpMail.Send(gMessage);
        }
    }
}

//RC.Gmail