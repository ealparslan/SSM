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
    public class COGsController : Controller
    {
        private SSMOrdinaryModel db = new SSMOrdinaryModel();

        // GET: COGs
        public ActionResult Index()
        {
            var COGS = db.COGS.Include(c => c.Product);
            return View(COGS.ToList());
        }

        // GET: COGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COG cOG = db.COGS.Find(id);
            if (cOG == null)
            {
                return HttpNotFound();
            }
            return View(cOG);
        }

        // GET: COGs/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU");
            return View();
        }

        // POST: COGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UnitPrice,MinQty,MaxQty,SetPrice,ProductId")] COG cOG)
        {
            if (ModelState.IsValid)
            {
                db.COGS.Add(cOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", cOG.ProductId);
            return View(cOG);
        }

        // GET: COGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COG cOG = db.COGS.Find(id);
            if (cOG == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", cOG.ProductId);
            return View(cOG);
        }

        // POST: COGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UnitPrice,MinQty,MaxQty,SetPrice,ProductId")] COG cOG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "SKU", cOG.ProductId);
            return View(cOG);
        }

        // GET: COGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COG cOG = db.COGS.Find(id);
            if (cOG == null)
            {
                return HttpNotFound();
            }
            return View(cOG);
        }

        // POST: COGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COG cOG = db.COGS.Find(id);
            db.COGS.Remove(cOG);
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
