using BudgeBuddyProject.Dtos;
using FluentValidation;

namespace BudgeBuddyProject.Validators
{
    public class BudgeTargetDtoValidator : AbstractValidator<BudgeTargetDto>
    {
        public BudgeTargetDtoValidator()
        {
            RuleFor(bt => bt.UserId)
                .NotEmpty().WithMessage("UserId cannot be empty.");

            RuleFor(bt => bt.DescriptionTarget)
                .NotEmpty().WithMessage("DescriptionTarget cannot be empty.");

            RuleFor(bt => bt.EndValue)
                .GreaterThan(0).WithMessage("EndValue must be greater than zero.");

            RuleFor(bt => bt.TotalValue)
                .GreaterThan(0).WithMessage("TotalValue must be greater than zero.");
        }
    }
}
