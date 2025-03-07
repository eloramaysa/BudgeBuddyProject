using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Services.Interfaces
{
    public interface IBudgeTargetService
    {
        void CreateBudgeTarget(BudgeTargetDto budgeTargetDto);
        void UpdateBudgeTarget(BudgeTargetDto budgeTargetDto);
        void DeleteBudgeTarget(Guid budgeTargetId);
    }
}
