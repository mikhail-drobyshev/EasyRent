using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using DAL.App.EF;
using Domain.App;
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
        private readonly AppDbContext _context;
        private readonly IAppBLL _bll;

        public ErUsersController(IAppBLL bll, AppDbContext context)
        {
            _bll = bll;
            _context = context;
        }

        // GET: api/ErUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.ErUser>>> GetErUsers()
        {
            return Ok(await _bll.ErUsers.GetAllWithPropertyTypeCountAsync(User.GetUserId()!.Value));
        }

        // GET: api/ErUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.ErUser>> GetErUser(Guid id, ErUser erUser)
        {
            if (id != erUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(erUser).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();

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
        public async Task<ActionResult<PublicApi.DTO.v1.ErUser>> PostErUser(PublicApi.DTO.v1.ErUser erUser)
        {
            var bllUser = new BLL.App.DTO.ErUser()
            {
                FirstName = erUser.FirstName,
                LastName = erUser.LastName,
            };
            bllUser.AppUserId = User.GetUserId()!.Value;
            
            var addedUser = _bll.ErUsers.Add(bllUser);
            await _bll.SaveChangesAsync();

            var returnErUser = new PublicApi.DTO.v1.ErUser()
            {
                Id = addedUser.Id,
                FirstName = addedUser.FirstName,
                LastName = addedUser.LastName,
                Gendervalue = addedUser.Gendervalue ?? "",
                PropertiesCount = addedUser.PropertiesCount??0
            };

            return CreatedAtAction("GetErUser", new
            {
                id = returnErUser.Id,
            }, returnErUser);
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
