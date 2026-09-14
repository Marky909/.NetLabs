using EcommerceApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceApi.Configurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.Property(s => s.StoreName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(s => s.User)
            .WithOne()
            .HasForeignKey<Seller>(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}