using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLL.App.DTO;
using Extensions.Base;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels.ErUsers;

namespace WebApp.Controllers
{
    [Authorize]
    public class ErUsersController : Controller
    {
        private readonly IAppBLL _bll;

        public ErUsersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: ErUsers
        public async Task<IActionResult> Index()
        {
            //TODO figure out why gender is empty
            var res = await _bll.ErUsers.GetAllWithPropertyTypeCountAsync(User.GetUserId()!.Value);
            return View(res);
        }

        // GET: ErUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _bll.ErUsers.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (erUser == null)
            {
                return NotFound();
            }

            return View(erUser);
        }

        // GET: ErUsers/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new ErUsersCreatEditViewModel();
            viewModel.GenderSelectList = new SelectList(await _bll.Genders.GetAllAsync(), nameof(Gender.Id), nameof(Gender.GenderValue));
            return View(viewModel);
        }

        // POST: ErUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErUser erUser, ErUsersCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                erUser.AppUserId = User.GetUserId()!.Value;
                _bll.ErUsers.Add(erUser);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.GenderSelectList = new SelectList(await _bll.Genders.GetAllAsync(), nameof(Gender.Id), nameof(Gender.GenderValue));
            return View(viewModel);
        }

        // GET: ErUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _bll.ErUsers.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (erUser == null)
            {
                return NotFound();
            } 
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

            if (!ModelState.IsValid || !await _bll.ErUsers.ExistsAsync(erUser.Id, User.GetUserId()!.Value))
                return View(erUser);

            erUser.AppUserId = User.GetUserId()!.Value;
            _bll.ErUsers.Update(erUser);
            await _bll.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: ErUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUser = await _bll.ErUsers.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
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
            await _bll.ErUsers.RemoveAsync(id, User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
