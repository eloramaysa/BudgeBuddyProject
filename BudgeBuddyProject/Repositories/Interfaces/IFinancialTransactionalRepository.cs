using BudgeBuddyProject.Domains;

namespace BudgeBuddyProject.Repositories.Interfaces
{
    public interface IFinancialTransactionalRepository
    {
        void AddTransactional(FinancialTransactionsDomain transactionDomain);
        void UpdateTransactional(FinancialTransactionsDomain transactionDomain);
        void DeleteTransactional(Guid transactionDomainId);
    }
}
