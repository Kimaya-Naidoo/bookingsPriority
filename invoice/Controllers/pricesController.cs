using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using invoice.Models;

namespace invoice.Controllers
{
    public class pricesController : Controller
    {
        private invoiceContext db = new invoiceContext();

        // GET: prices
        public ActionResult Index()
        {
            return View(db.Prices.ToList());
        }

        // GET: prices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prices prices = db.Prices.Find(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            return View(prices);
        }

        // GET: prices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rate,six,twelve,dry,tank,refridge,perishables")] prices prices)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(prices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prices);
        }

        // GET: prices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prices prices = db.Prices.Find(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            return View(prices);
        }

        // POST: prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rate,six,twelve,dry,tank,refridge,perishables")] prices prices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prices);
        }

        // GET: prices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prices prices = db.Prices.Find(id);
            if (prices == null)
            {
                return HttpNotFound();
            }
            return View(prices);
        }

        // POST: prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prices prices = db.Prices.Find(id);
            db.Prices.Remove(prices);
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
