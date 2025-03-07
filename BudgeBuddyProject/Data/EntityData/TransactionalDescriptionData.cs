using Dapper.Contrib.Extensions;

namespace BudgeBuddyProject.Data.EntityData
{
    public class TransactionalDescriptionData : AuthData
    {
        public Guid UserId { get; set; }
        public string TransactionalDescription { get; set; } = string.Empty;

        [Write(false)]
        public UserData User { get; set; }
    }
}
