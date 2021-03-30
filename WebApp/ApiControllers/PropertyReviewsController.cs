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
    public class PropertyReviewsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PropertyReviewsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PropertyReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyReview>>> GetPropertyReviews()
        {
            return Ok(await _uow.PropertyReviews.GetAllAsync());
        }

        // GET: api/PropertyReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyReview>> GetPropertyReview(Guid id)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyReview(Guid id, PropertyReview propertyReview)
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
        [HttpPost]
        public async Task<ActionResult<PropertyReview>> PostPropertyReview(PropertyReview propertyReview)
        {
            _uow.PropertyReviews.Add(propertyReview);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPropertyReview", new { id = propertyReview.Id }, propertyReview);
        }

        // DELETE: api/PropertyReviews/5
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
