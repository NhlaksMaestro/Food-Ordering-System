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
    public class OrderedItemController : Controller
    {
        private FoodOrderingSystemDBContext db = new FoodOrderingSystemDBContext();

        // GET: /OrderedItem/
        public async Task<ActionResult> Index()
        {
            var ordereditems = db.OrderedItems.Include(o => o.MenuItem).Include(o => o.Order);
            return View(await ordereditems.ToListAsync());
        }

        // GET: /OrderedItem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedItem ordereditem = await db.OrderedItems.FindAsync(id);
            if (ordereditem == null)
            {
                return HttpNotFound();
            }
            return View(ordereditem);
        }

        // GET: /OrderedItem/Create
        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "Name");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Name");
            return View();
        }

        // POST: /OrderedItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="OrderedItemId,MenuItemId,OrderId,Quantity")] OrderedItem ordereditem)
        {
            if (ModelState.IsValid)
            {
                db.OrderedItems.Add(ordereditem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "Name", ordereditem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Name", ordereditem.OrderId);
            return View(ordereditem);
        }

        // GET: /OrderedItem/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedItem ordereditem = await db.OrderedItems.FindAsync(id);
            if (ordereditem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "Name", ordereditem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Name", ordereditem.OrderId);
            return View(ordereditem);
        }

        // POST: /OrderedItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="OrderedItemId,MenuItemId,OrderId,Quantity")] OrderedItem ordereditem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordereditem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "Name", ordereditem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Name", ordereditem.OrderId);
            return View(ordereditem);
        }

        // GET: /OrderedItem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderedItem ordereditem = await db.OrderedItems.FindAsync(id);
            if (ordereditem == null)
            {
                return HttpNotFound();
            }
            return View(ordereditem);
        }

        // POST: /OrderedItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderedItem ordereditem = await db.OrderedItems.FindAsync(id);
            db.OrderedItems.Remove(ordereditem);
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
