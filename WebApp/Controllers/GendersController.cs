using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.DTO;

namespace WebApp.Controllers
{
    public class GendersController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public GendersController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Genders
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Genders.GetAllAsync();
            return View(res);
        }

        // GET: Genders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await _uow.Genders
                .FirstOrDefaultAsync(id.Value);
            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                _uow.Genders.Add(gender);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gender);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await _uow.Genders.FirstOrDefaultAsync(id.Value);
            if (gender == null)
            {
                return NotFound();
            }
            return View(gender);
        }

        // POST: Genders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Gender gender)
        {
            if (id != gender.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(gender);
            
            _uow.Genders.Update(gender);
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gender = await _uow.Genders
                .FirstOrDefaultAsync(id.Value);
            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.Genders.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
