using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Queries
{
    public class FixedBillQuery : IFixedBillQuery
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FixedBillQuery(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public FixedBillDto GetFixedBillById(Guid fixedBillId)
        {
            var fixedBill = _applicationDbContext.FixedBillDatas
                .Where(b => b.Id == fixedBillId)
                .Select(b => new FixedBillDto
                {
                    Id = b.Id,
                    UserId = b.UserId,
                    Description = b.Description,
                    ExpireDate = b.ExpireDate,
                    ExpireMonth = b.ExpireMonth,
                    Value = b.Value,
                    NotificationSent = b.NotificationSent
                }).FirstOrDefault() ?? new FixedBillDto();

            return fixedBill;
        }

        public List<FixedBillDto> GetFixedBillByUserId(Guid userId)
        {
            var totalItems = _applicationDbContext.FixedBillDatas
                .Count(b => b.UserId == userId);

            var fixedBills = _applicationDbContext.FixedBillDatas
                .Where(b => b.UserId == userId)
                .OrderBy(b => b.Description)
                .Select(b => new FixedBillDto
                {
                    Id = b.Id,
                    UserId = b.UserId,
                    Description = b.Description,
                    ExpireDate = b.ExpireDate,
                    ExpireMonth = b.ExpireMonth,
                    Value = b.Value,
                    NotificationSent = b.NotificationSent
                })
                .ToList();

            return fixedBills;
        }
    }
}
