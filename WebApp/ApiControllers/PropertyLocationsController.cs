using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyLocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropertyLocationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PropertyLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyLocation>>> GetPropertyLocations()
        {
            return await _context.PropertyLocations.ToListAsync();
        }

        // GET: api/PropertyLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyLocation>> GetPropertyLocation(Guid id)
        {
            var propertyLocation = await _context.PropertyLocations.FindAsync(id);

            if (propertyLocation == null)
            {
                return NotFound();
            }

            return propertyLocation;
        }

        // PUT: api/PropertyLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyLocation(Guid id, PropertyLocation propertyLocation)
        {
            if (id != propertyLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertyLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyLocationExists(id))
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

        // POST: api/PropertyLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyLocation>> PostPropertyLocation(PropertyLocation propertyLocation)
        {
            _context.PropertyLocations.Add(propertyLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyLocation", new { id = propertyLocation.Id }, propertyLocation);
        }

        // DELETE: api/PropertyLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyLocation(Guid id)
        {
            var propertyLocation = await _context.PropertyLocations.FindAsync(id);
            if (propertyLocation == null)
            {
                return NotFound();
            }

            _context.PropertyLocations.Remove(propertyLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyLocationExists(Guid id)
        {
            return _context.PropertyLocations.Any(e => e.Id == id);
        }
    }
}
