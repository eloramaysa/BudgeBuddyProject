using BudgeBuddyProject.Services.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BudgeBuddyProject.Services
{

    public class EmailService2 : IEmailService
    {
        private const string apiKey = "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";  // Substitua pela sua API Key

        public async Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("buddy.budge08@gmail.com", "Buddy Budge");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            var teste = response.Body.ReadAsStringAsync();  
            Console.WriteLine($"Status Code: {response.StatusCode}");
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Buddy Budge", "buddy.budge08@gmail.com"));
            message.To.Add(new MailboxAddress("Elóra", toEmail));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.sendgrid.net", 465, MailKit.Security.SecureSocketOptions.StartTls);

                // Autenticação
                client.Authenticate("apikey", apiKey);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }

    public class EmailServiceSMTP
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Seu Nome", "seuemail@exemplo.com"));
            message.To.Add(new MailboxAddress("Destinatário", toEmail));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.sendgrid.net", 587, MailKit.Security.SecureSocketOptions.StartTls);

                // Autenticação
                client.Authenticate("apikey", "SUA_API_KEY_AQUI");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }

    public class EmailService
    {
        private readonly string _smtpServer;//smtp.gmail.com
        private readonly int _smtpPort;//587
        private readonly string _smtpUser;//buddy.budge08@gmail.com
        private readonly string _smtpPass;//Buddy523Budge
        //Se@gre@do980408!

        public EmailService()
        {
            _smtpServer = "smtp.gmail.com";
            _smtpPort = 587;
            _smtpUser = "buddy.budge08@gmail.com";
            _smtpPass = "Buddy523Budge";
        }

        public async Task SendEmailAsync(string userName, string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("YourAppName", _smtpUser));
            email.To.Add(new MailboxAddress(userName, toEmail));
            email.Subject = subject;

            email.Body = new TextPart("html")
            {
                Text = body
            };

            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_smtpUser, _smtpPass);
                await smtp.SendAsync(email);
            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }
        }
    }
}
