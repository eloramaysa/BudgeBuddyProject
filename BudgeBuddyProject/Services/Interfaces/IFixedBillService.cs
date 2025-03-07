using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Services.Interfaces
{
    public interface IFixedBillService
    {
        void CreateFixedBill(FixedBillDto fixedBillDto);
        void UpdateFixedBill(FixedBillDto fixedBillDto);
        void DeleteFixedBill(Guid fixedBillId);
    }
}
