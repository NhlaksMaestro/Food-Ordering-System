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
    [RoutePrefix("api/menuitem")]
    public class MenuItemController : ApiController
    {
        private IFoodOrderingSystemRepository _repository = default(FoodOrderingSystemSqlRepository);
        public MenuItemController()
        {
            _repository = new FoodOrderingSystemSqlRepository();
        }

        [HttpGet]
        public HttpResponseMessage GetMenuItem()
        {
            try
            {
                var MenuItems = _repository.GetMenuItems();
                return Request.CreateResponse<List<MenuItem>>(HttpStatusCode.OK, MenuItems);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [Route("{MenuItemId}")]
        [HttpGet]
        public HttpResponseMessage GetMenuItemById(int menuItemId)
        {
            try
            {
                var menuItem = _repository.GetMenuItemById(menuItemId);
                return Request.CreateResponse<MenuItem>(HttpStatusCode.OK, menuItem);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage PostMenuItem(MenuItem menuItem)
        {
            try
            {
                var MenuItemAdded = _repository.InsertMenuItem(menuItem);
                return Request.CreateResponse<MenuItem>(HttpStatusCode.OK, MenuItemAdded);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutMenuItem(MenuItem menuItem)
        {
            try
            {
                var MenuItemUpdate = _repository.UpdateMenuItem(menuItem);
                return Request.CreateResponse<MenuItem>(HttpStatusCode.OK, MenuItemUpdate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteMenuItem(MenuItem menuItem)
        {
            try
            {
                var MenuItemDeleted = _repository.InsertMenuItem(menuItem);
                return Request.CreateResponse<MenuItem>(HttpStatusCode.OK, MenuItemDeleted);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
