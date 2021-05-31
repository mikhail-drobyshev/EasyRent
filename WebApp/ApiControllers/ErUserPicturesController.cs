using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.BLL.Base;
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
    public class ErUserPicturesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll"></param>
        public ErUserPicturesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ErUserPictures
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAL.App.DTO.ErUserPicture>>> GetErUserPictures()
        {
            return Ok(await _bll.ErUserPictures.GetAllAsync());
        }

        // GET: api/ErUserPictures/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DAL.App.DTO.ErUserPicture>> GetErUserPicture(Guid id)
        {
            var erUserPicture = await _bll.ErUserPictures.FirstOrDefaultAsync(id);

            if (erUserPicture == null)
            {
                return NotFound();
            }

            return Ok(erUserPicture);
        }

        // PUT: api/ErUserPictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="erUserPicture"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErUserPicture(Guid id, BLL.App.DTO.ErUserPicture erUserPicture)
        {
            if (id != erUserPicture.Id)
            {
                return BadRequest();
            }

            _bll.ErUserPictures.Update(erUserPicture);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/ErUserPictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="erUserPicture"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.ErUserPicture>> PostErUserPicture(BLL.App.DTO.ErUserPicture erUserPicture)
        {
            _bll.ErUserPictures.Add(erUserPicture);
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetErUserPicture",
                new
                {
                    id = erUserPicture.Id,
                    version = HttpContext.GetRequestedApiVersion()?.ToString()
                }, erUserPicture);
        }

        // DELETE: api/ErUserPictures/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErUserPicture(Guid id)
        {
            var erUserPicture = await _bll.ErUserPictures.FirstOrDefaultAsync(id);
            if (erUserPicture == null)
            {
                return NotFound();
            }

            _bll.ErUserPictures.Remove(erUserPicture);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
