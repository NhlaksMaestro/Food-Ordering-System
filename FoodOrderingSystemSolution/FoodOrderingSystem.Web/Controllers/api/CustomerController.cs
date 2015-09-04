using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodOrderingSystem.Entities;
using FoodOrderingSystem.DataStore;
using System.Threading.Tasks;

namespace FoodOrderingSystem.Web.Controllers.api
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private IFoodOrderingSystemRepository _repository = default(FoodOrderingSystemSqlRepository);
        public CustomerController()
        {
            _repository = new FoodOrderingSystemSqlRepository();
        }

        [HttpGet]
        public HttpResponseMessage GetCustomer()
        {
            try
            {
                var customers = _repository.GetCustomers();
                return Request.CreateResponse<List<Customer>>(HttpStatusCode.OK, customers);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [Route("{CustomerId}")]
        [HttpGet]
        public HttpResponseMessage GetCustomerById(int customerId)
        {
            try
            {
                var customer = _repository.GetCustomerById(customerId);
                return Request.CreateResponse<Customer>(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [HttpPost]
        public HttpResponseMessage PostCustomer(Customer customer)
        {
            try
            {
                var customerAdded = _repository.InsertCustomer(customer);
                return Request.CreateResponse<Customer>(HttpStatusCode.OK, customerAdded);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutCustomer(Customer customer)
        {
            try
            {
                var customerUpdate = _repository.UpdateCustomer(customer);
                return Request.CreateResponse<Customer>(HttpStatusCode.OK, customerUpdate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(Customer customer)
        {
            try
            {
                var customerDeleted = _repository.InsertCustomer(customer);
                return Request.CreateResponse<Customer>(HttpStatusCode.OK, customerDeleted);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
