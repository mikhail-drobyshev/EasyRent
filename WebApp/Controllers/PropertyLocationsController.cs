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
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title");
            return View();
        }

        // POST: PropertyLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyLocation propertyLocation)
        {
            if (ModelState.IsValid)
            {
                _uow.PropertyLocations.Add(propertyLocation);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", propertyLocation.Id);
            return View(propertyLocation);
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
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", propertyLocation.Id);
            return View(propertyLocation);
        }

        // POST: PropertyLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PropertyLocation propertyLocation)
        {
            if (id != propertyLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.PropertyLocations.Update(propertyLocation);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PropertyLocationExists(propertyLocation.Id))
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
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", propertyLocation.Id);
            return View(propertyLocation);
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

        private async Task<bool> PropertyLocationExists(Guid id)
        {
            return await _uow.PropertyLocations.ExistAsync(id);
        }
    }
}
