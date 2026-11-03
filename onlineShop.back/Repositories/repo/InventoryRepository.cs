using Microsoft.EntityFrameworkCore;
using onlineShop.back.Data;
using onlineShop.back.Data.DTOs;
using onlineShop.back.Data.Models;
using onlineShop.back.Repositories.Interface;

namespace onlineShop.back.Repositories.repo
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Inventory>> GetAllInventories()
        {
            var inventories = _context.Inventories.ToListAsync();
            return inventories;
        }

        public Task<Inventory?> GetInventoryByProductId(int productId)
        {
            var inventory = _context.Inventories.FirstOrDefault(i => i.ProductId == productId);
            return Task.FromResult(inventory);
        }

        public Task<Inventory?> UpdateInventory(int productId, UpdateInventoryDTO inventory)
        {
            var existingInventory = _context.Inventories.FirstOrDefault(i => i.ProductId == productId);
            if (existingInventory == null)
            {
                return Task.FromResult<Inventory?>(null);
            }

            existingInventory.StockAvailable = inventory.StockAvailable;
            existingInventory.ReorderStock = inventory.ReorderStock;

            _context.Inventories.Update(existingInventory);
            _context.SaveChangesAsync();

            return Task.FromResult<Inventory?>(existingInventory);
        }
    }
}
