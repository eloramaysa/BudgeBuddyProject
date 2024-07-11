using BudgeBuddyProject.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgeBuddyProject.Models.Maps
{
    public class FinancialTransactionsMap : IEntityTypeConfiguration<FinancialTransactionsData>
    {
        public void Configure(EntityTypeBuilder<FinancialTransactionsData> builder)
        {
            // Tabela
            builder.ToTable("FinancialTransactions");

            // Chave primária
            builder.HasKey(ft => ft.Id);

            // Propriedades
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
