using BudgeBuddyProject.Data.EntityData;
using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Repositories
{
    public class TransactionalDescriptionRepository(ApplicationDbContext applicationDbContext) : RepositoryBase, ITransactionalDescriptionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public void AddTransactionalDescription(TransactionalDescriptionDomain transactionalDescriptionDomain)
        {
            var data = MapDomainToData(transactionalDescriptionDomain);
            AddAuditData(data);

            _applicationDbContext.TransactionalDescriptionDatas.Add(data);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateTransactionalDescription(TransactionalDescriptionDomain transactionalDescriptionDomain)
        {
            var data = MapDomainToData(transactionalDescriptionDomain);
            UpdateAuditData(data);

            _applicationDbContext.Update(data);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteTransactionalDescription(Guid transactionalDescriptionId)
        {
            _applicationDbContext.Remove(transactionalDescriptionId);
            _applicationDbContext.SaveChanges();
        }

        private TransactionalDescriptionData MapDomainToData(TransactionalDescriptionDomain transactionalDescriptionDomain)
        {
            return new TransactionalDescriptionData
            {
                Id = transactionalDescriptionDomain.Id,
                UserId = transactionalDescriptionDomain.UserId,
                TransactionalDescription = transactionalDescriptionDomain.TransactionalDescription,
            };
        }
    }
}
