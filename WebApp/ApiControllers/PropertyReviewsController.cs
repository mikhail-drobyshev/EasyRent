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
    public class PropertyReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropertyReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PropertyReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyReview>>> GetPropertyReviews()
        {
            return await _context.PropertyReviews.ToListAsync();
        }

        // GET: api/PropertyReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyReview>> GetPropertyReview(Guid id)
        {
            var propertyReview = await _context.PropertyReviews.FindAsync(id);

            if (propertyReview == null)
            {
                return NotFound();
            }

            return propertyReview;
        }

        // PUT: api/PropertyReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyReview(Guid id, PropertyReview propertyReview)
        {
            if (id != propertyReview.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertyReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyReviewExists(id))
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

        // POST: api/PropertyReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyReview>> PostPropertyReview(PropertyReview propertyReview)
        {
            _context.PropertyReviews.Add(propertyReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyReview", new { id = propertyReview.Id }, propertyReview);
        }

        // DELETE: api/PropertyReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyReview(Guid id)
        {
            var propertyReview = await _context.PropertyReviews.FindAsync(id);
            if (propertyReview == null)
            {
                return NotFound();
            }

            _context.PropertyReviews.Remove(propertyReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyReviewExists(Guid id)
        {
            return _context.PropertyReviews.Any(e => e.Id == id);
        }
    }
}
