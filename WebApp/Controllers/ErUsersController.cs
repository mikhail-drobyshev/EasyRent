using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain.App;
using Extensions.Base;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize]
    public class ErUsersController : Controller
    {
        private readonly IAppUnitOfWork _uow;
        private readonly AppDbContext _context;

        public ErUsersController(IAppUnitOfWork uow, AppDbContext context)
        {
            _context = context;
            _uow = uow;

        }

        // GET: ErUsers
        public async Task<IActionResult> Index()
        {
            var res = await _uow.ErUsers.GetAllAsync();
            return View(res);
        }

        // GET: ErUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _uow.ErUsers.FirstOrDefaultAsync(id.Value);
            if (erUser == null)
            {
                return NotFound();
            }

            return View(erUser);
        }

        // GET: ErUsers/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "id", "Email");
            return View();
        }

        // POST: ErUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErUser erUser)
        {
            ViewData["AppUserId"] = new SelectList(_context.Users, "id", "Email");
            if (ModelState.IsValid)
            {
                erUser.AppUserId = User.GetUserId()!.Value;
                _uow.ErUsers.Add(erUser);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erUser);
        }

        // GET: ErUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _uow.ErUsers.FirstOrDefaultAsync(id.Value);
            if (erUser == null)
            {
                return NotFound();
            }
            ViewData["ErUserPictureId"] = new SelectList(await _uow.ErUserPictures.GetAllAsync(), "Id", "PictureUrl", erUser.Id);
            ViewData["GenderId"] = new SelectList(await _uow.Genders.GetAllAsync(), "Id", "GenderValue", erUser.Id);
            return View(erUser);
        }

        // POST: ErUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ErUser erUser)
        {
            if (id != erUser.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid || !await _uow.ErUsers.ExistsAsync(erUser.Id, User.GetUserId()!.Value))
                return View(erUser);

            erUser.AppUserId = User.GetUserId()!.Value;
            _uow.ErUsers.Update(erUser);
            await _uow.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ErUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _uow.ErUsers.FirstOrDefaultAsync(id.Value);
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
            await _uow.ErUsers.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
