using BudgeBuddyProject.Domains;

namespace BudgeBuddyProject.Repositories.Interfaces
{
    public interface ITransactionalDescriptionRepository
    {
        void AddTransactionalDescription(TransactionalDescriptionDomain transactionalDescriptionDomain);
        void UpdateTransactionalDescription(TransactionalDescriptionDomain transactionalDescriptionDomain);
        void DeleteTransactionalDescription(Guid transactionalDescriptionId);
    }
}
