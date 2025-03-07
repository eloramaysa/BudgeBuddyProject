using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Queries
{
    public class UserAndFixedBillToSendNotificationQuery(ApplicationDbContext applicationDbContext) : IUserAndFixedBillToSendNotificationQuery
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public List<UserAndFixedBillToSendNotificationDomain> GetUsersAndFixedBillToSendNotificationDomains()
        {
            var today = DateTime.Today.Day;
            var month = DateTime.Today.Month;
            var twoDaysFromNow = today + 2;

            return [.. _applicationDbContext.FixedBillDatas
                .Where(fixedBill => fixedBill.ExpireDate >= today && fixedBill.ExpireDate <= twoDaysFromNow)
                .Where(fixedBill => fixedBill.ExpireMonth.HasValue && fixedBill.ExpireMonth.Equals(month))
                .GroupBy(fixedBill => fixedBill.User)
                .Where(group => group.Key.AllowdSendEmail)
                .Select(group => new UserAndFixedBillToSendNotificationDomain
                {
                    Email = group.Key.Email,
                    Name = group.Key.Name,
                    FixedBillsAlmostExpired = group.Select(fb => new FixedBillAlmostExpired
                    {
                        BillDescription = fb.Description,
                        ExpireDate = fb.ExpireDate,
                        ExpireMonth = fb.ExpireMonth,
                        FixedBillId = fb.Id
                    }).ToList()
                })];
        }
    }
}
