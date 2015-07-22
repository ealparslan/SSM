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
    public class ShipmentsController : Controller
    {
        private SSMOrdinaryModel db = new SSMOrdinaryModel();


        // GET: Shipments
        public ActionResult Index()
        {
            return View(db.Shipments.ToList());
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
            String[] destCities = { "Los Angeles", "New York", "San Francisco" }; 
            ViewBag.destCities = new SelectList(destCities);

            Shipment model = new Shipment
            {
                CreatedUserId = User.Identity.Name ,
                CreatedDate =  new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
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
            shipment.UpdatedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
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
            return RedirectToAction("Index", "ShipmentLists");
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
