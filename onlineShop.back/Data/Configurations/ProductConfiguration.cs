using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShop.back.Data.Models;

namespace onlineShop.back.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.SKU)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(p => p.SKU)
                .IsUnique();

            builder.Property(p => p.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.DiscountPrice)
                .HasPrecision(18, 2);

            builder.Property(p => p.Brand)
                .HasMaxLength(100);

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(table =>
            {
                table.HasCheckConstraint(
                    "CK_Product_Price",
                    "[Price] > 0");

                table.HasCheckConstraint(
                    "CK_Product_DiscountPrice",
                    "[DiscountPrice] IS NULL OR " +
                    "([DiscountPrice] > 0 AND [DiscountPrice] < [Price])");
            });
        }
    }
}