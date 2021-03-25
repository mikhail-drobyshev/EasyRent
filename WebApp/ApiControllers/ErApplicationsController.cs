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
    public class ErApplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ErApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ErApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErApplication>>> GetErApplications()
        {
            return await _context.ErApplications.ToListAsync();
        }

        // GET: api/ErApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErApplication>> GetErApplication(Guid id)
        {
            var erApplication = await _context.ErApplications.FindAsync(id);

            if (erApplication == null)
            {
                return NotFound();
            }

            return erApplication;
        }

        // PUT: api/ErApplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErApplication(Guid id, ErApplication erApplication)
        {
            if (id != erApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(erApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErApplicationExists(id))
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

        // POST: api/ErApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ErApplication>> PostErApplication(ErApplication erApplication)
        {
            _context.ErApplications.Add(erApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErApplication", new { id = erApplication.Id }, erApplication);
        }

        // DELETE: api/ErApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErApplication(Guid id)
        {
            var erApplication = await _context.ErApplications.FindAsync(id);
            if (erApplication == null)
            {
                return NotFound();
            }

            _context.ErApplications.Remove(erApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErApplicationExists(Guid id)
        {
            return _context.ErApplications.Any(e => e.Id == id);
        }
    }
}
