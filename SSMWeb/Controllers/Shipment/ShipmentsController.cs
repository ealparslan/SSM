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
    [Authorize(Roles = "shipper, stocker, admin")]
    public class ShipmentsController : Controller
    {
        String[] destCities = { "Los Angeles", "New York", "San Francisco" };
        String[] containerTypes = { " ", "20", "40" };

        private SSMOrdinaryModel db = new SSMOrdinaryModel();


        // GET: Shipments
        public ActionResult Index()
        {
            return View(db.Shipments.OrderByDescending(s => s.CreatedDate).ToList());
        }

        // GET: Shipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            ViewBag.destCities = new SelectList(destCities);
            ViewBag.containerTypes = new SelectList(containerTypes);

            Shipment model = new Shipment
            {
                CreatedUserId = User.Identity.Name ,
                CreatedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            };
            return View(model);

        }

        // POST: Shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,LoadedDate,ContainerName,PONumber,BoxQuantity,DestinationCity,ETD,ContainerType,PickupReferanceID,VesselName,IsAirShipment,FreightCompany,IsCustomsCleared,IsDelivered,IsCustomsPaid,IsFreightPaid,CustomsAmount,FreightAmount,HandlingFeeAmount")] Shipment shipment)
        {
            ViewBag.destCities = new SelectList(destCities);
            ViewBag.containerTypes = new SelectList(containerTypes);

            if (ModelState.IsValid)
            {
                db.Shipments.Add(shipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipment);
        }

        // GET: Shipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.destCities = new SelectList(destCities);
            ViewBag.containerTypes = new SelectList(containerTypes);

            shipment.UpdatedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            shipment.UpdatedUserId = User.Identity.Name;
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,LoadedDate,ContainerName,PONumber,BoxQuantity,DestinationCity,ETD,ContainerType,PickupReferanceID,VesselName,IsAirShipment,FreightCompany,IsCustomsCleared,IsDelivered,IsCustomsPaid,IsFreightPaid,CustomsAmount,FreightAmount,HandlingFeeAmount")] Shipment shipment)
        {
            ViewBag.destCities = new SelectList(destCities);
            ViewBag.containerTypes = new SelectList(containerTypes);

            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipment shipment = db.Shipments.Find(id);
            if(shipment.IsDelivered)
            {
                TempData["ErrorMessage"] = "You cannot delete a shipment if it is delivered! This shipment is delivered on " + shipment.Deliveries.FirstOrDefault().Date;
                return RedirectToAction("Index");
            }
            db.Shipments.Remove(shipment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Shipments/AddNewItem/2
        public ActionResult AddNewItem(int? id)
        {
            return RedirectToAction("Create", "ShipmentLists", new {id = id});

        }
        // GET: Shipments/ListItems/2
        public ActionResult ListItems(int? id)
        {
            return RedirectToAction("Index", "ShipmentLists", new { id = id });
        }

        // GET: Shipments/Delivered/2
        public ActionResult Delivered(int? id)
        {
            Shipment shipment = db.Shipments.Find(id);
            shipment.IsDelivered = true;
            db.Entry(shipment).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Shipments/Undelivered/2
        public ActionResult Undelivered(int? id)
        {
            Shipment shipment = db.Shipments.Find(id);
            HashSet<DeliveryList> list = shipment.Deliveries.FirstOrDefault().DeliveryLists;
            foreach (DeliveryList item in list)
            {
                if (item.BarcodesPrinted)
                {
                    TempData["ErrorMessage"] = "At least one item in this delivery was boxed and barcoded. You cannot undeliver a shipment after barcodes printed!";
                    return RedirectToAction("Index");
                }
            }

            shipment.IsDelivered = false;
            db.Entry(shipment).State = EntityState.Modified;
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
