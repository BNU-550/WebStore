using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Data
{
    public class WebStoreDbContext : DbContext
    {


        public WebStoreDbContext(DbContextOptions<WebStoreDbContext> options) : base(options)
        {
        }



        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().ToTable("Phone");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
        }


    }
}