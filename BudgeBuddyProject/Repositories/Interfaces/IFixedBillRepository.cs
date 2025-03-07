using BudgeBuddyProject.Domains;

namespace BudgeBuddyProject.Repositories.Interfaces
{
    public interface IFixedBillRepository
    {
        void AddFixedBill(FixedBillDomain fixedBill);
        void UpdateFixedBill(FixedBillDomain fixedBill);
        void DeleteFixedBill(Guid fixedBill);
        void NotificationSent(List<Guid> fixedBillIds);
    }
}
