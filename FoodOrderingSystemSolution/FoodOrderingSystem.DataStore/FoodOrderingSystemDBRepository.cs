using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodOrderingSystem.Entities;
using FoodOrderingSystem.DataStore;

namespace FoodOrderingSystem.DataStore
{
    public class FoodOrderingSystemDBRepository
    {
        FoodOrderingSystemDBContext _dBContext = default(FoodOrderingSystemDBContext);
        public FoodOrderingSystemDBRepository()
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
        public void InsertCustomer(Customer Customer)
        {
            try
            {
                _dBContext.Customers.Add(Customer);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateCustomer(Customer Customer)
        {
            try
            {
                var empUpdate = _dBContext.Customers.FirstOrDefault(emp => emp.CustomerId == Customer.CustomerId);
                empUpdate.LastName = Customer.LastName;
                empUpdate.FirstName = Customer.FirstName;
                empUpdate.Address = Customer.Address;
                _dBContext.SaveChanges();
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
        public void InsertOrderedItem(OrderedItem OrderedItem)
        {
            try
            {
                _dBContext.OrderedItems.Add(OrderedItem);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateOrderedItem(OrderedItem OrderedItem)
        {
            try
            {
                var OrderedItemUpdate = _dBContext.OrderedItems.FirstOrDefault(aOrderedItem => aOrderedItem.OrderedItemId == aOrderedItem.OrderedItemId);
                OrderedItemUpdate.OrderedItemId = OrderedItem.OrderedItemId;
                OrderedItemUpdate.Quantity = OrderedItem.Quantity;
                OrderedItemUpdate.OrderId = OrderedItem.OrderId;
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteOrderedItem(int OrderedItemId)
        {
            try
            {
                var empDelete = _dBContext.OrderedItems.SingleOrDefault(emp => emp.OrderedItemId == OrderedItemId);
                _dBContext.OrderedItems.Remove(empDelete);
                _dBContext.SaveChanges(); ;
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
        public void InsertMenuItem(MenuItem MenuItem)
        {
            try
            {
                _dBContext.MenuItems.Add(MenuItem);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateMenuItem(MenuItem MenuItem)
        {
            try
            {
                var MenuItemUpdate = _dBContext.MenuItems.FirstOrDefault(aMenuItem => aMenuItem.MenuItemId == aMenuItem.MenuItemId);
                MenuItemUpdate.Name = MenuItem.Name;
                //MenuItemUpdate.Orders = MenuItem.Orders;
                //MenuItemUpdate.MenuItems = MenuItem.MenuItems;
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteMenuItem(int MenuItemId)
        {
            try
            {
                var empDelete = _dBContext.MenuItems.SingleOrDefault(emp => emp.MenuItemId == MenuItemId);
                _dBContext.MenuItems.Remove(empDelete);
                _dBContext.SaveChanges();
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
        public void InsertOrder(Order Order)
        {
            try
            {
                _dBContext.Orders.Add(Order);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateOrder(Order Order)
        {
            try
            {
                var OrderUpdate = _dBContext.Orders.FirstOrDefault(aOrder => aOrder.OrderId == aOrder.OrderId);
                OrderUpdate.Name = Order.Name;
                OrderUpdate.OrderId = Order.OrderId;
                OrderUpdate.AmountPaid = Order.AmountPaid;
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteOrder(int OrderId)
        {
            try
            {
                var empDelete = _dBContext.Orders.SingleOrDefault(emp => emp.OrderId == OrderId);
                _dBContext.Orders.Remove(empDelete);
                _dBContext.SaveChanges(); ;
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
        public void InsertMenuCategory(MenuCategory MenuCategory)
        {
            try
            {
                _dBContext.MenuCategories.Add(MenuCategory);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateMenuCategory(MenuCategory MenuCategory)
        {
            try
            {
                var MenuCategoryUpdate = _dBContext.MenuCategories.FirstOrDefault(aMenuCategory => aMenuCategory.MenuCategoryId == aMenuCategory.MenuCategoryId);
                MenuCategoryUpdate.CategoryName = MenuCategory.CategoryName;
                //MenuCategoryUpdate.Orders = MenuCategory.Orders;
                //MenuCategoryUpdate.MenuCategories = MenuCategory.MenuCategories;
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteMenuCategory(int MenuCategoryId)
        {
            try
            {
                var empDelete = _dBContext.MenuCategories.SingleOrDefault(emp => emp.MenuCategoryId == MenuCategoryId);
                _dBContext.MenuCategories.Remove(empDelete);
                _dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}