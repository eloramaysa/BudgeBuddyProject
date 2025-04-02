using BudgeBuddyProject.Domains;

namespace BudgeBuddyProject.Repositories.Interfaces
{
    public interface IBudgeTargetRepository
    {
        void AddBugdeTarget(BudgeTargetDomain fixedBill);
        void UpdateBudgeTarget(BudgeTargetDomain fixedBill);
        void DeleteBudgeTarget(Guid fixedBillId);
    }
}
