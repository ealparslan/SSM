using System;
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
    public class QuantityUnitsController : Controller
    {
        private SSMEntities db = new SSMEntities();

        // GET: QuantityUnits
        public ActionResult Index()
        {
            return View(db.QuantityUnits.ToList());
        }

        // GET: QuantityUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityUnit quantityUnit = db.QuantityUnits.Find(id);
            if (quantityUnit == null)
            {
                return HttpNotFound();
            }
            return View(quantityUnit);
        }

        // GET: QuantityUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuantityUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] QuantityUnit quantityUnit)
        {
            if (ModelState.IsValid)
            {
                db.QuantityUnits.Add(quantityUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quantityUnit);
        }

        // GET: QuantityUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityUnit quantityUnit = db.QuantityUnits.Find(id);
            if (quantityUnit == null)
            {
                return HttpNotFound();
            }
            return View(quantityUnit);
        }

        // POST: QuantityUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] QuantityUnit quantityUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quantityUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quantityUnit);
        }

        // GET: QuantityUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuantityUnit quantityUnit = db.QuantityUnits.Find(id);
            if (quantityUnit == null)
            {
                return HttpNotFound();
            }
            return View(quantityUnit);
        }

        // POST: QuantityUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuantityUnit quantityUnit = db.QuantityUnits.Find(id);
            db.QuantityUnits.Remove(quantityUnit);
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
