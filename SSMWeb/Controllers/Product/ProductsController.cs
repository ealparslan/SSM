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
    public class ProductsController : Controller
    {
        private SSMModel db = new SSMModel();

        [Authorize]
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.COG).Include(p => p.FulfilmentSKU).Include(p => p.ProductCategory).Include(p => p.ProductColor).Include(p => p.ProductSize).Include(p => p.QuantityUnit);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.COGSId = new SelectList(db.COGS, "Id", "UnitPrice");
            ViewBag.FulfilmentSKUId = new SelectList(db.FulfilmentSKUs, "Id", "SKU");
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name");
            ViewBag.ColorId = new SelectList(db.ProductColors, "Id", "Name");
            ViewBag.SizeId = new SelectList(db.ProductSizes, "Id", "Name");
            ViewBag.PartQtyUnitID = new SelectList(db.QuantityUnits, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SKU,FulfilmentSKUId,Aliases,Name,ParentId,IsDiscontinued,CategoryId,ColorId,SizeId,PartQtyUnitID,COGSId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COGSId = new SelectList(db.COGS, "Id", "UnitPrice", product.COGSId);
            ViewBag.FulfilmentSKUId = new SelectList(db.FulfilmentSKUs, "Id", "SKU", product.FulfilmentSKUId);
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.ProductColors, "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.ProductSizes, "Id", "Name", product.SizeId);
            ViewBag.PartQtyUnitID = new SelectList(db.QuantityUnits, "Id", "Name", product.PartQtyUnitID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.COGSId = new SelectList(db.COGS, "Id", "UnitPrice", product.COGSId);
            ViewBag.FulfilmentSKUId = new SelectList(db.FulfilmentSKUs, "Id", "SKU", product.FulfilmentSKUId);
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.ProductColors, "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.ProductSizes, "Id", "Name", product.SizeId);
            ViewBag.PartQtyUnitID = new SelectList(db.QuantityUnits, "Id", "Name", product.PartQtyUnitID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SKU,FulfilmentSKUId,Aliases,Name,ParentId,IsDiscontinued,CategoryId,ColorId,SizeId,PartQtyUnitID,COGSId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COGSId = new SelectList(db.COGS, "Id", "UnitPrice", product.COGSId);
            ViewBag.FulfilmentSKUId = new SelectList(db.FulfilmentSKUs, "Id", "SKU", product.FulfilmentSKUId);
            ViewBag.CategoryId = new SelectList(db.ProductCategories, "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.ProductColors, "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.ProductSizes, "Id", "Name", product.SizeId);
            ViewBag.PartQtyUnitID = new SelectList(db.QuantityUnits, "Id", "Name", product.PartQtyUnitID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
