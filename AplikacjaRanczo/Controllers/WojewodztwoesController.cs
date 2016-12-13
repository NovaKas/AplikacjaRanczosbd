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
    public class WojewodztwoesController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: Wojewodztwoes
        public ActionResult Index()
        {
            return View(db.Wojewodztwo.ToList());
        }

        // GET: Wojewodztwoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwo.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // GET: Wojewodztwoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wojewodztwoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WojewodztwoID,nazwa")] Wojewodztwo wojewodztwo)
        {
            if (ModelState.IsValid)
            {
                db.Wojewodztwo.Add(wojewodztwo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wojewodztwo);
        }

        // GET: Wojewodztwoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwo.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // POST: Wojewodztwoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WojewodztwoID,nazwa")] Wojewodztwo wojewodztwo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wojewodztwo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wojewodztwo);
        }

        // GET: Wojewodztwoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wojewodztwo wojewodztwo = db.Wojewodztwo.Find(id);
            if (wojewodztwo == null)
            {
                return HttpNotFound();
            }
            return View(wojewodztwo);
        }

        // POST: Wojewodztwoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wojewodztwo wojewodztwo = db.Wojewodztwo.Find(id);
            db.Wojewodztwo.Remove(wojewodztwo);
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
