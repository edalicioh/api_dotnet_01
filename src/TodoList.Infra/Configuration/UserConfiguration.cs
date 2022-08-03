
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities;

namespace TodoList.Infra.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("email")
                .IsUnicode();

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("password");

        }
    }
}