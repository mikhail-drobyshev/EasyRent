using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;

namespace WebApp.Controllers
{
    public class ErUserReviewsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ErUserReviewsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ErUserReviews
        public async Task<IActionResult> Index()
        {
            var res = await _uow.ErUserReviews.GetAllAsync();
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: ErUserReviews/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserReview = await _uow.ErUserReviews.FirstOrDefaultAsync(id.Value);
            if (erUserReview == null)
            {
                return NotFound();
            }

            return View(erUserReview);
        }

        // GET: ErUserReviews/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ErUserId"] = new SelectList(await _uow.ErUserReviews.GetAllAsync(), "Id", "FirstName");
            return View();
        }

        // POST: ErUserReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErUserReview erUserReview)
        {
            if (ModelState.IsValid)
            {
                _uow.ErUserReviews.Add(erUserReview);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(await _uow.ErUserReviews.GetAllAsync(), "Id", "FirstName", erUserReview.ErUserId);
            return View(erUserReview);
        }

        // GET: ErUserReviews/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserReview = await _uow.ErUserReviews.FirstOrDefaultAsync(id.Value);
            if (erUserReview == null)
            {
                return NotFound();
            }
            ViewData["ErUserId"] = new SelectList(await _uow.ErUserReviews.GetAllAsync(), "Id", "FirstName", erUserReview.ErUserId);
            return View(erUserReview);
        }

        // POST: ErUserReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ErUserReview erUserReview)
        {
            if (id != erUserReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ErUserReviews.Update(erUserReview);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ErUserReviewExists(erUserReview.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(await _uow.ErUserReviews.GetAllAsync(), "Id", "FirstName", erUserReview.ErUserId);
            return View(erUserReview);
        }

        // GET: ErUserReviews/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserReview = await _uow.ErUserReviews.FirstOrDefaultAsync(id.Value);
            if (erUserReview == null)
            {
                return NotFound();
            }

            return View(erUserReview);
        }

        // POST: ErUserReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.ErUserReviews.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ErUserReviewExists(Guid id)
        {
            return await _uow.ErUserReviews.ExistAsync(id);        }
    }
}
