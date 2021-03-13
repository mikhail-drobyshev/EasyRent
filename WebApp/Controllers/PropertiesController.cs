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
            var appDbContext = _context.Properties.Include(x => x.ErUser).Include(x => x.PropertyLocation).Include(x => x.PropertyType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties
                .Include(x => x.ErUser)
                .Include(x => x.PropertyLocation)
                .Include(x => x.PropertyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName");
            ViewData["PropertyLocationId"] = new SelectList(_context.PropertyLocations, "Id", "City");
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Price,Description,BedroomCount,TenantsCount,ErUserId,PropertyTypeId,PropertyLocationId,Id")] Property @property)
        {
            if (ModelState.IsValid)
            {
                @property.Id = Guid.NewGuid();
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", @property.ErUserId);
            ViewData["PropertyLocationId"] = new SelectList(_context.PropertyLocations, "Id", "City", @property.PropertyLocationId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", @property.PropertyTypeId);
            return View(@property);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", property.ErUserId);
            ViewData["PropertyLocationId"] = new SelectList(_context.PropertyLocations, "Id", "City", property.PropertyLocationId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", property.PropertyTypeId);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Price,Description,BedroomCount,TenantsCount,ErUserId,PropertyTypeId,PropertyLocationId,Id")] Property @property)
        {
            if (id != @property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.Id))
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
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", @property.ErUserId);
            ViewData["PropertyLocationId"] = new SelectList(_context.PropertyLocations, "Id", "City", @property.PropertyLocationId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", @property.PropertyTypeId);
            return View(@property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.Properties
                .Include(x => x.ErUser)
                .Include(x => x.PropertyLocation)
                .Include(x => x.PropertyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @property = await _context.Properties.FindAsync(id);
            _context.Properties.Remove(@property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(Guid id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
