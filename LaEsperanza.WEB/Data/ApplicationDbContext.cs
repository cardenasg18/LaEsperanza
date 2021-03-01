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
        public DbSet<LaEsperanza.WEB.Models.OrderDetail> OrderDetail { get; set; }
        public DbSet<LaEsperanza.WEB.Models.Order> Order { get; set; }
    }
}
