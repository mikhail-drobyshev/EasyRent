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
    public class ErUserPicturesController : Controller
    {
        private readonly AppDbContext _context;

        public ErUserPicturesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ErUserPictures
        public async Task<IActionResult> Index()
        {
            return View(await _context.ErUserPictures.ToListAsync());
        }

        // GET: ErUserPictures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserPicture = await _context.ErUserPictures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erUserPicture == null)
            {
                return NotFound();
            }

            return View(erUserPicture);
        }

        // GET: ErUserPictures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ErUserPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PictureUrl")] ErUserPicture erUserPicture)
        {
            if (ModelState.IsValid)
            {
                erUserPicture.Id = Guid.NewGuid();
                _context.Add(erUserPicture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erUserPicture);
        }

        // GET: ErUserPictures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserPicture = await _context.ErUserPictures.FindAsync(id);
            if (erUserPicture == null)
            {
                return NotFound();
            }
            return View(erUserPicture);
        }

        // POST: ErUserPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PictureUrl")] ErUserPicture erUserPicture)
        {
            if (id != erUserPicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(erUserPicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErUserPictureExists(erUserPicture.Id))
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
            return View(erUserPicture);
        }

        // GET: ErUserPictures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserPicture = await _context.ErUserPictures
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erUserPicture == null)
            {
                return NotFound();
            }

            return View(erUserPicture);
        }

        // POST: ErUserPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var erUserPicture = await _context.ErUserPictures.FindAsync(id);
            _context.ErUserPictures.Remove(erUserPicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErUserPictureExists(Guid id)
        {
            return _context.ErUserPictures.Any(e => e.Id == id);
        }
    }
}
