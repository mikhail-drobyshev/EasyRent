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
    public class PropertyLocationsController : Controller
    {
        private readonly AppDbContext _context;

        public PropertyLocationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PropertyLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropertyLocations.ToListAsync());
        }

        // GET: PropertyLocations/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLocation = await _context.PropertyLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyLocation == null)
            {
                return NotFound();
            }

            return View(propertyLocation);
        }

        // GET: PropertyLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City,Street,Building")] PropertyLocation propertyLocation)
        {
            if (ModelState.IsValid)
            {
                propertyLocation.Id = Guid.NewGuid();
                _context.Add(propertyLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyLocation);
        }

        // GET: PropertyLocations/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLocation = await _context.PropertyLocations.FindAsync(id);
            if (propertyLocation == null)
            {
                return NotFound();
            }
            return View(propertyLocation);
        }

        // POST: PropertyLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,City,Street,Building")] PropertyLocation propertyLocation)
        {
            if (id != propertyLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyLocationExists(propertyLocation.Id))
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
            return View(propertyLocation);
        }

        // GET: PropertyLocations/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLocation = await _context.PropertyLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyLocation == null)
            {
                return NotFound();
            }

            return View(propertyLocation);
        }

        // POST: PropertyLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var propertyLocation = await _context.PropertyLocations.FindAsync(id);
            _context.PropertyLocations.Remove(propertyLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyLocationExists(Guid id)
        {
            return _context.PropertyLocations.Any(e => e.Id == id);
        }
    }
}
