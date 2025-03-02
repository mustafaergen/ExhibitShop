using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using ProductCatalog_Services.Contracts;
using System;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ProductCatalog", _configuration["EmailSettings:SenderEmail"]));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = body
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_configuration["EmailSettings:SmtpServer"],int.Parse(_configuration["EmailSettings:Port"]),MailKit.Security.SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(_configuration["EmailSettings:SenderEmail"],_configuration["EmailSettings:Password"]);
            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
