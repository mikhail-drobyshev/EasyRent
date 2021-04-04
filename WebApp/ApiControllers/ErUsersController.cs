using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DTO.App;
using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =  JwtBearerDefaults.AuthenticationScheme)]

    public class ErUsersController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public ErUsersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ErUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErUserDTO>>> GetErUsers()
        {
            return Ok(await _uow.ErUsers.GetAllWithPropertyTypeCountAsync(User.GetUserId()!.Value));
        }

        // GET: api/ErUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.ErUser>> GetErUser(Guid id)
        {
            var erUser = await _uow.ErUsers.FirstOrDefaultAsync(id);

            if (erUser == null)
            {
                return NotFound();
            }

            return erUser;
        }

        // PUT: api/ErUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErUser(Guid id, DAL.App.DTO.ErUser erUser)
        {
            if (id != erUser.Id)
            {
                return BadRequest();
            }

            _uow.ErUsers.Update(erUser);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ErUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.ErUser>> PostErUser(DAL.App.DTO.ErUser erUser)
        {
            _uow.ErUsers.Add(erUser);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetErUser", new { id = erUser.Id }, erUser);
        }

        // DELETE: api/ErUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErUser(Guid id)
        {
            var erUser = await _uow.ErUsers.FirstOrDefaultAsync(id);
            if (erUser == null)
            {
                return NotFound();
            }

            _uow.ErUsers.Remove(erUser);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
