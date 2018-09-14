using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using invoice.Models;
using System.Globalization;

namespace invoice.Controllers
{
    public class Bookings1Controller : Controller
    {
        private invoiceContext db = new invoiceContext();

        // GET: Bookings1
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: Bookings1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingIds,pickupdate,dropofdate,dropCity,clientname,cellnum,email,ConNum,ConType,Size,specInstruct,testtext,two,Distance,final,Collection,Dropoff,priorty")] Booking booking)
        {
            if (ModelState.IsValid)
            {

                string neww = booking.testtext;

                neww = neww.Replace("km", "");
                neww = neww.Replace(",", "");
                neww = neww.Trim();

                string dist = neww;
                booking.two = Convert.ToDouble(neww, CultureInfo.InvariantCulture);
                booking.two = Math.Round(booking.two);
                booking.Distance = booking.testtext;

                //prices prices = new prices();
                //booking.final = booking.finalAmt();

                var c = db.Prices.Where(x => x.id == 1);
                double r = Convert.ToDouble(c.Sum(y => y.rate));
                double s = Convert.ToDouble(c.Sum(a => a.six));
                double t = Convert.ToDouble(c.Sum(v => v.twelve));
                double ta = Convert.ToDouble(c.Sum(w => w.tank));
                double re = Convert.ToDouble(c.Sum(f => f.refridge));
                double p = Convert.ToDouble(c.Sum(e => e.dry));

                double tot = 0.00;

                if (booking.Size == "6m" && booking.ConType == "Tank")
                {
                    tot = s + ta;
                }
                else if (booking.Size == "6m" && booking.ConType == "Dry Container")
                {
                    tot = s + p;
                }
                else if (booking.Size == "6m" && booking.ConType == "Refrigderated ISO")
                {
                    tot = s + re;
                }
                else if (booking.Size == "12m" && booking.ConType == "Tank")
                {
                    tot = t + ta;
                }
                else if (booking.Size == "12m" && booking.ConType == "Dry Container")
                {
                    tot = t + p;
                }
                else if (booking.Size == "12m" && booking.ConType == "Refrigderated ISO")
                {
                    tot = t + re;
                }


                
        
            if (booking.two > 550 && booking.two < 1500)
            {
                booking.priorty = "Medium";
            }
            else if (booking.two > 1500)
            {
                    booking.priorty = "High";
            }
            else { booking.priorty = "Low"; }

           
        


                booking.final = booking.two * r + (tot);
                booking.Collection = booking.Collection;
                booking.Dropoff = booking.Dropoff;
                booking.priorty = booking.priorty;


                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingIds,pickupdate,dropofdate,dropCity,clientname,cellnum,email,ConNum,ConType,Size,specInstruct,testtext,two,Distance,final,Collection,Dropoff,priorty")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
