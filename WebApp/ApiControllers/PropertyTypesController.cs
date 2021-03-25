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
    public class PropertyTypesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PropertyTypesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PropertyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyType>>> GetPropertyTypes()
        {
            return Ok(await _uow.PropertyTypes.GetAllAsync());
        }

        // GET: api/PropertyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyType>> GetPropertyType(Guid id)
        {
            var propertyType = await _uow.PropertyTypes.FirstOrDefaultAsync(id);

            if (propertyType == null)
            {
                return NotFound();
            }

            return propertyType;
        }

        // PUT: api/PropertyTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyType(Guid id, PropertyType propertyType)
        {
            if (id != propertyType.Id)
            {
                return BadRequest();
            }

            _uow.PropertyTypes.Update(propertyType);
            await _uow.SaveChangesAsync();
            

            return NoContent();
        }

        // POST: api/PropertyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PropertyType>> PostPropertyType(PropertyType propertyType)
        {
            _uow.PropertyTypes.Add(propertyType);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPropertyType", new { id = propertyType.Id }, propertyType);
        }

        // DELETE: api/PropertyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyType(Guid id)
        {
            var propertyType = await _uow.PropertyTypes.FirstOrDefaultAsync(id);
            if (propertyType == null)
            {
                return NotFound();
            }

            _uow.PropertyTypes.Remove(propertyType);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
