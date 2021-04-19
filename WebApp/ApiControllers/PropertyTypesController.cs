using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Domain.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin", AuthenticationSchemes =  JwtBearerDefaults.AuthenticationScheme)]

    public class PropertyTypesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PropertyTypesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/PropertyTypes
        [HttpGet]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PropertyType>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<PropertyType>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.PropertyType>>> GetPropertyTypes()
        {
            // var data = await _bll.PropertyTypes.GetAllAsync();
            // var result = data.Select(propertyType => new PropertyTypeDTO()
            // {
            //     PropertyTypeValue = propertyType.PropertyTypeValue,
            //     PropertyCount = propertyType.Properties!.Count
            // });

            var result = (await _bll.PropertyTypes.GetAllWithPropertyTypeCountAsync()).Select(p=>new PublicApi.DTO.v1.PropertyType()
            {
                Id = p.Id,
                PropertyTypeValue = p.PropertyTypeValue,
                PropertyCount = p.PropertiesCount ?? 0
            });
            return Ok(result);
        }

        // GET: api/PropertyTypes/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BLL.App.DTO.PropertyType>> GetPropertyType(Guid id)
        {
            var propertyType = await _bll.PropertyTypes.FirstOrDefaultAsync(id);

            if (propertyType == null)
            {
                return NotFound();
            }

            return propertyType;
        }

        // PUT: api/PropertyTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyType(Guid id, BLL.App.DTO.PropertyType propertyType)
        {
            if (id != propertyType.Id)
            {
                return BadRequest();
            }

            _bll.PropertyTypes.Update(propertyType);
            await _bll.SaveChangesAsync();
            

            return NoContent();
        }

        // POST: api/PropertyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.PropertyType>> PostPropertyType(BLL.App.DTO.PropertyType propertyType)
        {
            _bll.PropertyTypes.Add(propertyType);
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetPropertyType",
                new
                {
                    id = propertyType.Id,
                    version = HttpContext.GetRequestedApiVersion()?.ToString()
                }, propertyType);
        }

        // DELETE: api/PropertyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyType(Guid id)
        {
            var propertyType = await _bll.PropertyTypes.FirstOrDefaultAsync(id);
            if (propertyType == null)
            {
                return NotFound();
            }

            _bll.PropertyTypes.Remove(propertyType);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
