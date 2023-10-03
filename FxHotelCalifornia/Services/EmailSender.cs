using System;
using FxHotelCalifornia.Interfaces;
using Microsoft.Extensions.Options;
using FxHotelCalifornia.Models;
using System.Net;
using System.Net.Mail;

namespace FxHotelCalifornia.Services
{
	public class EmailSender : IEmailSender
	{
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using (SmtpClient client = new SmtpClient())
            {
                var credentials = new NetworkCredential
                {
                    UserName = _emailSettings.SmtpUsername,
                    Password = _emailSettings.SmtpPassword
                };

                client.Credentials = credentials;
                client.Host = _emailSettings.SmtpServer;
                client.Port = _emailSettings.SmtpPort;
                client.EnableSsl = true;

                var mail = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName)
                };

                mail.To.Add(new MailAddress(email));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                await client.SendMailAsync(mail);
            }
        }
    }
}

