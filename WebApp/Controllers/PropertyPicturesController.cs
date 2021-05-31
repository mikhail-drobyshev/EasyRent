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
using WebApp.ViewModels.PropertyPictures;

namespace WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertyPicturesController : Controller
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll"></param>
        public PropertyPicturesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: PropertyPictures
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var res = await _bll.PropertyPictures.GetAllAsync(User.GetUserId()!.Value);
            return View(res);
        }

        // GET: PropertyPictures/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _bll.PropertyPictures.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            return View(propertyPicture);
        }

        // GET: PropertyPictures/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            var viewModel = new PropertyPicturesCreatEditViewModel();
            viewModel.PropertySelectList = new SelectList(await _bll.Properties.GetAllAsync(User.GetUserId()!.Value), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: PropertyPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertyPicturesCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _bll.PropertyPictures.Add(viewModel.PropertyPicture);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.PropertySelectList = new SelectList(await _bll.Properties.GetAllAsync(User.GetUserId()!.Value), nameof(Property.Id), nameof(Property.Title), viewModel.PropertyPicture.PropertyId);
            return View(viewModel);
        }

        // GET: PropertyPictures/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _bll.PropertyPictures.FirstOrDefaultAsync(id.Value);
            if (propertyPicture == null)
            {
                return NotFound();
            }
            var viewModel = new PropertyPicturesCreatEditViewModel();
            viewModel.PropertyPicture = propertyPicture;
            viewModel.PropertySelectList = new SelectList(await _bll.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title));
            return View(viewModel);
        }

        // POST: PropertyPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
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
                _bll.PropertyPictures.Update(viewModel.PropertyPicture);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.PropertySelectList = new SelectList(await _bll.Properties.GetAllAsync(), nameof(Property.Id), nameof(Property.Title), viewModel.PropertyPicture.PropertyId);
            return View(viewModel);
        }

        // GET: PropertyPictures/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _bll.PropertyPictures.FirstOrDefaultAsync(id.Value);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            return View(propertyPicture);
        }

        // POST: PropertyPictures/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            await _bll.PropertyPictures.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
