using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FoodOrderingSystem.Web.Models
{
    public class FoodOrderingSystemContext : DbContext
    {
        public FoodOrderingSystemContext()
            : base("FoodOrderingSystemContext")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
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

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<MenuCategoryModel> MenuCategories { get; set; }
        public DbSet<MenuItemModel> MenuItems { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderStatusModel> OrderStatuses { get; set; }
        public DbSet<OrderedItemModel> OrderedItems { get; set; }
    }
}