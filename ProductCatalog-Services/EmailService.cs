using MailKit.Net.Smtp;
using MimeKit;
using ProductCatalog_Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog_Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ProductCatalog", "mvc.productcatalog@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder()
            {
                TextBody = body
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var stmpClient = new SmtpClient();
            await stmpClient.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await stmpClient.AuthenticateAsync("mvc.productcatalog@gmail.com", "anmk iryu joad lccd");
            await stmpClient.SendAsync(message);
            await stmpClient.DisconnectAsync(true);
        }
    }
}
