using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FoodOrderingSystem.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FoodOrderingSystem.DataStore
{
    public class FoodOrderingSystemContext : DbContext
    {
        public FoodOrderingSystemContext()
            : base("FoodOrderingSystemContext")
        {
            //Database.SetInitializer<FoodOrderingSystemContext>(new CreateDatabaseIfNotExists<FoodOrderingSystemContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderedItem> OrderedItems { get; set; }
    }
}