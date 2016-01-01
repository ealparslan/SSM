using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSMWeb.Models;

namespace SSMWeb.Controllers.Order
{
    [Authorize(Roles = "stocker, admin")]
    public class OrderListsController : Controller
    {
        private SSMOrdinaryModel db = new SSMOrdinaryModel();

        // GET: OrderLists
        public async Task<ActionResult> Index(int id)
        {
            if(TempData["ErrorMessage"] != null)
                @ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            if (TempData["BoxId"] != null)
                @ViewBag.BoxId = TempData["BoxId"].ToString();
            var orderLists = db.OrderLists.Include(o => o.Order).Where(o => o.OrderId == id);
            TempData["OrderId"] = id;
            @ViewBag.OrderId = id;
            return View(await orderLists.ToListAsync());
        }

        // GET: OrderLists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = await db.OrderLists.FindAsync(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // GET: OrderLists/Create
        public ActionResult Create(int id)
        {

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderName", id);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU");

            return View();
        }

        //Action Function 
        [HttpPost]
        public int SelectAction(int id)
        {
            return db.Products.Find(id).BoxCapacity;
        }

        // POST: OrderLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductId,OrderId,RequestedBoxQuantity,SoldBoxQuantity")] OrderList orderList, string Create)
        {
            if (ModelState.IsValid)
            {
                db.OrderLists.Add(orderList);
                await db.SaveChangesAsync();
                switch (Create)
                {
                    case "Add":
                        return RedirectToAction("Index", "Orders");
                        break;
                    case "Add More":
                        return RedirectToAction("Create", "OrderLists", new { id = orderList.OrderId });
                        break;
                };
            }

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderName", orderList.OrderId);
            return View(orderList);
        }

        // GET: OrderLists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = await db.OrderLists.FindAsync(id);

            if (orderList == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderName", orderList.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", orderList.ProductId);
            return View(orderList);
        }

        // POST: OrderLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductId,OrderId,RequestedBoxQuantity,SoldBoxQuantity")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderName", orderList.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", orderList.ProductId);
            return View(orderList);
        }

        // GET: OrderLists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = await db.OrderLists.FindAsync(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // POST: OrderLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderList orderList = await db.OrderLists.FindAsync(id);
            db.OrderLists.Remove(orderList);
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

        //[HandleError()]
        public ActionResult Sell(string boxid, int orderid)
        {
            //int orderid = (int)RouteData.Values["id"];

            TempData["ErrorMessage"] = "";
            TempData["RegularMessage"] = "";

            Box box = db.Boxes.Where(b => b.BarcodeId == boxid).FirstOrDefault();

            if (box == null)
            {
                TempData["ErrorMessage"] = "NO ANY BOX WITH THIS ID!";
                //throw new Exception("BOX ID NOT FOUND!");
            }
            else if (box.PartQtyLeft == 0)
            {
                TempData["ErrorMessage"] = "This Box has been sold before!";
            }
            else
            {
                OrderList orderList = db.OrderLists.Where(s=>s.OrderId == orderid).Where(s => s.ProductId == box.ProductId).FirstOrDefault(); // each orderlist must have different SKU!!!
                if(orderList == null)
                {
                    TempData["ErrorMessage"] = "NO ANY ORDER ITEMS RELATED TO THIS BOX!";
                }
                else
                {
                    if (orderList.RequestedBoxQuantity > orderList.SoldBoxQuantity)
                    {
                        orderList.SoldBoxQuantity++;
                        box.PartQtyLeft = 0;
                        db.Entry(box).State = EntityState.Modified;
                        db.Entry(orderList).State = EntityState.Modified;
                        db.SaveChanges();
                        TempData["BoxId"] = boxid;
                    }
                }    
            }
            return RedirectToAction("Index", "OrderLists", new { id = (int)TempData["OrderId"]/*, r = "refreshing"*/ });
        }

    }
}
