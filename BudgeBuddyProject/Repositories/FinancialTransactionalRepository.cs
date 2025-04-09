using BudgeBuddyProject.Data.EntityData;
using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Repositories
{
    public class FinancialTransactionalRepository(ApplicationDbContext applicationDbContext) : RepositoryBase, IFinancialTransactionalRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public void AddTransactional(FinancialTransactionsDomain transactionDomain)
        {
            var data = MapDomainToData(transactionDomain);
            AddAuditData(data);

            _applicationDbContext.Add(data);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateTransactional(FinancialTransactionsDomain transactionDomain)
        {
            var data = MapDomainToData(transactionDomain);
            UpdateAuditData(data);

            _applicationDbContext.Update(data);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteTransactional(Guid transactionDomainId)
        {
            _applicationDbContext.Remove(transactionDomainId);
            _applicationDbContext.SaveChanges();
        }

        private FinancialTransactionsData MapDomainToData(FinancialTransactionsDomain transactionDomain)
        {
            return new FinancialTransactionsData
            {
                Id = transactionDomain.Id,
                Day = transactionDomain.Day,
                Month = transactionDomain.Month,
                FixedBillId = transactionDomain.FixedBillId,
                TransactionalDescriptionId = transactionDomain.TransactionalDescriptionId,
                TypeTransaction = (int)transactionDomain.TypeTransaction,
                UserId = transactionDomain.UserId,
                Value = transactionDomain.Value,
                User = null,
                TransactionalDescription = null, 
                FixedBill = null
            };
        }
    }
}
