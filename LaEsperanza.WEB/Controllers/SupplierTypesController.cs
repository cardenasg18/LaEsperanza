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
    public class SupplierTypesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext _context;

        public SupplierTypesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: Clasifications
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupplierType.ToListAsync());
        }

        // GET: SupplierTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierType
                .FirstOrDefaultAsync(m => m.SupplierTypeId == id);
            if (supplierType == null)
            {
                return NotFound();
            }

            return View(supplierType);
        }

        // GET: SupplierTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupplierTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierTypeId,Type")] SupplierType supplierType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplierType);
        }

        // GET: SupplierTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierType.FindAsync(id);
            if (supplierType == null)
            {
                return NotFound();
            }
            return View(supplierType);
        }

        // POST: SupplierTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierTypeId,Type")] SupplierType supplierType)
        {
            if (id != supplierType.SupplierTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierTypeExists(supplierType.SupplierTypeId))
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
            return View(supplierType);
        }

        // GET: SupplierTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierType = await _context.SupplierType
                .FirstOrDefaultAsync(m => m.SupplierTypeId == id);
            if (supplierType == null)
            {
                return NotFound();
            }

            return View(supplierType);
        }

        // POST: SupplierTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierType = await _context.SupplierType.FindAsync(id);
            _context.SupplierType.Remove(supplierType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierTypeExists(int id)
        {
            return _context.SupplierType.Any(e => e.SupplierTypeId == id);
        }
    }
}
