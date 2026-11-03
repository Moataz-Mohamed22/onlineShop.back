using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using onlineShop.back.Data.Models;

namespace onlineShop.back.Data.Configurations
{
    public class InventoryConfiguration
        : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Product)
                .WithOne(p => p.Inventory)
                .HasForeignKey<Inventory>(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(i => i.ProductId)
                .IsUnique();

            builder.Property(i => i.StockAvailable)
                .IsRequired();

            builder.Property(i => i.ReorderStock)
                .IsRequired();

            builder.ToTable(table =>
            {
                table.HasCheckConstraint(
                    "CK_Inventory_StockAvailable",
                    "[StockAvailable] >= 0");

                table.HasCheckConstraint(
                    "CK_Inventory_ReorderStock",
                    "[ReorderStock] >= 0");
            });
        }
    }
}