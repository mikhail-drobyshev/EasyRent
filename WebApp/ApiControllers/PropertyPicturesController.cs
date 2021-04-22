using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyPicturesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        public PropertyPicturesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PropertyPictures
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.PropertyPicture>>> GetPropertyPictures()
        {
            return Ok(await _uow.PropertyPictures.GetAllAsync());
        }

        // GET: api/PropertyPictures/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.PropertyPicture>> GetPropertyPicture(Guid id)
        {
            var propertyPicture = await _uow.PropertyPictures.FirstOrDefaultAsync(id);

            if (propertyPicture == null)
            {
                return NotFound();
            }

            return propertyPicture;
        }

        // PUT: api/PropertyPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="propertyPicture"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyPicture(Guid id, DAL.App.DTO.PropertyPicture propertyPicture)
        {
            if (id != propertyPicture.Id)
            {
                return BadRequest();
            }

            _uow.PropertyPictures.Update(propertyPicture);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/PropertyPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyPicture"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.PropertyPicture>> PostPropertyPicture(DAL.App.DTO.PropertyPicture propertyPicture)
        {
            _uow.PropertyPictures.Add(propertyPicture);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPropertyPicture", new { id = propertyPicture.Id }, propertyPicture);
        }

        // DELETE: api/PropertyPictures/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyPicture(Guid id)
        {
            var propertyPicture = await _uow.PropertyPictures.FirstOrDefaultAsync(id);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            _uow.PropertyPictures.Remove(propertyPicture);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

    }
}
