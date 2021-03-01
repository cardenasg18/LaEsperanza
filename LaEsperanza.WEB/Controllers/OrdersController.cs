using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaEsperanza.WEB.Data;
using LaEsperanza.WEB.Models;
using LaEsperanza.WEB.ViewModels;



namespace LaEsperanza.WEB.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Order.Include(o => o.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            var orderview = new OrderView();
            var orderdetail = new OrderDetail();

            orderview.Order = await _context.Order
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.OrderId == id);

            var dataorder = _context.OrderDetail.Include(od => od.Order).Include(od => od.Product).Where(od => od.OrderId.Equals(id)).ToList();
            orderview.Details = dataorder;

            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", orderdetail.OrderId);
            ViewData["ProductiD"] = new SelectList(_context.Products, "ProductiD", "ProductName", orderdetail.ProductiD);

            return View(orderview);

        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,SupplierId,OrderTime,comentario,SubTotal,Valueimp")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", order.SupplierId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", order.SupplierId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,SupplierId,OrderTime,comentario,SubTotal,Valueimp")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", order.SupplierId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);

        }

        //POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }

        public async Task<IActionResult> AdicionarProducto([Bind("DetailId,ProductiD,Quantity,UnitPrice,TotalValue,OrderId")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);

                int id = orderDetail.OrderId;
                int id_producto = orderDetail.ProductiD;

                Product product = _context.Products.Find(id_producto);
                decimal precio = product.PriceP;
                product.Cantidad += Convert.ToInt32(orderDetail.Quantity);
                _context.Update(product);
                _context.SaveChanges();

                decimal cantidad = Convert.ToDecimal(orderDetail.Quantity);
                decimal preciot = cantidad * Convert.ToDecimal(precio);
                decimal impuesto;

                orderDetail.UnitPrice = Convert.ToInt32(precio);
                orderDetail.TotalValue = preciot;

                await _context.SaveChangesAsync();

                Order order = _context.Order.Find(id);
                order.SubTotal += preciot;
                order.Valueimp = Convert.ToDecimal(0.18);
                decimal precioimp = order.Valueimp;
                impuesto = preciot * precioimp;
                order.Valueimp = impuesto;
                preciot = preciot + impuesto;
                order.TotalValue += preciot;
                _context.Update(order);
                _context.SaveChanges();

                return RedirectToAction("Details", new { id = id });

            }

            ViewData["ProductiD"] = new SelectList(_context.Products, "ProductiD", "ProductName", orderDetail.ProductiD);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", orderDetail.OrderId);
            return View(orderDetail);

        }

        public async Task<IActionResult> PrintPDF(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            var orderview = new OrderView();
            var orderdetail = new OrderDetail();

            orderview.Order = await _context.Order
                .Include(o => o.Supplier)
                .FirstOrDefaultAsync(m => m.OrderId == id);

            var dataorder = _context.OrderDetail.Include(od => od.Order).Include(od => od.Product).Where(od => od.OrderId.Equals(id)).ToList();
            orderview.Details = dataorder;

            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", orderdetail.OrderId);
            ViewData["ProductiD"] = new SelectList(_context.Products, "ProductiD", "ProductName", orderdetail.ProductiD);

            return View(orderview);

        }
    }

}
