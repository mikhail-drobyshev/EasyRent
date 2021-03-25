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
using Extensions.Base;
using WebApp.ViewModels.ErApplications;

namespace WebApp.Controllers
{
    public class ErApplicationsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ErApplicationsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ErApplications
        public async Task<IActionResult> Index()
        {
            var res = await _uow.ErApplications.GetAllAsync();
            await _uow.SaveChangesAsync();

            return View(res);
        }

        // GET: ErApplications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplication = await _uow.ErApplications.FirstOrDefaultAsync(id.Value);
            if (erApplication == null)
            {
                return NotFound();
            }

            return View(erApplication);
        }

        // GET: ErApplications/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new ErApplicationsCreatEditViewModel();
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName));
            viewModel.PropertySelectList  = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View();
        }

        // POST: ErApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErApplicationsCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.ErApplications.Add(viewModel.ErApplication);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.ErApplication.ErUserId);
            viewModel.PropertySelectList  = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.ErApplication.PropertyId);
            return View(viewModel);
        }

        // GET: ErApplications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplication = await _uow.ErApplications.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (erApplication == null)
            {
                return NotFound();
            }
            var viewModel = new ErApplicationsCreatEditViewModel();
            viewModel.ErApplication = erApplication;
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName));
            viewModel.PropertySelectList  = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: ErApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ErApplicationsCreatEditViewModel viewModel)
        {
            if (id != viewModel.ErApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.ErApplications.Update(viewModel.ErApplication);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.ErApplication.ErUserId);
            viewModel.PropertySelectList  = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.ErApplication.PropertyId);
            return View(viewModel);

        }

        // GET: ErApplications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplication = await _uow.ErApplications.FirstOrDefaultAsync(id.Value);
            if (erApplication == null)
            {
                return NotFound();
            }

            return View(erApplication);
        }

        // POST: ErApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.ErApplications.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
