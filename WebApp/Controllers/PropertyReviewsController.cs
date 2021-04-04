using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.DTO;
using Extensions.Base;
using WebApp.ViewModels.PropertyReviews;

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
            var viewModel = new PropertyReviewsCreatEditViewModel();
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName));
            viewModel.PropertySelectList  = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: PropertyReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyReviewsCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.PropertyReviews.Add(viewModel.PropertyReview);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.PropertyReview.ErUserId);
            viewModel.PropertySelectList  = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.PropertyReview.PropertyId);
            return View(viewModel);
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
            var viewModel = new PropertyReviewsCreatEditViewModel();
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName));
            viewModel.PropertySelectList  = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: PropertyReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PropertyReviewsCreatEditViewModel viewModel)
        {
            if (id != viewModel.PropertyReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.PropertyReviews.Update(viewModel.PropertyReview);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.PropertyReview.ErUserId);
            viewModel.PropertySelectList  = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.PropertyReview.PropertyId);
            return View(viewModel);
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
        
    }
}
