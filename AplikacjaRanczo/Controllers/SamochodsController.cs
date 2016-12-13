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
    public class SamochodsController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: Samochods
        public ActionResult Index()
        {
            var samochod = db.Samochod.Include(s => s.Kraj).Include(s => s.Marka);
            return View(samochod.ToList());
        }

        // GET: Samochods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod samochod = db.Samochod.Find(id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            return View(samochod);
        }

        // GET: Samochods/Create
        public ActionResult Create()
        {
            ViewBag.KrajID = new SelectList(db.Kraj, "KrajID", "nazwa");
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "nazwa");
            return View();
        }

        // POST: Samochods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SamochodID,nr_rejestracyjny,MarkaID,model,rocznik,KrajID")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                db.Samochod.Add(samochod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KrajID = new SelectList(db.Kraj, "KrajID", "nazwa", samochod.KrajID);
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "nazwa", samochod.MarkaID);
            return View(samochod);
        }

        // GET: Samochods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod samochod = db.Samochod.Find(id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            ViewBag.KrajID = new SelectList(db.Kraj, "KrajID", "nazwa", samochod.KrajID);
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "nazwa", samochod.MarkaID);
            return View(samochod);
        }

        // POST: Samochods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SamochodID,nr_rejestracyjny,MarkaID,model,rocznik,KrajID")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(samochod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KrajID = new SelectList(db.Kraj, "KrajID", "nazwa", samochod.KrajID);
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "nazwa", samochod.MarkaID);
            return View(samochod);
        }

        // GET: Samochods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samochod samochod = db.Samochod.Find(id);
            if (samochod == null)
            {
                return HttpNotFound();
            }
            return View(samochod);
        }

        // POST: Samochods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samochod samochod = db.Samochod.Find(id);
            db.Samochod.Remove(samochod);
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
