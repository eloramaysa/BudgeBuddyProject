using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using FluentValidation;

namespace BudgeBuddyProject.Services
{
    public class FixedBillService(IFixedBillRepository fixedBillRepository, IValidator<FixedBillDto> fixedBillValidator) : IFixedBillService
    {
        private readonly IFixedBillRepository _fixedBillRepository = fixedBillRepository;
        private readonly IValidator<FixedBillDto> _fixedBillValidator = fixedBillValidator;

        public void CreateFixedBill(FixedBillDto fixedBillDto)
        {
            var validator = _fixedBillValidator.Validate(fixedBillDto);

            if (validator.IsValid)
                _fixedBillRepository.AddFixedBill(CreateDomain(fixedBillDto));
            else
                throw new ArgumentException(validator.Errors.ToString());
        }

        public void UpdateFixedBill(FixedBillDto fixedBillDto)
        {
            var validator = _fixedBillValidator.Validate(fixedBillDto);

            if (validator.IsValid)
                _fixedBillRepository.UpdateFixedBill(CreateDomain(fixedBillDto));
            else
                throw new ArgumentException(validator.Errors.ToString());
        }

        public void DeleteFixedBill(Guid fixedBillId)
        {
            _fixedBillRepository.DeleteFixedBill(fixedBillId);
        }

        private static FixedBillDomain CreateDomain(FixedBillDto fixedBillDto)
        {
            return new FixedBillDomain.Builder()
                .SetId(Guid.NewGuid())
                .SetUserId(fixedBillDto.UserId)
                .SetDescription(fixedBillDto.Description)
                .SetExpireDate(fixedBillDto.ExpireDate)
                .SetExpireMonth(fixedBillDto.ExpireMonth)
                .SetValue(fixedBillDto.Value)
                .SetNotificationSent(fixedBillDto.NotificationSent)
                .Build();
        }
    }
}
