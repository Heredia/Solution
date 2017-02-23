using System.Net;
using System.Net.Mail;

namespace Helper.Messaging
{
    public class EmailHelper
    {
        private readonly MailMessage _mailMessage;
        private readonly SmtpClient _smtpClient;

        public EmailHelper(string host, int port, string user, string password,
            string subject, string body, MailPriority priority, string from, string to)
        {
            var credentials = new NetworkCredential(user, password);
            _smtpClient = new SmtpClient { Host = host, Port = port, UseDefaultCredentials = false, Credentials = credentials };
            _mailMessage = new MailMessage { IsBodyHtml = true, Priority = priority, Subject = subject, Body = body, From = new MailAddress(from), To = { new MailAddress(to) } };
        }

        public void AddAttachment(string path)
        {
            using (var attachment = new Attachment(path))
            {
                _mailMessage.Attachments.Add(attachment);
            }
        }

        public void AddCopy(string emailTo)
        {
            _mailMessage.CC.Add(emailTo);
        }

        public void AddHiddenCopy(string emailTo)
        {
            _mailMessage.Bcc.Add(emailTo);
        }

        public void AddTo(string emailTo)
        {
            _mailMessage.To.Add(emailTo);
        }

        public void Send()
        {
            _smtpClient.Send(_mailMessage);
        }
    }
}