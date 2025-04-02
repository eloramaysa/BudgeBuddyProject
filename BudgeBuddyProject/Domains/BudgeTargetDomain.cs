namespace BudgeBuddyProject.Domains
{
    public class BudgeTargetDomain
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string DescriptionTarget { get; private set; } = string.Empty;
        public decimal EndValue { get; private set; }
        public decimal TotalValue { get; private set; }

        public class Builder
        {
            private Guid _id;
            private Guid _userId;
            private string _descriptionTarget = string.Empty;
            private decimal _endValue;
            private decimal _totalValue;

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

            public Builder SetDescriptionTarget(string descriptionTarget)
            {
                _descriptionTarget = descriptionTarget;
                return this;
            }

            public Builder SetEndValue(decimal endValue)
            {
                _endValue = endValue;
                return this;
            }

            public Builder SetTotalValue(decimal totalValue)
            {
                _totalValue = totalValue;
                return this;
            }

            public BudgeTargetDomain Build()
            {
                return new BudgeTargetDomain
                {
                    Id = _id,
                    UserId = _userId,
                    DescriptionTarget = _descriptionTarget,
                    EndValue = _endValue,
                    TotalValue = _totalValue,
                };
            }
        }
    }
}
