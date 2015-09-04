using FoodOrderingSystem.DataStore;
using FoodOrderingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodOrderingSystem.Web.Controllers.api
{
        [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private IFoodOrderingSystemRepository _repository = default(FoodOrderingSystemSqlRepository);
        public OrderController()
        {
            _repository = new FoodOrderingSystemSqlRepository();
        }

        [HttpGet]
        public HttpResponseMessage GetOrder()
        {
            try
            {
                var orders = _repository.GetOrders();
                return Request.CreateResponse<List<Order>>(HttpStatusCode.OK, orders);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [Route("{orderId}")]
        [HttpGet]
        public HttpResponseMessage GetOrderById(int orderId)
        {
            try
            {
                var order = _repository.GetOrderById(orderId);
                return Request.CreateResponse<Order>(HttpStatusCode.OK, order);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [HttpPost]
        public HttpResponseMessage PostOrder(Order order)
        {
            try
            {
                var OrderAdded = _repository.InsertOrder(order);
                return Request.CreateResponse<Order>(HttpStatusCode.OK, OrderAdded);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutOrder(Order order)
        {
            try
            {
                var OrderUpdate = _repository.UpdateOrder(order);
                return Request.CreateResponse<Order>(HttpStatusCode.OK, OrderUpdate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Order order)
        {
            try
            {
                var OrderDeleted = _repository.InsertOrder(order);
                return Request.CreateResponse<Order>(HttpStatusCode.OK, OrderDeleted);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
