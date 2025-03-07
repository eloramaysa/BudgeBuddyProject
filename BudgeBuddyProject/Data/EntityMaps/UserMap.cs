using BudgeBuddyProject.Data.EntityData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgeBuddyProject.Data.EntityMaps
{
    public class UserMap : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.ToTable("User");

            builder.HasKey(ud => ud.Id);

            builder.Property(ud => ud.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ud => ud.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ud => ud.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ud => ud.Login)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ud => ud.Active)
                   .IsRequired();

            builder.Property(ud => ud.AllowdSendEmail)
                  .IsRequired();

            builder.Property(ud => ud.CreatedDate)
                   .IsRequired();

            builder.Property(ud => ud.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(ud => ud.UpdatedDate)
                   .IsRequired();

            builder.Property(ud => ud.UpdatedBy)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
