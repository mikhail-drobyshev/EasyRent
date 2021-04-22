using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Extensions.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        public PropertiesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Properties
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.Property>>> GetProperties()
        {
            return Ok(await _uow.Properties.GetAllAsync(User.GetUserId()!.Value));
        }

        // GET: api/Properties/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.Property>> GetProperty(Guid id)
        {
            var @property = await _uow.Properties.FirstOrDefaultAsync(id);

            if (@property == null)
            {
                return NotFound();
            }

            return @property;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperty(Guid id, DAL.App.DTO.Property @property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            _uow.Properties.Update(property);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.Property>> PostProperty(DAL.App.DTO.Property @property)
        {
            _uow.Properties.Add(@property);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new
            {
                id = @property.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString()
            }, @property);
        }

        // DELETE: api/Properties/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            var @property = await _uow.Properties.FirstOrDefaultAsync(id);
            if (@property == null)
            {
                return NotFound();
            }

            _uow.Properties.Remove(@property);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
