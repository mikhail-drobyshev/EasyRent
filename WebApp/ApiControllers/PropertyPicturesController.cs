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
    public class PropertyPicturesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropertyPicturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PropertyPictures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyPicture>>> GetPropertyPictures()
        {
            return await _context.PropertyPictures.ToListAsync();
        }

        // GET: api/PropertyPictures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyPicture>> GetPropertyPicture(Guid id)
        {
            var propertyPicture = await _context.PropertyPictures.FindAsync(id);

            if (propertyPicture == null)
            {
                return NotFound();
            }

            return propertyPicture;
        }

        // PUT: api/PropertyPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyPicture(Guid id, PropertyPicture propertyPicture)
        {
            if (id != propertyPicture.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertyPicture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyPictureExists(id))
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

        // POST: api/PropertyPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyPicture>> PostPropertyPicture(PropertyPicture propertyPicture)
        {
            _context.PropertyPictures.Add(propertyPicture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyPicture", new { id = propertyPicture.Id }, propertyPicture);
        }

        // DELETE: api/PropertyPictures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyPicture(Guid id)
        {
            var propertyPicture = await _context.PropertyPictures.FindAsync(id);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            _context.PropertyPictures.Remove(propertyPicture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyPictureExists(Guid id)
        {
            return _context.PropertyPictures.Any(e => e.Id == id);
        }
    }
}
