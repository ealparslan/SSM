using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSMWeb.Models;

namespace SSMWeb.Models
{
    public class OrderListsController : Controller
    {
        private SSMModel db = new SSMModel();

        // GET: OrderLists
        public ActionResult Index()
        {
            var orderLists = db.OrderLists.Include(o => o.Box);
            return View(orderLists.ToList());
        }

        // GET: OrderLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = db.OrderLists.Find(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // GET: OrderLists/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Boxes, "Id", "PONumber");
            return View();
        }

        // POST: OrderLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderName,SoldDate,SalesChannel,BoxId,SoldQty")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                db.OrderLists.Add(orderList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Boxes, "Id", "PONumber", orderList.Id);
            return View(orderList);
        }

        // GET: OrderLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = db.OrderLists.Find(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Boxes, "Id", "PONumber", orderList.Id);
            return View(orderList);
        }

        // POST: OrderLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderName,SoldDate,SalesChannel,BoxId,SoldQty")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Boxes, "Id", "PONumber", orderList.Id);
            return View(orderList);
        }

        // GET: OrderLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = db.OrderLists.Find(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // POST: OrderLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderList orderList = db.OrderLists.Find(id);
            db.OrderLists.Remove(orderList);
            db.SaveChanges();
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
