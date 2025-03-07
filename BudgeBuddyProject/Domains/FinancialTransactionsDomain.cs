using BudgeBuddyProject.Utils.Enuns;

namespace BudgeBuddyProject.Domains
{
    public class FinancialTransactionsDomain
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid TransactionalDescriptionId { get; private set; }
        public Guid? FixedBillId { get; private set; }
        public TypeTransactionEnum TypeTransaction { get; private set; }
        public decimal Value { get; private set; }
        public int Day { get; private set; }
        public int Month { get; private set; }

        public class Builder
        {
            private Guid _id;
            private Guid _userId;
            private Guid _transactionalDescriptionId;
            private Guid? _fixedBillId;
            private TypeTransactionEnum _typeTransaction;
            private decimal _value;
            private int _day;
            private int _month;

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

            public Builder SetTypeTransaction(TypeTransactionEnum typeTransaction)
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
