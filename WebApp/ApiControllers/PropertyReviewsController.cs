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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyReviewsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        public PropertyReviewsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PropertyReviews
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.PropertyReview>>> GetPropertyReviews()
        {
            return Ok(await _uow.PropertyReviews.GetAllAsync());
        }

        // GET: api/PropertyReviews/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.PropertyReview>> GetPropertyReview(Guid id)
        {
            var propertyReview = await _uow.PropertyReviews.FirstOrDefaultAsync(id);

            if (propertyReview == null)
            {
                return NotFound();
            }

            return propertyReview;
        }

        // PUT: api/PropertyReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="propertyReview"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyReview(Guid id, DAL.App.DTO.PropertyReview propertyReview)
        {
            if (id != propertyReview.Id)
            {
                return BadRequest();
            }

            _uow.PropertyReviews.Update(propertyReview);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/PropertyReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyReview"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.PropertyReview>> PostPropertyReview(DAL.App.DTO.PropertyReview propertyReview)
        {
            _uow.PropertyReviews.Add(propertyReview);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPropertyReview", new { id = propertyReview.Id }, propertyReview);
        }

        // DELETE: api/PropertyReviews/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyReview(Guid id)
        {
            var propertyReview = await _uow.PropertyReviews.FirstOrDefaultAsync(id);
            if (propertyReview == null)
            {
                return NotFound();
            }

            _uow.PropertyReviews.Remove(propertyReview);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
