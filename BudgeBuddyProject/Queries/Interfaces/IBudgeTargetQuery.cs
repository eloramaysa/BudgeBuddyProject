using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Queries.Interfaces
{
    public interface IBudgeTargetQuery
    {
        BudgeTargetDto GetBudgeTargetById(Guid budgeTargetId);
        PagedResult<BudgeTargetDto> GetBudgeTargetsByUserId(Guid userId, int pageNumber, int pageSize);
    }
}
