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
    public class KrajsController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: Krajs
        public ActionResult Index()
        {
            return View(db.Kraj.ToList());
        }

        // GET: Krajs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kraj kraj = db.Kraj.Find(id);
            if (kraj == null)
            {
                return HttpNotFound();
            }
            return View(kraj);
        }

        // GET: Krajs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Krajs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KrajID,nazwa")] Kraj kraj)
        {
            if (ModelState.IsValid)
            {
                db.Kraj.Add(kraj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kraj);
        }

        // GET: Krajs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kraj kraj = db.Kraj.Find(id);
            if (kraj == null)
            {
                return HttpNotFound();
            }
            return View(kraj);
        }

        // POST: Krajs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KrajID,nazwa")] Kraj kraj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kraj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kraj);
        }

        // GET: Krajs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kraj kraj = db.Kraj.Find(id);
            if (kraj == null)
            {
                return HttpNotFound();
            }
            return View(kraj);
        }

        // POST: Krajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kraj kraj = db.Kraj.Find(id);
            db.Kraj.Remove(kraj);
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
