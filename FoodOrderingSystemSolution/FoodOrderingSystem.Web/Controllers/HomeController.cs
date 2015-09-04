using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrderingSystem.DataStore;
using FoodOrderingSystem.Entities;

namespace FoodOrderingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private FoodOrderingSystemSqlRepository _repository = new FoodOrderingSystemSqlRepository();

        public ActionResult Index()
        {
            var randomizer = new Random();
            int randomNumber = _repository.GetCustomers().Count > 0 ? randomizer.Next(1, _repository.GetCustomers().Count) : randomizer.Next(0, _repository.GetCustomers().Count);
            var customer = new Customer();

            if ((Session["customer"] as Customer) == null)
            {
                Session["customer"] = new Customer();
                customer = _repository.GetCustomerById(randomNumber);
            }
            else
            {
                customer = Session["customer"] as Customer;
            }

            ViewData["MenuCategories"] = _repository.GetMenuCategories();
            ViewData["Customer"] = customer;
            Session["customer"] = customer;
            if (Session["totalCost"] == null)
            {
                Session["totalCost"] = 0.00;
            }
            ViewData["totalCosts"] = (double)Session["totalCost"];
            //var customerOrders = _repository.GetOrdersByCustomerId(customer.CustomerId);

            //foreach (var customerOrder in customerOrders)
            //{
            //    customerOrder = _repository.GetOrders();
            //}
            if ((Session["orderedItems"] as List<OrderedItem>) != null)
            {
                if ((Session["orderedItems"] as List<OrderedItem>).Count > 0)
                {
                    ViewData["orderedItems"] = Session["orderedItems"] as List<OrderedItem>;
                    ViewBag.Message = "Customer Orders For " + customer.FirstName + ' ' + customer.LastName;
                }
                else
                {
                    ViewBag.Message = "Customer Orders For " + customer.FirstName + ' ' + customer.LastName;
                    ViewData["orderedItems"] = new List<OrderedItem>() { };
                }
            }
            else
            {
                ViewBag.Message = "Customer " + customer.FirstName + ' ' + customer.LastName + " has no orders made.";
                ViewData["orderedItems"] = new List<OrderedItem>() { };
            }

            var menuCategories = _repository.GetMenuCategories();
            foreach (var menuCategory in menuCategories)
            {
                menuCategory.MenuItems = _repository.GetMenuItemByCategoryId(menuCategory.MenuCategoryId);
            }
            ViewData["MenuCategories"] = menuCategories;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[HttpGet]
        //[Route("selectedMenuItem/{menuItemId}")]
        public PartialViewResult SelectedMenuItem(int menuItemId, int customerId)
        {
            var theMenuItem = _repository.GetMenuItemById(menuItemId);
            ViewData["CustomerId"] = customerId;
            ViewData["MenuItem"] = theMenuItem;
            ViewData["OrderedItem"] = new OrderedItem();
            return PartialView("SelectedMenuItem", theMenuItem);
        }
        [HttpPost]
        public JsonResult OrderMenuItem(OrderedItem model)//, Order order)
        {
            if ((Session["orders"] as List<Order>) == null)
            {
                Session["orders"] = new List<Order>();
            }
            if ((Session["orderedItems"] as List<OrderedItem>) == null)
            {
                Session["orderedItems"] = new List<OrderedItem>();
            }
            if (Request.IsAjaxRequest())
            {
                var order = new Order();
                //order.OrderId = _repository.GetOrders().Count + 1;
                order.Name = "Order Number: " + _repository.GetOrders().Count;
                order.DateOrdered = DateTime.Now;
                //order.OrderId = _repository.GetOrders().Count + 1;
                order.Customer = Session["customer"] as Customer;
                order.OrderedItems = new List<OrderedItem>();
                order = _repository.InsertOrder(order);
                (Session["orders"] as List<Order>).Add(order);

                var orderItem = new OrderedItem();
                //orderItem.OrderedItemId = _repository.GetOrderedItems().Count + 1;
                orderItem.MenuItem = _repository.GetMenuItemById(model.MenuItemId);
                orderItem.Order = order;
                orderItem.Quantity = model.Quantity;
                orderItem = _repository.InsertOrderedItem(orderItem);
                (Session["orderedItems"] as List<OrderedItem>).Add(orderItem);
            }
            var totalCost = 0.00;
            if ((Session["orders"] as List<Order>).Count > 0)
            {
                foreach (var item in (Session["orderedItems"] as List<OrderedItem>))
                {
                    var quantityAndPrice = 0.00;
                    if (item.Quantity > 0)
                    {
                        quantityAndPrice = item.MenuItem.Price * item.Quantity;
                    }
                    if (quantityAndPrice > 0)
                    {
                        totalCost = totalCost + quantityAndPrice;
                    }
                    else
                    {
                        totalCost = totalCost + item.MenuItem.Price;
                    }
                }
                Session["totalCost"] = totalCost;
            }
            else
            {
                Session["totalCost"] = totalCost;
            }
            //var orderToSave = order;
            var menuItemToSave = new { Url = "Home/Index" };
            //return Json(data);
            return Json(menuItemToSave);
        }

        [HttpDelete]
        public JsonResult DeleteOrderedMenuItem(int orderedItemId)//, Order order)
        {
            if ((Session["orders"] as List<Order>) == null)
            {
                Session["orders"] = new List<Order>();
            }
            if ((Session["orderedItems"] as List<OrderedItem>) == null)
            {
                Session["orderedItems"] = new List<OrderedItem>();
            }
            if (Request.IsAjaxRequest())
            {
                var theOrderToDelete = _repository.GetOrderedItemById(orderedItemId);
                var removeOrderedMenuItem = (Session["orderedItems"] as List<OrderedItem>).Find(x => x.OrderedItemId == orderedItemId);
                theOrderToDelete = _repository.DeleteOrderedItem(orderedItemId);
                (Session["orderedItems"] as List<OrderedItem>).Remove(removeOrderedMenuItem);
                //var orderItem = new OrderedItem();
                //orderItem.MenuItem = _repository.GetMenuItemById(model.MenuItemId);
                //orderItem.Order = order;
                //orderItem.Quantity = model.Quantity;
                //orderItem = _repository.InsertOrderedItem(orderItem);
                //(Session["orderedItems"] as List<OrderedItem>).Add(orderItem);
            }
            //var totalCost = 0.00;
            //if ((Session["orders"] as List<Order>).Count > 0)
            //{
            //    foreach (var item in (Session["orderedItems"] as List<OrderedItem>))
            //    {
            //        var quantityAndPrice = 0.00;
            //        if (item.Quantity > 0)
            //        {
            //            quantityAndPrice = item.MenuItem.Price * item.Quantity;
            //        }
            //        if (quantityAndPrice > 0)
            //        {
            //            totalCost = quantityAndPrice;
            //        }
            //        else
            //        {
            //            totalCost = totalCost + item.MenuItem.Price;
            //        }
            //    }
            //    Session["totalCost"] = totalCost;
            //}
            //else
            //{
            //    Session["totalCost"] = totalCost;
            //}
            //var orderToSave = order;
            var menuItemToDelete = Url.Action("Index");
            //return Json(data);
            return Json(menuItemToDelete);
        }

        [HttpPost]
        public JsonResult PlaceOrder()//, Order order)
        {
            if ((Session["orderedItems"] as List<OrderedItem>) == null)
            {
                Session["orderedItems"] = new List<OrderedItem>();
            }
            if ((Session["modelSaved"] as List<OrderedItem>) == null)
            {
                Session["modelSaved"] = new List<OrderedItem>();
            }
            if (Request.IsAjaxRequest())
            {
                if ((Session["orderedItems"] as List<OrderedItem>).Count > 0)
                {
                    var modelSaved = new OrderedItem();
                    foreach (var item in (Session["orderedItems"] as List<OrderedItem>))
                    {
                        item.Order.DateReceived = DateTime.Now;
                        item.Order.AmountPaid = item.Quantity * item.MenuItem.Price;
                        modelSaved = _repository.InsertOrderedItem(item);
                        (Session["modelSaved"] as List<OrderedItem>).Add(modelSaved);
                    }
                    modelSaved = null;
                }
                else
                {
                    Session["orderedItems"] = new List<OrderedItem>();
                }
            }
            var menuItemToDelete = Url.Action("Index", "Summary");
            return Json(menuItemToDelete);
        }

    }
}