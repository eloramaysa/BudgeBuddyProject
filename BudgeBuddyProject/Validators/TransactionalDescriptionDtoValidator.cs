using BudgeBuddyProject.Dtos;
using FluentValidation;

namespace BudgeBuddyProject.Validators
{
    public class TransactionalDescriptionDtoValidator: AbstractValidator<TransactionalDescriptionDto>
    {
        public TransactionalDescriptionDtoValidator() 
        {
            RuleFor(td => td.TransactionalDescription)
                .NotEmpty().WithMessage("Transactional description cannot be empty");
        }
    }
}
