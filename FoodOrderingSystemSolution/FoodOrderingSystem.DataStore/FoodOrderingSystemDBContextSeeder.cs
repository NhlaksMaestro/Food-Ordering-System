using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FoodOrderingSystem.Entities;

namespace FoodOrderingSystem.DataStore
{
    public class FoodOrderingSystemDBContextSeeder : DropCreateDatabaseAlways<FoodOrderingSystemDBContext>//CreateDatabaseIfNotExists<FoodOrderingSystemDBContext>
    {
        protected override void Seed(FoodOrderingSystemDBContext context)
        {
            foreach (var customer in this.Customers())
            {
                context.Customers.Add(customer);
            }
            context.SaveChanges();
            foreach (var menuCategory in this.MenuCategories())
            {
                context.MenuCategories.Add(menuCategory);
            }
            context.SaveChanges();
            foreach (var menuItem in this.MenuItems())
            {
                if (menuItem.Name.Contains("SOUP"))
                {
                    menuItem.MenuCategory = context.MenuCategories.FirstOrDefault(m => m.MenuCategoryId == 1);
                }
                if (menuItem.Name.Contains("DESERT"))
                {
                    menuItem.MenuCategory = context.MenuCategories.FirstOrDefault(m => m.MenuCategoryId == 2);
                }
                if (menuItem.Name.Contains("SALAD"))
                {
                    menuItem.MenuCategory = context.MenuCategories.FirstOrDefault(m => m.MenuCategoryId == 3);
                }
                if (menuItem.Name.Contains("DRINK"))
                {
                    menuItem.MenuCategory = context.MenuCategories.FirstOrDefault(m => m.MenuCategoryId == 4);
                }
                if (menuItem.Name.Contains("SEAFOOD"))
                {
                    menuItem.MenuCategory = context.MenuCategories.FirstOrDefault(m => m.MenuCategoryId == 5);
                }
                if (menuItem.Name.Contains("MEAT"))
                {
                    menuItem.MenuCategory = context.MenuCategories.FirstOrDefault(m => m.MenuCategoryId == 6);
                }
                context.MenuItems.Add(menuItem);
            }
            context.SaveChanges();
            foreach (var Order in this.Orders())
            {
                var randomizer = new Random();
                int randomNumber = context.Customers.Count() > 0 ? randomizer.Next(1, context.Customers.Count()) : randomizer.Next(0, context.Customers.Count());
                Order.Customer = context.Customers.FirstOrDefault(x => x.CustomerId == randomNumber);
                context.Orders.Add(Order);
            }
            context.SaveChanges();
            foreach (var orderedItem in this.OrderedItems())
            {
                var randomizer = new Random();
                int randomNumMenuItem = context.MenuItems.Count() > 0 ? randomizer.Next(1, context.MenuItems.Count()) : randomizer.Next(0, context.MenuItems.Count());
                int randomNumOrder = context.Orders.Count() > 0 ? randomizer.Next(1, context.Orders.Count()) : randomizer.Next(0, context.Orders.Count());
                var order = context.Orders.FirstOrDefault(x => x.OrderId == randomNumOrder);
                var menuItem = context.MenuItems.FirstOrDefault(x => x.MenuItemId == randomNumMenuItem);
                orderedItem.Order = order;
                orderedItem.MenuItem = menuItem;
                context.OrderedItems.Add(orderedItem);
            }
            context.SaveChanges();
            base.Seed(context);
        }
        private List<Customer> Customers()
        {
            var customersEntityData = new List<Customer>()
            {
                new Customer{ 
                    CustomerId = 1,
                    FirstName = "Mabongi",
                    LastName = "Mkhize", 
                    Phone = "0117822345", 
                    Address = "2434 Drago Street",
                    Orders = new List<Order>(){}
                },
                new Customer{ 
                    CustomerId = 2,
                    FirstName = "Basetsana",
                    LastName = "Lerumo", 
                    Phone = "014549383", 
                    Address = "345 Domino Street",
                      Orders =   new List<Order>(){}
                },
                new Customer{ 
                    CustomerId = 3,
                    FirstName = "Mabongi",
                    LastName = "Mkhize", 
                    Phone = "0193345567", 
                    Address = "5678 Yehla Street",
                   Orders = new List<Order>(){}
                }
            };
            return customersEntityData;
        }
        private List<MenuCategory> MenuCategories()
        {
            var menuCategoriesEntityData = new List<MenuCategory>()
            {
                new MenuCategory{ 
                    MenuCategoryId = 1,
                    CategoryName = "soup".ToUpper(),
                    ImagePath = "http://localhost:4493/image_category/soup.gif",
                    MenuItems = new List<MenuItem>(){}
                },
                new MenuCategory{ 
                    MenuCategoryId = 2,
                    CategoryName = "desert".ToUpper(),
                    ImagePath = "http://localhost:4493/image_category/desert.gif",
                    MenuItems = new List<MenuItem>(){
                    }
                },
                new MenuCategory{ 
                    MenuCategoryId = 3,
                    CategoryName = "salad".ToUpper(),
                    ImagePath = "http://localhost:4493/image_category/salad.gif",
                    MenuItems = new List<MenuItem>(){}
                },
                new MenuCategory{ 
                    MenuCategoryId = 4,
                    CategoryName = "drink".ToUpper(),
                    ImagePath = "http://localhost:4493/image_category/drink.gif",
                    MenuItems = new List<MenuItem>(){}
                },
                new MenuCategory{ 
                    MenuCategoryId = 5,
                    CategoryName = "seafood".ToUpper(),
                    ImagePath = "http://localhost:4493/image_category/seafood.gif",
                    MenuItems = new List<MenuItem>(){}
                },
                new MenuCategory{ 
                    MenuCategoryId = 6,
                    CategoryName = "meat".ToUpper(),
                    ImagePath = "http://localhost:4493/image_category/meat.gif",
                    MenuItems = new List<MenuItem>(){}
                },
            };
            return menuCategoriesEntityData;
        }
        private List<Order> Orders()
        {
            var ordersEntityData = new List<Order>()
            {
                new Order{ 
                    OrderId = 1,
                    Name = "Order 1",
                    AmountPaid = 500.00,
                    DateOrdered = new DateTime(2015, 01, 14, 14, 14, 40),
                    DateReceived = new DateTime(2015, 01, 14, 14, 57, 40),
                    //Customer = this.Customers().FirstOrDefault(x => x.CustomerId == 3),
                    CustomerId = 3,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new Order{ 
                    OrderId = 2,
                    Name = "Order 2",
                    DateOrdered = new DateTime(2015, 02, 10, 13, 40, 40),
                    DateReceived =  new DateTime(2015, 02, 10, 13, 00, 40),
                    OrderedItems = new List<OrderedItem>(){},
                    //Customer = this.Customers().FirstOrDefault(x => x.CustomerId == 2),
                    CustomerId = 2,
                    AmountPaid = 230.00
                },
                new Order{ 
                    OrderId = 3,
                    Name = "Order 3",
                    DateOrdered = new DateTime(2015, 03, 14, 05, 25, 20),
                    DateReceived = new DateTime(2015, 03, 14, 06, 25, 20),
                    OrderedItems = new List<OrderedItem>(){},
                    //Customer = this.Customers().FirstOrDefault(x => x.CustomerId == 2),
                    CustomerId = 2,
                    AmountPaid = 450.00
                    
                },
                new Order{ 
                    OrderId = 4,
                    Name = "Order 4",
                    DateOrdered = new DateTime(2015, 04, 04, 15, 55, 20),
                    DateReceived = new DateTime(2015, 04, 04, 15, 20, 20),
                    OrderedItems = new List<OrderedItem>(){},
                    //Customer = this.Customers().FirstOrDefault(x => x.CustomerId == 1),
                    CustomerId = 1,
                    AmountPaid = 300.00
                },
                new Order{ 
                    OrderId = 5,
                    Name = "Order 5",
                    DateOrdered = new DateTime(2015, 05, 24, 12, 11, 35),
                    DateReceived =  new DateTime(2015, 05, 24, 13, 00, 40),
                    OrderedItems = new List<OrderedItem>(){},
                    //Customer = this.Customers().FirstOrDefault(x => x.CustomerId == 1),
                    CustomerId = 1,
                    AmountPaid = 100.00
                }
            };
            return ordersEntityData;
        }
        private List<MenuItem> MenuItems()
        {
            var menuItemsEntityData = new List<MenuItem>()
            {
                new MenuItem{ 
                    MenuItemId = 1,
                    Name = "ukrainian-borsch-soup".Replace('-',' ').ToUpper(),
                    ImagePath = "http://localhost:4493/image_category/soup/ukrainian-borsch-soup.gif",
                    Description = "Soup that was created in Ukraine now available to the world.",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 1),
                    Price = 18.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 2,
                    Name = "cheesecake-with-icecream-desert".Replace('-',' ').ToUpper(),
                    Description = "Tasty cheese cake and ice cream.",
                    ImagePath = "http://localhost:4493/image_category/desert/cheesecake-with-icecream-desert.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 2),
                    Price = 30.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 3,
                    Name = "baked-pumpkin-desert".Replace('-',' ').ToUpper(),
                    Description = "Tasty baked pumpkin desert.",
                    ImagePath = "http://localhost:4493/image_category/desert/baked-pumpkin-desert.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 2),
                    Price = 30.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 4,
                    Name = "banana-split-with-ice-cream-desert".Replace('-',' ').ToUpper(),
                    Description = "Tasty banana split with ice cream desert.",
                    ImagePath = "http://localhost:4493/image_category/desert/banana-split-with-ice-cream-desert.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 2),
                    Price = 30.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 5,
                    Name = "diet-bread-salad".Replace('-',' ').ToUpper(),
                    Description = "Healthy and nutritional Salad.",
                    ImagePath = "http://localhost:4493/image_category/salad/diet-bread-salad.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 3),
                    Price = 25.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 6,
                    Name = "roasted-meat-beans-pepper-salad".Replace('-',' ').ToUpper(),
                    Description = "This is meaty Salad.",
                    ImagePath = "http://localhost:4493/image_category/salad/roasted-meat-beans-pepper-salad.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 3),
                    Price = 25.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 7,
                    Name = "drink".ToUpper(),
                    Description = "A big range of drinks to refresh yourself from.",
                    ImagePath = "http://localhost:4493/image_category/drink/drink.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 4),
                    Price = 20.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 8,
                    Name = "cold-boiled-pork-meat".Replace('-',' ').ToUpper(),
                    Description = "Meat pork boiled cold.",
                    ImagePath = "http://localhost:4493/image_category/meat/cold-boiled-pork.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 6),
                    Price = 30.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                //new MenuItem{ 
                //    MenuItemId = 9,
                //    Name = "cheese-and-chicken-meat".Replace('-',' ').ToUpper(),
                //    Description = "Meaty cheese and chicken sliced rolls with sauce and parsley very tasty.",
                //    ImagePath = "http://localhost:4493/image_category/meat/cheese-and-chicken-meat.gif",
                //    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 6),
                //    Price = 30.00,
                //    OrderedItems = new List<OrderedItem>(){}
                //},
                new MenuItem{ 
                    MenuItemId = 10,
                    Name = "sliced-ham-meat".Replace('-',' ').ToUpper(),
                    Description = "Meaty sliced ham with cheese roll.",
                    ImagePath = "http://localhost:4493/image_category/meat/sliced-ham-meat.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 6),
                    Price = 30.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 11,
                    Name = "cold-boiled-pork-meat".Replace('-',' ').ToUpper(),
                    Description = "Meaty sliced ham with vegatables.",
                    ImagePath = "http://localhost:4493/image_category/meat/sliced-ham-with-vegatables-meat.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 6),
                    Price = 30.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 12,
                    Name = "fishcakes-with-lemon-seafood".Replace('-',' ').ToUpper(),
                    Description = "Filling fishy Dish with basl leaves and green sauce",
                    ImagePath = "http://localhost:4493/image_category/seafood/fishcakes-with-lemon-seafood.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 6),
                    Price = 30.00,
                    OrderedItems = new List<OrderedItem>(){}
                },
                new MenuItem{ 
                    MenuItemId = 13,
                    Name = "sliced-herring-seafood".Replace('-',' ').ToUpper(),
                    Description = "Filling fishy Dish.",
                    ImagePath = "http://localhost:4493/image_category/seafood/sliced-herring-seafood.gif",
                    //MenuCategory = this.MenuCategories().FirstOrDefault(m => m.//MenuCategoryId == 6),
                    Price = 30.00,
                    OrderedItems = new List<OrderedItem>(){}
                    //OrderedItems = new List<OrderedItem>(){}
                }
            };
            return menuItemsEntityData;
        }
        private List<OrderedItem> OrderedItems()
        {
            var OrderedItemsEntityData = new List<OrderedItem>()
            {
                new OrderedItem{
                    OrderedItemId = 1,
                    Quantity = 3
                },
                new OrderedItem{
                    OrderedItemId = 2,
                    Quantity = 2
                },
                new OrderedItem{
                    OrderedItemId = 3,
                    Quantity = 3
                },
                new OrderedItem{
                    OrderedItemId = 4,
                    Quantity = 1
                },
                new OrderedItem{
                    OrderedItemId = 5,
                    Quantity = 5
                }
            };
            return OrderedItemsEntityData;
        }
    }
}
