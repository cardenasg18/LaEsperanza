using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaEsperanza.WEB.Data;
using LaEsperanza.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LaEsperanza.WEB.Controllers
{
    public class ClasificationsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;

        public ClasificationsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: Clasifications
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clasifications.ToListAsync());
        }

        // GET: Clasifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasification = await _context.Clasifications
                .FirstOrDefaultAsync(m => m.ClasificationId == id);
            if (clasification == null)
            {
                return NotFound();
            }

            return View(clasification);
        }

        // GET: Clasifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clasifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasificationId,ItemType")] Clasification clasification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(clasification);
        }

        // GET: Clasifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasification = await _context.Clasifications.FindAsync(id);
            if (clasification == null)
            {
                return NotFound();
            }
            return View(clasification);
        }

        // POST: Clasifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasificationId,ItemType")] Clasification clasification)
        {
            if (id != clasification.ClasificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificationExists(clasification.ClasificationId))
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
            return View(clasification);
        }

        // GET: Clasifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasification = await _context.Clasifications
                .FirstOrDefaultAsync(m => m.ClasificationId == id);
            if (clasification == null)
            {
                return NotFound();
            }

            return View(clasification);
        }

        // POST: Clasifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clasification = await _context.Clasifications.FindAsync(id);
            _context.Clasifications.Remove(clasification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificationExists(int id)
        {
            return _context.Clasifications.Any(e => e.ClasificationId == id);
        }
    }
}
