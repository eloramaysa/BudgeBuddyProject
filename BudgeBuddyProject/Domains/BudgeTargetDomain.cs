namespace BudgeBuddyProject.Domains
{
    public class BudgeTargetDomain
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string CreatedBy { get; private set; } = string.Empty;
        public DateTime UpdatedDate { get; private set; }
        public string UpdatedBy { get; private set; } = string.Empty;
        public Guid UserId { get; private set; }
        public string DescriptionTarget { get; private set; } = string.Empty;
        public decimal EndValue { get; private set; }
        public decimal TotalValue { get; private set; }

        public class Builder
        {
            private Guid _id;
            private DateTime _createdDate;
            private string _createdBy = string.Empty;
            private DateTime _updatedDate;
            private string _updatedBy = string.Empty;
            private Guid _userId;
            private string _descriptionTarget = string.Empty;
            private decimal _endValue;
            private decimal _totalValue;

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
                    CreatedDate = _createdDate,
                    CreatedBy = _createdBy,
                    UpdatedDate = _updatedDate,
                    UpdatedBy = _updatedBy,
                    UserId = _userId,
                    DescriptionTarget = _descriptionTarget,
                    EndValue = _endValue,
                    TotalValue = _totalValue,
                };
            }
        }
    }
}
