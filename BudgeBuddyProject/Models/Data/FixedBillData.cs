using Dapper.Contrib.Extensions;

namespace BudgeBuddyProject.Models.Data
{
    public class FixedBillData : AuthData
    {
        public Guid UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ExpireDate { get; set; }
        public int ExpireMonth { get; set; }
        public decimal Value { get; set; }
        public bool NotificationSent { get; set; }

        [Write(false)]
        public UserData User { get; set; } = new UserData();
    }
}
