using BudgeBuddyProject.Dtos;
using FluentValidation;

namespace BudgeBuddyProject.Validators
{
    public class FixedBillDtoValidator : AbstractValidator<FixedBillDto>
    {
        public FixedBillDtoValidator()
        {
            RuleFor(fb => fb.Description)
                .NotEmpty().WithMessage("Description cannot be empty.");

            RuleFor(fb => fb.ExpireDate)
                .GreaterThan(0)
                .InclusiveBetween(1, 31)
                .WithMessage("Expire date must be a positive integer.");

            RuleFor(fb => fb.ExpireMonth)
                .InclusiveBetween(1, 12).WithMessage("Expire month must be between 1 and 12.");

            RuleFor(fb => fb.Value)
                .GreaterThan(0).WithMessage("Value must be greater than zero.");

            RuleFor(fb => fb.NotificationSent)
                .NotNull().WithMessage("NotificationSent cannot be null.");
        }
    }
}
