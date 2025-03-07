using BudgeBuddyProject.Data.EntityData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgeBuddyProject.Data.EntityMaps
{
    public class FinancialTransactionsMap : IEntityTypeConfiguration<FinancialTransactionsData>
    {
        public void Configure(EntityTypeBuilder<FinancialTransactionsData> builder)
        {
            builder.ToTable("FinancialTransactions");

            builder.HasKey(ft => ft.Id);

            builder.Property(ft => ft.UserId)
                   .IsRequired();

            builder.Property(ft => ft.TransactionalDescriptionId)
                   .IsRequired();

            builder.Property(ft => ft.FixedBillId)
                   .IsRequired(false);

            builder.Property(ft => ft.TypeTransaction)
                   .IsRequired();

            builder.Property(ft => ft.Value)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(ft => ft.Day)
                   .IsRequired();

            builder.Property(ft => ft.Month)
                   .IsRequired();

            builder.Property(ft => ft.CreatedDate)
                   .IsRequired();

            builder.Property(ft => ft.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(ft => ft.UpdatedDate)
                   .IsRequired();

            builder.Property(ft => ft.UpdatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            // Relacionamentos
            builder.HasOne(ft => ft.User)
                   .WithMany()
                   .HasForeignKey(ft => ft.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ft => ft.TransactionalDescription)
                   .WithMany()
                   .HasForeignKey(ft => ft.TransactionalDescriptionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ft => ft.FixedBill)
                   .WithMany()
                   .HasForeignKey(ft => ft.FixedBillId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
