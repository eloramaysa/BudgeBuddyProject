namespace BudgeBuddyProject.Dtos
{
    public class UserDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public bool Active { get; set; }
        public bool AllowdSendEmail { get; set; }
    }

    public class LoginUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
