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
    public class ProductsController : Controller
    {
        private SSMOrdinaryModel db = new SSMOrdinaryModel();

        [Authorize]
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products./*Include(p => p.FulfilmentSKU).*/Include(p => p.ProductCategory).Include(p => p.ProductColor).Include(p => p.ProductSize).Include(p => p.QuantityUnit).Where(p=>p.IsDeleted == false);
            return View(products.ToList());
        }

        [Authorize]
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

        [Authorize(Roles = "admin")]
        // GET: Products/Create
        public ActionResult Create()
        {
            //ViewBag.FulfilmentSKUId = new SelectList(db.FulfilmentSKUs, "Id", "SKU");
            ViewBag.CategoryId = new SelectList(db.ProductCategories.Where(c=>c.IsEnabled == true), "Id", "Name");
            ViewBag.ColorId = new SelectList(db.ProductColors.Where(c => c.IsEnabled == true), "Id", "Name");
            ViewBag.SizeId = new SelectList(db.ProductSizes.Where(c => c.IsEnabled == true), "Id", "Name");
            ViewBag.PartQtyUnitID = new SelectList(db.QuantityUnits.Where(c => c.IsEnabled == true), "Id", "Name");
            return View();
        }


        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SKU,Aliases,Name,ParentId,IsDiscontinued,CategoryId,ColorId,SizeId,PartQtyUnitID,BoxCapacity,IsDeleted")] Product product)
        {
            if (product.PartQtyUnitID == 0)
            {
                TempData["ErrorMessage"] = "PartQuantity must be filled!";
            }
            else if (product.SizeId == 0)
            {
                TempData["ErrorMessage"] = "Size must be filled!";
            }
            else if (product.CategoryId == 0)
            {
                TempData["ErrorMessage"] = "Category must be filled!";
            }
            else if (product.ColorId == 0)
            {
                TempData["ErrorMessage"] = "Color must be filled!";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //ViewBag.FulfilmentSKUId = new SelectList(db.FulfilmentSKUs, "Id", "SKU", product.FulfilmentSKUId);
            ViewBag.CategoryId = new SelectList(db.ProductCategories.Where(c => c.IsEnabled == true), "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.ProductColors.Where(c => c.IsEnabled == true), "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.ProductSizes.Where(c => c.IsEnabled == true), "Id", "Name", product.SizeId);
            ViewBag.PartQtyUnitID = new SelectList(db.QuantityUnits.Where(c => c.IsEnabled == true), "Id", "Name", product.PartQtyUnitID);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "admin")]
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
            //ViewBag.FulfilmentSKUId = new SelectList(db.FulfilmentSKUs, "Id", "SKU", product.FulfilmentSKUId);
            ViewBag.CategoryId = new SelectList(db.ProductCategories.Where(c => c.IsEnabled == true), "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.ProductColors.Where(c => c.IsEnabled == true), "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.ProductSizes.Where(c => c.IsEnabled == true), "Id", "Name", product.SizeId);
            ViewBag.PartQtyUnitID = new SelectList(db.QuantityUnits.Where(c => c.IsEnabled == true), "Id", "Name", product.PartQtyUnitID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SKU,Aliases,Name,ParentId,IsDiscontinued,CategoryId,ColorId,SizeId,PartQtyUnitID,BoxCapacity,IsDeleted")] Product product)
        {
            if (product.PartQtyUnitID == 0)
            {
                TempData["ErrorMessage"] = "PartQuantity must be filled!";
            }
            else if (product.SizeId == 0)
            {
                TempData["ErrorMessage"] = "Size must be filled!";
            }
            else if (product.CategoryId == 0)
            {
                TempData["ErrorMessage"] = "Category must be filled!";
            }
            else if (product.ColorId == 0)
            {
                TempData["ErrorMessage"] = "Color must be filled!";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            //ViewBag.FulfilmentSKUId = new SelectList(db.FulfilmentSKUs, "Id", "SKU", product.FulfilmentSKUId);
            ViewBag.CategoryId = new SelectList(db.ProductCategories.Where(c => c.IsEnabled == true), "Id", "Name", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.ProductColors.Where(c => c.IsEnabled == true), "Id", "Name", product.ColorId);
            ViewBag.SizeId = new SelectList(db.ProductSizes.Where(c => c.IsEnabled == true), "Id", "Name", product.SizeId);
            ViewBag.PartQtyUnitID = new SelectList(db.QuantityUnits.Where(c => c.IsEnabled == true), "Id", "Name", product.PartQtyUnitID);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            product.IsDeleted = true;
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
