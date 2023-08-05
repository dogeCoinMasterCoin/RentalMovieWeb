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
    public class UserAppsController : Controller
    {
        private readonly MovieContext _context;

        public UserAppsController(MovieContext context)
        {
            _context = context;
        }

        // GET: UserApps
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserApps.ToListAsync());
        }

        // GET: UserApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApp = await _context.UserApps
                .FirstOrDefaultAsync(m => m.UserAppId == id);
            if (userApp == null)
            {
                return NotFound();
            }

            return View(userApp);
        }

        // GET: UserApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserApps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserAppId,Username,Password,Email")] UserApp userApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userApp);
        }

        // GET: UserApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApp = await _context.UserApps.FindAsync(id);
            if (userApp == null)
            {
                return NotFound();
            }
            return View(userApp);
        }

        // POST: UserApps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserAppId,Username,Password,Email")] UserApp userApp)
        {
            if (id != userApp.UserAppId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAppExists(userApp.UserAppId))
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
            return View(userApp);
        }

        // GET: UserApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userApp = await _context.UserApps
                .FirstOrDefaultAsync(m => m.UserAppId == id);
            if (userApp == null)
            {
                return NotFound();
            }

            return View(userApp);
        }

        // POST: UserApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userApp = await _context.UserApps.FindAsync(id);
            _context.UserApps.Remove(userApp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAppExists(int id)
        {
            return _context.UserApps.Any(e => e.UserAppId == id);
        }
    }
}
