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
    public class BarcodesController : Controller
    {
        private SSMEntities db = new SSMEntities();

        // GET: Barcodes
        public ActionResult Index()
        {
            return View(db.Barcodes.ToList());
        }

        // GET: Barcodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcode barcode = db.Barcodes.Find(id);
            if (barcode == null)
            {
                return HttpNotFound();
            }
            return View(barcode);
        }

        // GET: Barcodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barcodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodeNumber,CodeType,Image")] Barcode barcode)
        {
            if (ModelState.IsValid)
            {
                db.Barcodes.Add(barcode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(barcode);
        }

        // GET: Barcodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcode barcode = db.Barcodes.Find(id);
            if (barcode == null)
            {
                return HttpNotFound();
            }
            return View(barcode);
        }

        // POST: Barcodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodeNumber,CodeType,Image")] Barcode barcode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barcode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barcode);
        }

        // GET: Barcodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcode barcode = db.Barcodes.Find(id);
            if (barcode == null)
            {
                return HttpNotFound();
            }
            return View(barcode);
        }

        // POST: Barcodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barcode barcode = db.Barcodes.Find(id);
            db.Barcodes.Remove(barcode);
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