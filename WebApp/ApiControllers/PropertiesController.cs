using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(AuthenticationSchemes =  JwtBearerDefaults.AuthenticationScheme)]
    public class PropertiesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll"></param>
        public PropertiesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Properties
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.Property>>> GetProperties()
        {
            var res = await _bll.Properties.GetAllWithUserIdAsync();
            return Ok(res);
        }

        // GET: api/Properties/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Property>> GetProperty(Guid id)
        {
            var property = await _bll.Properties.FirstOrDefaultAsync(id, User.GetUserId()!.Value);

            if (property?.Id == null)
            {
                return NotFound();
            }

            return property;
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
        public async Task<IActionResult> PutProperty(Guid id, BLL.App.DTO.Property property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            _bll.Properties.Update(property);
            await _bll.SaveChangesAsync();
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
        public async Task<ActionResult<BLL.App.DTO.Property>> PostProperty(BLL.App.DTO.Property property)
        {
            _bll.Properties.Add(property);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetProperty", new
            {
                id = property.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString()
            }, property);
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
            var property = await _bll.Properties.FirstOrDefaultAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            _bll.Properties.Remove(property);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
