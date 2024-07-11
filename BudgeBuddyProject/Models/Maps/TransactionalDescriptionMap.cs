using BudgeBuddyProject.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgeBuddyProject.Models.Maps
{
    public class TransactionalDescriptionMap : IEntityTypeConfiguration<TransactionalDescriptionData>
    {
        public void Configure(EntityTypeBuilder<TransactionalDescriptionData> builder)
        {
            // Tabela
            builder.ToTable("TransactionalDescription");

            // Chave primária
            builder.HasKey(td => td.Id);

            // Propriedades
            builder.Property(td => td.TransactionalDescription)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(td => td.CreatedDate)
                   .IsRequired();

            builder.Property(td => td.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(td => td.UpdatedDate)
                   .IsRequired();

            builder.Property(td => td.UpdatedBy)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
