using BudgeBuddyProject.Data.EntityData;

namespace BudgeBuddyProject.Repositories
{
    public abstract class RepositoryBase
    {
        protected static void AddAuditData(AuthData authData)
        {
            authData.CreatedBy = "System";
            authData.CreatedDate = DateTime.UtcNow;
        }

        protected static void UpdateAuditData(AuthData authData)
        {
            authData.UpdatedBy = "System";
            authData.UpdatedDate = DateTime.UtcNow;
        }
    }
}
