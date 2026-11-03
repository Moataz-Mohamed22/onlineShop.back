using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineShop.back.Repositories.Interface;

namespace onlineShop.back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly IInventoryRepository _context;

        public InventoriesController(IInventoryRepository context)
        {
            _context = context;
        }

        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAllInventories()
        {
            var inventories = await _context.GetAllInventories();
            return Ok(inventories);
        }
    }
}
