using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin", AuthenticationSchemes =  JwtBearerDefaults.AuthenticationScheme)]

    public class PropertyTypesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PropertyTypesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PropertyTypes
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.PropertyType>>> GetPropertyTypes()
        {
            // var data = await _uow.PropertyTypes.GetAllAsync();
            // var result = data.Select(propertyType => new PropertyTypeDTO()
            // {
            //     PropertyTypeValue = propertyType.PropertyTypeValue,
            //     PropertyCount = propertyType.Properties!.Count
            // });

            var result = await _uow.PropertyTypes.GetAllWithPropertyTypeCountAsync();
            return Ok(result);
        }

        // GET: api/PropertyTypes/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<DAL.App.DTO.PropertyType>> GetPropertyType(Guid id)
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
        public async Task<IActionResult> PutPropertyType(Guid id, DAL.App.DTO.PropertyType propertyType)
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
        public async Task<ActionResult<DAL.App.DTO.PropertyType>> PostPropertyType(DAL.App.DTO.PropertyType propertyType)
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
