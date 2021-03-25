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
    public class DisputesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisputesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Disputes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dispute>>> GetDisputes()
        {
            return await _context.Disputes.ToListAsync();
        }

        // GET: api/Disputes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dispute>> GetDispute(Guid id)
        {
            var dispute = await _context.Disputes.FindAsync(id);

            if (dispute == null)
            {
                return NotFound();
            }

            return dispute;
        }

        // PUT: api/Disputes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispute(Guid id, Dispute dispute)
        {
            if (id != dispute.Id)
            {
                return BadRequest();
            }

            _context.Entry(dispute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisputeExists(id))
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

        // POST: api/Disputes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dispute>> PostDispute(Dispute dispute)
        {
            _context.Disputes.Add(dispute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDispute", new { id = dispute.Id }, dispute);
        }

        // DELETE: api/Disputes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispute(Guid id)
        {
            var dispute = await _context.Disputes.FindAsync(id);
            if (dispute == null)
            {
                return NotFound();
            }

            _context.Disputes.Remove(dispute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisputeExists(Guid id)
        {
            return _context.Disputes.Any(e => e.Id == id);
        }
    }
}
