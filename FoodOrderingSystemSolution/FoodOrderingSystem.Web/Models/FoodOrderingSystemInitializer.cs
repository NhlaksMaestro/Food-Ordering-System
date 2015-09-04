using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FoodOrderingSystem.Web.Models
{
    public class FoodOrderingSystemInitializer : DropCreateDatabaseAlways<FoodOrderingSystemContext>
    {
        protected override void Seed(FoodOrderingSystemContext context)
        {
            this.customers().ForEach(customer => context.Customers.Add(customer));
            //context.SaveChanges();
            this.MenuCategories().ForEach(menuCategory => context.MenuCategories.Add(menuCategory));
            //context.SaveChanges();
            base.Seed(context);
        }
        private List<CustomerModel> customers()
        {
            var CustomerModelsEntityData = new List<CustomerModel>()
            {
                new CustomerModel{ 
                    CustomerId = 1,
                    FirstName = "Mabongi",
                    LastName = "Mkhize", 
                    Phone = "0117822345", 
                    Address = "2434 Drago Street",
                    Orders = new List<OrderModel>(){
                        new OrderModel{
                            OrderId = 1,
                            Name = "Order 1",
                            OrderStatus = new OrderStatusModel{
                                OrderStatusId = 1,
                                Status = "received"
                            }
                        }
                    }
                },
                new CustomerModel{ 
                    CustomerId = 2,
                    FirstName = "Basetsana",
                    LastName = "Lerumo", 
                    Phone = "014549383", 
                    Address = "345 Domino Street",
                      Orders =   new List<OrderModel>()
                      {
                          new OrderModel{
                            OrderId = 2,
                            Name = "Order 2",
                            OrderStatus = new OrderStatusModel{
                                OrderStatusId = 1,
                                Status = "received"
                            }
                      }
                  }
                },
                new CustomerModel{ 
                    CustomerId = 3,
                    FirstName = "Mabongi",
                    LastName = "Mkhize", 
                    Phone = "0193345567", 
                    Address = "5678 Yehla Street",
                   Orders = new List<OrderModel>(){
                       new OrderModel{ OrderId = 3,
                           Name = "Order 3",
                           OrderStatus = new OrderStatusModel{
                               OrderStatusId = 1,
                               Status = "received"
                           }
                       }
                   }
                }
            };
            return CustomerModelsEntityData;
        }
        private List<string> GetNames()
        {
            return new List<string>();
        }
        private List<MenuCategoryModel> MenuCategories()
        {
            var menuCategoriesEntityData = new List<MenuCategoryModel>()
            {
                new MenuCategoryModel{ 
                    MenuCategoryId = 1,
                    CategoryName = "soup".ToUpper(),
                    ImagePath = "",
                    MenuItems = new List<MenuItemModel>(){
                       new MenuItemModel{
                        MenuItemId = 1,
                        Name = "ukrainian-borsch-soup".Replace('-', ' ').ToUpper(),
                        Description = "Soup Created in Ukraine now available World Wide.",
                        ImageName = "ukrainian-borsch-soup.gif",
                        Price = 49.99,
                        MenuCategoryId = 1,
                        ImagePath = "category/soup/"
                       }
                    }
                },
                new MenuCategoryModel{ 
                    MenuCategoryId = 2,
                    CategoryName = "Desert".ToUpper(),
                    ImagePath = "",
                    MenuItems = new List<MenuItemModel>(){
                       new MenuItemModel{
                        MenuItemId = 2,
                        Name = "baked-pumpkin-desert".Replace('-', ' ').ToUpper(),
                        Description = "Pumpkin filled pie with chocolate dressing.",
                        ImageName = "baked-pumpkin-desert.gif",
                        Price = 49.99,
                        MenuCategoryId = 2,
                        ImagePath = "category/desert/"
                       },
                       new MenuItemModel{
                        MenuItemId = 3,
                        Name = "banana-split-with-ice-cream-desert".Replace('-', ' ').ToUpper(),
                        Description = "A Banana and ice cream combo that will leave you wanting more.",
                        ImageName = "banana-split-with-ice-cream-desert.gif",
                        Price = 49.99,
                        MenuCategoryId = 2,
                        ImagePath = "category/desert/"
                       },
                       new MenuItemModel{
                        MenuItemId = 4,
                        Name = "cheesecake-with-icecream-desert".Replace('-', ' ').ToUpper(),
                        Description = "A cheese cake with ice cream combo that will leave you wanting more.",
                        ImageName = "cheesecake-with-icecream-desert.gif",
                        Price = 49.99,
                        MenuCategoryId = 2,
                        ImagePath = "category/desert/"
                       }
                    }
                },
                new MenuCategoryModel{ 
                    MenuCategoryId = 3,
                    CategoryName = "salad".ToUpper(),
                    ImagePath = "category/salad/",
                    MenuItems = new List<MenuItemModel>(){
                       new MenuItemModel{
                        MenuItemId = 5,
                        Name = "diet-bread-salad".Replace('-', ' ').ToUpper(),
                        Description = "A diet bread salad made for everyone who wants a salad.",
                        ImageName = "diet-bread-salad.gif",
                        Price = 49.99,
                        MenuCategoryId = 2,
                        ImagePath = "category/desert/"
                       },
                       new MenuItemModel{
                        MenuItemId = 5,
                        Name = "roasted-meat-beans-pepper-salad".Replace('-', ' ').ToUpper(),
                        Description = "A salad made to taste good with a combination of different goodies.",
                        ImageName = "roasted-meat-beans-pepper-salad.gif",
                        Price = 49.99,
                        MenuCategoryId = 2,
                        ImagePath = "category/desert/"
                       }
                    }
                }//,
                //new MenuCategory{ 
                //    MenuCategoryId = 4,
                //    CategoryName = "drinks".ToUpper(),
                //    ImagePath = "",
                //    MenuItems = new List<MenuItem>(){
                //       new MenuItem{
                //        MenuCategoryId = 1
                //       }
                //    }
                //},
                //new MenuCategory{ 
                //    MenuCategoryId = 5,
                //    CategoryName = "Other".ToUpper(),
                //    ImagePath = "",
                //    MenuItems = new List<MenuItem>(){
                //       new MenuItem{
                //        MenuCategoryId = 1
                //       }
                //    }
                //},
            };
            return menuCategoriesEntityData;
        }
    }
}
