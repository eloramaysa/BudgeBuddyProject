using BudgeBuddyProject.Utils.Enuns;

namespace BudgeBuddyProject.Dtos
{
    public class FinancialTransactionsFilterDto
        {
            public Guid UserId { get; set; }
            public Guid? FixedBillId { get; set; }
            public TypeTransactionEnum? TypeTransaction { get; set; }
            public int? Month { get; set; }
        }
}
