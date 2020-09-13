using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using f12020.Models;

namespace f12020.Controllers
{
    public class temporadas1Controller : Controller
    {
        private f1apiEntities db = new f1apiEntities();

        // GET: temporadas1
        public ActionResult Index()
        {
            return View(db.temporada.ToList());
        }

        // GET: temporadas1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temporada temporada = db.temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // GET: temporadas1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: temporadas1/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_temporada,nome")] temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.temporada.Add(temporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temporada);
        }

        // GET: temporadas1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temporada temporada = db.temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // POST: temporadas1/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_temporada,nome")] temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(temporada);
        }

        // GET: temporadas1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temporada temporada = db.temporada.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // POST: temporadas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            temporada temporada = db.temporada.Find(id);
            db.temporada.Remove(temporada);
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
