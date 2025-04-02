using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Services.Interfaces
{
    public interface IFinancialTransactionsService
    {
        void CreateFinancialTransaction(FinancialTransactionsDto financialTransactionsDto);
        void UpdateFinancialTransaction(FinancialTransactionsDto financialTransactionsDto);
        void DeleteFinancialTransaction(Guid financialTransactionId);
    }
}
