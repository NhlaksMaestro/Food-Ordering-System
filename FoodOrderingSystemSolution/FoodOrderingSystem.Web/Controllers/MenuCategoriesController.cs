using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FoodOrderingSystem.DataStore;
using FoodOrderingSystem.Entities;

namespace FoodOrderingSystem.Web.Controllers
{
    public class MenuCategoriesController : ApiController
    {
        private FoodOrderingSystemDBContext db = new FoodOrderingSystemDBContext();

        // GET: api/MenuCategories
        public IQueryable<MenuCategory> GetMenuCategories()
        {
            return db.MenuCategories;
        }

        // GET: api/MenuCategories/5
        [ResponseType(typeof(MenuCategory))]
        public async Task<IHttpActionResult> GetMenuCategory(int id)
        {
            MenuCategory menuCategory = await db.MenuCategories.FindAsync(id);
            if (menuCategory == null)
            {
                return NotFound();
            }

            return Ok(menuCategory);
        }

        // PUT: api/MenuCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMenuCategory(int id, MenuCategory menuCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuCategory.MenuCategoryId)
            {
                return BadRequest();
            }

            db.Entry(menuCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MenuCategories
        [ResponseType(typeof(MenuCategory))]
        public async Task<IHttpActionResult> PostMenuCategory(MenuCategory menuCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuCategories.Add(menuCategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = menuCategory.MenuCategoryId }, menuCategory);
        }

        // DELETE: api/MenuCategories/5
        [ResponseType(typeof(MenuCategory))]
        public async Task<IHttpActionResult> DeleteMenuCategory(int id)
        {
            MenuCategory menuCategory = await db.MenuCategories.FindAsync(id);
            if (menuCategory == null)
            {
                return NotFound();
            }

            db.MenuCategories.Remove(menuCategory);
            await db.SaveChangesAsync();

            return Ok(menuCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuCategoryExists(int id)
        {
            return db.MenuCategories.Count(e => e.MenuCategoryId == id) > 0;
        }
    }
}