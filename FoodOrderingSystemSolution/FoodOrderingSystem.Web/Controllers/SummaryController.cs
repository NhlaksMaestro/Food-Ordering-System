using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrderingSystem.DataStore;
using FoodOrderingSystem.Entities;

namespace FoodOrderingSystem.Web.Controllers
{
    public class SummaryController : Controller
    {
        private FoodOrderingSystemSqlRepository _repository = new FoodOrderingSystemSqlRepository();

        public ActionResult Index()
        {
            var totalCost = 0.00;
            double? amountPaid = 0.00;
            var customer = new Customer();

            if ((Session["customer"] as Customer) == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                customer = Session["customer"] as Customer;
                ViewData["Customer"] = customer;
            }
            
            var orders = _repository.GetOrderedItemByUserId(customer.CustomerId);
            
            if (orders != null && orders.Count > 0)
            {
                
                foreach (var orderedItem in orders)
                {
                    totalCost = totalCost + (orderedItem.MenuItem.Price * orderedItem.Quantity);
                    amountPaid = amountPaid + orderedItem.Order.AmountPaid;
                }
                ViewData["orderedItems"] = orders;
                ViewData["totalCosts"] = totalCost;
                ViewData["amountPaid"] = amountPaid;
                ViewBag.Message = "Total Orders For " + customer.FirstName + ' ' + customer.LastName;
            }
            else
            {
                ViewBag.Message = "Customer " + customer.FirstName + ' ' + customer.LastName + " has no orders made.";
                ViewData["orderedItems"] = new List<OrderedItem>() { };
                ViewData["totalCosts"] = totalCost;
                ViewData["amountPaid"] = amountPaid;
            }

            return View();
        }
    }
}
