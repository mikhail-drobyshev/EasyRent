using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
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
        private readonly IAppUnitOfWork _uow;

        public ErApplicationsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ErApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErApplication>>> GetErApplications()
        {
            return Ok(await _uow.ErApplications.GetAllAsync());
        }

        // GET: api/ErApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErApplication>> GetErApplication(Guid id)
        {
            var erApplication = await _uow.ErApplications.FirstOrDefaultAsync(id);

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

            _uow.ErApplications.Update(erApplication);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ErApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ErApplication>> PostErApplication(ErApplication erApplication)
        {
            _uow.ErApplications.Add(erApplication);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetErApplication", new { id = erApplication.Id }, erApplication);
        }

        // DELETE: api/ErApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErApplication(Guid id)
        {
            var erApplication = await _uow.ErApplications.FirstOrDefaultAsync(id);
            if (erApplication == null)
            {
                return NotFound();
            }

            _uow.ErApplications.Remove(erApplication);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
