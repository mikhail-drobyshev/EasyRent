using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLL.App.DTO;
using Extensions.Base;
using WebApp.ViewModels.ErUserPictures;

namespace WebApp.Controllers
{
    public class ErUserPicturesController : Controller
    {
        private readonly IAppBLL _bll;

        public ErUserPicturesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: ErUserPictures
        public async Task<IActionResult> Index()
        {
            var res = await _bll.ErUserPictures.GetAllAsync(User.GetUserId()!.Value);
            return View(res);
        }

        // GET: ErUserPictures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserPicture = await _bll.ErUserPictures.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (erUserPicture == null)
            {
                return NotFound();
            }

            return View(erUserPicture);
        }

        // GET: ErUserPictures/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new ErUserPicturesCreatEditViewModel();
            viewModel.ErUserSelectList = new SelectList(await _bll.ErUsers.GetAllAsync(User.GetUserId()!.Value), nameof(ErUser.Id), nameof(ErUser.FirstName));
            return View(viewModel);
        }

        // POST: ErUserPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErUserPicturesCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _bll.ErUserPictures.Add(viewModel.ErUserPicture);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _bll.ErUsers.GetAllAsync(User.GetUserId()!.Value), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.ErUserPicture.ErUserId);
            return View(viewModel);
        }

        // GET: ErUserPictures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserPicture = await _bll.ErUserPictures.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (erUserPicture == null)
            {
                return NotFound();
            }
            var viewModel = new ErUserPicturesCreatEditViewModel();
            viewModel.ErUserPicture = erUserPicture;
            viewModel.ErUserSelectList = new SelectList(await _bll.ErUsers.GetAllAsync(User.GetUserId()!.Value), nameof(ErUser.Id), nameof(ErUser.FirstName));

            return View(viewModel);
        }

        // POST: ErUserPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ErUserPicturesCreatEditViewModel viewModel)
        {
            if (id != viewModel.ErUserPicture.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                _bll.ErUserPictures.Update(viewModel.ErUserPicture);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _bll.ErUsers.GetAllAsync(User.GetUserId()!.Value), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.ErUserPicture.ErUserId);
            return View(viewModel);
        }

        // GET: ErUserPictures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserPicture = await _bll.ErUserPictures.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (erUserPicture == null)
            {
                return NotFound();
            }

            return View(erUserPicture);
        }

        // POST: ErUserPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.ErUserPictures.RemoveAsync(id, User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
