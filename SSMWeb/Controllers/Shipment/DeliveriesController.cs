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
    [Authorize(Roles = "stocker, admin")]
    public class DeliveriesController : Controller
    {
        private SSMOrdinaryModel db = new SSMOrdinaryModel();

        // GET: Deliveries
        public ActionResult Index()
        {
            var deliveries = db.Deliveries.Include(d => d.Shipment).OrderByDescending(d => d.Date);
            return View(deliveries.ToList());
        }

        // GET: Deliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,ShipmentId")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Deliveries.Add(delivery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShipmentId = new SelectList(db.Shipments, "Id", "ContainerName", delivery.ShipmentId);
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,ShipmentId")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Deliveries.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery delivery = db.Deliveries.Find(id);
            db.Deliveries.Remove(delivery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DeliveryLists/AddNewItem/2
        public ActionResult AddNewItem(int? id)
        {
            return RedirectToAction("Create", "DeliveryLists", new { id = id });

        }
        // GET: DeliveryLists/ListItems/2
        public ActionResult ListItems(int? id)
        {
            return RedirectToAction("Index", "DeliveryLists", new { id = id });
        }

        // GET: Deliveries/Box/5
        public ActionResult Box(int? id)
        {
            Delivery delivery = db.Deliveries.Find(id);

            foreach (DeliveryList deliveryList in delivery.DeliveryLists)
            {
                BoxesController boxer = new BoxesController();
                boxer.Create(deliveryList.ProductId, 0, deliveryList.Id, deliveryList.BoxQuantity, deliveryList.PartCapOfBox, deliveryList.Product.PartQtyUnitID, deliveryList.PartCapOfBox);
                if (ModelState.IsValid)
                {
                    deliveryList.BarcodesPrinted = true;
                    db.Entry(deliveryList).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            if (ModelState.IsValid)
            {
                delivery.BarcodesPrinted = true;
                db.Entry(delivery).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        // GET: Deliveries/PrintBarcodes/5
        public ActionResult PrintBarcodes(int? id)
        {
            return Redirect("../../PrintBarcodes.aspx?entity=Deliveries&id=" + id);
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
