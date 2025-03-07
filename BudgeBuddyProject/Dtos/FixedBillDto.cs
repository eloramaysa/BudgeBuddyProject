namespace BudgeBuddyProject.Dtos
{
    public class FixedBillDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ExpireDate { get; set; }
        public int? ExpireMonth { get; set; }
        public decimal Value { get; set; }
        public bool NotificationSent { get; set; }
    }
}
