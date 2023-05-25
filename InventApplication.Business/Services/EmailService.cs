using InventApplication.Domain.Exceptions;
using InventApplication.Domain.Interfaces.BusinessInterfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace InventApplication.Business.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private async Task<bool> SendEmail(string email, string subject, string body)
        {
            try
            {
                var _fromEmail = _configuration["DNS:email"];
                var _fromEmailPassword = _configuration["DNS:password"];
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("", _fromEmail));
                message.To.Add(new MailboxAddress("", email));
                message.Subject = subject;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = body
                };

                message.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true; // Ignore certificate validation
                    await client.ConnectAsync(_smtpServer, _smtpPort, false);
                    await client.AuthenticateAsync(_fromEmail, _fromEmailPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error in Email Sending : {ex.Message}");
            }
        }

        public async Task<bool> SendPasswordResetEmail(string email, string token)
        {
            var domainname = _configuration["DNS:applicationUrl"];
            var resetLink = $"{domainname}/resetpassword?token={token}";
            var emailBody = $"Click the link below to reset your password:<br><br><a href=\"{resetLink}\">{resetLink}</a>";
            var subject = $"Password Reset";

            var emailSent = await SendEmail(email, subject, emailBody);

            return emailSent;
        }
    }
}
