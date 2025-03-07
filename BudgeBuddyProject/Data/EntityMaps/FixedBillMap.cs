using BudgeBuddyProject.Data.EntityData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgeBuddyProject.Data.EntityMaps
{
    public class FixedBillMap : IEntityTypeConfiguration<FixedBillData>
    {
        public void Configure(EntityTypeBuilder<FixedBillData> builder)
        {
            builder.ToTable("FixedBill");

            builder.HasKey(fb => fb.Id);

            builder.Property(fb => fb.UserId)
                   .IsRequired()
                   .ValueGeneratedNever();

            builder.Property(fb => fb.Description)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(fb => fb.ExpireDate)
                   .IsRequired();

            builder.Property(fb => fb.ExpireMonth);

            builder.Property(fb => fb.Value)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(fb => fb.NotificationSent)
                   .IsRequired();

            builder.Property(fb => fb.CreatedDate)
                   .IsRequired();

            builder.Property(fb => fb.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(fb => fb.UpdatedDate)
                   .IsRequired();

            builder.Property(fb => fb.UpdatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            // Relacionamento
            builder.HasOne(fb => fb.User)
                   .WithMany()
                   .HasForeignKey(fb => fb.UserId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}
