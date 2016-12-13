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
    public class KodPocztowiesController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: KodPocztowies
        public ActionResult Index()
        {
            var kodPocztowy = db.KodPocztowy.Include(k => k.Miejscowosc);
            return View(kodPocztowy.ToList());
        }

        // GET: KodPocztowies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KodPocztowy kodPocztowy = db.KodPocztowy.Find(id);
            if (kodPocztowy == null)
            {
                return HttpNotFound();
            }
            return View(kodPocztowy);
        }

        // GET: KodPocztowies/Create
        public ActionResult Create()
        {
            ViewBag.MiejscowoscID = new SelectList(db.Miejscowosc, "MiejscowoscID", "nazwa");
            return View();
        }

        // POST: KodPocztowies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KodPocztowyID,kod,MiejscowoscID")] KodPocztowy kodPocztowy)
        {
            if (ModelState.IsValid)
            {
                db.KodPocztowy.Add(kodPocztowy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MiejscowoscID = new SelectList(db.Miejscowosc, "MiejscowoscID", "nazwa", kodPocztowy.MiejscowoscID);
            return View(kodPocztowy);
        }

        // GET: KodPocztowies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KodPocztowy kodPocztowy = db.KodPocztowy.Find(id);
            if (kodPocztowy == null)
            {
                return HttpNotFound();
            }
            ViewBag.MiejscowoscID = new SelectList(db.Miejscowosc, "MiejscowoscID", "nazwa", kodPocztowy.MiejscowoscID);
            return View(kodPocztowy);
        }

        // POST: KodPocztowies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KodPocztowyID,kod,MiejscowoscID")] KodPocztowy kodPocztowy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kodPocztowy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MiejscowoscID = new SelectList(db.Miejscowosc, "MiejscowoscID", "nazwa", kodPocztowy.MiejscowoscID);
            return View(kodPocztowy);
        }

        // GET: KodPocztowies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KodPocztowy kodPocztowy = db.KodPocztowy.Find(id);
            if (kodPocztowy == null)
            {
                return HttpNotFound();
            }
            return View(kodPocztowy);
        }

        // POST: KodPocztowies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KodPocztowy kodPocztowy = db.KodPocztowy.Find(id);
            db.KodPocztowy.Remove(kodPocztowy);
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
