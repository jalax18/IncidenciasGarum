using RevisionFicherosGarumForm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RevisionFicherosGarumForm.Models
{
    public class EmailSender : IEmailSender
    {
        private SmtpClient _smtpClient { get; set; }
        private string _emailFrom { get; set; }

        public EmailSender(SmtpClient smtpClient, string emailFrom)
        {
            _smtpClient = smtpClient;
            _emailFrom = emailFrom;
        }

        public Task SendEmailAsync(string emailTo, string subject, string message)
        {
            var correo = new MailMessage(from: _emailFrom, to: emailTo, subject: subject, body: message);
            correo.IsBodyHtml = true;
            return _smtpClient.SendMailAsync(correo);
        }
    }
}
