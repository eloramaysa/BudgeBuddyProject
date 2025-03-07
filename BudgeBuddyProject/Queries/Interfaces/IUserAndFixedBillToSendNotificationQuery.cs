using BudgeBuddyProject.Domains;

namespace BudgeBuddyProject.Queries.Interfaces
{
    public interface IUserAndFixedBillToSendNotificationQuery
    {
        List<UserAndFixedBillToSendNotificationDomain> GetUsersAndFixedBillToSendNotificationDomains();
    }
}
