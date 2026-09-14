using Microsoft.EntityFrameworkCore;
using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceApi.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
