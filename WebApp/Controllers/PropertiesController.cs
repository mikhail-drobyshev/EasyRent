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
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName");
            ViewData["PropertyTypeId"] = new SelectList(await _uow.PropertyTypes.GetAllAsync(), "Id", "PropertyTypeValue");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Property dproperty)
        {
            if (ModelState.IsValid)
            {
                _uow.Properties.Add(dproperty);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", dproperty.Id);
            ViewData["PropertyTypeId"] = new SelectList(await _uow.PropertyTypes.GetAllAsync(), "Id", "PropertyTypeValue", dproperty.Id);
            return View(dproperty);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", dproperty.Id);
            ViewData["PropertyTypeId"] = new SelectList(await _uow.PropertyTypes.GetAllAsync(), "Id", "PropertyTypeValue", dproperty.Id);
            return View(dproperty);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Property dproperty)
        {
            if (id != dproperty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Properties.Update(dproperty);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PropertyExists(dproperty.Id))
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
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", dproperty.Id);
            ViewData["PropertyTypeId"] = new SelectList(await _uow.PropertyTypes.GetAllAsync(), "Id", "PropertyTypeValue", dproperty.Id);
            return View(dproperty);
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

        private async Task<bool> PropertyExists(Guid id)
        {
            return await _uow.Properties.ExistAsync(id);
        }
    }
}
