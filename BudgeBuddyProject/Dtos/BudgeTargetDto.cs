namespace BudgeBuddyProject.Dtos
{
    public class BudgeTargetDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string DescriptionTarget { get; set; } = string.Empty;
        public decimal EndValue { get; set; }
        public decimal TotalValue { get; set; }
    }
}
