using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using System.Text;

namespace BudgeBuddyProject.Services
{
    public class SendNotificationByEmailService(IUserAndFixedBillToSendNotificationQuery userAndFixedBillToSendNotificationQuery,
                                                IFixedBillRepository fixedBillRepository,
                                                IEmailService emailService) : ISendNotificationByEmailService
    {
        private readonly IUserAndFixedBillToSendNotificationQuery _userAndFixedBillToSendNotificationQuery = userAndFixedBillToSendNotificationQuery;
        private readonly IFixedBillRepository _fixedBillRepository = fixedBillRepository;
        private readonly IEmailService _emailService = emailService;

        public async Task SendNotificationByEmail()
        {
            var usersWithFixedBill = _userAndFixedBillToSendNotificationQuery.GetUsersAndFixedBillToSendNotificationDomains();
            foreach (var user in usersWithFixedBill)
            {
                var message = "Uma mensagem teste";
                await _emailService.SendEmailAsync(user.Email, "Alerta de Pagamento de contas fixas", message, GenerateNotificationMessage(user));
            }

            UpdateFixedBillToNotificationSent(usersWithFixedBill);
        }

        private string GenerateNotificationMessage(UserAndFixedBillToSendNotificationDomain user)
        {
            var message = new StringBuilder();

            message.AppendLine($"Olá {user.Name},");
            message.AppendLine("Suas contas fixas estão prestes a expirar. Aqui estão as contas que precisam ser pagas:");

            foreach (var bill in user.FixedBillsAlmostExpired)
            {
                message.AppendLine($"- Descrição: {bill.BillDescription}");
                message.AppendLine($"  Data de Expiração: {bill.ExpireDate}");

                if (bill.ExpireMonth.HasValue)
                    message.AppendLine($"  Mês de Expiração: {bill.ExpireMonth.Value}");

                message.AppendLine();
            }

            message.AppendLine("Por favor, certifique-se de realizar o pagamento o mais breve possível.");

            return message.ToString();
        }


        private void UpdateFixedBillToNotificationSent(List<UserAndFixedBillToSendNotificationDomain> usersWithFixedBill)
        {
            var fixedBillsIds = usersWithFixedBill.SelectMany(x => x.FixedBillsAlmostExpired.Select(x => x.FixedBillId)).ToList();
            _fixedBillRepository.NotificationSent(fixedBillsIds);
        }
    }
}
