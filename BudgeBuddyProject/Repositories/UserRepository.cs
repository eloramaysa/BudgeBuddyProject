using BudgeBuddyProject.Data.EntityData;
using BudgeBuddyProject.Domains;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProjects.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace BudgeBuddyProject.Repositories
{
    public class UserRepository(ApplicationDbContext applicationDbContext) : RepositoryBase, IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
        private readonly PasswordHasher<UserData> _passwordHasher = new PasswordHasher<UserData>();

        public void AddUser(UserDomain user)
        {
            var userData = MapDomainToData(user);
            AddAuditData(userData);

            _applicationDbContext.Add(userData);
            _applicationDbContext.SaveChanges();
        }

        public void UpdateUser(UserDomain user)
        {
            var userData = MapDomainToData(user);
            UpdateAuditData(userData);

            _applicationDbContext.Update(userData);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteUser(Guid userId)
        {
            _applicationDbContext.Remove(userId);
            _applicationDbContext.SaveChanges();
        }

        public UserDomain LoginUser(string email, string password)
        {
            var userData = _applicationDbContext.UserDatas.Where(x => x.Email == email).FirstOrDefault();

            if (userData == null) 
                return new UserDomain();
            else
            {
                var passwordVerify = _passwordHasher.VerifyHashedPassword(userData, userData.Password, password);

                if (passwordVerify == PasswordVerificationResult.Success)
                    return MapDataToDomain(userData);
                else
                    return new UserDomain();
            }
        }

        private UserDomain MapDataToDomain(UserData user)
        {
            var userDomain = new UserDomain.Builder()
                                       .SetId(user.Id)
                                       .SetName(user.Name)
                                       .SetEmail(user.Email)
                                       .SetLogin(user.Login)
                                       .SetActive(user.Active)
                                       .Build();

            return userDomain;
        }

        private UserData MapDomainToData(UserDomain user)
        {
            var userData = new UserData
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Active = user.Active,
                AllowdSendEmail = user.AllowdSendEmail,
            };

            userData.Password = _passwordHasher.HashPassword(userData, user.Password);

            return userData;
        }
    }
}
