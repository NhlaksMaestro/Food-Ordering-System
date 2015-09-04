using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingSystem.Entities;

namespace FoodOrderingSystem.DataStore
{
    public interface IFoodOrderingSystemRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int CustomerId);
        Customer InsertCustomer(Customer Customer);
        Customer UpdateCustomer(Customer Customer);
        Customer DeleteCustomer(int CustomerId);

        List<OrderedItem> GetOrderedItems();
        List<OrderedItem> GetOrderedItemByMenuItemId(int menuItemId);
        List<OrderedItem> GetOrderedItemByOrderId(int orderId);
        List<OrderedItem> GetOrderedItemByUserId(int userId);
        OrderedItem GetOrderedItemById(int OrderedItemId);
        OrderedItem InsertOrderedItem(OrderedItem OrderedItem);
        OrderedItem UpdateOrderedItem(OrderedItem OrderedItem);
        OrderedItem DeleteOrderedItem(int OrderedItemId);


        List<MenuItem> GetMenuItems();
        List<MenuItem> GetMenuItemByCategoryId(int categoryId);
        MenuItem GetMenuItemById(int MenuItemId);
        MenuItem InsertMenuItem(MenuItem MenuItem);
        MenuItem UpdateMenuItem(MenuItem MenuItem);
        MenuItem DeleteMenuItem(int MenuItemId);

        List<Order> GetOrders();
        List<Order> GetOrdersByCustomerId(int customerId);
        Order GetOrderById(int OrderId);
        Order InsertOrder(Order Order);
        Order UpdateOrder(Order Order);
        Order DeleteOrder(int OrderId);

        List<MenuCategory> GetMenuCategories();
        MenuCategory GetMenuCategoryById(int MenuCategoryId);
        MenuCategory InsertMenuCategory(MenuCategory MenuCategory);
        MenuCategory UpdateMenuCategory(MenuCategory MenuCategory);
        MenuCategory DeleteMenuCategory(int MenuCategoryId);
    }
}
