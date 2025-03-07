namespace BudgeBuddyProject.Domains
{
    public class UserAndFixedBillToSendNotificationDomain
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<FixedBillAlmostExpired> FixedBillsAlmostExpired { get; set; } = new List<FixedBillAlmostExpired>();
    }

    public class FixedBillAlmostExpired
    {
        public string BillDescription { get; set; } = string.Empty;
        public int ExpireDate { get; set; }
        public int? ExpireMonth { get; set; }
        public Guid FixedBillId { get; set; }
    }
}
