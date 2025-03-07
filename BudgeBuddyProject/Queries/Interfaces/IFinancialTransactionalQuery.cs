﻿using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Queries.Interfaces
{
    public interface IFinancialTransactionalQuery
    {
        FinancialTransactionsDto GetFinancialTransactionsById(Guid financialTransactionId);
        PagedResult<FinancialTransactionsDto> GetFinancialTransactionsByFilter(FinancialTransactionsFilterDto filterDto, int pageNumber, int pageSize);
    }
}
