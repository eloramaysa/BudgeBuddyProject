using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Queries.Interfaces
{
    public interface IFixedBillQuery
    {
        FixedBillDto GetFixedBillById(Guid fixedBillId);
        List<FixedBillDto> GetFixedBillByUserId(Guid userId);
    }
}
