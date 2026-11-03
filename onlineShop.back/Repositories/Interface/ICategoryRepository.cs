using onlineShop.back.Data.DTOs;
using onlineShop.back.Data.Models;

namespace onlineShop.back.Repositories.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAllCategories();
        public Task<Category?> GetCategoryById(int id);
        public Task<Category> CreateCategory(CategoryDTO dTO);
        public Task<Category?> UpdateCategory(int id, CategoryDTO category);
        public Task<bool> DeleteCategory(int id);
    }
}
