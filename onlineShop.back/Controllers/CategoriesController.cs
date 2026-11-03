using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineShop.back.Data.DTOs;
using onlineShop.back.Repositories.Interface;

namespace onlineShop.back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _repository.GetAllCategories();
            return Ok(categories);
        }
        [HttpGet("Get-By-Id/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _repository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO dto)
        {
            var category = await _repository.CreateCategory(dto);

            if (category == null)
                return Conflict(new
                {
                    message = "Category already exists."
                });
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO dto)
        {
            var category = await _repository.UpdateCategory(id, dto);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _repository.DeleteCategory(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
