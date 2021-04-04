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
using WebApp.ViewModels.PropertyLocations;

namespace WebApp.Controllers
{
    public class PropertyLocationsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PropertyLocationsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PropertyLocations
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PropertyLocations.GetAllAsync();
            return View(res);
        }

        // GET: PropertyLocations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLocation = await _uow.PropertyLocations.FirstOrDefaultAsync(id.Value);
            if (propertyLocation == null)
            {
                return NotFound();
            }

            return View(propertyLocation);
        }

        // GET: PropertyLocations/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new PropertyLocationsCreatEditViewModel();
            viewModel.PropertySelectList = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: PropertyLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyLocationsCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.PropertyLocations.Add(viewModel.PropertyLocation);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.PropertySelectList = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.PropertyLocation.PropertyId);
            return View(viewModel);
        }

        // GET: PropertyLocations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLocation = await _uow.PropertyLocations.FirstOrDefaultAsync(id.Value);
            if (propertyLocation == null)
            {
                return NotFound();
            }
            var viewModel = new PropertyLocationsCreatEditViewModel();
            viewModel.PropertySelectList = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: PropertyLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PropertyLocationsCreatEditViewModel viewModel)
        {
            if (id != viewModel.PropertyLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.PropertyLocations.Update(viewModel.PropertyLocation);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.PropertySelectList = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.PropertyLocation.PropertyId);

            return View(viewModel);
        }

        // GET: PropertyLocations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLocation = await _uow.PropertyLocations.FirstOrDefaultAsync(id.Value);
            if (propertyLocation == null)
            {
                return NotFound();
            }

            return View(propertyLocation);
        }

        // POST: PropertyLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PropertyLocations.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
