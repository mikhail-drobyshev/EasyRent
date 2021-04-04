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
    public class DisputeStatusesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public DisputeStatusesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/DisputeStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisputeStatus>>> GetDisputeStatuses()
        {
            return Ok(await _uow.DisputeStatuses.GetAllAsync());
        }

        // GET: api/DisputeStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.DisputeStatus>> GetDisputeStatus(Guid id)
        {
            var disputeStatus = await _uow.DisputeStatuses.FirstOrDefaultAsync(id);

            if (disputeStatus == null)
            {
                return NotFound();
            }

            return disputeStatus;
        }

        // PUT: api/DisputeStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisputeStatus(Guid id, DAL.App.DTO.DisputeStatus disputeStatus)
        {
            if (id != disputeStatus.Id)
            {
                return BadRequest();
            }

            _uow.DisputeStatuses.Update(disputeStatus);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/DisputeStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisputeStatus>> PostDisputeStatus(DAL.App.DTO.DisputeStatus disputeStatus)
        {
            _uow.DisputeStatuses.Add(disputeStatus);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetDisputeStatus", new { id = disputeStatus.Id }, disputeStatus);
        }

        // DELETE: api/DisputeStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisputeStatus(Guid id)
        {
            var disputeStatus = await _uow.DisputeStatuses.FirstOrDefaultAsync(id);
            if (disputeStatus == null)
            {
                return NotFound();
            }

            _uow.DisputeStatuses.Remove(disputeStatus);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
