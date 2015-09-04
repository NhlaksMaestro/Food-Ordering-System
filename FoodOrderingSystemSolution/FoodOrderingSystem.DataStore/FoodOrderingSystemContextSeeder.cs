using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FoodOrderingSystem.Entity;

namespace FoodOrderingSystem.DataStore
{
    public class FoodOrderingSystemContextSeeder : CreateDatabaseIfNotExists<FoodOrderingSystemContext>
    {
        protected override void Seed(FoodOrderingSystemContext context)
        {
            this.Customers().ForEach(customer => context.Customers.Add(customer));
            this.MenuCategories().ForEach(menuCategory => context.MenuCategories.Add(menuCategory));
            //this.MenuItems().ForEach(menuItem => context.MenuItems.Add(menuItem));
            base.Seed(context);
        }
        private List<Customer> Customers()
        {
            var customersEntityData = new List<Customer>()
            {
                new Customer{ 
                    //CustomerId = 1,
                    FirstName = "Mabongi",
                    LastName = "Mkhize", 
                    Phone = "0117822345", 
                    Address = "2434 Drago Street",
                    Orders = new List<Order>(){
                        new Order{
                            OrderId = 1,
                            Name = "Order 1",
                            AmountPaid = 50.00,
                            DateOrdered = new DateTime(2014, 1, 18),
                            DateReceived = new DateTime(2014, 1, 18),
                            OrderStatus = new OrderStatus{
                                OrderStatusId = 1,
                                Status = "received"
                            }
                        }
                    }
                },
                new Customer{ 
                    //CustomerId = 2,
                    FirstName = "Basetsana",
                    LastName = "Lerumo", 
                    Phone = "014549383", 
                    Address = "345 Domino Street",
                      Orders =   new List<Order>()
                      {
                          new Order{
                            OrderId = 2,
                            Name = "Order 2",
                            DateOrdered = new DateTime(2014, 1, 18),
                            DateReceived = new DateTime(2014, 1, 18),
                            AmountPaid = 50.00,
                            OrderStatus = new OrderStatus{
                                OrderStatusId = 1,
                                Status = "received"
                            }
                      }
                  }
                },
                new Customer{ 
                    //CustomerId = 3,
                    FirstName = "Mabongi",
                    LastName = "Mkhize", 
                    Phone = "0193345567", 
                    Address = "5678 Yehla Street",
                   Orders = new List<Order>(){
                       new Order{
                           OrderId = 3,
                           Name = "Order 3",
                            AmountPaid = 50.00,
                           DateOrdered = new DateTime(2014, 1, 18),
                           DateReceived = new DateTime(2014, 1, 18),
                           OrderStatus = new OrderStatus{
                               OrderStatusId = 1,
                               Status = "received"
                           }
                       }
                   }
                }
            };
            return customersEntityData;
        }
        private List<string> GetNames()
        {
            return new List<string>();
        }
        private List<MenuCategory> MenuCategories()
        {
            var menuCategoriesEntityData = new List<MenuCategory>()
            {
                new MenuCategory{ 
                    //MenuCategoryId = 1,
                    CategoryName = "soup".ToUpper(),
                    ImagePath = "category/",
                    MenuItems = new List<MenuItem>(){
                       //new MenuItem{
                       // //MenuItemId = 1,
                       // Name = "ukrainian-borsch-soup".Replace('-', ' ').ToUpper(),
                       // Description = "Soup Created in Ukraine now available World Wide.",
                       // ImageName = "ukrainian-borsch-soup.gif",
                       // Price = 49.99,
                       // OrderedItems = new List<OrderedItem>(){},
                       // MenuCategoryId = 1,
                       // ImagePath = "category/soup/",     
                       // //MenuCategory = new MenuCategory()
                       //}
                    }
                },
                new MenuCategory{ 
                    //MenuCategoryId = 2,
                    CategoryName = "Desert".ToUpper(),
                    ImagePath = "category",
                    MenuItems = new List<MenuItem>(){
                       //new MenuItem{
                       // MenuItemId = 2,
                       // Name = "baked-pumpkin-desert".Replace('-', ' ').ToUpper(),
                       // Description = "Pumpkin filled pie with chocolate dressing.",
                       // ImageName = "baked-pumpkin-desert.gif",
                       // Price = 49.99,
                        //MenuCategoryId = 2,
                       // ImagePath = "category/desert/"
                       //},
                       //new MenuItem{
                       // MenuItemId = 3,
                       // Name = "banana-split-with-ice-cream-desert".Replace('-', ' ').ToUpper(),
                       // Description = "A Banana and ice cream combo that will leave you wanting more.",
                       // ImageName = "banana-split-with-ice-cream-desert.gif",
                       // Price = 49.99,
                       // //MenuCategoryId = 2,
                       // ImagePath = "category/desert/"
                       //},
                       //new MenuItem{
                       // MenuItemId = 4,
                       // Name = "cheesecake-with-icecream-desert".Replace('-', ' ').ToUpper(),
                       // Description = "A cheese cake with ice cream combo that will leave you wanting more.",
                       // ImageName = "cheesecake-with-icecream-desert.gif",
                       // Price = 49.99,
                       // //MenuCategoryId = 2,
                       // ImagePath = "category/desert/"
                       //}
                    }
                },
                new MenuCategory{ 
                    //MenuCategoryId = 3,
                    CategoryName = "salad".ToUpper(),
                    ImagePath = "category/",
                    MenuItems = new List<MenuItem>(){
                       //new MenuItem{
                       // MenuItemId = 5,
                       // Name = "diet-bread-salad".Replace('-', ' ').ToUpper(),
                       // Description = "A diet bread salad made for everyone who wants a salad.",
                       // ImageName = "diet-bread-salad.gif",
                       // Price = 49.99,
                       // //MenuCategoryId = 3,
                       // ImagePath = "category/salad/"
                       //},
                       //new MenuItem{
                       // MenuItemId = 6,
                       // Name = "roasted-meat-beans-pepper-salad".Replace('-', ' ').ToUpper(),
                       // Description = "A salad made to taste good with a combination of different goodies.",
                       // ImageName = "roasted-meat-beans-pepper-salad.gif",
                       // Price = 49.99,
                       // //MenuCategoryId = 3,
                       // ImagePath = "category/salad/"
                       //}
                    }
                },
                new MenuCategory{ 
                    //MenuCategoryId = 4,
                    CategoryName = "drinks".ToUpper(),
                    ImagePath = "category",
                    MenuItems = new List<MenuItem>(){
                       //new MenuItem{
                       // //MenuCategoryId = 1
                       //}
                    }
                },
                new MenuCategory{ 
                    //MenuCategoryId = 5,
                    CategoryName = "Other".ToUpper(),
                    ImagePath = "category",
                    MenuItems = new List<MenuItem>(){
                       //new MenuItem{
                       // //MenuCategoryId = 1
                       //}
                    }
                }
            };
            return menuCategoriesEntityData;
        }
        //private List<MenuItem> MenuItems()
        //{
        //    var menuItemsEntityData = new List<MenuItem>()
        //    {
        //        new MenuItem{
        //                //MenuItemId = 1,
        //                Name = "ukrainian-borsch-soup".Replace('-', ' ').ToUpper(),
        //                Description = "Soup Created in Ukraine now available World Wide.",
        //                ImageName = "ukrainian-borsch-soup.gif",
        //                Price = 49.99,
        //                OrderedItems = new List<OrderedItem>(){},
        //                MenuCategoryId = 1,
        //                ImagePath = "category/soup/",     
        //                //MenuCategory = new MenuCategory()
        //               },
        //               new MenuItem{
        //                //MenuItemId = 2,
        //                Name = "baked-pumpkin-desert".Replace('-', ' ').ToUpper(),
        //                Description = "Pumpkin filled pie with chocolate dressing.",
        //                ImageName = "baked-pumpkin-desert.gif",
        //                Price = 49.99,
        //                MenuCategoryId = 2,
        //                ImagePath = "category/desert/"
        //               },
        //               new MenuItem{
        //                //MenuItemId = 3,
        //                Name = "banana-split-with-ice-cream-desert".Replace('-', ' ').ToUpper(),
        //                Description = "A Banana and ice cream combo that will leave you wanting more.",
        //                ImageName = "banana-split-with-ice-cream-desert.gif",
        //                Price = 49.99,
        //                //MenuCategoryId = 2,
        //                ImagePath = "category/desert/"
        //               },
        //               new MenuItem{
        //                //MenuItemId = 4,
        //                Name = "cheesecake-with-icecream-desert".Replace('-', ' ').ToUpper(),
        //                Description = "A cheese cake with ice cream combo that will leave you wanting more.",
        //                ImageName = "cheesecake-with-icecream-desert.gif",
        //                Price = 49.99,
        //                //MenuCategoryId = 2,
        //                ImagePath = "category/desert/"
        //               },
        //               new MenuItem{
        //                //MenuItemId = 5,
        //                Name = "diet-bread-salad".Replace('-', ' ').ToUpper(),
        //                Description = "A diet bread salad made for everyone who wants a salad.",
        //                ImageName = "diet-bread-salad.gif",
        //                Price = 49.99,
        //                //MenuCategoryId = 3,
        //                ImagePath = "category/salad/"
        //               },
        //               new MenuItem{
        //                MenuItemId = 6,
        //                Name = "roasted-meat-beans-pepper-salad".Replace('-', ' ').ToUpper(),
        //                Description = "A salad made to taste good with a combination of different goodies.",
        //                ImageName = "roasted-meat-beans-pepper-salad.gif",
        //                Price = 49.99,
        //                //MenuCategoryId = 3,
        //                ImagePath = "category/salad/"
        //               }
        //    };
        //    return menuItemsEntityData;
        //}

    }
}
