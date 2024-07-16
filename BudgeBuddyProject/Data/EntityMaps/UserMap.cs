using BudgeBuddyProject.Data.EntityData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgeBuddyProject.Data.EntityMaps
{
    public class UserMap : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            // Tabela
            builder.ToTable("User");

            // Chave primária
            builder.HasKey(ud => ud.Id);

            // Propriedades
            builder.Property(ud => ud.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ud => ud.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ud => ud.Senha)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ud => ud.Login)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(ud => ud.Active)
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
