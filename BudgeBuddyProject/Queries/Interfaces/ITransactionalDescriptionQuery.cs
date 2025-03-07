using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Queries.Interfaces
{
    public interface ITransactionalDescriptionQuery
    {
        TransactionalDescriptionDto GetTransactionalDescriptionById(Guid transactionalTransactionId);
        PagedResult<TransactionalDescriptionDto> GetTransactionalDescriptionsByUserId(Guid userId,int pageNumber, int pageSize);
    }
}
