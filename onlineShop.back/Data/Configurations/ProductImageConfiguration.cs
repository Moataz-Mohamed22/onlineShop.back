using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShop.back.Data.Models;

namespace onlineShop.back.Data.Configurations
{
    public class ProductImageConfiguration
        : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.ImageUrl)
                .IsRequired()
                .HasMaxLength(500);

           

            builder.HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}