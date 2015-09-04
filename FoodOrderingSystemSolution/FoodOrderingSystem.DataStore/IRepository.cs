using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingSystem.Entities;

namespace FoodOrderingSystem.DataStore
{
    public interface IRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int CustomerId);
        void InsertCustomer(Customer Customer);
        void UpdateCustomer(Customer Customer);
        Customer DeleteCustomer(int CustomerId);

        List<OrderedItem> GetOrderedItems();
        OrderedItem GetOrderedItemById(int OrderedItemId);
        void InsertOrderedItem(OrderedItem OrderedItem);
        void UpdateOrderedItem(OrderedItem OrderedItem);
        void DeleteOrderedItem(int OrderedItemId);

        List<MenuItem> GetMenuItems();
        List<MenuItem> GetMenuItemCategoryId(int categoryId);
        MenuItem GetMenuItemById(int MenuItemId);
        void InsertMenuItem(MenuItem MenuItem);
        void UpdateMenuItem(MenuItem MenuItem);
        void DeleteMenuItem(int MenuItemId);

        List<Order> GetOrders();
        List<Order> GetOrdersByCustomerId(int customerId);
        Order GetOrderById(int OrderId);
        void InsertOrder(Order Order);
        void UpdateOrder(Order Order);
        void DeleteOrder(int OrderId);

        List<MenuCategory> GetMenuCategories();
        MenuCategory GetMenuCategoryById(int MenuCategoryId);
        void InsertMenuCategory(MenuCategory MenuCategory);
        void UpdateMenuCategory(MenuCategory MenuCategory);
        void DeleteMenuCategory(int MenuCategoryId);
    }
}
