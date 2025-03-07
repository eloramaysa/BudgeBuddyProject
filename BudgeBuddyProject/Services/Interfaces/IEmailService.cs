namespace BudgeBuddyProject.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string plainTextContent, string htmlContent);
        void SendEmail(string toEmail, string subject, string body);
    }
}
