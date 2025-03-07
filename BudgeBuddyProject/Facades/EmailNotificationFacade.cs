using BudgeBuddyProject.Services.Interfaces;

namespace BudgeBuddyProject.Facades
{
    public class EmailNotificationFacade(ISendNotificationByEmailService sendNotificationByEmail)
    {
        private readonly ISendNotificationByEmailService _sendNotificationByEmail = sendNotificationByEmail;

        public void SendFixedBillNotificationByEmail()
        {
            _sendNotificationByEmail.SendNotificationByEmail().GetAwaiter().GetResult();
        }
    }
}
