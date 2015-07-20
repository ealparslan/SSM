﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSMWeb.Models;

namespace SSMWeb.Controllers
{
    public class ShipmentListsController : Controller
    {
        private SSMEntities db = new SSMEntities();

        // GET: ShipmentLists
        public ActionResult Index()
        {
            var shipmentLists = db.ShipmentLists.Include(s => s.Product).Include(s => s.Shipment);
            return View(shipmentLists.ToList());
        }

        // GET: ShipmentLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentList shipmentList = db.ShipmentLists.Find(id);
            if (shipmentList == null)
            {
                return HttpNotFound();
            }
            return View(shipmentList);
        }

        /*
        // GET: ShipmentLists/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU");
            ViewBag.ShipmentId = new SelectList(db.Shipments, "Id", "ContainerName");
            return View();
        }
        */

        public ActionResult Create(int? id)
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU");
            ViewBag.ShipmentId = new SelectList(db.Shipments, "Id", "ContainerName", db.Shipments.Find(id).Id);

            return View();
        }

        // POST: ShipmentLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,BoxCapacity,BoxQuantity,ShipmentId")] ShipmentList shipmentList)
        {
            if (ModelState.IsValid)
            {
                db.ShipmentLists.Add(shipmentList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", shipmentList.ProductId);
            ViewBag.ShipmentId = new SelectList(db.Shipments, "Id", "ContainerName", shipmentList.ShipmentId);
            return View(shipmentList);
        }

        // GET: ShipmentLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentList shipmentList = db.ShipmentLists.Find(id);
            if (shipmentList == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", shipmentList.ProductId);
            ViewBag.ShipmentId = new SelectList(db.Shipments, "Id", "ContainerName", shipmentList.ShipmentId);
            return View(shipmentList);
        }

        // POST: ShipmentLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,BoxCapacity,BoxQuantity,ShipmentId")] ShipmentList shipmentList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipmentList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", shipmentList.ProductId);
            ViewBag.ShipmentId = new SelectList(db.Shipments, "Id", "ContainerName", shipmentList.ShipmentId);
            return View(shipmentList);
        }

        // GET: ShipmentLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipmentList shipmentList = db.ShipmentLists.Find(id);
            if (shipmentList == null)
            {
                return HttpNotFound();
            }
            return View(shipmentList);
        }

        // POST: ShipmentLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipmentList shipmentList = db.ShipmentLists.Find(id);
            db.ShipmentLists.Remove(shipmentList);
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