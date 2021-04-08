using System;
using System.Collections.Generic;
using System.Text;
using LaEsperanza.WEB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaEsperanza.WEB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Clasification> Clasifications { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<LaEsperanza.WEB.Models.SupplierType> SupplierType { get; set; }
        public DbSet<LaEsperanza.WEB.Models.Unit> Unit { get; set; }
        public DbSet<ItemWithImage> ItemWithImages { get; set; }
    }
}
