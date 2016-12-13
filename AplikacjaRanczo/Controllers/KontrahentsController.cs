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
    public class KontrahentsController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: Kontrahents
        public ActionResult Index()
        {
            var kontrahent = db.Kontrahent.Include(k => k.KodPocztowy);
            return View(kontrahent.ToList());
        }

        // GET: Kontrahents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrahent kontrahent = db.Kontrahent.Find(id);
            if (kontrahent == null)
            {
                return HttpNotFound();
            }
            return View(kontrahent);
        }

        // GET: Kontrahents/Create
        public ActionResult Create()
        {
            ViewBag.KodPocztowyID = new SelectList(db.KodPocztowy, "KodPocztowyID", "kod");
            return View();
        }

        // POST: Kontrahents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KontrahentID,nazwa,nip,KodPocztowyID,ulica,nr_domu")] Kontrahent kontrahent)
        {
            if (ModelState.IsValid)
            {
                db.Kontrahent.Add(kontrahent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KodPocztowyID = new SelectList(db.KodPocztowy, "KodPocztowyID", "kod", kontrahent.KodPocztowyID);
            return View(kontrahent);
        }

        // GET: Kontrahents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrahent kontrahent = db.Kontrahent.Find(id);
            if (kontrahent == null)
            {
                return HttpNotFound();
            }
            ViewBag.KodPocztowyID = new SelectList(db.KodPocztowy, "KodPocztowyID", "kod", kontrahent.KodPocztowyID);
            return View(kontrahent);
        }

        // POST: Kontrahents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KontrahentID,nazwa,nip,KodPocztowyID,ulica,nr_domu")] Kontrahent kontrahent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontrahent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KodPocztowyID = new SelectList(db.KodPocztowy, "KodPocztowyID", "kod", kontrahent.KodPocztowyID);
            return View(kontrahent);
        }

        // GET: Kontrahents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontrahent kontrahent = db.Kontrahent.Find(id);
            if (kontrahent == null)
            {
                return HttpNotFound();
            }
            return View(kontrahent);
        }

        // POST: Kontrahents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kontrahent kontrahent = db.Kontrahent.Find(id);
            db.Kontrahent.Remove(kontrahent);
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
