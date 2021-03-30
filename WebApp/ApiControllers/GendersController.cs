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
    public class GendersController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;


        public GendersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            return Ok(await _uow.Genders.GetAllAsync());
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(Guid id)
        {
            var gender = await _uow.Genders.FirstOrDefaultAsync(id);

            if (gender == null)
            {
                return NotFound();
            }

            return gender;
        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(Guid id, Gender gender)
        {
            if (id != gender.Id)
            {
                return BadRequest();
            }

            _uow.Genders.Update(gender);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Genders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gender>> PostGender(Gender gender)
        {
            _uow.Genders.Add(gender);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetGender", new { id = gender.Id }, gender);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(Guid id)
        {
            var gender = await _uow.Genders.FirstOrDefaultAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            _uow.Genders.Remove(gender);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
