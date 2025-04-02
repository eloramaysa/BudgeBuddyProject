using BudgeBuddyProject.Domains;

namespace BudgeBuddyProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(UserDomain user);
        void UpdateUser(UserDomain user);
        void DeleteUser(Guid userId);
        UserDomain LoginUser(string email, string password);
    }
}
