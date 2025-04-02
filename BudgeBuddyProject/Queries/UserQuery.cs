using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProjects.Data.Context;

namespace BudgeBuddyProject.Queries
{
    public class UserQuery(ApplicationDbContext applicationDbContext) : IUserQuery
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

        public UserDto GetUserById(Guid userId)
        {
            var user = _applicationDbContext.UserDatas
                .Where(u => u.Id == userId)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Login = u.Login,
                    Password = u.Password,
                    Active = u.Active,
                    AllowdSendEmail = u.AllowdSendEmail,
                }).FirstOrDefault() ?? new UserDto();

            return user;
        }

        public PagedResult<UserDto> GetUsersPaged(int pageNumber, int pageSize)
        {
            var totalItems = _applicationDbContext.UserDatas.Count();
            var users = _applicationDbContext.UserDatas
                .OrderBy(u => u.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Login = u.Login,
                    Password = u.Password,
                    Active = u.Active,
                    AllowdSendEmail = u.AllowdSendEmail
                })
                .ToList();

            return new PagedResult<UserDto>
            {
                Items = users,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
