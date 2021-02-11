using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestOrderApplication.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext() : base("OrderDB")
        {
            Database.SetInitializer(new OrderDbInitializer());
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Provider> Provider { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().Property(x => x.Quantity).HasPrecision(18, 3);
            //modelBuilder.Entity<Order>().Property(x => x.Number).IsRequired;
        }
    }
   
}