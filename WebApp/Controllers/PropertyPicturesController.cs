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
using WebApp.ViewModels.PropertyPictures;

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
            var viewModel = new PropertyPicturesCreatEditViewModel();
            viewModel.PropertySelectList = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: PropertyPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyPicturesCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.PropertyPictures.Add(viewModel.PropertyPicture);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.PropertySelectList = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.PropertyPicture.PropertyId);
            return View(viewModel);
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
            var viewModel = new PropertyPicturesCreatEditViewModel();
            viewModel.PropertyPicture = propertyPicture;
            viewModel.PropertySelectList = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: PropertyPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PropertyPicturesCreatEditViewModel viewModel)
        {
            if (id != viewModel.PropertyPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.PropertyPictures.Update(viewModel.PropertyPicture);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.PropertySelectList = new SelectList(await _uow.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.PropertyPicture.PropertyId);
            return View(viewModel);
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
