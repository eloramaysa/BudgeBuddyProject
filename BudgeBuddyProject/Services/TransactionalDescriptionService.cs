using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using FluentValidation;

namespace BudgeBuddyProject.Services
{
    public class TransactionalDescriptionService(
        ITransactionalDescriptionRepository transactionalDescriptionRepository,
        IValidator<TransactionalDescriptionDto> transactionalDescriptionValidator) : ITransactionalDescriptionService
    {
        private readonly ITransactionalDescriptionRepository _transactionalDescriptionRepository = transactionalDescriptionRepository;
        private readonly IValidator<TransactionalDescriptionDto> _transactionalDescriptionValidator = transactionalDescriptionValidator;

        public void CreateTransactionalDescription(TransactionalDescriptionDto transactionalDescriptionDto)
        {
            var validator = _transactionalDescriptionValidator.Validate(transactionalDescriptionDto);

            if (validator.IsValid)
                _transactionalDescriptionRepository.AddTransactionalDescription(CreateDomain(transactionalDescriptionDto));
            else
                throw new ArgumentException(validator.Errors.ToString());
        }

        public void UpdateTransactionalDescription(TransactionalDescriptionDto transactionalDescriptionDto)
        {
            var validator = _transactionalDescriptionValidator.Validate(transactionalDescriptionDto);

            if (validator.IsValid)
                _transactionalDescriptionRepository.UpdateTransactionalDescription(CreateDomain(transactionalDescriptionDto));
            else
                throw new ArgumentException(validator.Errors.ToString());
        }

        public void DeleteTransactionalDescription(Guid transactionalDescriptionId)
        {
            _transactionalDescriptionRepository.DeleteTransactionalDescription(transactionalDescriptionId);
        }

        private static TransactionalDescriptionDomain CreateDomain(TransactionalDescriptionDto transactionalDescriptionDto)
        {
            return new TransactionalDescriptionDomain.Builder()
                .SetId(Guid.NewGuid())
                .SetUserId(transactionalDescriptionDto.UserId)
                .SetTransactionalDescription(transactionalDescriptionDto.TransactionalDescription)
                .Build();
        }
    }
}
