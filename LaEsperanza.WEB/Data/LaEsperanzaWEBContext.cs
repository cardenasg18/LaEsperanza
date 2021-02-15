using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaEsperanza.WEB.Models;

namespace LaEsperanza.WEB.Data
{
    public class LaEsperanzaWEBContext : DbContext
    {
        public LaEsperanzaWEBContext (DbContextOptions<LaEsperanzaWEBContext> options)
            : base(options)
        {
        }

        public DbSet<LaEsperanza.WEB.Models.Customer> Customer { get; set; }

        public DbSet<LaEsperanza.WEB.Models.Clasification> Clasification { get; set; }

        public DbSet<LaEsperanza.WEB.Models.Item> Item { get; set; }

        public DbSet<LaEsperanza.WEB.Models.DocumentType> DocumentType { get; set; }
    }
}
