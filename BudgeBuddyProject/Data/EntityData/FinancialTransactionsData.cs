using Dapper.Contrib.Extensions;

namespace BudgeBuddyProject.Data.EntityData
{
    public class FinancialTransactionsData : AuthData
    {
        public Guid UserId { get; set; }
        public Guid TransactionalDescriptionId { get; set; }
        public Guid? FixedBillId { get; set; }

        public int TypeTransaction { get; set; }
        public decimal Value { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }

        [Write(false)]
        public UserData User { get; set; } = new UserData();

        [Write(false)]
        public TransactionalDescriptionData TransactionalDescription { get; set; } = new TransactionalDescriptionData();

        [Write(false)]
        public FixedBillData FixedBill { get; set; } = new FixedBillData();
    }
}
