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
    public class ErUserReviewsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;


        public ErUserReviewsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/ErUserReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.ErUserReview>>> GetErUserReviews()
        {
            return Ok(await _uow.ErUserReviews.GetAllAsync());        }

        // GET: api/ErUserReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.ErUserReview>> GetErUserReview(Guid id)
        {
            var erUserReview = await _uow.ErUserReviews.FirstOrDefaultAsync(id);

            if (erUserReview == null)
            {
                return NotFound();
            }

            return erUserReview;
        }

        // PUT: api/ErUserReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErUserReview(Guid id, DAL.App.DTO.ErUserReview erUserReview)
        {
            if (id != erUserReview.Id)
            {
                return BadRequest();
            }

            _uow.ErUserReviews.Update(erUserReview);
            await _uow.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ErUserReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DAL.App.DTO.ErUserReview>> PostErUserReview(DAL.App.DTO.ErUserReview erUserReview)
        {
            _uow.ErUserReviews.Add(erUserReview);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetErUserReview", new { id = erUserReview.Id }, erUserReview);
        }

        // DELETE: api/ErUserReviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErUserReview(Guid id)
        {
            var erUserReview = await _uow.ErUserReviews.FirstOrDefaultAsync(id);
            if (erUserReview == null)
            {
                return NotFound();
            }

            _uow.ErUserReviews.Remove(erUserReview);
            await _uow.SaveChangesAsync();

            return NoContent();
        }
    }
}
