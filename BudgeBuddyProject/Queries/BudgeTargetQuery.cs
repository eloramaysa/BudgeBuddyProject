using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Queries
{
    public class BudgeTargetQuery(ApplicationDbContext applicationDbContext) : IBudgeTargetQuery
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public BudgeTargetDto GetBudgeTargetById(Guid budgeTargetId)
        {
            var budgeTarget = _applicationDbContext.BudgeTargetDatas
                .Where(bt => bt.Id == budgeTargetId)
                .Select(bt => new BudgeTargetDto
                {
                    Id = bt.Id,
                    UserId = bt.UserId,
                    DescriptionTarget = bt.DescriptionTarget,
                    EndValue = bt.EndValue,
                    TotalValue = bt.TotalValue
                }).FirstOrDefault() ?? new BudgeTargetDto();

            return budgeTarget;
        }

        public PagedResult<BudgeTargetDto> GetBudgeTargetsByUserId(Guid userId, int pageNumber, int pageSize)
        {
            var totalItems = _applicationDbContext.BudgeTargetDatas
                .Count(bt => bt.UserId == userId);

            var budgeTargets = _applicationDbContext.BudgeTargetDatas
                .Where(bt => bt.UserId == userId)
                .OrderBy(bt => bt.DescriptionTarget)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(bt => new BudgeTargetDto
                {
                    Id = bt.Id,
                    UserId = bt.UserId,
                    DescriptionTarget = bt.DescriptionTarget,
                    EndValue = bt.EndValue,
                    TotalValue = bt.TotalValue
                })
                .ToList();

            return new PagedResult<BudgeTargetDto>
            {
                Items = budgeTargets,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
