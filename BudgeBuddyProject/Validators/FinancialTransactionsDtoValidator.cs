using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Utils.Enuns;
using FluentValidation;

namespace BudgeBuddyProject.Validators
{
    public class FinancialTransactionsDtoValidator : AbstractValidator<FinancialTransactionsDto>
    {
        public FinancialTransactionsDtoValidator()
        {
            RuleFor(ft => ft.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.");

            RuleFor(ft => ft.TransactionalDescriptionId)
                .NotEmpty().WithMessage("TransactionalDescriptionId cannot be empty.");

            RuleFor(ft => ft.TypeTransaction)
                .IsInEnum().WithMessage("TypeTransaction must be 1 (income) or 2 (expense).");

            RuleFor(ft => ft.Value)
                .GreaterThan(0).WithMessage("Value must be greater than zero.");

            RuleFor(ft => ft.Day)
                .InclusiveBetween(1, 31).WithMessage("Day must be between 1 and 31.");

            RuleFor(ft => ft.Month)
                .InclusiveBetween(1, 12).WithMessage("Month must be between 1 and 12.");
        }
    }
}
