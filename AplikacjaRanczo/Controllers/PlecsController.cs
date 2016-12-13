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
    public class PlecsController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: Plecs
        public ActionResult Index()
        {
            return View(db.Plec.ToList());
        }

        // GET: Plecs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plec plec = db.Plec.Find(id);
            if (plec == null)
            {
                return HttpNotFound();
            }
            return View(plec);
        }

        // GET: Plecs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plecs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlecID,nazwa,skrot")] Plec plec)
        {
            if (ModelState.IsValid)
            {
                db.Plec.Add(plec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plec);
        }

        // GET: Plecs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plec plec = db.Plec.Find(id);
            if (plec == null)
            {
                return HttpNotFound();
            }
            return View(plec);
        }

        // POST: Plecs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlecID,nazwa,skrot")] Plec plec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plec);
        }

        // GET: Plecs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plec plec = db.Plec.Find(id);
            if (plec == null)
            {
                return HttpNotFound();
            }
            return View(plec);
        }

        // POST: Plecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plec plec = db.Plec.Find(id);
            db.Plec.Remove(plec);
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
