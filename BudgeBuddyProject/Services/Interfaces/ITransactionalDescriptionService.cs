using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Services.Interfaces
{
    public interface ITransactionalDescriptionService
    {
        void CreateTransactionalDescription(TransactionalDescriptionDto transactionalDescriptionDto);
        void UpdateTransactionalDescription(TransactionalDescriptionDto transactionalDescriptionDto);
        void DeleteTransactionalDescription(Guid transactionalDescriptionId);
    }
}
