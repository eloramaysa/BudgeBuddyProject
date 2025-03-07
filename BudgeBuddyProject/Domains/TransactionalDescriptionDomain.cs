namespace BudgeBuddyProject.Domains
{
    public class TransactionalDescriptionDomain
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string TransactionalDescription { get; private set; } = string.Empty;

        public class Builder
        {
            private Guid _id;
            private Guid _userId;
            private string _transactionalDescription = string.Empty;

            public Builder SetId(Guid id)
            {
                _id = id;
                return this;
            }

            public Builder SetUserId(Guid userId)
            {
                _userId = userId;
                return this;
            }

            public Builder SetTransactionalDescription(string transactionalDescription)
            {
                _transactionalDescription = transactionalDescription;
                return this;
            }

            public TransactionalDescriptionDomain Build()
            {
                return new TransactionalDescriptionDomain
                {
                    Id = _id,
                    UserId = _userId,
                    TransactionalDescription = _transactionalDescription
                };
            }
        }
    }
}
