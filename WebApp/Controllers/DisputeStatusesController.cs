using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain.App;

namespace WebApp.Controllers
{
    public class DisputeStatusesController : Controller
    {
        private readonly AppDbContext _context;

        public DisputeStatusesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DisputeStatuses
        public async Task<IActionResult> Index()
        {
            return View(await _context.DisputeStatuses.ToListAsync());
        }

        // GET: DisputeStatuses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disputeStatus = await _context.DisputeStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,DisputeStatusValue")] DisputeStatus disputeStatus)
        {
            if (ModelState.IsValid)
            {
                disputeStatus.Id = Guid.NewGuid();
                _context.Add(disputeStatus);
                await _context.SaveChangesAsync();
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

            var disputeStatus = await _context.DisputeStatuses.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DisputeStatusValue")] DisputeStatus disputeStatus)
        {
            if (id != disputeStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disputeStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisputeStatusExists(disputeStatus.Id))
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

            var disputeStatus = await _context.DisputeStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var disputeStatus = await _context.DisputeStatuses.FindAsync(id);
            _context.DisputeStatuses.Remove(disputeStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisputeStatusExists(Guid id)
        {
            return _context.DisputeStatuses.Any(e => e.Id == id);
        }
    }
}
