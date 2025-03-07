using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProject.Services.Interfaces;
using FluentValidation;

namespace BudgeBuddyProject.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserDto> _userValidator;

        public UserService(IUserRepository userRepository, IValidator<UserDto> userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public UserDto CreateUser(UserDto userDto)
        {
            //validar se tem o mesmo email
            var validator = _userValidator.Validate(userDto);

            if (validator.IsValid)
            {
                var userDomain = CreateDomain(userDto);
                _userRepository.AddUser(userDomain);
                userDto.Id = userDomain.Id;
                return userDto;
            }
               
            else
                throw new ArgumentNullException(validator.Errors.ToString());
        }

        public UserDto UpdateUser(UserDto userDto)
        {
            //validar se tem o mesmo email
            var validator = _userValidator.Validate(userDto);

            if (validator.IsValid)
            {
                _userRepository.UpdateUser(CreateDomain(userDto));
                return userDto;
            }
                
            else
                throw new ArgumentNullException(validator.Errors.ToString());
        }

        public void DeleteUser(Guid userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public UserDto LoginUser(string email, string password)
        {
            var user =  _userRepository.LoginUser(email, password);

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login
            };
        }

        private static UserDomain CreateDomain(UserDto userDto)
        {
            return new UserDomain.Builder()
                                       .SetId(Guid.NewGuid())
                                       .SetName(userDto.Name)
                                       .SetEmail(userDto.Email)
                                       .SetLogin(userDto.Login ?? userDto.Email)
                                       .SetPassword(userDto.Password)
                                       .SetActive(userDto.Active)
                                       .Build();
        }

    }
}
