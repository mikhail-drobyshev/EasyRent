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
    public class ErApplicationStatusesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public ErApplicationStatusesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ErApplicationStatuses
        public async Task<IActionResult> Index()
        {
            var res = await _uow.ErApplicationsStatuses.GetAllAsync();
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: ErApplicationStatuses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplicationStatus = await _uow.ErApplicationsStatuses.FirstOrDefaultAsync(id.Value);
            if (erApplicationStatus == null)
            {
                return NotFound();
            }

            return View(erApplicationStatus);
        }

        // GET: ErApplicationStatuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ErApplicationStatuses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErApplicationStatus erApplicationStatus)
        {
            if (ModelState.IsValid)
            {
                _uow.ErApplicationsStatuses.Add(erApplicationStatus);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erApplicationStatus);
        }

        // GET: ErApplicationStatuses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplicationStatus = await _uow.ErApplicationsStatuses.FirstOrDefaultAsync(id.Value);
            if (erApplicationStatus == null)
            {
                return NotFound();
            }
            return View(erApplicationStatus);
        }

        // POST: ErApplicationStatuses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ErApplicationStatus erApplicationStatus)
        {
            if (id != erApplicationStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ErApplicationsStatuses.Update(erApplicationStatus);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ErApplicationStatusExists(erApplicationStatus.Id))
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
            return View(erApplicationStatus);
        }

        // GET: ErApplicationStatuses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplicationStatus = await _uow.ErApplicationsStatuses.FirstOrDefaultAsync(id.Value);
            if (erApplicationStatus == null)
            {
                return NotFound();
            }

            return View(erApplicationStatus);
        }

        // POST: ErApplicationStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.ErApplicationsStatuses.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ErApplicationStatusExists(Guid id)
        {
            return await _uow.ErApplicationsStatuses.ExistAsync(id);
        }
    }
}
