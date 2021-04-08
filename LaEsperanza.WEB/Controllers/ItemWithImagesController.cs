using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaEsperanza.WEB.Data;
using LaEsperanza.WEB.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LaEsperanza.WEB.Controllers
{
    public class ItemWithImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostingEnvironment _hostEnvironment;

        public ItemWithImagesController(ApplicationDbContext context, IHostingEnvironment hostEnvironment, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: ItemWithImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemWithImages.ToListAsync());
        }

        // GET: ItemWithImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemWithImage = await _context.ItemWithImages
                .FirstOrDefaultAsync(m => m.UserProductID == id);
            if (itemWithImage == null)
            {
                return NotFound();
            }

            return View(itemWithImage);
        }

        // GET: ItemWithImages/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemWithImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public async Task<IActionResult> Create([Bind("UserProductID,ImageFile,Title,ProductName,Description,PriceP,Presentation")] ItemWithImage itemWithImage)
        {
            if (ModelState.IsValid)
            {
                // Save image to wwwroot/UserImages
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(itemWithImage.ImageFile.FileName);
                string extension = Path.GetExtension(itemWithImage.ImageFile.FileName);
                itemWithImage.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/UserImages/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await itemWithImage.ImageFile.CopyToAsync(fileStream);
                }

                // Insert record
                _context.Add(itemWithImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemWithImage);
        }

        // GET: ItemWithImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemWithImage = await _context.ItemWithImages.FindAsync(id);
            if (itemWithImage == null)
            {
                return NotFound();
            }
            return View(itemWithImage);
        }

        // POST: ItemWithImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserProductID,ImageName,Title,ProductName,Description,PriceP,Presentation")] ItemWithImage itemWithImage)
        {
            if (id != itemWithImage.UserProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemWithImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemWithImageExists(itemWithImage.UserProductID))
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
            return View(itemWithImage);
        }

        // GET: ItemWithImages/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemWithImage = await _context.ItemWithImages
                .FirstOrDefaultAsync(m => m.UserProductID == id);
            if (itemWithImage == null)
            {
                return NotFound();
            }

            return View(itemWithImage);
        }

        // POST: ItemWithImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemWithImage = await _context.ItemWithImages.FindAsync(id);

            // Delete image from wwwroot/UserImages
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "UserImages", itemWithImage.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            // Delete the record
            _context.ItemWithImages.Remove(itemWithImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemWithImageExists(int id)
        {
            return _context.ItemWithImages.Any(e => e.UserProductID == id);
        }
    }
}
