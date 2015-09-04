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
        [RoutePrefix("api/menucategory")]
    public class MenuCategoryController : ApiController
    {
        private IFoodOrderingSystemRepository _repository = default(FoodOrderingSystemSqlRepository);
        public MenuCategoryController()
        {
            _repository = new FoodOrderingSystemSqlRepository();
        }

        [HttpGet]
        public HttpResponseMessage GetMenuCategory()
        {
            try
            {
                var MenuCategories = _repository.GetMenuCategories();
                return Request.CreateResponse<List<MenuCategory>>(HttpStatusCode.OK, MenuCategories);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [Route("{menuCategoryId}")]
        [HttpGet]
        public HttpResponseMessage GetMenuCategoryById(int menuCategoryId)
        {
            try
            {
                var menuCategory = _repository.GetMenuCategoryById(menuCategoryId);
                return Request.CreateResponse<MenuCategory>(HttpStatusCode.OK, menuCategory);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [HttpPost]
        public HttpResponseMessage PostMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                var MenuCategoryAdded = _repository.InsertMenuCategory(menuCategory);
                return Request.CreateResponse<MenuCategory>(HttpStatusCode.OK, MenuCategoryAdded);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage PutMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                var MenuCategoryUpdate = _repository.UpdateMenuCategory(menuCategory);
                return Request.CreateResponse<MenuCategory>(HttpStatusCode.OK, MenuCategoryUpdate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                var MenuCategoryDeleted = _repository.InsertMenuCategory(menuCategory);
                return Request.CreateResponse<MenuCategory>(HttpStatusCode.OK, MenuCategoryDeleted);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);
            }
        }
    }
}
