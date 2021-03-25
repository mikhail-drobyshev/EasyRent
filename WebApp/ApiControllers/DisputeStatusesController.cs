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
    public class DisputeStatusesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisputeStatusesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DisputeStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisputeStatus>>> GetDisputeStatuses()
        {
            return await _context.DisputeStatuses.ToListAsync();
        }

        // GET: api/DisputeStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisputeStatus>> GetDisputeStatus(Guid id)
        {
            var disputeStatus = await _context.DisputeStatuses.FindAsync(id);

            if (disputeStatus == null)
            {
                return NotFound();
            }

            return disputeStatus;
        }

        // PUT: api/DisputeStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisputeStatus(Guid id, DisputeStatus disputeStatus)
        {
            if (id != disputeStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(disputeStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisputeStatusExists(id))
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

        // POST: api/DisputeStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisputeStatus>> PostDisputeStatus(DisputeStatus disputeStatus)
        {
            _context.DisputeStatuses.Add(disputeStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisputeStatus", new { id = disputeStatus.Id }, disputeStatus);
        }

        // DELETE: api/DisputeStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisputeStatus(Guid id)
        {
            var disputeStatus = await _context.DisputeStatuses.FindAsync(id);
            if (disputeStatus == null)
            {
                return NotFound();
            }

            _context.DisputeStatuses.Remove(disputeStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisputeStatusExists(Guid id)
        {
            return _context.DisputeStatuses.Any(e => e.Id == id);
        }
    }
}
