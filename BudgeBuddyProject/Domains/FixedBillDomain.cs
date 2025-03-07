namespace BudgeBuddyProject.Domains
{
    public class FixedBillDomain
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public int ExpireDate { get; private set; }
        public int? ExpireMonth { get; private set; }
        public decimal Value { get; private set; }
        public bool NotificationSent { get; private set; }

        public class Builder
        {
            private Guid _id;
            private Guid _userId;
            private string _description = string.Empty;
            private int _expireDate;
            private int? _expireMonth;
            private decimal _value;
            private bool _notificationSent;

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

            public Builder SetDescription(string description)
            {
                _description = description;
                return this;
            }

            public Builder SetExpireDate(int expireDate)
            {
                _expireDate = expireDate;
                return this;
            }

            public Builder SetExpireMonth(int? expireMonth)
            {
                _expireMonth = expireMonth;
                return this;
            }

            public Builder SetValue(decimal value)
            {
                _value = value;
                return this;
            }

            public Builder SetNotificationSent(bool notificationSent)
            {
                _notificationSent = notificationSent;
                return this;
            }

            public FixedBillDomain Build()
            {
                return new FixedBillDomain
                {
                    Id = _id,
                    UserId = _userId,
                    Description = _description,
                    ExpireDate = _expireDate,
                    ExpireMonth = _expireMonth,
                    Value = _value,
                    NotificationSent = _notificationSent,
                };
            }
        }
    }
}
