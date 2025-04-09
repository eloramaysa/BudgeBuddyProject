using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using FluentValidation;

namespace BudgeBuddyProject.Services
{
    public class BudgeTargetService(IBudgeTargetRepository budgeTargetRepository, IValidator<BudgeTargetDto> budgeTargetValidator) : IBudgeTargetService
    {
        private readonly IBudgeTargetRepository _budgeTargetRepository = budgeTargetRepository;
        private readonly IValidator<BudgeTargetDto> _budgeTargetValidator = budgeTargetValidator;

        public void CreateBudgeTarget(BudgeTargetDto budgeTargetDto)
        {
            var validator = _budgeTargetValidator.Validate(budgeTargetDto);

            if (validator.IsValid)
                _budgeTargetRepository.AddBugdeTarget(CreateDomain(budgeTargetDto));
            else
                throw new ArgumentException(validator.Errors.ToString());
        }

        public void UpdateBudgeTarget(BudgeTargetDto budgeTargetDto)
        {
            var validator = _budgeTargetValidator.Validate(budgeTargetDto);

            if (validator.IsValid)
                _budgeTargetRepository.UpdateBudgeTarget(CreateDomain(budgeTargetDto));
            else
                throw new ArgumentException(validator.Errors.ToString());
        }

        public void DeleteBudgeTarget(Guid budgeTargetId)
        {
            _budgeTargetRepository.DeleteBudgeTarget(budgeTargetId);
        }

        private static BudgeTargetDomain CreateDomain(BudgeTargetDto budgeTargetDto)
        {
            return new BudgeTargetDomain.Builder()
                                       .SetId(Guid.NewGuid())
                                       .SetUserId(budgeTargetDto.UserId)
                                       .SetDescriptionTarget(budgeTargetDto.DescriptionTarget)
                                       .SetEndValue(budgeTargetDto.EndValue)
                                       .SetTotalValue(budgeTargetDto.TotalValue)
                                       .Build();
        }
    }
}
