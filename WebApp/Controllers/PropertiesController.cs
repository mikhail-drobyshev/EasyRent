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
    public class PropertiesController : Controller
    {
        private readonly AppDbContext _context;

        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Properties.Include(e => e.ErUser).Include(e => e.PropertyType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eproperty = await _context.Properties
                .Include(e => e.ErUser)
                .Include(e => e.PropertyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eproperty == null)
            {
                return NotFound();
            }

            return View(eproperty);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName");
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,Description,BedroomCount,TenantsCount,ErUserId,PropertyTypeId")] Property eproperty)
        {
            if (ModelState.IsValid)
            {
                eproperty.Id = Guid.NewGuid();
                _context.Add(eproperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", eproperty.ErUserId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", eproperty.PropertyTypeId);
            return View(eproperty);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eproperty = await _context.Properties.FindAsync(id);
            if (eproperty == null)
            {
                return NotFound();
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", eproperty.ErUserId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", eproperty.PropertyTypeId);
            return View(eproperty);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Price,Description,BedroomCount,TenantsCount,ErUserId,PropertyTypeId")] Property eproperty)
        {
            if (id != eproperty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eproperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(eproperty.Id))
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
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", eproperty.ErUserId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", eproperty.PropertyTypeId);
            return View(eproperty);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eproperty = await _context.Properties
                .Include(e => e.ErUser)
                .Include(e => e.PropertyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eproperty == null)
            {
                return NotFound();
            }

            return View(eproperty);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eproperty = await _context.Properties.FindAsync(id);
            _context.Properties.Remove(eproperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(Guid id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}

