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
    public class DisputesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;


        public DisputesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Disputes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dispute>>> GetDisputes()
        {
            return Ok(await _uow.DisputeStatuses.GetAllAsync());
        }

        // GET: api/Disputes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dispute>> GetDispute(Guid id)
        {
            var dispute = await _uow.Disputes.FirstOrDefaultAsync(id);

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

            _uow.Disputes.Update(dispute);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Disputes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dispute>> PostDispute(Dispute dispute)
        {
            _uow.Disputes.Add(dispute);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetDispute", new { id = dispute.Id }, dispute);
        }

        // DELETE: api/Disputes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispute(Guid id)
        {
            var dispute = await _uow.Disputes.FirstOrDefaultAsync(id);
            if (dispute == null)
            {
                return NotFound();
            }

            _uow.Disputes.Remove(dispute);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
