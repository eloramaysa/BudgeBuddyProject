namespace BudgeBuddyProject.Domains
{
    public class UserDomain
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Login { get; private set; } = string.Empty;
        public bool Active { get; private set; }
        public bool AllowdSendEmail { get; private set; }

        public class Builder
        {
            private Guid _id;
            private string _name = string.Empty;
            private string _email = string.Empty;
            private string _password = string.Empty;
            private string _login = string.Empty;
            private bool _active;
            private bool _allowdSendEmail;

            public Builder SetId(Guid id)
            {
                _id = id;
                return this;
            }

            public Builder SetName(string name)
            {
                _name = name;
                return this;
            }

            public Builder SetEmail(string email)
            {
                _email = email;
                return this;
            }

            public Builder SetPassword(string password)
            {
                _password = password;
                return this;
            }

            public Builder SetLogin(string login)
            {
                _login = login;
                return this;
            }

            public Builder SetActive(bool active)
            {
                _active = active;
                return this;
            }

            public Builder SetAllowSendEmail(bool allowdSendEmail)
            {
                _allowdSendEmail = allowdSendEmail;
                return this;
            }

            public UserDomain Build()
            {
                return new UserDomain
                {
                    Id = _id,
                    Name = _name,
                    Email = _email,
                    Password = _password,
                    Login = _login,
                    Active = _active,
                    AllowdSendEmail = _allowdSendEmail,
                };
            }
        }
    }
}
