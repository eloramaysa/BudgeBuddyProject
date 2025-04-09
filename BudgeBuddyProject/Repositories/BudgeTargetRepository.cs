using BudgeBuddyProject.Data.EntityData;
using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Repositories
{
    public class BudgeTargetRepository(ApplicationDbContext applicationDbContext) : RepositoryBase, IBudgeTargetRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public void AddBugdeTarget(BudgeTargetDomain fixedBill)
        {
            var data = MapDataToDomain(fixedBill);

            AddAuditData(data);

            _applicationDbContext.Add(data);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateBudgeTarget(BudgeTargetDomain fixedBill)
        {
            var data = MapDataToDomain(fixedBill);

            UpdateAuditData(data);

            _applicationDbContext.Update(data);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteBudgeTarget(Guid fixedBillId)
        {
            _applicationDbContext.Remove(fixedBillId);
            _applicationDbContext.SaveChanges();
        }

        private BudgeTargetData MapDataToDomain(BudgeTargetDomain fixedBill)
        {
            return new BudgeTargetData
            {
                Id = fixedBill.Id,
                DescriptionTarget = fixedBill.DescriptionTarget,
                EndValue = fixedBill.EndValue,
                TotalValue = fixedBill.TotalValue,
                UserId = fixedBill.UserId
            };
        }
    }
}
