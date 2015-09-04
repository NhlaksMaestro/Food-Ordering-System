using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FoodOrderingSystem.Entities;

namespace FoodOrderingSystem.DataStore
{
    public class FoodOrderingSystemDBContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MenuCategory> MenuCategories { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderedItem> OrderedItems { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderStatuses>()
        //        .HasMany(a => a.Employees)
        //        .WithMany(b => b.Jobs)
        //        .Map(m =>
        //        {
        //            m.ToTable("EmployeeJobs");
        //            m.MapLeftKey("EmployeeId");
        //            m.MapRightKey("JobId");
        //        });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}