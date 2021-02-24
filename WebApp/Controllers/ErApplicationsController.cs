using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class ErApplicationsController : Controller
    {
        private readonly AppDbContext _context;

        public ErApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ErApplications
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ErApplications.Include(e => e.ErApplicationStatus).Include(e => e.ErUser).Include(e => e.Property);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ErApplications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplication = await _context.ErApplications
                .Include(e => e.ErApplicationStatus)
                .Include(e => e.ErUser)
                .Include(e => e.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erApplication == null)
            {
                return NotFound();
            }

            return View(erApplication);
        }

        // GET: ErApplications/Create
        public IActionResult Create()
        {
            ViewData["ErApplicationStatusId"] = new SelectList(_context.ErApplicationStatuses, "Id", "ErApplicationStatusValue");
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName");
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title");
            return View();
        }

        // POST: ErApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RentFrom,Comment,ErUserId,PropertyId,ErApplicationStatusId,CreatedOn,UpdatedOn")] ErApplication erApplication)
        {
            if (ModelState.IsValid)
            {
                erApplication.Id = Guid.NewGuid();
                _context.Add(erApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErApplicationStatusId"] = new SelectList(_context.ErApplicationStatuses, "Id", "ErApplicationStatusValue", erApplication.ErApplicationStatusId);
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", erApplication.ErUserId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", erApplication.PropertyId);
            return View(erApplication);
        }

        // GET: ErApplications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplication = await _context.ErApplications.FindAsync(id);
            if (erApplication == null)
            {
                return NotFound();
            }
            ViewData["ErApplicationStatusId"] = new SelectList(_context.ErApplicationStatuses, "Id", "ErApplicationStatusValue", erApplication.ErApplicationStatusId);
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", erApplication.ErUserId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", erApplication.PropertyId);
            return View(erApplication);
        }

        // POST: ErApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RentFrom,Comment,ErUserId,PropertyId,ErApplicationStatusId,CreatedOn,UpdatedOn")] ErApplication erApplication)
        {
            if (id != erApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(erApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErApplicationExists(erApplication.Id))
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
            ViewData["ErApplicationStatusId"] = new SelectList(_context.ErApplicationStatuses, "Id", "ErApplicationStatusValue", erApplication.ErApplicationStatusId);
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", erApplication.ErUserId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", erApplication.PropertyId);
            return View(erApplication);
        }

        // GET: ErApplications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplication = await _context.ErApplications
                .Include(e => e.ErApplicationStatus)
                .Include(e => e.ErUser)
                .Include(e => e.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var erApplication = await _context.ErApplications.FindAsync(id);
            _context.ErApplications.Remove(erApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErApplicationExists(Guid id)
        {
            return _context.ErApplications.Any(e => e.Id == id);
        }
    }
}
