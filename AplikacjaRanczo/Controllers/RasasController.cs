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
    public class RasasController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: Rasas
        public ActionResult Index()
        {
            return View(db.Rasa.ToList());
        }

        // GET: Rasas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rasa rasa = db.Rasa.Find(id);
            if (rasa == null)
            {
                return HttpNotFound();
            }
            return View(rasa);
        }

        // GET: Rasas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rasas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RasaID,nazwa,skrot")] Rasa rasa)
        {
            if (ModelState.IsValid)
            {
                db.Rasa.Add(rasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rasa);
        }

        // GET: Rasas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rasa rasa = db.Rasa.Find(id);
            if (rasa == null)
            {
                return HttpNotFound();
            }
            return View(rasa);
        }

        // POST: Rasas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RasaID,nazwa,skrot")] Rasa rasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rasa);
        }

        // GET: Rasas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rasa rasa = db.Rasa.Find(id);
            if (rasa == null)
            {
                return HttpNotFound();
            }
            return View(rasa);
        }

        // POST: Rasas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rasa rasa = db.Rasa.Find(id);
            db.Rasa.Remove(rasa);
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
