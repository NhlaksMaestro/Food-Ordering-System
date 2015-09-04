using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodOrderingSystem.Entities;
using FoodOrderingSystem.DataStore;

namespace FoodOrderingSystem.Web.Controllers
{
    public class MenuCategoryController : Controller
    {
        private FoodOrderingSystemDBContext db = new FoodOrderingSystemDBContext();

        // GET: /MenuCategory/
        public async Task<ActionResult> Index()
        {
            return View(await db.MenuCategories.ToListAsync());
        }

        // GET: /MenuCategory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCategory menucategory = await db.MenuCategories.FindAsync(id);
            if (menucategory == null)
            {
                return HttpNotFound();
            }
            return View(menucategory);
        }

        // GET: /MenuCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /MenuCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="MenuCategoryId,CategoryName,ImagePath")] MenuCategory menucategory)
        {
            if (ModelState.IsValid)
            {
                db.MenuCategories.Add(menucategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(menucategory);
        }

        // GET: /MenuCategory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCategory menucategory = await db.MenuCategories.FindAsync(id);
            if (menucategory == null)
            {
                return HttpNotFound();
            }
            return View(menucategory);
        }

        // POST: /MenuCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="MenuCategoryId,CategoryName,ImagePath")] MenuCategory menucategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menucategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(menucategory);
        }

        // GET: /MenuCategory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuCategory menucategory = await db.MenuCategories.FindAsync(id);
            if (menucategory == null)
            {
                return HttpNotFound();
            }
            return View(menucategory);
        }

        // POST: /MenuCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MenuCategory menucategory = await db.MenuCategories.FindAsync(id);
            db.MenuCategories.Remove(menucategory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
