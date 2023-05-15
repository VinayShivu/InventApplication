using InventApplication.Domain.Interfaces.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using InventApplication.Domain.Exceptions;
using Microsoft.Extensions.Configuration;

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
        public async Task<bool> SendEmail(string email, string subject, string body)
        {
            try
            {
                //var _fromEmail = _configuration["DNS:email"];
                //var _fromEmailPassword = _configuration["DNS:password"];
                //var smtpClient = new SmtpClient(_smtpServer, _smtpPort);
                //smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = new NetworkCredential(_fromEmail, _fromEmailPassword);
                //smtpClient.EnableSsl = true;

                //var message = new MailMessage();
                //message.From = new MailAddress(_fromEmail);
                //message.To.Add(new MailAddress(email));
                //message.Subject = subject;
                //message.Body = body;

                //await smtpClient.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"Error in Email Sending : {ex}");
            }
        }
    }
}
