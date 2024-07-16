using Dapper.Contrib.Extensions;

namespace BudgeBuddyProject.Data.EntityData
{
    public class BudgeTargetData : AuthData
    {
        public Guid UserId { get; set; }
        public string DescriptionTarget { get; set; } = string.Empty;

        public decimal EndValue { get; set; }
        public decimal TotalValue { get; set; }

        [Write(false)]
        public UserData User { get; set; } = new UserData();
    }
}
