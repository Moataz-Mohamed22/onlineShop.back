using System.ComponentModel.DataAnnotations;

namespace onlineShop.back.Data.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Range(0, int.MaxValue)]
        public int StockAvailable { get; set; }

        [Range(0, int.MaxValue)]
        public int ReorderStock { get; set; }

        
        public Product Product { get; set; } = null!;
    }
}