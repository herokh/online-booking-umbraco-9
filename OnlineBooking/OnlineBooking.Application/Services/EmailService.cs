using Microsoft.Extensions.Options;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Models.Email;
using System.Net;
using System.Net.Mail;
using System.Text;
using Umbraco.Cms.Core.Configuration.Models;

namespace OnlineBooking.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly GlobalSettings _globalSettings;
        public EmailService(IOptions<GlobalSettings> globalSettings)
        {
            _globalSettings = globalSettings.Value;
        }

        public void SendEmail(EmailModel email)
        {
            var smtpSettings = _globalSettings.Smtp;
            using (var client = new SmtpClient(smtpSettings.Host, smtpSettings.Port))
            {
                client.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);
                client.EnableSsl = smtpSettings.SecureSocketOptions == SecureSocketOptions.SslOnConnect;

                var mailMessage = new MailMessage();
                mailMessage.Subject = email.Subject;
                mailMessage.Body = email.Body;
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.From = new MailAddress(smtpSettings.From);
                foreach (var to in email.To)
                {
                    mailMessage.To.Add(to);
                }

                client.Send(mailMessage);
            }
        }
    }
}
