namespace BudgeBuddyProject.Domains
{
    public class UserDomain
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string CreatedBy { get; private set; } = string.Empty;
        public DateTime UpdatedDate { get; private set; }
        public string UpdatedBy { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;
        public string Login { get; private set; } = string.Empty;
        public bool Active { get; private set; }

        public class Builder
        {
            private Guid _id;
            private DateTime _createdDate;
            private string _createdBy = string.Empty;
            private DateTime _updatedDate;
            private string _updatedBy = string.Empty;
            private string _name = string.Empty;
            private string _email = string.Empty;
            private string _senha = string.Empty;
            private string _login = string.Empty;
            private bool _active;

            public Builder SetId(Guid id)
            {
                _id = id;
                return this;
            }

            public Builder SetCreatedDate(DateTime createdDate)
            {
                _createdDate = createdDate;
                return this;
            }

            public Builder SetCreatedBy(string createdBy)
            {
                _createdBy = createdBy;
                return this;
            }

            public Builder SetUpdatedDate(DateTime updatedDate)
            {
                _updatedDate = updatedDate;
                return this;
            }

            public Builder SetUpdatedBy(string updatedBy)
            {
                _updatedBy = updatedBy;
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

            public Builder SetSenha(string senha)
            {
                _senha = senha;
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

            public UserDomain Build()
            {
                return new UserDomain
                {
                    Id = _id,
                    CreatedDate = _createdDate,
                    CreatedBy = _createdBy,
                    UpdatedDate = _updatedDate,
                    UpdatedBy = _updatedBy,
                    Name = _name,
                    Email = _email,
                    Senha = _senha,
                    Login = _login,
                    Active = _active
                };
            }
        }
    }
}
