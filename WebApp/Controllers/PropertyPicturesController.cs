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

namespace WebApp.Controllers
{
    public class PropertyPicturesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public PropertyPicturesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: PropertyPictures
        public async Task<IActionResult> Index()
        {
            var res = await _uow.PropertyPictures.GetAllAsync();
            return View(res);
        }

        // GET: PropertyPictures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _uow.PropertyPictures.FirstOrDefaultAsync(id.Value);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            return View(propertyPicture);
        }

        // GET: PropertyPictures/Create
        public async Task<IActionResult> Create()
        {
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title");
            return View();
        }

        // POST: PropertyPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyPicture propertyPicture)
        {
            if (ModelState.IsValid)
            {
                _uow.PropertyPictures.Add(propertyPicture);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", propertyPicture.PropertyId);
            return View(propertyPicture);
        }

        // GET: PropertyPictures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _uow.PropertyPictures.FirstOrDefaultAsync(id.Value);
            if (propertyPicture == null)
            {
                return NotFound();
            }
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", propertyPicture.PropertyId);
            return View(propertyPicture);
        }

        // POST: PropertyPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PropertyPicture propertyPicture)
        {
            if (id != propertyPicture.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid || !await _uow.PropertyPictures.ExistsAsync(propertyPicture.Id, User.GetUserId()!.Value))
                return View(propertyPicture);

            propertyPicture.AppUserId = User.GetUserId()!.Value;
            _uow.PropertyPictures.Update(propertyPicture);
            await _uow.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: PropertyPictures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _uow.PropertyPictures.FirstOrDefaultAsync(id.Value);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            return View(propertyPicture);
        }

        // POST: PropertyPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _uow.PropertyPictures.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
