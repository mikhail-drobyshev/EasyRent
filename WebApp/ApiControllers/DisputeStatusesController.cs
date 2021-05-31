using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DisputeStatusesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll"></param>
        public DisputeStatusesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/DisputeStatuses
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisputeStatus>>> GetDisputeStatuses()
        {
            return Ok(await _bll.DisputeStatuses.GetAllAsync());
        }

        // GET: api/DisputeStatuses/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.DisputeStatus>> GetDisputeStatus(Guid id)
        {
            var disputeStatus = await _bll.DisputeStatuses.FirstOrDefaultAsync(id);

            if (disputeStatus == null)
            {
                return NotFound();
            }

            return Ok(disputeStatus);
        }

        // PUT: api/DisputeStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="disputeStatus"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisputeStatus(Guid id, BLL.App.DTO.DisputeStatus disputeStatus)
        {
            if (id != disputeStatus.Id)
            {
                return BadRequest();
            }

            _bll.DisputeStatuses.Update(disputeStatus);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/DisputeStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disputeStatus"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DisputeStatus>> PostDisputeStatus(BLL.App.DTO.DisputeStatus disputeStatus)
        {
            _bll.DisputeStatuses.Add(disputeStatus);
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetDisputeStatus",
                new
                {
                    id = disputeStatus.Id,
                    version = HttpContext.GetRequestedApiVersion()?.ToString()
                }, disputeStatus);
        }

        // DELETE: api/DisputeStatuses/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisputeStatus(Guid id)
        {
            var disputeStatus = await _bll.DisputeStatuses.FirstOrDefaultAsync(id);
            if (disputeStatus == null)
            {
                return NotFound();
            }

            _bll.DisputeStatuses.Remove(disputeStatus);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
