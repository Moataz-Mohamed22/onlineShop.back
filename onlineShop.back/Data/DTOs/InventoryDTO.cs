using System.ComponentModel.DataAnnotations;

namespace onlineShop.back.Data.DTOs
{
    public class InventoryResponseDTO
    {
        public int ProductId { get; set; }

        public int StockAvailable { get; set; }

        public int ReorderStock { get; set; }
    }
    public class UpdateInventoryDTO
    {
        [Range(0, int.MaxValue)]
        public int StockAvailable { get; set; }

        [Range(0, int.MaxValue)]
        public int ReorderStock { get; set; }
    }
}
