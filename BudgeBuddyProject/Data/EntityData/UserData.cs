namespace BudgeBuddyProject.Data.EntityData
{
    public class UserData : AuthData
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public bool Active { get; set; }

        public bool AllowdSendEmail { get; set; }
    }
}
