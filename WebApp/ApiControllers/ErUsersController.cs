using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ErUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ErUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErUser>>> GetErUsers()
        {
            return await _context.ErUsers.ToListAsync();
        }

        // GET: api/ErUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErUser>> GetErUser(Guid id)
        {
            var erUser = await _context.ErUsers.FindAsync(id);

            if (erUser == null)
            {
                return NotFound();
            }

            return erUser;
        }

        // PUT: api/ErUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErUser(Guid id, ErUser erUser)
        {
            if (id != erUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(erUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErUserExists(id))
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

        // POST: api/ErUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ErUser>> PostErUser(ErUser erUser)
        {
            _context.ErUsers.Add(erUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErUser", new { id = erUser.Id }, erUser);
        }

        // DELETE: api/ErUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErUser(Guid id)
        {
            var erUser = await _context.ErUsers.FindAsync(id);
            if (erUser == null)
            {
                return NotFound();
            }

            _context.ErUsers.Remove(erUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErUserExists(Guid id)
        {
            return _context.ErUsers.Any(e => e.Id == id);
        }
    }
}
