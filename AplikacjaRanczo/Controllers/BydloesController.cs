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
    public class BydloesController : Controller
    {
        private RanczoContext db = new RanczoContext();

        // GET: Bydloes
        public ActionResult Index(string option, string searchString)
        {
            var bydlo = db.Bydlo.Include(b => b.Matka).Include(b => b.Plec).Include(b => b.Rasa);
             bydlo = from m in db.Bydlo
                        select m;
            /*      if (option == "nrpaszportu")
                  {
                      if (!String.IsNullOrEmpty(searchString))
                      {
                          bydlo = bydlo.Where(s => s.nr_paszportu.Contains(searchString));
                      }
                  }
                  else if (option == "nrarimr")
                  {
                      if (!String.IsNullOrEmpty(searchString))
                      {
                          bydlo = bydlo.Where(s => s.id_armir.Contains(searchString));
                      }
                  }*/

            if (option == "nr_paszportu")
            {
                bydlo = bydlo.Where(s => s.nr_paszportu.Contains(searchString) || searchString == null);
            }
            else if (option == "id_arimr")
            {
                bydlo = bydlo.Where(s => s.id_armir.Contains(searchString) || searchString == null);
            }
            else
            {
                bydlo = bydlo.Where(s => s.nr_paszportu.StartsWith(searchString) || searchString == null);
            }

            return View(bydlo.ToList());
        }

        // GET: Bydloes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bydlo bydlo = db.Bydlo.Find(id);
            if (bydlo == null)
            {
                return HttpNotFound();
            }
            return View(bydlo);
        }

        // GET: Bydloes/Create
        public ActionResult Create()
        {
            ViewBag.MatkaID = new SelectList(db.Bydlo, "BydloID", "id_armir");
            ViewBag.PlecID = new SelectList(db.Plec, "PlecID", "nazwa");
            ViewBag.RasaID = new SelectList(db.Rasa, "RasaID", "nazwa");
            return View();
        }

        // POST: Bydloes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BydloID,id_armir,nr_paszportu,MatkaID,RasaID,PlecID")] Bydlo bydlo)
        {
            if (ModelState.IsValid)
            {
                db.Bydlo.Add(bydlo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatkaID = new SelectList(db.Bydlo, "BydloID", "id_armir", bydlo.MatkaID);
            ViewBag.PlecID = new SelectList(db.Plec, "PlecID", "nazwa", bydlo.PlecID);
            ViewBag.RasaID = new SelectList(db.Rasa, "RasaID", "nazwa", bydlo.RasaID);
            return View(bydlo);
        }

        // GET: Bydloes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bydlo bydlo = db.Bydlo.Find(id);
            if (bydlo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatkaID = new SelectList(db.Bydlo, "BydloID", "id_armir", bydlo.MatkaID);
            ViewBag.PlecID = new SelectList(db.Plec, "PlecID", "nazwa", bydlo.PlecID);
            ViewBag.RasaID = new SelectList(db.Rasa, "RasaID", "nazwa", bydlo.RasaID);
            return View(bydlo);
        }

        // POST: Bydloes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BydloID,id_armir,nr_paszportu,MatkaID,RasaID,PlecID")] Bydlo bydlo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bydlo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatkaID = new SelectList(db.Bydlo, "BydloID", "id_armir", bydlo.MatkaID);
            ViewBag.PlecID = new SelectList(db.Plec, "PlecID", "nazwa", bydlo.PlecID);
            ViewBag.RasaID = new SelectList(db.Rasa, "RasaID", "nazwa", bydlo.RasaID);
            return View(bydlo);
        }

        // GET: Bydloes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bydlo bydlo = db.Bydlo.Find(id);
            if (bydlo == null)
            {
                return HttpNotFound();
            }
            return View(bydlo);
        }

        // POST: Bydloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bydlo bydlo = db.Bydlo.Find(id);
            db.Bydlo.Remove(bydlo);
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

        public ActionResult Find(string nr_paszportu, string searchString)
        {

//var bydloo = db.Bydlo.Include(b => b.Matka).Include(b => b.Plec).Include(b => b.Rasa);
            var bydlo = from m in db.Bydlo
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                bydlo = bydlo.Where(s => s.nr_paszportu.Contains(searchString));
            }

           /* if (!string.IsNullOrEmpty(nr_paszportu))
            {
                bydlo = bydlo.Where(x => x.nr_paszportu == nr_paszportu);
            }
            */



            

            return View(bydlo.ToList());
        }
    }
}
