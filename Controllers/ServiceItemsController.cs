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
    [Route("[controller]")]
    [ApiController]
    public class ServiceItemsController : ControllerBase
    {
        private readonly ServiceContext _context;

        public ServiceItemsController(ServiceContext context)
        {
            _context = context;
        }

        // GET: api/ServiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceItem>>> GetServiceItems()
        {
            return await _context.ServiceItems.ToListAsync();
        }

        // GET: api/ServiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceItem>> GetServiceItem(long id)
        {
            var serviceItem = await _context.ServiceItems.FindAsync(id);

            if (serviceItem == null)
            {
                return NotFound();
            }

            return serviceItem;
        }

        // PUT: api/ServiceItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceItem(long id, ServiceItem serviceItem)
        {
            if (id != serviceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceItemExists(id))
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

        // POST: api/ServiceItems
        [HttpPost]
        public async Task<ActionResult<ServiceItem>> PostServiceItem(ServiceItem serviceItem)
        {
            _context.ServiceItems.Add(serviceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiceItem), new { id = serviceItem.Id }, serviceItem);
        }

        // DELETE: api/ServiceItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceItem>> DeleteServiceItem(long id)
        {
            var serviceItem = await _context.ServiceItems.FindAsync(id);
            if (serviceItem == null)
            {
                return NotFound();
            }

            _context.ServiceItems.Remove(serviceItem);
            await _context.SaveChangesAsync();

            return serviceItem;
        }

        private bool ServiceItemExists(long id)
        {
            return _context.ServiceItems.Any(e => e.Id == id);
        }
    }
}
