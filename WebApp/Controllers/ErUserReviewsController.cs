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
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels.ErUserReviews;

namespace WebApp.Controllers
{
    [Authorize]
    public class ErUserReviewsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ErUserReviewsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ErUserReviews
        [AllowAnonymous]
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
            var viewModel = new ErUserReviewsCreatEditViewModel();
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName));
            return View(viewModel);
        }

        // POST: ErUserReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErUserReviewsCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.ErUserReviews.Add(viewModel.ErUserReview);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.ErUserReview.ErUserId);
            return View(viewModel);
        }

        // GET: ErUserReviews/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserReview = await _uow.ErUserReviews.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (erUserReview == null)
            {
                return NotFound();
            }
            var viewModel = new ErUserReviewsCreatEditViewModel();
            viewModel.ErUserReview = erUserReview;
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName));

            return View(viewModel);
        }

        // POST: ErUserReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ErUserReviewsCreatEditViewModel viewModel)
        {
            if (id != viewModel.ErUserReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.ErUserReviews.Update(viewModel.ErUserReview);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.ErUserReview.ErUserId);
            return View(viewModel);
        }

        // GET: ErUserReviews/Delete/5
        [AllowAnonymous]
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
        
    }
}
