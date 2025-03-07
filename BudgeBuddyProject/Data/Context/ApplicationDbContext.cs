using BudgeBuddyProject.Data.EntityData;
using BudgeBuddyProject.Data.EntityMaps;
using Microsoft.EntityFrameworkCore;

namespace BudgeBuddyProjects.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FinancialTransactionsData> FinancialTransactionsDatas { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<TransactionalDescriptionData> TransactionalDescriptionDatas { get; set; }
        public DbSet<FixedBillData> FixedBillDatas { get; set; }
        public DbSet<BudgeTargetData> BudgeTargetDatas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BudgeTargetMap());
            modelBuilder.ApplyConfiguration(new FinancialTransactionsMap());
            modelBuilder.ApplyConfiguration(new FixedBillMap());
            modelBuilder.ApplyConfiguration(new TransactionalDescriptionMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<FixedBillData>()
            .Property(c => c.UserId)
            .ValueGeneratedNever();
        }
    }
}
