using BudgeBuddyProject.Data.EntityData;
using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Repositories
{
    public class FixedBillRepository(ApplicationDbContext applicationDbContext) : RepositoryBase, IFixedBillRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public void AddFixedBill(FixedBillDomain fixedBill)
        {
            var data = MapDataToDomain(fixedBill);

            AddAuditData(data);

            _applicationDbContext.Add(data);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateFixedBill(FixedBillDomain fixedBill)
        {
            var data = MapDataToDomain(fixedBill);

            UpdateAuditData(data);

            _applicationDbContext.Update(data);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteFixedBill(Guid fixedId)
        {
            _applicationDbContext.Remove(fixedId);
            _applicationDbContext.SaveChanges();
        }

        public void NotificationSent(List<Guid> fixedBillIds)
        {
            var fixedBills = _applicationDbContext.FixedBillDatas.Where(x => fixedBillIds.Contains(x.Id)).ToList();
            fixedBills.ForEach(fixedBill =>
            {
                fixedBill.NotificationSent = true;
                UpdateAuditData(fixedBill);
            });

            _applicationDbContext.UpdateRange(fixedBills);
            _applicationDbContext.SaveChanges();
        }

        private FixedBillData MapDataToDomain(FixedBillDomain fixedBill) =>
        new()
        {
            Id = fixedBill.Id,
            Description = fixedBill.Description,
            ExpireDate = fixedBill.ExpireDate,
            ExpireMonth = fixedBill.ExpireMonth,
            NotificationSent = fixedBill.NotificationSent,
            UserId = fixedBill.UserId,
            Value = fixedBill.Value,
            User = null
        };
    }
}
