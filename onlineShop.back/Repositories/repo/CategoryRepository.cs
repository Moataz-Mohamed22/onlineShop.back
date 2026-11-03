using Microsoft.EntityFrameworkCore;
using onlineShop.back.Data;
using onlineShop.back.Data.DTOs;
using onlineShop.back.Data.Models;
using onlineShop.back.Repositories.Interface;

namespace onlineShop.back.Repositories.repo
{
    public class CategoryRepository : ICategoryRepository
    {
      private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories
         .AsNoTracking()
         .ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }
        

        public async Task<Category?> UpdateCategory(int id, CategoryDTO category)
        {
            var existingCategory =await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            await _context.SaveChangesAsync();
            return existingCategory;
        }
        public async Task<Category> CreateCategory(CategoryDTO dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public Task<bool> DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id); 
            if(category == null)
            {
                return Task.FromResult(false);
            }
            _context.Categories.Remove(category);
            _context.SaveChangesAsync();
            return Task.FromResult(true);
        }
    }
}
