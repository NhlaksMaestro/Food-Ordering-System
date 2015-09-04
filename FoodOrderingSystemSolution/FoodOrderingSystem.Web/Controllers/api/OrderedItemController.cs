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
    public class OrderedItemController : ApiController
    {
        private IFoodOrderingSystemRepository _repository = default(FoodOrderingSystemSqlRepository);
        public OrderedItemController()
        {
            _repository = new FoodOrderingSystemSqlRepository();
        }

        [HttpGet]
        public HttpResponseMessage GetOrderedItem()
        {
            try
            {
                var orderedItems = _repository.GetOrderedItems();
                return Request.CreateResponse<List<OrderedItem>>(HttpStatusCode.OK, orderedItems);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [Route("{orderedItemId}")]
        [HttpGet]
        public HttpResponseMessage GetOrderedItemById(int orderedItemId)
        {
            try
            {
                var orderedItem = _repository.GetOrderedItemById(orderedItemId);
                return Request.CreateResponse<OrderedItem>(HttpStatusCode.OK, orderedItem);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [HttpPost]
        public HttpResponseMessage PostOrderedItem(OrderedItem orderedItem)
        {
            try
            {
                var OrderedItemAdded = _repository.InsertOrderedItem(orderedItem);
                return Request.CreateResponse<OrderedItem>(HttpStatusCode.Created, OrderedItemAdded);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutOrderedItem(OrderedItem orderedItem)
        {
            try
            {
                var OrderedItemUpdate = _repository.UpdateOrderedItem(orderedItem);
                return Request.CreateResponse<OrderedItem>(HttpStatusCode.OK, OrderedItemUpdate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteOrderedItem(OrderedItem orderedItem)
        {
            try
            {
                var OrderedItemDeleted = _repository.InsertOrderedItem(orderedItem);
                return Request.CreateResponse<OrderedItem>(HttpStatusCode.OK, OrderedItemDeleted);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
