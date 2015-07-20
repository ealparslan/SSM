using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SSMWeb.Models
{
    public class BoxesController : Controller
    {
        private SSMEntities db = new SSMEntities();

        // GET: Boxes
        public ActionResult Index()
        {
            var boxes = db.Boxes.Include(b => b.Barcode).Include(b => b.Location).Include(b => b.Product);
            return View(boxes.ToList());
        }

        // GET: Boxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box box = db.Boxes.Find(id);
            if (box == null)
            {
                return HttpNotFound();
            }
            return View(box);
        }

        // GET: Boxes/Create
        public ActionResult Create()
        {
            ViewBag.BarcodeId = new SelectList(db.Barcodes, "Id", "CodeNumber");
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU");
            return View();
        }

        // POST: Boxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BarcodeId,ProductId,PartCapOfBox,PartQtyUnitID,PartQtyLeft,BoxUnitOfTotal,BoxTotalOfTotal,PONumber,LocationID,DeliveryId")] Box box)
        {
            if (ModelState.IsValid)
            {
                db.Boxes.Add(box);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarcodeId = new SelectList(db.Barcodes, "Id", "CodeNumber", box.BarcodeId);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "Name", box.LocationID);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", box.ProductId);
            return View(box);
        }

        // GET: Boxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box box = db.Boxes.Find(id);
            if (box == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarcodeId = new SelectList(db.Barcodes, "Id", "CodeNumber", box.BarcodeId);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "Name", box.LocationID);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", box.ProductId);
            return View(box);
        }

        // POST: Boxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BarcodeId,ProductId,PartCapOfBox,PartQtyUnitID,PartQtyLeft,BoxUnitOfTotal,BoxTotalOfTotal,PONumber,LocationID,DeliveryId")] Box box)
        {
            if (ModelState.IsValid)
            {
                db.Entry(box).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarcodeId = new SelectList(db.Barcodes, "Id", "CodeNumber", box.BarcodeId);
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "Name", box.LocationID);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", box.ProductId);
            return View(box);
        }

        // GET: Boxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box box = db.Boxes.Find(id);
            if (box == null)
            {
                return HttpNotFound();
            }
            return View(box);
        }

        // POST: Boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Box box = db.Boxes.Find(id);
            db.Boxes.Remove(box);
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
