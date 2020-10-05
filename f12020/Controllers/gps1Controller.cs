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
    public class gps1Controller : Controller
    {
        private Database1Entities db = new Database1Entities();
        // GET: gps1
        public ActionResult Index()
        {
            var gp = db.gp.Include(g => g.temporada);
            return View(gp.ToList());
        }

        // GET: gps1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gp gp = db.gp.Find(id);
            if (gp == null)
            {
                return HttpNotFound();
            }
            return View(gp);
        }

        // GET: gps1/Create
        public ActionResult Create()
        {
            ViewBag.temporada_id_temporada = new SelectList(db.temporada, "id_temporada", "nome");
            return View();
        }

        // POST: gps1/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_gp,nome,local_gp,data_gp,temporada_id_temporada")] gp gp)
        {
            if (ModelState.IsValid)
            {
                db.gp.Add(gp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.temporada_id_temporada = new SelectList(db.temporada, "id_temporada", "nome", gp.temporada_id_temporada);
            return View(gp);
        }

        // GET: gps1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gp gp = db.gp.Find(id);
            if (gp == null)
            {
                return HttpNotFound();
            }
            ViewBag.temporada_id_temporada = new SelectList(db.temporada, "id_temporada", "nome", gp.temporada_id_temporada);
            return View(gp);
        }

        // POST: gps1/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_gp,nome,local_gp,data_gp,temporada_id_temporada")] gp gp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.temporada_id_temporada = new SelectList(db.temporada, "id_temporada", "nome", gp.temporada_id_temporada);
            return View(gp);
        }

        // GET: gps1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gp gp = db.gp.Find(id);
            if (gp == null)
            {
                return HttpNotFound();
            }
            return View(gp);
        }

        // POST: gps1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gp gp = db.gp.Find(id);
            db.gp.Remove(gp);
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
