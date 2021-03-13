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
    public class ErUsersController : Controller
    {
        private readonly AppDbContext _context;

        public ErUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ErUsers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ErUsers.Include(e => e.ErUserPicture).Include(e => e.Gender);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ErUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _context.ErUsers
                .Include(e => e.ErUserPicture)
                .Include(e => e.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erUser == null)
            {
                return NotFound();
            }

            return View(erUser);
        }

        // GET: ErUsers/Create
        public IActionResult Create()
        {
            ViewData["ErUserPictureId"] = new SelectList(_context.ErUserPictures, "Id", "PictureUrl");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderValue");
            return View();
        }

        // POST: ErUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ErUserPictureId,ErUserTypeId,GenderId")] ErUser erUser)
        {
            if (ModelState.IsValid)
            {
                erUser.Id = Guid.NewGuid();
                _context.Add(erUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ErUserPictureId"] = new SelectList(_context.ErUserPictures, "Id", "PictureUrl", erUser.ErUserPictureId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderValue", erUser.GenderId);
            return View(erUser);
        }

        // GET: ErUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _context.ErUsers.FindAsync(id);
            if (erUser == null)
            {
                return NotFound();
            }
            ViewData["ErUserPictureId"] = new SelectList(_context.ErUserPictures, "Id", "PictureUrl", erUser.ErUserPictureId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderValue", erUser.GenderId);
            return View(erUser);
        }

        // POST: ErUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,ErUserPictureId,ErUserTypeId,GenderId")] ErUser erUser)
        {
            if (id != erUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(erUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErUserExists(erUser.Id))
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
            ViewData["ErUserPictureId"] = new SelectList(_context.ErUserPictures, "Id", "PictureUrl", erUser.ErUserPictureId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderValue", erUser.GenderId);
            return View(erUser);
        }

        // GET: ErUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _context.ErUsers
                .Include(e => e.ErUserPicture)
                .Include(e => e.Gender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erUser == null)
            {
                return NotFound();
            }

            return View(erUser);
        }

        // POST: ErUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var erUser = await _context.ErUsers.FindAsync(id);
            _context.ErUsers.Remove(erUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErUserExists(Guid id)
        {
            return _context.ErUsers.Any(e => e.Id == id);
        }
    }
}
