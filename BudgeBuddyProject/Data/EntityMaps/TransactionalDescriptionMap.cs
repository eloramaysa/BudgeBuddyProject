using BudgeBuddyProject.Data.EntityData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgeBuddyProject.Data.EntityMaps
{
    public class TransactionalDescriptionMap : IEntityTypeConfiguration<TransactionalDescriptionData>
    {
        public void Configure(EntityTypeBuilder<TransactionalDescriptionData> builder)
        {
            builder.ToTable("TransactionalDescription");

            builder.HasKey(td => td.Id);

            builder.Property(td => td.TransactionalDescription)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(ft => ft.UserId)
                   .IsRequired();

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

            builder.HasOne(ft => ft.User)
                   .WithMany()
                   .HasForeignKey(ft => ft.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
