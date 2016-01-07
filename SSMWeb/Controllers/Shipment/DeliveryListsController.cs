using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSMWeb.Models;
using System.Collections;

namespace SSMWeb.Models
{
    [Authorize(Roles = "stocker, admin")]
    public class DeliveryListsController : Controller
    {
        private SSMOrdinaryModel db = new SSMOrdinaryModel();

        // GET: DeliveryLists
        public ActionResult Index(int? id)
        {
            var deliveryLists = db.DeliveryLists.Include(d => d.Delivery).Include(d => d.Product);
            List<DeliveryList> selectedItems = new List<DeliveryList>();
            
            foreach (DeliveryList item in deliveryLists)
            {
                if (item.DeliveryId == id)
                {
                    selectedItems.Add(item);
                }
            }
            ViewBag.DeliveryId = id;

            return View(selectedItems);
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

        // GET: DeliveryLists/Create/3
        public ActionResult Create(int id)
        {
            Shipment shipment = db.Shipments.Find(id);
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.IsDeleted == false), "Id", "SKU");
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "Id", "Shipment.ContainerName",id);
            ViewBag.ReturnRedirectId = id;

            return View();
        }

        // POST: DeliveryLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,BoxQuantity,PartCapOfBox,DeliveryId")] DeliveryList deliveryList, string Create)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryLists.Add(deliveryList);
                db.SaveChanges();
                switch (Create)
                {
                    case "Add":
                        return RedirectToAction("Index", "Deliveries");
                        break;
                    case "Add More":
                        return RedirectToAction("Create", "DeliveryLists", new { id = deliveryList.DeliveryId });
                        break;
                };
            }
            ViewBag.ProductId = new SelectList(db.Products.Where(p => p.IsDeleted == false), "Id", "SKU", deliveryList.ProductId);
            ViewBag.ShipmentId = new SelectList(db.Shipments, "Id", "Date", deliveryList.DeliveryId);

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
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", deliveryList.ProductId);
            ViewBag.DeliveryId = new SelectList(db.Deliveries, "Id", "Shipment.ContainerName", deliveryList.DeliveryId);
            return View(deliveryList);
        }

        // POST: DeliveryLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,BoxQuantity,PartCapOfBox,DeliveryId")] DeliveryList deliveryList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Deliveries");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", deliveryList.ProductId);
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
            return RedirectToAction("Index", "Deliveries");
        }

        // GET: DeliveryLists/Box/5
        public ActionResult Box(int? id)
        {
            DeliveryList deliveryList = db.DeliveryLists.Find(id);
            BoxesController boxer = new BoxesController();
            boxer.Create(deliveryList.ProductId, 1, deliveryList.Id, deliveryList.BoxQuantity, deliveryList.PartCapOfBox, deliveryList.Product.PartQtyUnitID,deliveryList.PartCapOfBox);

            if (ModelState.IsValid)
            {
                deliveryList.BarcodesPrinted = true;
                db.Entry(deliveryList).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index","DeliveryLists", new { id = deliveryList.DeliveryId });
        }


        // GET: DeliveryLists/PrintBarcodes/5
        public ActionResult PrintBarcodes(int? id)
        {
            return Redirect("../../PrintBarcodes.aspx?entity=DeliveryLists&id=" + id);
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
