using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Queries
{
    public class TransactionalDescriptionQuery(ApplicationDbContext applicationDbContext) : ITransactionalDescriptionQuery
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public TransactionalDescriptionDto GetTransactionalDescriptionById(Guid transactionalDescriptionId)
        {
            var transactionalDescription = _applicationDbContext.TransactionalDescriptionDatas
                .Where(t => t.Id == transactionalDescriptionId)
                .Select(t => new TransactionalDescriptionDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    TransactionalDescription = t.TransactionalDescription
                }).FirstOrDefault() ?? new TransactionalDescriptionDto();

            return transactionalDescription;
        }

        public PagedResult<TransactionalDescriptionDto> GetTransactionalDescriptionsByUserId(Guid userId, int pageNumber, int pageSize)
        {
            var totalItems = _applicationDbContext.TransactionalDescriptionDatas
                .Count(t => t.UserId == userId);

            var descriptions = _applicationDbContext.TransactionalDescriptionDatas
                .Where(t => t.UserId == userId)
                .OrderBy(t => t.TransactionalDescription)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new TransactionalDescriptionDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    TransactionalDescription = t.TransactionalDescription
                })
                .ToList();

            return new PagedResult<TransactionalDescriptionDto>
            {
                Items = descriptions,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
