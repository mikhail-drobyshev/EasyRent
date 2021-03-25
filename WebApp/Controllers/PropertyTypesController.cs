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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PropertyTypesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PropertyTypesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PropertyTypes
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PropertyTypes.GetAllAsync();
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: PropertyTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyType = await _uow.PropertyTypes.FirstOrDefaultAsync(id.Value);
            if (propertyType == null)
            {
                return NotFound();
            }

            return View(propertyType);
        }

        // GET: PropertyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyType propertyType)
        {
            if (ModelState.IsValid)
            {
                _uow.PropertyTypes.Add(propertyType);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyType);
        }

        // GET: PropertyTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyType = await _uow.PropertyTypes.FirstOrDefaultAsync(id.Value);
            if (propertyType == null)
            {
                return NotFound();
            }
            return View(propertyType);
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PropertyType propertyType)
        {
            if (id != propertyType.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(propertyType);
            
            _uow.PropertyTypes.Update(propertyType);
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: PropertyTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyType = await _uow.PropertyTypes.FirstOrDefaultAsync(id.Value);
            if (propertyType == null)
            {
                return NotFound();
            }

            return View(propertyType);
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.PropertyTypes.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
