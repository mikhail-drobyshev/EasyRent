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
    public class PropertyReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public PropertyReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PropertyReviews
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PropertyReviews.Include(p => p.ErUser).Include(p => p.Property);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PropertyReviews/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyReview = await _context.PropertyReviews
                .Include(p => p.ErUser)
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyReview == null)
            {
                return NotFound();
            }

            return View(propertyReview);
        }

        // GET: PropertyReviews/Create
        public IActionResult Create()
        {
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName");
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title");
            return View();
        }

        // POST: PropertyReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rating,Comment,PropertyId,ErUserId")] PropertyReview propertyReview)
        {
            if (ModelState.IsValid)
            {
                propertyReview.Id = Guid.NewGuid();
                _context.Add(propertyReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", propertyReview.ErUserId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", propertyReview.PropertyId);
            return View(propertyReview);
        }

        // GET: PropertyReviews/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyReview = await _context.PropertyReviews.FindAsync(id);
            if (propertyReview == null)
            {
                return NotFound();
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", propertyReview.ErUserId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", propertyReview.PropertyId);
            return View(propertyReview);
        }

        // POST: PropertyReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Rating,Comment,PropertyId,ErUserId")] PropertyReview propertyReview)
        {
            if (id != propertyReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyReviewExists(propertyReview.Id))
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
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", propertyReview.ErUserId);
            ViewData["PropertyId"] = new SelectList(_context.Properties, "Id", "Title", propertyReview.PropertyId);
            return View(propertyReview);
        }

        // GET: PropertyReviews/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyReview = await _context.PropertyReviews
                .Include(p => p.ErUser)
                .Include(p => p.Property)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propertyReview == null)
            {
                return NotFound();
            }

            return View(propertyReview);
        }

        // POST: PropertyReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var propertyReview = await _context.PropertyReviews.FindAsync(id);
            _context.PropertyReviews.Remove(propertyReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyReviewExists(Guid id)
        {
            return _context.PropertyReviews.Any(e => e.Id == id);
        }
    }
}
