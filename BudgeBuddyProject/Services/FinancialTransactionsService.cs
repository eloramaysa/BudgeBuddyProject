using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using FluentValidation;

namespace BudgeBuddyProject.Services
{
    public class FinancialTransactionsService(
        IFinancialTransactionalRepository financialTransactionsRepository,
        IValidator<FinancialTransactionsDto> financialTransactionsValidator) : IFinancialTransactionsService
    {
        private readonly IFinancialTransactionalRepository _financialTransactionsRepository = financialTransactionsRepository;
        private readonly IValidator<FinancialTransactionsDto> _financialTransactionsValidator = financialTransactionsValidator;

        public void CreateFinancialTransaction(FinancialTransactionsDto financialTransactionsDto)
        {
            var validator = _financialTransactionsValidator.Validate(financialTransactionsDto);

            if (validator.IsValid)
                _financialTransactionsRepository.AddTransactional(CreateDomain(financialTransactionsDto));
            else
                throw new ArgumentException(validator.Errors.ToString());
        }

        public void UpdateFinancialTransaction(FinancialTransactionsDto financialTransactionsDto)
        {
            var validator = _financialTransactionsValidator.Validate(financialTransactionsDto);

            if (validator.IsValid)
                _financialTransactionsRepository.UpdateTransactional(CreateDomain(financialTransactionsDto));
            else
                throw new ArgumentException(validator.Errors.ToString());
        }

        public void DeleteFinancialTransaction(Guid financialTransactionId)
        {
            _financialTransactionsRepository.DeleteTransactional(financialTransactionId);
        }

        private static FinancialTransactionsDomain CreateDomain(FinancialTransactionsDto financialTransactionsDto)
        {
            return new FinancialTransactionsDomain.Builder()
                .SetId(Guid.NewGuid())
                .SetUserId(financialTransactionsDto.UserId)
                .SetTransactionalDescriptionId(financialTransactionsDto.TransactionalDescriptionId)
                .SetFixedBillId(financialTransactionsDto.FixedBillId)
                .SetTypeTransaction(financialTransactionsDto.TypeTransaction)
                .SetValue(financialTransactionsDto.Value)
                .SetDay(financialTransactionsDto.Day)
                .SetMonth(financialTransactionsDto.Month)
                .Build();
        }
    }
}
