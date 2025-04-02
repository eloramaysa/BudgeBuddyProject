using BudgeBuddyProject.Dtos;

namespace BudgeBuddyProject.Queries.Interfaces
{
    public interface IUserQuery
    {
        UserDto GetUserById(Guid userId);
        PagedResult<UserDto> GetUsersPaged(int pageNumber, int pageSize);
    }
}
