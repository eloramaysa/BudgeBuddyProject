namespace BudgeBuddyProject.Dtos
{
    public class TransactionalDescriptionDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string TransactionalDescription { get; set; } = string.Empty;
    }
}
