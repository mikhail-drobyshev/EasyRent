using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}[controller]")]
    [ApiController]
    public class DisputesController : ControllerBase
    {
        private readonly IAppBLL _bll;


        public DisputesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Disputes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.Dispute>>> GetDisputes()
        {
            return Ok(await _bll.DisputeStatuses.GetAllAsync());
        }

        // GET: api/Disputes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Dispute>> GetDispute(Guid id)
        {
            var dispute = await _bll.Disputes.FirstOrDefaultAsync(id);

            if (dispute == null)
            {
                return NotFound();
            }

            return dispute;
        }

        // PUT: api/Disputes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispute(Guid id, BLL.App.DTO.Dispute dispute)
        {
            if (id != dispute.Id)
            {
                return BadRequest();
            }

            _bll.Disputes.Update(dispute);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Disputes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.Dispute>> PostDispute(BLL.App.DTO.Dispute dispute)
        {
            _bll.Disputes.Add(dispute);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetDispute", new { id = dispute.Id }, dispute);
        }

        // DELETE: api/Disputes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispute(Guid id)
        {
            var dispute = await _bll.Disputes.FirstOrDefaultAsync(id);
            if (dispute == null)
            {
                return NotFound();
            }

            _bll.Disputes.Remove(dispute);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
