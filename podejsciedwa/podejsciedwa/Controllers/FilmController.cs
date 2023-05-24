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
    public class FilmController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Film
        public ActionResult Index()
        {
            var filmy = db.Filmy.Include(f => f.Aktor).Include(f => f.Biblioteka);
            return View(filmy.ToList());
        }

        // GET: Film/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmy.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            var aktorzy = db.Aktorzy.OrderBy(a => a.Nazwisko).ToList();
            ViewBag.Aktorzy = aktorzy;
            ViewBag.AktorId = new SelectList(db.Aktorzy, "AktorId", "Imie");
            ViewBag.BibliotekaId = new SelectList(db.Biblioteki, "BibliotekaId", "Nazwa");
            return View();
        }

        // POST: Film/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmId,Tytul,Gatunek,AktorId,BibliotekaId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Filmy.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AktorId = new SelectList(db.Aktorzy, "AktorId", "Imie", film.AktorId);
            ViewBag.BibliotekaId = new SelectList(db.Biblioteki, "BibliotekaId", "Nazwa", film.BibliotekaId);
            return View(film);
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmy.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            var aktorzy = db.Aktorzy.OrderBy(a => a.Nazwisko).ToList();
            ViewBag.Aktorzy = aktorzy;
            ViewBag.AktorId = new SelectList(db.Aktorzy, "AktorId", "Imie", film.AktorId);
            ViewBag.BibliotekaId = new SelectList(db.Biblioteki, "BibliotekaId", "Nazwa", film.BibliotekaId);
            return View(film);
        }

        // POST: Film/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmId,Tytul,Gatunek,AktorId,BibliotekaId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AktorId = new SelectList(db.Aktorzy, "AktorId", "Imie", film.AktorId);
            ViewBag.BibliotekaId = new SelectList(db.Biblioteki, "BibliotekaId", "Nazwa", film.BibliotekaId);
            return View(film);
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmy.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Filmy.Find(id);
            db.Filmy.Remove(film);
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
