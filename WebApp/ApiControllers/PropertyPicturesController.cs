using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using BLL.App.DTO;
using DAL.App.EF;
using Extensions.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.ApiControllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =  JwtBearerDefaults.AuthenticationScheme)]

    public class PropertyPicturesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly AppDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll"></param>
        public PropertyPicturesController(IAppBLL bll, AppDbContext context)
        {
            _bll = bll;
            _context = context;
        }

        // GET: api/PropertyPictures
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.PropertyPicture>>> GetPropertyPictures()
        {
            return Ok(await _bll.PropertyPictures.GetAllWithPropertyIdAsync());
        }

        // GET: api/PropertyPictures/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<DAL.App.DTO.PropertyPicture>> GetPropertyPicture(Guid id)
        {
            var propertyPicture = await _bll.PropertyPictures.FirstOrDefaultAsync(id);

            if (propertyPicture?.Id == null)
            {
                return NotFound();
            }

            return Ok(propertyPicture);
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
        public async Task<IActionResult> PutPropertyPicture(Guid id, BLL.App.DTO.PropertyPicture propertyPicture)
        {
            if (id != propertyPicture.Id)
            {
                return BadRequest();
            }

            _bll.PropertyPictures.Update(propertyPicture);
            await _bll.SaveChangesAsync();
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
        public async Task<ActionResult<BLL.App.DTO.PropertyPicture>> PostPropertyPicture(BLL.App.DTO.PropertyPicture propertyPicture)
        {
            

            _bll.PropertyPictures.Add(propertyPicture);
            await _bll.SaveChangesAsync();
            

            
            // var test = propertyPicture.PropertyId;
            // Property? house = await _bll.Properties.FirstOrDefaultAsync(test, User.GetUserId()!.Value);
            //
            // if (house?.Id != null && house.PropertyPictures !=null)
            // {
            //     house.PropertyPictures.Add(propertyPicture);
            //     _bll.Properties.Update(house);
            //     await _bll.SaveChangesAsync();
            // }
            // var testRes = await _bll.Properties.FirstOrDefaultAsync(test, User.GetUserId()!.Value);



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
            var propertyPicture = await _bll.PropertyPictures.FirstOrDefaultAsync(id);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            _bll.PropertyPictures.Remove(propertyPicture);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
