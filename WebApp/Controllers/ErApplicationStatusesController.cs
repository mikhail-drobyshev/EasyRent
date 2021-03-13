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
    public class ErApplicationStatusesController : Controller
    {
        private readonly AppDbContext _context;

        public ErApplicationStatusesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ErApplicationStatuses
        public async Task<IActionResult> Index()
        {
            return View(await _context.ErApplicationStatuses.ToListAsync());
        }

        // GET: ErApplicationStatuses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplicationStatus = await _context.ErApplicationStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,ErApplicationStatusValue")] ErApplicationStatus erApplicationStatus)
        {
            if (ModelState.IsValid)
            {
                erApplicationStatus.Id = Guid.NewGuid();
                _context.Add(erApplicationStatus);
                await _context.SaveChangesAsync();
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

            var erApplicationStatus = await _context.ErApplicationStatuses.FindAsync(id);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ErApplicationStatusValue")] ErApplicationStatus erApplicationStatus)
        {
            if (id != erApplicationStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(erApplicationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErApplicationStatusExists(erApplicationStatus.Id))
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

            var erApplicationStatus = await _context.ErApplicationStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var erApplicationStatus = await _context.ErApplicationStatuses.FindAsync(id);
            _context.ErApplicationStatuses.Remove(erApplicationStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErApplicationStatusExists(Guid id)
        {
            return _context.ErApplicationStatuses.Any(e => e.Id == id);
        }
    }
}
