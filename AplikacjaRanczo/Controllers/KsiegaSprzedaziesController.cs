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
    public class KsiegaSprzedaziesController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: KsiegaSprzedazies
        public ActionResult Index()
        {
            var ksiegaSprzedazy = db.KsiegaSprzedazy.Include(k => k.Bydlo).Include(k => k.Kontrahent).Include(k => k.Samochod);
            return View(ksiegaSprzedazy.ToList());
        }

        // GET: KsiegaSprzedazies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiegaSprzedazy ksiegaSprzedazy = db.KsiegaSprzedazy.Find(id);
            if (ksiegaSprzedazy == null)
            {
                return HttpNotFound();
            }
            return View(ksiegaSprzedazy);
        }

        // GET: KsiegaSprzedazies/Create
        public ActionResult Create()
        {
            ViewBag.BydloID = new SelectList(db.Bydlo, "BydloID", "id_armir");
            ViewBag.KontrahentID = new SelectList(db.Kontrahent, "KontrahentID", "nazwa");
            ViewBag.SamochodID = new SelectList(db.Samochod, "SamochodID", "nr_rejestracyjny");
            return View();
        }

        // POST: KsiegaSprzedazies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KsiegaSprzedazyID,BydloID,KontrahentID,SamochodID,data,czyZakup")] KsiegaSprzedazy ksiegaSprzedazy)
        {
            if (ModelState.IsValid)
            {
                db.KsiegaSprzedazy.Add(ksiegaSprzedazy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BydloID = new SelectList(db.Bydlo, "BydloID", "id_armir", ksiegaSprzedazy.BydloID);
            ViewBag.KontrahentID = new SelectList(db.Kontrahent, "KontrahentID", "nazwa", ksiegaSprzedazy.KontrahentID);
            ViewBag.SamochodID = new SelectList(db.Samochod, "SamochodID", "nr_rejestracyjny", ksiegaSprzedazy.SamochodID);
            return View(ksiegaSprzedazy);
        }

        // GET: KsiegaSprzedazies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiegaSprzedazy ksiegaSprzedazy = db.KsiegaSprzedazy.Find(id);
            if (ksiegaSprzedazy == null)
            {
                return HttpNotFound();
            }
            ViewBag.BydloID = new SelectList(db.Bydlo, "BydloID", "id_armir", ksiegaSprzedazy.BydloID);
            ViewBag.KontrahentID = new SelectList(db.Kontrahent, "KontrahentID", "nazwa", ksiegaSprzedazy.KontrahentID);
            ViewBag.SamochodID = new SelectList(db.Samochod, "SamochodID", "nr_rejestracyjny", ksiegaSprzedazy.SamochodID);
            return View(ksiegaSprzedazy);
        }

        // POST: KsiegaSprzedazies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KsiegaSprzedazyID,BydloID,KontrahentID,SamochodID,data,czyZakup")] KsiegaSprzedazy ksiegaSprzedazy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ksiegaSprzedazy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BydloID = new SelectList(db.Bydlo, "BydloID", "id_armir", ksiegaSprzedazy.BydloID);
            ViewBag.KontrahentID = new SelectList(db.Kontrahent, "KontrahentID", "nazwa", ksiegaSprzedazy.KontrahentID);
            ViewBag.SamochodID = new SelectList(db.Samochod, "SamochodID", "nr_rejestracyjny", ksiegaSprzedazy.SamochodID);
            return View(ksiegaSprzedazy);
        }

        // GET: KsiegaSprzedazies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KsiegaSprzedazy ksiegaSprzedazy = db.KsiegaSprzedazy.Find(id);
            if (ksiegaSprzedazy == null)
            {
                return HttpNotFound();
            }
            return View(ksiegaSprzedazy);
        }

        // POST: KsiegaSprzedazies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KsiegaSprzedazy ksiegaSprzedazy = db.KsiegaSprzedazy.Find(id);
            db.KsiegaSprzedazy.Remove(ksiegaSprzedazy);
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
