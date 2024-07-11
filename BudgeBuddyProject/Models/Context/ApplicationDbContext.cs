using BudgeBuddyProject.Models.Data;
using BudgeBuddyProject.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace BudgeBuddyProject.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FinancialTransactionsData> FinancialTransactionsDatas { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<TransactionalDescriptionData> TransactionalDescriptionDatas { get; set; }
        public DbSet<FixedBillData> FixedBillDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BudgeTargetMap());
            modelBuilder.ApplyConfiguration(new FinancialTransactionsMap());
            modelBuilder.ApplyConfiguration(new FixedBillMap());
            modelBuilder.ApplyConfiguration(new TransactionalDescriptionMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringHere"); // Coloque sua string de conexão aqui
        }
    }
}
