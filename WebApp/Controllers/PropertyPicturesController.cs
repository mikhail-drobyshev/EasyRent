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
    public class PropertyPicturesController : Controller
    {
        private readonly AppDbContext _context;

        public PropertyPicturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PropertyPictures
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PropertyPictures.Include(p => p.Property);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PropertyPictures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _context.PropertyPictures
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            return View(propertyPicture);
        }

        // GET: PropertyPictures/Create
        public IActionResult Create()
        {
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title");
            return View();
        }

        // POST: PropertyPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PictureUrl,Title,PropertyId,Id")] PropertyPicture propertyPicture)
        {
            if (ModelState.IsValid)
            {
                propertyPicture.Id = Guid.NewGuid();
                _context.Add(propertyPicture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", propertyPicture.PropertyId);
            return View(propertyPicture);
        }

        // GET: PropertyPictures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _context.PropertyPictures.FindAsync(id);
            if (propertyPicture == null)
            {
                return NotFound();
            }
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", propertyPicture.PropertyId);
            return View(propertyPicture);
        }

        // POST: PropertyPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PictureUrl,Title,PropertyId,Id")] PropertyPicture propertyPicture)
        {
            if (id != propertyPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyPicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyPictureExists(propertyPicture.Id))
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
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", propertyPicture.PropertyId);
            return View(propertyPicture);
        }

        // GET: PropertyPictures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyPicture = await _context.PropertyPictures
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyPicture == null)
            {
                return NotFound();
            }

            return View(propertyPicture);
        }

        // POST: PropertyPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var propertyPicture = await _context.PropertyPictures.FindAsync(id);
            _context.PropertyPictures.Remove(propertyPicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyPictureExists(Guid id)
        {
            return _context.PropertyPictures.Any(e => e.Id == id);
        }
    }
}
