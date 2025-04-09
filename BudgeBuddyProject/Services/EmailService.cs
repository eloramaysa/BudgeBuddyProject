using BudgeBuddyProject.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BudgeBuddyProject.Services
{

    public class EmailService : IEmailService
    {
        private const string apiKey = "key";

        public async Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("emailTeste@gmail.com", "Buddy Budge");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine($"Status Code: {response.StatusCode}");
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Buddy Budge", "emailTeste@gmail.com"));
            message.To.Add(new MailboxAddress("Buddy Budge", toEmail));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.sendgrid.net", 465, MailKit.Security.SecureSocketOptions.StartTls);

                client.Authenticate("apikey", apiKey);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
