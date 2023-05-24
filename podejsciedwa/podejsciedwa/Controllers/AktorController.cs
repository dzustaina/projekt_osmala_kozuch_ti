using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using podejsciedwa.Models;
using podejsciedwa.Models.DbModels;

namespace podejsciedwa.Controllers
{
    public class AktorController : Controller
    {
        public DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public ActionResult Create()
        {
            
            return View(new Aktor());
        }
       
        [HttpPost]
        public ActionResult Create(Aktor aktor)
        {
            if (ModelState.IsValid)
            {
                using(DatabaseContext db = new DatabaseContext())
                {
                    db.Aktorzy.Add(aktor);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new Aktor());
        }

        [HttpGet]
        public ActionResult ViewAll()
        {
            List<Aktor> aktorzy;
            using (DatabaseContext db = new DatabaseContext())
                aktorzy = db.Aktorzy.ToList();
            return View(aktorzy);
        }

        public ActionResult View(int id)
        {
            Aktor aktor;
            using (DatabaseContext db = new DatabaseContext())
                aktor = db.Aktorzy.FirstOrDefault(x => x.AktorId == id);

            return View(aktor);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            Aktor aktor;
            using (DatabaseContext db = new DatabaseContext())
                aktor = db.Aktorzy.FirstOrDefault(x => x.AktorId == id);

            return View(aktor);
        }

        [HttpPost]
        public ActionResult Edit(Aktor aktor)
        {
            if (!ModelState.IsValid)
                return View(aktor);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(aktor).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Aktor aktor;
            using (DatabaseContext db = new DatabaseContext())
            {
                aktor = db.Aktorzy.FirstOrDefault(x => x.AktorId == id);
            }
                

            return View(aktor);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Aktor aktor;
            using (DatabaseContext db = new DatabaseContext())
            {
                aktor = db.Aktorzy.FirstOrDefault(x => x.AktorId == id);
                db.Aktorzy.Remove(aktor);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }





    }
}
