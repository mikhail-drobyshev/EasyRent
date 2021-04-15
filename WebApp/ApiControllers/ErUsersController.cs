using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =  JwtBearerDefaults.AuthenticationScheme)]

    public class ErUsersController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ErUsersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ErUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.ErUser>>> GetErUsers()
        {
            return Ok(await _bll.ErUsers.GetAllWithPropertyTypeCountAsync(User.GetUserId()!.Value));
        }

        // GET: api/ErUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.ErUser>> GetErUser(Guid id)
        {
            var erUser = await _bll.ErUsers.FirstOrDefaultAsync(id);

            if (erUser == null)
            {
                return NotFound();
            }

            return erUser;
        }

        // PUT: api/ErUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErUser(Guid id, BLL.App.DTO.ErUser erUser)
        {
            if (id != erUser.Id)
            {
                return BadRequest();
            }

            _bll.ErUsers.Update(erUser);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ErUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.ErUser>> PostErUser(BLL.App.DTO.ErUser erUser)
        {
            _bll.ErUsers.Add(erUser);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetErUser", new
            {
                id = erUser.Id,
                version = HttpContext.GetRequestedApiVersion()?.ToString()
            }, erUser);
        }

        // DELETE: api/ErUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErUser(Guid id)
        {
            var erUser = await _bll.ErUsers.FirstOrDefaultAsync(id);
            if (erUser == null)
            {
                return NotFound();
            }

            _bll.ErUsers.Remove(erUser);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
