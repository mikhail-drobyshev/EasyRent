using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.App.DTO;
using Extensions.Base;
using WebApp.ViewModels.Properties;

namespace WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertiesController : Controller
    {
        private readonly IAppBLL _bll;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll"></param>
        public PropertiesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Properties
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var res = await _bll.Properties.GetAllAsync(User.GetUserId()!.Value);
            return View(res);
        }

        // GET: Properties/Details/5
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

            var dproperty = await _bll.Properties.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (dproperty == null)
            {
                return NotFound();
            }

            return View(dproperty);
        }

        // GET: Properties/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            var viewModel = new PropertiesCreatEditViewModel();
            viewModel.ErUserSelectList = new SelectList(await _bll.ErUsers.GetAllAsync(User.GetUserId()!.Value), nameof(ErUser.Id), nameof(ErUser.FirstName));
            viewModel.PropertyTypeSelectList  = new SelectList(await _bll.PropertyTypes.GetAllAsync(), nameof(PropertyType.Id), nameof(PropertyType.PropertyTypeValue));
            return View(viewModel);
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PropertiesCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _bll.Properties.Add(viewModel.Property);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } 
            viewModel.ErUserSelectList = new SelectList(await _bll.ErUsers.GetAllAsync(User.GetUserId()!.Value), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.Property.ErUserId);
            viewModel.PropertyTypeSelectList  = new SelectList(await _bll.PropertyTypes.GetAllAsync(), nameof(PropertyType.Id), nameof(PropertyType.PropertyTypeValue), viewModel.Property.Id);
            return View(viewModel);
        }

        // GET: Properties/Edit/5
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

            var property = await _bll.Properties.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (property == null)
            {
                return NotFound();
            }
            var viewModel = new PropertiesCreatEditViewModel();
            viewModel.Property = property;
            viewModel.ErUserSelectList = new SelectList(await _bll.ErUsers.GetAllAsync(User.GetUserId()!.Value), nameof(ErUser.Id), nameof(ErUser.FirstName));
            viewModel.PropertyTypeSelectList  = new SelectList(await _bll.PropertyTypes.GetAllAsync(), nameof(PropertyType.Id), nameof(PropertyType.PropertyTypeValue));
            return View(viewModel);
        }

        // POST: Properties/Edit/5
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
        public async Task<IActionResult> Edit(Guid id, PropertiesCreatEditViewModel viewModel)
        {
            if (id != viewModel.Property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Properties.Update(viewModel.Property);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.ErUserSelectList = new SelectList(await _bll.ErUsers.GetAllAsync(User.GetUserId()!.Value), nameof(ErUser.Id), nameof(ErUser.FirstName), viewModel.Property.ErUserId);
            viewModel.PropertyTypeSelectList  = new SelectList(await _bll.PropertyTypes.GetAllAsync(), nameof(PropertyType.Id), nameof(PropertyType.PropertyTypeValue), viewModel.Property.Id);
            return View(viewModel);
        }

        // GET: Properties/Delete/5
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

            var dproperty =  await _bll.Properties.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (dproperty == null)
            {
                return NotFound();
            }

            return View(dproperty);
        }

        // POST: Properties/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.Properties.RemoveAsync(id, User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
