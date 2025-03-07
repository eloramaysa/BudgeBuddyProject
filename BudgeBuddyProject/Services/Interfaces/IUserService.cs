using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Services.Interfaces
{
    public interface IUserService
    {
        UserDto CreateUser(UserDto userDto);
        UserDto UpdateUser(UserDto userDto);
        UserDto LoginUser(string email, string password);
        void DeleteUser(Guid userId);
    }
}
