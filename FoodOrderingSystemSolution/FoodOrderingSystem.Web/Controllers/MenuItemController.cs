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
    public class MenuItemController : Controller
    {
        private FoodOrderingSystemDBContext db = new FoodOrderingSystemDBContext();

        // GET: /MenuItem/
        public async Task<ActionResult> Index()
        {
            var menuitems = db.MenuItems.Include(m => m.MenuCategory);
            return View(await menuitems.ToListAsync());
        }

        // GET: /MenuItem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuitem = await db.MenuItems.FindAsync(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        // GET: /MenuItem/Create
        public ActionResult Create()
        {
            ViewBag.MenuCategoryId = new SelectList(db.MenuCategories, "MenuCategoryId", "CategoryName");
            return View();
        }

        // POST: /MenuItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="MenuItemId,Name,Description,Price,ImagePath,MenuCategoryId")] MenuItem menuitem)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menuitem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MenuCategoryId = new SelectList(db.MenuCategories, "MenuCategoryId", "CategoryName", menuitem.MenuCategoryId);
            return View(menuitem);
        }

        // GET: /MenuItem/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuitem = await db.MenuItems.FindAsync(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuCategoryId = new SelectList(db.MenuCategories, "MenuCategoryId", "CategoryName", menuitem.MenuCategoryId);
            return View(menuitem);
        }

        // POST: /MenuItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="MenuItemId,Name,Description,Price,ImagePath,MenuCategoryId")] MenuItem menuitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuitem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MenuCategoryId = new SelectList(db.MenuCategories, "MenuCategoryId", "CategoryName", menuitem.MenuCategoryId);
            return View(menuitem);
        }

        // GET: /MenuItem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuitem = await db.MenuItems.FindAsync(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        // POST: /MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MenuItem menuitem = await db.MenuItems.FindAsync(id);
            db.MenuItems.Remove(menuitem);
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
