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
            ViewData["ErApplicationStatusId"] = new SelectList(await _uow.ErApplicationsStatuses.GetAllAsync(), "Id", "ErApplicationStatusValue");
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName");
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title");
            return View();
        }

        // POST: ErApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErApplication erApplication)
        {
            if (ModelState.IsValid)
            {
                _uow.ErApplications.Add(erApplication);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErApplicationStatusId"] = new SelectList(await _uow.ErApplicationsStatuses.GetAllAsync(), "Id", "ErApplicationStatusValue", erApplication.Id);
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", erApplication.Id);
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", erApplication.Id);
            return View(erApplication);
        }

        // GET: ErApplications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
            ViewData["ErApplicationStatusId"] = new SelectList(await _uow.ErApplicationsStatuses.GetAllAsync(), "Id", "ErApplicationStatusValue", erApplication.Id);
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", erApplication.Id);
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", erApplication.Id);
            return View(erApplication);
        }

        // POST: ErApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ErApplication erApplication)
        {
            if (id != erApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ErApplications.Update(erApplication);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ErApplicationExists(erApplication.Id))
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
            ViewData["ErApplicationStatusId"] = new SelectList(await _uow.ErApplicationsStatuses.GetAllAsync(), "Id", "ErApplicationStatusValue", erApplication.Id);
            ViewData["ErUserId"] = new SelectList(await _uow.ErUsers.GetAllAsync(), "Id", "FirstName", erApplication.Id);
            ViewData["PropertyId"] = new SelectList(await _uow.Properties.GetAllAsync(), "Id", "Title", erApplication.Id);
            return View(erApplication);
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

        private async Task<bool> ErApplicationExists(Guid id)
        {
            return await _uow.ErApplications.ExistAsync(id);
        }
    }
}
