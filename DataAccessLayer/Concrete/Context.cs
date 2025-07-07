using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BARANPC\\SQLEXPRESS;Database=DbDemoProductOopCore;integrated security=True; TrustServerCertificate=True;");
        }
        public DbSet<Product> Products { get; set; } // Product C#daki hali products ise veritabanındaki tablo adı
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}

