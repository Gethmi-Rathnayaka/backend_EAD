using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoServiceBackend.Data;
using backend_EAD.Models;

namespace backend_EAD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpGet("test")]
        public async Task<IActionResult> TestDatabase()
        {
            try
            {
                var count = await _context.Products.CountAsync();
                return Ok(new { message = "Database test successful!", products = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Database test failed", error = ex.Message });
            }
        }
    }
}
