using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductItemsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/ProductItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProductItem()
        {
            return await _context.ProductItem.ToListAsync();
        }

        // GET: api/ProductItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> GetProductItem(int id)
        {
            var productItem = await _context.ProductItem.FindAsync(id);

            if (productItem == null)
            {
                return NotFound();
            }

            return productItem;
        }

        // PUT: api/ProductItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductItem(int id, ProductItem productItem)
        {
            if (id != productItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(productItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductItems
        [HttpPost]
        public async Task<ActionResult<ProductItem>> PostProductItem(ProductItem productItem)
        {
            _context.ProductItem.Add(productItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductItem", new { id = productItem.Id }, productItem);
        }

        // DELETE: api/ProductItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductItem>> DeleteProductItem(int id)
        {
            var productItem = await _context.ProductItem.FindAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }

            _context.ProductItem.Remove(productItem);
            await _context.SaveChangesAsync();

            return productItem;
        }

        private bool ProductItemExists(int id)
        {
            return _context.ProductItem.Any(e => e.Id == id);
        }
    }
}
