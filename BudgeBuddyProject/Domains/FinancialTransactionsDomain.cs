namespace BudgeBuddyProject.Domains
{
    public class FinancialTransactionsDomain
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string CreatedBy { get; private set; } = string.Empty;
        public DateTime UpdatedDate { get; private set; }
        public string UpdatedBy { get; private set; } = string.Empty;
        public Guid UserId { get; private set; }
        public Guid TransactionalDescriptionId { get; private set; }
        public Guid? FixedBillId { get; private set; }
        public int TypeTransaction { get; private set; }
        public decimal Value { get; private set; }
        public int Day { get; private set; }
        public int Month { get; private set; }

        public class Builder
        {
            private Guid _id;
            private DateTime _createdDate;
            private string _createdBy = string.Empty;
            private DateTime _updatedDate;
            private string _updatedBy = string.Empty;
            private Guid _userId;
            private Guid _transactionalDescriptionId;
            private Guid? _fixedBillId;
            private int _typeTransaction;
            private decimal _value;
            private int _day;
            private int _month;

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

            public Builder SetTransactionalDescriptionId(Guid transactionalDescriptionId)
            {
                _transactionalDescriptionId = transactionalDescriptionId;
                return this;
            }

            public Builder SetFixedBillId(Guid? fixedBillId)
            {
                _fixedBillId = fixedBillId;
                return this;
            }

            public Builder SetTypeTransaction(int typeTransaction)
            {
                _typeTransaction = typeTransaction;
                return this;
            }

            public Builder SetValue(decimal value)
            {
                _value = value;
                return this;
            }

            public Builder SetDay(int day)
            {
                _day = day;
                return this;
            }

            public Builder SetMonth(int month)
            {
                _month = month;
                return this;
            }

            public FinancialTransactionsDomain Build()
            {
                return new FinancialTransactionsDomain
                {
                    Id = _id,
                    CreatedDate = _createdDate,
                    CreatedBy = _createdBy,
                    UpdatedDate = _updatedDate,
                    UpdatedBy = _updatedBy,
                    UserId = _userId,
                    TransactionalDescriptionId = _transactionalDescriptionId,
                    FixedBillId = _fixedBillId,
                    TypeTransaction = _typeTransaction,
                    Value = _value,
                    Day = _day,
                    Month = _month,
                };
            }
        }
    }
}
