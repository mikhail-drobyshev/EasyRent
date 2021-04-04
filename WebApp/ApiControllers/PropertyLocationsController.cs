using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyLocationsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PropertyLocationsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PropertyLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.PropertyLocation>>> GetPropertyLocations()
        {
            return Ok(await _uow.PropertyLocations.GetAllAsync());

        }

        // GET: api/PropertyLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.PropertyLocation>> GetPropertyLocation(Guid id)
        {
            var propertyLocation = await _uow.PropertyLocations.FirstOrDefaultAsync(id);

            if (propertyLocation == null)
            {
                return NotFound();
            }

            return propertyLocation;
        }

        // PUT: api/PropertyLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyLocation(Guid id, DAL.App.DTO.PropertyLocation propertyLocation)
        {
            if (id != propertyLocation.Id)
            {
                return BadRequest();
            }

            _uow.PropertyLocations.Update(propertyLocation);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/PropertyLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.PropertyLocation>> PostPropertyLocation(DAL.App.DTO.PropertyLocation propertyLocation)
        {
            _uow.PropertyLocations.Add(propertyLocation);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPropertyLocation", new { id = propertyLocation.Id }, propertyLocation);
        }

        // DELETE: api/PropertyLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyLocation(Guid id)
        {
            var propertyLocation = await _uow.PropertyLocations.FirstOrDefaultAsync(id);
            if (propertyLocation == null)
            {
                return NotFound();
            }

            _uow.PropertyLocations.Remove(propertyLocation);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
