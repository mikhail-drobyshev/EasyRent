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
            var appDbContext = _context.Properties.Include(d => d.ErUser).Include(d => d.PropertyType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dproperty = await _context.Properties
                .Include(d => d.ErUser)
                .Include(d => d.PropertyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dproperty == null)
            {
                return NotFound();
            }

            return View(dproperty);
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
        public async Task<IActionResult> Create([Bind("Title,Price,Description,BedroomCount,TenantsCount,ErUserId,PropertyTypeId,Id")] Property dproperty)
        {
            if (ModelState.IsValid)
            {
                dproperty.Id = Guid.NewGuid();
                _context.Add(dproperty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", dproperty.ErUserId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", dproperty.PropertyTypeId);
            return View(dproperty);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dproperty = await _context.Properties.FindAsync(id);
            if (dproperty == null)
            {
                return NotFound();
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", dproperty.ErUserId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", dproperty.PropertyTypeId);
            return View(dproperty);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Price,Description,BedroomCount,TenantsCount,ErUserId,PropertyTypeId,Id")] Property dproperty)
        {
            if (id != dproperty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dproperty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(dproperty.Id))
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
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", dproperty.ErUserId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "PropertyTypeValue", dproperty.PropertyTypeId);
            return View(dproperty);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dproperty = await _context.Properties
                .Include(d => d.ErUser)
                .Include(d => d.PropertyType)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var dproperty = await _context.Properties.FindAsync(id);
            _context.Properties.Remove(dproperty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(Guid id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
