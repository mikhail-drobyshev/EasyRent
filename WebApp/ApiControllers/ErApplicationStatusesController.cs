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
    public class ErApplicationStatusesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ErApplicationStatusesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ErApplicationStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErApplicationStatus>>> GetErApplicationStatuses()
        {
            return await _context.ErApplicationStatuses.ToListAsync();
        }

        // GET: api/ErApplicationStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErApplicationStatus>> GetErApplicationStatus(Guid id)
        {
            var erApplicationStatus = await _context.ErApplicationStatuses.FindAsync(id);

            if (erApplicationStatus == null)
            {
                return NotFound();
            }

            return erApplicationStatus;
        }

        // PUT: api/ErApplicationStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErApplicationStatus(Guid id, ErApplicationStatus erApplicationStatus)
        {
            if (id != erApplicationStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(erApplicationStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErApplicationStatusExists(id))
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

        // POST: api/ErApplicationStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ErApplicationStatus>> PostErApplicationStatus(ErApplicationStatus erApplicationStatus)
        {
            _context.ErApplicationStatuses.Add(erApplicationStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErApplicationStatus", new { id = erApplicationStatus.Id }, erApplicationStatus);
        }

        // DELETE: api/ErApplicationStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErApplicationStatus(Guid id)
        {
            var erApplicationStatus = await _context.ErApplicationStatuses.FindAsync(id);
            if (erApplicationStatus == null)
            {
                return NotFound();
            }

            _context.ErApplicationStatuses.Remove(erApplicationStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErApplicationStatusExists(Guid id)
        {
            return _context.ErApplicationStatuses.Any(e => e.Id == id);
        }
    }
}
