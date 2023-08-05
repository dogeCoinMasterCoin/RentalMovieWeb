using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Data1.Controllers
{
    //[Authorize]
    [Authorize(Roles = "Administrator")]
    public class UserWatchListsController : Controller
    {
        private readonly MovieContext _context;

        public UserWatchListsController(MovieContext context)
        {
            _context = context;
        }

        // GET: UserWatchLists
        public async Task<IActionResult> Index()
        {
            var movieContext = _context.UserWatchLists.Include(u => u.UserApp).Include(u => u.WatchList);
            return View(await movieContext.ToListAsync());
        }

        // GET: UserWatchLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWatchList = await _context.UserWatchLists
                .Include(u => u.UserApp)
                .Include(u => u.WatchList)
                .FirstOrDefaultAsync(m => m.UserWatchListId == id);
            if (userWatchList == null)
            {
                return NotFound();
            }

            return View(userWatchList);
        }

        // GET: UserWatchLists/Create
        public IActionResult Create()
        {
            ViewData["UserAppId"] = new SelectList(_context.UserApps, "UserAppId", "UserAppId");
            ViewData["WatchListId"] = new SelectList(_context.WatchLists, "WatchListId", "WatchListId");
            return View();
        }

        // POST: UserWatchLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserWatchListId,WatchListId,UserAppId")] UserWatchList userWatchList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userWatchList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserAppId"] = new SelectList(_context.UserApps, "UserAppId", "UserAppId", userWatchList.UserAppId);
            ViewData["WatchListId"] = new SelectList(_context.WatchLists, "WatchListId", "WatchListId", userWatchList.WatchListId);
            return View(userWatchList);
        }

        // GET: UserWatchLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWatchList = await _context.UserWatchLists.FindAsync(id);
            if (userWatchList == null)
            {
                return NotFound();
            }
            ViewData["UserAppId"] = new SelectList(_context.UserApps, "UserAppId", "UserAppId", userWatchList.UserAppId);
            ViewData["WatchListId"] = new SelectList(_context.WatchLists, "WatchListId", "WatchListId", userWatchList.WatchListId);
            return View(userWatchList);
        }

        // POST: UserWatchLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserWatchListId,WatchListId,UserAppId")] UserWatchList userWatchList)
        {
            if (id != userWatchList.UserWatchListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userWatchList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserWatchListExists(userWatchList.UserWatchListId))
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
            ViewData["UserAppId"] = new SelectList(_context.UserApps, "UserAppId", "UserAppId", userWatchList.UserAppId);
            ViewData["WatchListId"] = new SelectList(_context.WatchLists, "WatchListId", "WatchListId", userWatchList.WatchListId);
            return View(userWatchList);
        }

        // GET: UserWatchLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userWatchList = await _context.UserWatchLists
                .Include(u => u.UserApp)
                .Include(u => u.WatchList)
                .FirstOrDefaultAsync(m => m.UserWatchListId == id);
            if (userWatchList == null)
            {
                return NotFound();
            }

            return View(userWatchList);
        }

        // POST: UserWatchLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userWatchList = await _context.UserWatchLists.FindAsync(id);
            _context.UserWatchLists.Remove(userWatchList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserWatchListExists(int id)
        {
            return _context.UserWatchLists.Any(e => e.UserWatchListId == id);
        }
    }
}
