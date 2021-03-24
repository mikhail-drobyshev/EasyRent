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
using WebApp.ViewModels.Properties;

namespace WebApp.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PropertiesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Properties.GetAllAsync();
            return View(res);
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dproperty = await _uow.Properties.FirstOrDefaultAsync(id.Value);
            if (dproperty == null)
            {
                return NotFound();
            }

            return View(dproperty);
        }

        // GET: Properties/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new PropertiesCreatEditViewModel();
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName));
            viewModel.PropertyTypeSelectList  = new SelectList(await _uow.PropertyTypes.GetAllAsync(), nameof(PropertyType.Id), nameof(PropertyType.PropertyTypeValue));
            return View(viewModel);
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertiesCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.Properties.Add(viewModel.Property);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } 
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.Property.ErUserId);
            viewModel.PropertyTypeSelectList  = new SelectList(await _uow.PropertyTypes.GetAllAsync(), nameof(PropertyType.Id), nameof(PropertyType.PropertyTypeValue), viewModel.Property.Id);
            return View(viewModel);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _uow.Properties.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (property == null)
            {
                return NotFound();
            }
            var viewModel = new PropertiesCreatEditViewModel();
            viewModel.Property = property;
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName));
            viewModel.PropertyTypeSelectList  = new SelectList(await _uow.PropertyTypes.GetAllAsync(), nameof(PropertyType.Id), nameof(PropertyType.PropertyTypeValue));
            return View(viewModel);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PropertiesCreatEditViewModel viewModel)
        {
            if (id != viewModel.Property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Properties.Update(viewModel.Property);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _uow.ErUsers.GetAllAsync(), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.Property.ErUserId);
            viewModel.PropertyTypeSelectList  = new SelectList(await _uow.PropertyTypes.GetAllAsync(), nameof(PropertyType.Id), nameof(PropertyType.PropertyTypeValue), viewModel.Property.Id);
            return View(viewModel);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dproperty =  await _uow.Properties.FirstOrDefaultAsync(id.Value);
            if (dproperty == null)
            {
                return NotFound();
            }

            return View(dproperty);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Properties.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
