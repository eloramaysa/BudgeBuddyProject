using BudgeBuddyProject.Data.EntityData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgeBuddyProject.Data.EntityMaps
{
    public class BudgeTargetMap : IEntityTypeConfiguration<BudgeTargetData>
    {
        public void Configure(EntityTypeBuilder<BudgeTargetData> builder)
        {
            builder.ToTable("BudgeTarget");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.UserId)
                   .IsRequired();

            builder.Property(b => b.DescriptionTarget)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(b => b.EndValue)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(b => b.TotalValue)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(b => b.CreatedDate)
                   .IsRequired();

            builder.Property(b => b.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(b => b.UpdatedDate)
                   .IsRequired();

            builder.Property(b => b.UpdatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            // Relacionamento
            builder.HasOne(b => b.User)
                   .WithMany()
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
