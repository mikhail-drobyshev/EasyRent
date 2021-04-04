using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErApplicationStatusesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;


        public ErApplicationStatusesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ErApplicationStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.ErApplicationStatus>>> GetErApplicationStatuses()
        {
            return Ok(await _uow.ErApplicationStatuses.GetAllAsync());

        }

        // GET: api/ErApplicationStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.ErApplicationStatus>> GetErApplicationStatus(Guid id)
        {
            var erApplicationStatus = await _uow.ErApplicationStatuses.FirstOrDefaultAsync(id);

            if (erApplicationStatus == null)
            {
                return NotFound();
            }

            return erApplicationStatus;
        }

        // PUT: api/ErApplicationStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErApplicationStatus(Guid id, DAL.App.DTO.ErApplicationStatus erApplicationStatus)
        {
            if (id != erApplicationStatus.Id)
            {
                return BadRequest();
            }

            _uow.ErApplicationStatuses.Update(erApplicationStatus);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ErApplicationStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.ErApplicationStatus>> PostErApplicationStatus(DAL.App.DTO.ErApplicationStatus erApplicationStatus)
        {
            _uow.ErApplicationStatuses.Add(erApplicationStatus);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetErApplicationStatus", new { id = erApplicationStatus.Id }, erApplicationStatus);
        }

        // DELETE: api/ErApplicationStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErApplicationStatus(Guid id)
        {
            var erApplicationStatus = await _uow.ErApplicationStatuses.FirstOrDefaultAsync(id);
            if (erApplicationStatus == null)
            {
                return NotFound();
            }

            _uow.ErApplicationStatuses.Remove(erApplicationStatus);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
