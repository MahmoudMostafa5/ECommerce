using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Database
{
    public class ProductContext:IdentityDbContext
    {
        public ProductContext(DbContextOptions<ProductContext> opts):base(opts){  }

        public DbSet<product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=MAHMOUDMOSTAFA\\SQLEXPRESS ; database=Ecommerce; Trusted_Connection=True");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderProduct>().HasKey(a => new { a.OrderId, a.ProductId });
        //    modelBuilder.Entity<OrderProduct>().HasOne(a => a.Order).WithMany(a => a.orderProducts).HasForeignKey(a => a.OrderId);
        //    modelBuilder.Entity<OrderProduct>().HasOne(a => a.product).WithMany(a => a.OrderProducts).HasForeignKey(a => a.ProductId);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderProduct>().HasKey(a => new { a.OrderId, a.ProductId });
            modelBuilder.Entity<OrderProduct>().HasOne(a => a.Order).WithMany(a => a.orderProducts).HasForeignKey(a => a.OrderId);
            modelBuilder.Entity<OrderProduct>().HasOne(a => a.product).WithMany(a => a.OrderProducts).HasForeignKey(a => a.ProductId);
        }
    }
}
