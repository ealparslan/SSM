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
    [Authorize]
    public class FulfilmentSKUsController : Controller
    {
        private SSMOrdinaryModel db = new SSMOrdinaryModel();

        // GET: FulfilmentSKUs
        public ActionResult Index()
        {
            return View(db.FulfilmentSKUs.ToList());
        }

        // GET: FulfilmentSKUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FulfilmentSKU fulfilmentSKU = db.FulfilmentSKUs.Find(id);
            if (fulfilmentSKU == null)
            {
                return HttpNotFound();
            }
            return View(fulfilmentSKU);
        }

        // GET: FulfilmentSKUs/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            var fulfilmentSku = new FulfilmentSKU();
            fulfilmentSku.IsDiscontinued = false;
            return View(fulfilmentSku);
        }

        // POST: FulfilmentSKUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SKU,Name,SCName,ASIN,IsDiscontinued")] FulfilmentSKU fulfilmentSKU)
        {
            if (ModelState.IsValid)
            {
                db.FulfilmentSKUs.Add(fulfilmentSKU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fulfilmentSKU);
        }

        // GET: FulfilmentSKUs/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FulfilmentSKU fulfilmentSKU = db.FulfilmentSKUs.Find(id);
            if (fulfilmentSKU == null)
            {
                return HttpNotFound();
            }
            return View(fulfilmentSKU);
        }

        // POST: FulfilmentSKUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SKU,Name,SCName,ASIN,IsDiscontinued")] FulfilmentSKU fulfilmentSKU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fulfilmentSKU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fulfilmentSKU);
        }

        // GET: FulfilmentSKUs/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FulfilmentSKU fulfilmentSKU = db.FulfilmentSKUs.Find(id);
            if (fulfilmentSKU == null)
            {
                return HttpNotFound();
            }
            return View(fulfilmentSKU);
        }

        // POST: FulfilmentSKUs/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FulfilmentSKU fulfilmentSKU = db.FulfilmentSKUs.Find(id);
            db.FulfilmentSKUs.Remove(fulfilmentSKU);
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
