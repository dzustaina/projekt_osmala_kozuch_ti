using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using podejsciedwa.Models;
using podejsciedwa.Models.DbModels;

namespace podejsciedwa.Controllers
{
    public class BibliotekaController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Biblioteka
        public ActionResult Index()
        {
            return View(db.Biblioteki.ToList());
        }

        // GET: Biblioteka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biblioteka biblioteka = db.Biblioteki.Find(id);
            if (biblioteka == null)
            {
                return HttpNotFound();
            }
            return View(biblioteka);
        }

        // GET: Biblioteka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Biblioteka/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BibliotekaId,Nazwa")] Biblioteka biblioteka)
        {
            if (ModelState.IsValid)
            {
                db.Biblioteki.Add(biblioteka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(biblioteka);
        }

        // GET: Biblioteka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biblioteka biblioteka = db.Biblioteki.Find(id);
            if (biblioteka == null)
            {
                return HttpNotFound();
            }
            return View(biblioteka);
        }

        // POST: Biblioteka/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BibliotekaId,Nazwa")] Biblioteka biblioteka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biblioteka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(biblioteka);
        }

        // GET: Biblioteka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biblioteka biblioteka = db.Biblioteki.Find(id);
            if (biblioteka == null)
            {
                return HttpNotFound();
            }
            return View(biblioteka);
        }

        // POST: Biblioteka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Biblioteka biblioteka = db.Biblioteki.Find(id);
            db.Biblioteki.Remove(biblioteka);
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
