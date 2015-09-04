using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodOrderingSystem.Entities;
using FoodOrderingSystem.DataStore;

namespace FoodOrderingSystem.DataStore
{
    public class FoodOrderingSystemSqlRepository : IFoodOrderingSystemRepository
    {
        private FoodOrderingSystemDBContext _dBContext = default(FoodOrderingSystemDBContext);
        public FoodOrderingSystemSqlRepository()
        {
            _dBContext = new FoodOrderingSystemDBContext();
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                var Customers = _dBContext.Customers.ToList();
                return Customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer GetCustomerById(int CustomerId)
        {
            try
            {
                var Customer = _dBContext.Customers
                    //.Include("Orders")
                .FirstOrDefault(x => x.CustomerId == CustomerId);
                return Customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer InsertCustomer(Customer customer)
        {
            try
            {
                _dBContext.Customers.Add(customer);
                _dBContext.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer UpdateCustomer(Customer customer)
        {
            try
            {
                var empUpdate = _dBContext.Customers.FirstOrDefault(emp => emp.CustomerId == customer.CustomerId);
                empUpdate.LastName = customer.LastName;
                empUpdate.FirstName = customer.FirstName;
                empUpdate.Address = customer.Address;
                _dBContext.SaveChanges();
                return customer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Customer DeleteCustomer(int CustomerId)
        {
            try
            {
                var empDelete = _dBContext.Customers.SingleOrDefault(emp => emp.CustomerId == CustomerId);
                _dBContext.Customers.Remove(empDelete);
                _dBContext.SaveChanges();
                return empDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderedItem> GetOrderedItems()
        {
            try
            {
                var OrderedItems = _dBContext.OrderedItems.ToList();
                return OrderedItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OrderedItem> GetOrderedItemByMenuItemId(int menuItemId)
        {
            try
            {
                var orders = _dBContext.OrderedItems
                    .Where<OrderedItem>(item => item.MenuItem.MenuItemId == menuItemId)
                    .ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OrderedItem> GetOrderedItemByUserId(int userId)
        {
            try
            {
                var newOrders = new List<OrderedItem>();
                var custOrders = _dBContext.Orders.Where(c => c.CustomerId == userId).ToList();
                var orders = _dBContext.OrderedItems.ToList();
                foreach (var custOrder in custOrders)
                {
                    //custOrder.Order = _dBContext.Orders.FirstOrDefault(x => x.OrderId == custOrder.OrderId);
                    //custOrder.MenuItem = _dBContext.MenuItems.FirstOrDefault(x => x.MenuItemId == custOrder.MenuItemId);
                    //custOrder.Order.Customer = _dBContext.Customers.FirstOrDefault(x => x.CustomerId == userId);
                    custOrder.Customer = _dBContext.Customers.FirstOrDefault(c => c.CustomerId == userId);
                    var orderedItem = _dBContext.OrderedItems.FirstOrDefault(oi => oi.OrderId == custOrder.OrderId);
                    orderedItem.MenuItem = _dBContext.MenuItems.FirstOrDefault(mi => mi.MenuItemId == orderedItem.MenuItemId);
                    orderedItem.Order = custOrder;
                    newOrders.Add(orderedItem);
                }
                orders = newOrders;
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrderedItem> GetOrderedItemByOrderId(int orderId)
        {
            try
            {
                var orders = _dBContext.OrderedItems
                    .Where<OrderedItem>(item => item.Order.OrderId == orderId)
                    .ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderedItem GetOrderedItemById(int OrderedItemId)
        {
            try
            {
                var OrderedItem = _dBContext.OrderedItems
                   .FirstOrDefault(x => x.OrderedItemId == OrderedItemId);
                return OrderedItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public OrderedItem InsertOrderedItem(OrderedItem orderedItem)
        {
            try
            {
                _dBContext.OrderedItems.Add(orderedItem);
                _dBContext.SaveChanges();
                return orderedItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderedItem UpdateOrderedItem(OrderedItem orderedItem)
        {
            try
            {
                var OrderedItemUpdate = _dBContext.OrderedItems.FirstOrDefault(aOrderedItem => aOrderedItem.OrderedItemId == aOrderedItem.OrderedItemId);
                OrderedItemUpdate.OrderedItemId = orderedItem.OrderedItemId;
                OrderedItemUpdate.Quantity = orderedItem.Quantity;
                OrderedItemUpdate.OrderId = orderedItem.OrderId;
                _dBContext.SaveChanges();
                return orderedItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OrderedItem DeleteOrderedItem(int OrderedItemId)
        {
            try
            {
                var empDelete = _dBContext.OrderedItems.SingleOrDefault(emp => emp.OrderedItemId == OrderedItemId);
                _dBContext.OrderedItems.Remove(empDelete);
                _dBContext.SaveChanges();
                return empDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MenuItem> GetMenuItems()
        {
            try
            {
                var MenuItems = _dBContext.MenuItems.ToList();
                return MenuItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MenuItem> GetMenuItemByCategoryId(int categoryId)
        {
            try
            {
                var orders = _dBContext.MenuItems
                    .Where<MenuItem>(item => item.MenuCategoryId == categoryId)
                    .ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public MenuItem GetMenuItemById(int MenuItemId)
        {
            try
            {
                var MenuItem = _dBContext.MenuItems
               .FirstOrDefault(x => x.MenuItemId == MenuItemId);
                return MenuItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuItem InsertMenuItem(MenuItem menuItem)
        {
            try
            {
                _dBContext.MenuItems.Add(menuItem);
                _dBContext.SaveChanges();
                return menuItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuItem UpdateMenuItem(MenuItem menuItem)
        {
            try
            {
                var MenuItemUpdate = _dBContext.MenuItems.FirstOrDefault(aMenuItem => aMenuItem.MenuItemId == aMenuItem.MenuItemId);
                MenuItemUpdate.Name = menuItem.Name;
                //MenuItemUpdate.Orders = MenuItem.Orders;
                //MenuItemUpdate.MenuItems = MenuItem.MenuItems;
                _dBContext.SaveChanges();
                return MenuItemUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuItem DeleteMenuItem(int MenuItemId)
        {
            try
            {
                var empDelete = _dBContext.MenuItems.SingleOrDefault(emp => emp.MenuItemId == MenuItemId);
                _dBContext.MenuItems.Remove(empDelete);
                _dBContext.SaveChanges();
                return empDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Order> GetOrders()
        {
            try
            {
                var Orders = _dBContext.Orders.ToList();
                return Orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            try
            {
                var orders = _dBContext.Orders
                    .Where<Order>(ord => ord.CustomerId == customerId)
                    .ToList();
                return orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Order GetOrderById(int OrderId)
        {
            try
            {
                var Order = _dBContext.Orders
                   .FirstOrDefault(x => x.OrderId == OrderId);
                return Order;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Order InsertOrder(Order order)
        {
            try
            {
                _dBContext.Orders.Add(order);
                _dBContext.SaveChanges();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Order UpdateOrder(Order order)
        {
            try
            {
                var OrderUpdate = _dBContext.Orders.FirstOrDefault(aOrder => aOrder.OrderId == aOrder.OrderId);
                OrderUpdate.Name = order.Name;
                OrderUpdate.OrderId = order.OrderId;
                OrderUpdate.AmountPaid = order.AmountPaid;
                _dBContext.SaveChanges();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Order DeleteOrder(int OrderId)
        {
            try
            {
                var orderDelete = _dBContext.Orders.SingleOrDefault(emp => emp.OrderId == OrderId);
                _dBContext.Orders.Remove(orderDelete);
                _dBContext.SaveChanges();
                return orderDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public List<MenuCategory> GetMenuCategories()
        {
            try
            {
                var MenuCategories = _dBContext.MenuCategories
                    .Include("MenuItems")
                    .ToList();
                return MenuCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuCategory GetMenuCategoryById(int MenuCategoryId)
        {
            try
            {
                var MenuCategory = _dBContext.MenuCategories
               .FirstOrDefault(x => x.MenuCategoryId == MenuCategoryId);
                return MenuCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuCategory InsertMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                _dBContext.MenuCategories.Add(menuCategory);
                _dBContext.SaveChanges();
                return menuCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuCategory UpdateMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                var MenuCategoryUpdate = _dBContext.MenuCategories.FirstOrDefault(aMenuCategory => aMenuCategory.MenuCategoryId == aMenuCategory.MenuCategoryId);
                MenuCategoryUpdate.CategoryName = menuCategory.CategoryName;
                //MenuCategoryUpdate.Orders = MenuCategory.Orders;
                //MenuCategoryUpdate.MenuCategories = MenuCategory.MenuCategories;
                _dBContext.SaveChanges();
                return menuCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MenuCategory DeleteMenuCategory(int MenuCategoryId)
        {
            try
            {
                var menuCategoryDelete = _dBContext.MenuCategories.SingleOrDefault(emp => emp.MenuCategoryId == MenuCategoryId);
                _dBContext.MenuCategories.Remove(menuCategoryDelete);
                _dBContext.SaveChanges();
                return menuCategoryDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}