using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayerPrimitives;

namespace SSMWeb.Models
{
    public class DeliveryListsController : Controller
    {
        private SSMModel db = new SSMModel();

        // GET: DeliveryLists
        public ActionResult Index()
        {
            var deliveryLists = db.DeliveryLists.Include(d => d.Delivery);
            return View(deliveryLists.ToList());
        }

        // GET: DeliveryLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryList deliveryList = db.DeliveryLists.Find(id);
            if (deliveryList == null)
            {
                return HttpNotFound();
            }
            return View(deliveryList);
        }

        // GET: DeliveryLists/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "Id", "Date");
            return View();
        }

        // POST: DeliveryLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,BoxQuantiy,PartCapOfBox,DeliveryId")] DeliveryList deliveryList)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryLists.Add(deliveryList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryId = new SelectList(db.Deliveries, "Id", "Date", deliveryList.DeliveryId);
            return View(deliveryList);
        }

        // GET: DeliveryLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryList deliveryList = db.DeliveryLists.Find(id);
            if (deliveryList == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "Id", "Date", deliveryList.DeliveryId);
            return View(deliveryList);
        }

        // POST: DeliveryLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,BoxQuantiy,PartCapOfBox,DeliveryId")] DeliveryList deliveryList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "Id", "Date", deliveryList.DeliveryId);
            return View(deliveryList);
        }

        // GET: DeliveryLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryList deliveryList = db.DeliveryLists.Find(id);
            if (deliveryList == null)
            {
                return HttpNotFound();
            }
            return View(deliveryList);
        }

        // POST: DeliveryLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryList deliveryList = db.DeliveryLists.Find(id);
            db.DeliveryLists.Remove(deliveryList);
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
