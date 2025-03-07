using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProject.Utils.Enuns;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Queries
{
    public class FinancialTransactionQuery(ApplicationDbContext applicationDbContext) : IFinancialTransactionalQuery
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public FinancialTransactionsDto GetFinancialTransactionsById(Guid financialTransactionId)
        {
            var financialTransaction = _applicationDbContext.FinancialTransactionsDatas
                .Where(ft => ft.Id == financialTransactionId)
                .Select(ft => new FinancialTransactionsDto
                {
                    Id = ft.Id,
                    UserId = ft.UserId,
                    TransactionalDescriptionId = ft.TransactionalDescriptionId,
                    FixedBillId = ft.FixedBillId,
                    TypeTransaction = (TypeTransactionEnum)ft.TypeTransaction,
                    Value = ft.Value,
                    Day = ft.Day,
                    Month = ft.Month
                }).FirstOrDefault() ?? new FinancialTransactionsDto();

            return financialTransaction;
        }

        public PagedResult<FinancialTransactionsDto> GetFinancialTransactionsByFilter(FinancialTransactionsFilterDto filterDto, int pageNumber, int pageSize)
        {
            var query = _applicationDbContext.FinancialTransactionsDatas
                .Where(ft => ft.UserId == filterDto.UserId);

            if (filterDto.FixedBillId.HasValue)
                query = query.Where(ft => ft.FixedBillId == filterDto.FixedBillId);

            if (filterDto.TypeTransaction.HasValue)
                query = query.Where(ft => ft.TypeTransaction == (int)filterDto.TypeTransaction);

            if (filterDto.Month.HasValue)
                query = query.Where(ft => ft.Month == filterDto.Month);

            var totalItems = query.Count();

            var financialTransactions = query
                .OrderBy(ft => ft.Day)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(ft => new FinancialTransactionsDto
                {
                    Id = ft.Id,
                    UserId = ft.UserId,
                    TransactionalDescriptionId = ft.TransactionalDescriptionId,
                    FixedBillId = ft.FixedBillId,
                    TypeTransaction = (TypeTransactionEnum)ft.TypeTransaction,
                    Value = ft.Value,
                    Day = ft.Day,
                    Month = ft.Month
                })
                .ToList();

            return new PagedResult<FinancialTransactionsDto>
            {
                Items = financialTransactions,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
