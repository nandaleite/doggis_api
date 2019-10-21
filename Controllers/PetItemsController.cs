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
    public class PetItemsController : ControllerBase
    {
        private readonly PetContext _context;

        public PetItemsController(PetContext context)
        {
            _context = context;
        }

        // GET: api/PetItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetItem>>> GetPetItems()
        {
            return await _context.PetItems.ToListAsync();
        }

        // GET: api/PetItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetItem>> GetPetItem(int id)
        {
            var petItem = await _context.PetItems.FindAsync(id);

            if (petItem == null)
            {
                return NotFound();
            }

            return petItem;
        }

        // PUT: api/PetItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetItem(int id, PetItem petItem)
        {
            if (id != petItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(petItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetItemExists(id))
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

        // POST: api/PetItems
        [HttpPost]
        public async Task<ActionResult<PetItem>> PostPetItem(PetItem petItem)
        {
            _context.PetItems.Add(petItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetItem", new { id = petItem.Id }, petItem);
        }

        // DELETE: api/PetItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetItem>> DeletePetItem(int id)
        {
            var petItem = await _context.PetItems.FindAsync(id);
            if (petItem == null)
            {
                return NotFound();
            }

            _context.PetItems.Remove(petItem);
            await _context.SaveChangesAsync();

            return petItem;
        }

        private bool PetItemExists(int id)
        {
            return _context.PetItems.Any(e => e.Id == id);
        }
    }
}
