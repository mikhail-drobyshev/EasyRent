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
    public class ErUserReviewsController : Controller
    {
        private readonly AppDbContext _context;

        public ErUserReviewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ErUserReviews
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ErUserReviews.Include(e => e.ErUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ErUserReviews/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserReview = await _context.ErUserReviews
                .Include(e => e.ErUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erUserReview == null)
            {
                return NotFound();
            }

            return View(erUserReview);
        }

        // GET: ErUserReviews/Create
        public IActionResult Create()
        {
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName");
            return View();
        }

        // POST: ErUserReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rating,Comment,ErUserId,CreatedOn,UpdatedOn")] ErUserReview erUserReview)
        {
            if (ModelState.IsValid)
            {
                erUserReview.Id = Guid.NewGuid();
                _context.Add(erUserReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", erUserReview.ErUserId);
            return View(erUserReview);
        }

        // GET: ErUserReviews/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserReview = await _context.ErUserReviews.FindAsync(id);
            if (erUserReview == null)
            {
                return NotFound();
            }
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", erUserReview.ErUserId);
            return View(erUserReview);
        }

        // POST: ErUserReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Rating,Comment,ErUserId")] ErUserReview erUserReview)
        {
            if (id != erUserReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(erUserReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErUserReviewExists(erUserReview.Id))
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
            ViewData["ErUserId"] = new SelectList(_context.ErUsers, "Id", "FirstName", erUserReview.ErUserId);
            return View(erUserReview);
        }

        // GET: ErUserReviews/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserReview = await _context.ErUserReviews
                .Include(e => e.ErUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erUserReview == null)
            {
                return NotFound();
            }

            return View(erUserReview);
        }

        // POST: ErUserReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var erUserReview = await _context.ErUserReviews.FindAsync(id);
            _context.ErUserReviews.Remove(erUserReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErUserReviewExists(Guid id)
        {
            return _context.ErUserReviews.Any(e => e.Id == id);
        }
    }
}
