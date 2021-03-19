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
    public class PropertyReviewsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PropertyReviewsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PropertyReviews
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PropertyReviews.GetAllAsync();
            return View(res);
        }

        // GET: PropertyReviews/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyReview = await _uow.PropertyReviews.FirstOrDefaultAsync(id.Value);
            if (propertyReview == null)
            {
                return NotFound();
            }

            return View(propertyReview);
        }

        // GET: PropertyReviews/Create
        public async Task <IActionResult> Create()
        {
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName");
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title");
            return View();
        }

        // POST: PropertyReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyReview propertyReview)
        {
            if (ModelState.IsValid)
            {
                _uow.PropertyReviews.Add(propertyReview);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", propertyReview.ErUserId);
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", propertyReview.PropertyId);
            return View(propertyReview);
        }

        // GET: PropertyReviews/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyReview = await _uow.PropertyReviews.FirstOrDefaultAsync(id.Value);
            if (propertyReview == null)
            {
                return NotFound();
            }
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", propertyReview.ErUserId);
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", propertyReview.PropertyId);
            return View(propertyReview);
        }

        // POST: PropertyReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PropertyReview propertyReview)
        {
            if (id != propertyReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.PropertyReviews.Update(propertyReview);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PropertyReviewExists(propertyReview.Id))
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
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", propertyReview.ErUserId);
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", propertyReview.PropertyId);
            return View(propertyReview);
        }

        // GET: PropertyReviews/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyReview = await _uow.PropertyReviews.FirstOrDefaultAsync(id.Value);
            if (propertyReview == null)
            {
                return NotFound();
            }

            return View(propertyReview);
        }

        // POST: PropertyReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PropertyReviews.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PropertyReviewExists(Guid id)
        {
            return await _uow.PropertyReviews.ExistAsync(id);
        }
    }
}
