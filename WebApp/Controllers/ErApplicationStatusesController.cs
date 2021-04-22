using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.DTO;
using Extensions.Base;

namespace WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ErApplicationStatusesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uow"></param>
        public ErApplicationStatusesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ErApplicationStatuses
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var res = await _uow.ErApplicationStatuses.GetAllAsync();
            await _uow.SaveChangesAsync();
            return View(res);
        }

        // GET: ErApplicationStatuses/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplicationStatus = await _uow.ErApplicationStatuses.FirstOrDefaultAsync(id.Value);
            if (erApplicationStatus == null)
            {
                return NotFound();
            }

            return View(erApplicationStatus);
        }

        // GET: ErApplicationStatuses/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: ErApplicationStatuses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="erApplicationStatus"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ErApplicationStatus erApplicationStatus)
        {
            if (ModelState.IsValid)
            {
                _uow.ErApplicationStatuses.Add(erApplicationStatus);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erApplicationStatus);
        }

        // GET: ErApplicationStatuses/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplicationStatus = await _uow.ErApplicationStatuses.FirstOrDefaultAsync(id.Value);
            if (erApplicationStatus == null)
            {
                return NotFound();
            }
            return View(erApplicationStatus);
        }

        // POST: ErApplicationStatuses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="erApplicationStatus"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ErApplicationStatus erApplicationStatus)
        {
            if (id != erApplicationStatus.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(erApplicationStatus);
            
            _uow.ErApplicationStatuses.Update(erApplicationStatus);
            await _uow.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: ErApplicationStatuses/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erApplicationStatus = await _uow.ErApplicationStatuses.FirstOrDefaultAsync(id.Value);
            if (erApplicationStatus == null)
            {
                return NotFound();
            }

            return View(erApplicationStatus);
        }

        // POST: ErApplicationStatuses/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _uow.ErApplicationStatuses.RemoveAsync(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
