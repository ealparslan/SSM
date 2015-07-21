﻿using System;
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
        private SSMOrdinaryModel db = new SSMOrdinaryModel();

        // GET: Boxes
        public ActionResult Index()
        {
            var boxes = db.Boxes.Include(b => b.Location).Include(b => b.Product).Include(b => b.DeliveryList);
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
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU");
            return View();
        }

        // POST: Boxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,PartCapOfBox,PartQtyUnitID,PartQtyLeft,BoxUnitOfTotal,BoxTotalOfTotal,PONumber,LocationID,DeliveryListId,BarcodeType,BarcodeId,BarcodeImage")] Box box)
        {
            if (ModelState.IsValid)
            {
                db.Boxes.Add(box);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "Id", "Name", box.LocationID);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", box.ProductId);
            return View(box);
        }

        public int Create(int productId,int locationId, int deliveryListId, int boxQty)
        {

                if (ModelState.IsValid)
                {
                    //Box box;
                    string barcodePrefix = deliveryListId.ToString() + "-" + productId.ToString() + "-" + locationId.ToString();
                    
                    for (int i = 1; i <= boxQty; i++)
                    {
                        Box box = new Box();
                        box.DeliveryListId = deliveryListId;
                        box.LocationID = locationId;
                        box.ProductId = productId;
                        box.BarcodeId = barcodePrefix + "-" + i.ToString();
                        box.BarcodeImage = GetBarcodeImage(box.BarcodeId);
                        db.Boxes.Add(box);
                    }
                    db.SaveChanges();
                    return 0;
                }

            return -1;
        }

        private byte[] GetBarcodeImage(string barcodeSource)
        {
            //Create an instance of BarcodeProfessional class
            using (Neodynamic.Web.MVC.Barcode.BarcodeProfessional bcp = new Neodynamic.Web.MVC.Barcode.BarcodeProfessional())
            {
                //Set the desired barcode type or symbology
                bcp.Symbology = Neodynamic.Web.MVC.Barcode.Symbology.QRCode;
                //Set value to encode
                bcp.Code = barcodeSource;
                //Generate barcode image
                byte[] imgBuffer = bcp.GetBarcodeImage(System.Drawing.Imaging.ImageFormat.Png);
                //Write image buffer to Response obj
                return imgBuffer;
            }
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
            ViewBag.LocationID = new SelectList(db.Locations, "Id", "Name", box.LocationID);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", box.ProductId);
            return View(box);
        }

        // POST: Boxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,PartCapOfBox,PartQtyUnitID,PartQtyLeft,BoxUnitOfTotal,BoxTotalOfTotal,PONumber,LocationID,DeliveryListId,BarcodeType,BarcodeId,BarcodeImage")] Box box)
        {
            if (ModelState.IsValid)
            {
                db.Entry(box).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
