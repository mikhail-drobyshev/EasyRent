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
    public class DisputeStatusesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public DisputeStatusesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: DisputeStatuses
        public async Task<IActionResult> Index()
        {
            var res = await _uow.DisputeStatuses.GetAllAsync();
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: DisputeStatuses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disputeStatus = await _uow.DisputeStatuses.FirstOrDefaultAsync(id.Value);
            if (disputeStatus == null)
            {
                return NotFound();
            }

            return View(disputeStatus);
        }

        // GET: DisputeStatuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisputeStatuses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DisputeStatus disputeStatus)
        {
            if (ModelState.IsValid)
            {
                _uow.DisputeStatuses.Add(disputeStatus);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disputeStatus);
        }

        // GET: DisputeStatuses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disputeStatus = await _uow.DisputeStatuses.FirstOrDefaultAsync(id.Value);
            if (disputeStatus == null)
            {
                return NotFound();
            }
            return View(disputeStatus);
        }

        // POST: DisputeStatuses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DisputeStatus disputeStatus)
        {
            if (id != disputeStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.DisputeStatuses.Update(disputeStatus);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await DisputeStatusExists(disputeStatus.Id))
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
            return View(disputeStatus);
        }

        // GET: DisputeStatuses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disputeStatus = await _uow.DisputeStatuses.FirstOrDefaultAsync(id.Value);
            if (disputeStatus == null)
            {
                return NotFound();
            }

            return View(disputeStatus);
        }

        // POST: DisputeStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.DisputeStatuses.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DisputeStatusExists(Guid id)
        {
            return await _uow.DisputeStatuses.ExistAsync(id);
        }
    }
}
