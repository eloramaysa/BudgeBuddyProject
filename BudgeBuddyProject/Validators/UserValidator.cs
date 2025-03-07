using BudgeBuddyProject.Dtos;
using FluentValidation;

namespace BudgeBuddyProject.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name cannot be empty.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Email is not in a valid format.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
        }
    }
}
