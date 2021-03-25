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
    public class ErUserReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ErUserReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ErUserReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErUserReview>>> GetErUserReviews()
        {
            return await _context.ErUserReviews.ToListAsync();
        }

        // GET: api/ErUserReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErUserReview>> GetErUserReview(Guid id)
        {
            var erUserReview = await _context.ErUserReviews.FindAsync(id);

            if (erUserReview == null)
            {
                return NotFound();
            }

            return erUserReview;
        }

        // PUT: api/ErUserReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErUserReview(Guid id, ErUserReview erUserReview)
        {
            if (id != erUserReview.Id)
            {
                return BadRequest();
            }

            _context.Entry(erUserReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErUserReviewExists(id))
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

        // POST: api/ErUserReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ErUserReview>> PostErUserReview(ErUserReview erUserReview)
        {
            _context.ErUserReviews.Add(erUserReview);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErUserReview", new { id = erUserReview.Id }, erUserReview);
        }

        // DELETE: api/ErUserReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErUserReview(Guid id)
        {
            var erUserReview = await _context.ErUserReviews.FindAsync(id);
            if (erUserReview == null)
            {
                return NotFound();
            }

            _context.ErUserReviews.Remove(erUserReview);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErUserReviewExists(Guid id)
        {
            return _context.ErUserReviews.Any(e => e.Id == id);
        }
    }
}
