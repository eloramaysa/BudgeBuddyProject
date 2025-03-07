using BudgeBuddyProject.Utils.Enuns;

namespace BudgeBuddyProject.Dtos
{
    public class FinancialTransactionsDto
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public Guid TransactionalDescriptionId { get; set; }
            public Guid? FixedBillId { get; set; }
            public TypeTransactionEnum TypeTransaction { get; set; }
            public decimal Value { get; set; }
            public int Day { get; set; }
            public int Month { get; set; }
        }
}
