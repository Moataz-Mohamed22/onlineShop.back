using onlineShop.back.Data.DTOs;
using onlineShop.back.Data.Models;

namespace onlineShop.back.Repositories.Interface
{
    public interface IInventoryRepository
    {
        Task<List<Inventory>> GetAllInventories();

        Task<Inventory?> GetInventoryByProductId(int productId);

        Task<Inventory?> UpdateInventory(
            int productId,
            UpdateInventoryDTO inventory);
    }
}