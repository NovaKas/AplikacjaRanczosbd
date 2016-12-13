using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplikacjaRanczo.Models;

namespace AplikacjaRanczo.Controllers
{
    public class MiejscowoscsController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: Miejscowoscs
        public ActionResult Index()
        {
            var miejscowosc = db.Miejscowosc.Include(m => m.Wojewodztwo);
            return View(miejscowosc.ToList());
        }

        // GET: Miejscowoscs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejscowosc miejscowosc = db.Miejscowosc.Find(id);
            if (miejscowosc == null)
            {
                return HttpNotFound();
            }
            return View(miejscowosc);
        }

        // GET: Miejscowoscs/Create
        public ActionResult Create()
        {
            ViewBag.WojewodztwoID = new SelectList(db.Wojewodztwo, "WojewodztwoID", "nazwa");
            return View();
        }

        // POST: Miejscowoscs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MiejscowoscID,nazwa,WojewodztwoID")] Miejscowosc miejscowosc)
        {
            if (ModelState.IsValid)
            {
                db.Miejscowosc.Add(miejscowosc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WojewodztwoID = new SelectList(db.Wojewodztwo, "WojewodztwoID", "nazwa", miejscowosc.WojewodztwoID);
            return View(miejscowosc);
        }

        // GET: Miejscowoscs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejscowosc miejscowosc = db.Miejscowosc.Find(id);
            if (miejscowosc == null)
            {
                return HttpNotFound();
            }
            ViewBag.WojewodztwoID = new SelectList(db.Wojewodztwo, "WojewodztwoID", "nazwa", miejscowosc.WojewodztwoID);
            return View(miejscowosc);
        }

        // POST: Miejscowoscs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MiejscowoscID,nazwa,WojewodztwoID")] Miejscowosc miejscowosc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miejscowosc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WojewodztwoID = new SelectList(db.Wojewodztwo, "WojewodztwoID", "nazwa", miejscowosc.WojewodztwoID);
            return View(miejscowosc);
        }

        // GET: Miejscowoscs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miejscowosc miejscowosc = db.Miejscowosc.Find(id);
            if (miejscowosc == null)
            {
                return HttpNotFound();
            }
            return View(miejscowosc);
        }

        // POST: Miejscowoscs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miejscowosc miejscowosc = db.Miejscowosc.Find(id);
            db.Miejscowosc.Remove(miejscowosc);
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
