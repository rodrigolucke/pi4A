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
    public class pilotos1Controller : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: pilotos1
        public ActionResult Index()
        {
            var piloto = db.piloto.Include(p => p.equipe);
            return View(piloto.ToList());
        }

        // GET: pilotos1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            piloto piloto = db.piloto.Find(id);
            if (piloto == null)
            {
                return HttpNotFound();
            }
            return View(piloto);
        }

        // GET: pilotos1/Create
        public ActionResult Create()
        {
            ViewBag.equipe_id_equipe = new SelectList(db.equipe, "id_equipe", "nome");
            return View();
        }

        // POST: pilotos1/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_piloto,nome,sobrenome,equipe_id_equipe")] piloto piloto)
        {
            if (ModelState.IsValid)
            {
                db.piloto.Add(piloto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.equipe_id_equipe = new SelectList(db.equipe, "id_equipe", "nome", piloto.equipe_id_equipe);
            return View(piloto);
        }

        // GET: pilotos1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            piloto piloto = db.piloto.Find(id);
            if (piloto == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipe_id_equipe = new SelectList(db.equipe, "id_equipe", "nome", piloto.equipe_id_equipe);
            return View(piloto);
        }

        // POST: pilotos1/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_piloto,nome,sobrenome,equipe_id_equipe")] piloto piloto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(piloto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipe_id_equipe = new SelectList(db.equipe, "id_equipe", "nome", piloto.equipe_id_equipe);
            return View(piloto);
        }

        // GET: pilotos1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            piloto piloto = db.piloto.Find(id);
            if (piloto == null)
            {
                return HttpNotFound();
            }
            return View(piloto);
        }

        // POST: pilotos1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            piloto piloto = db.piloto.Find(id);
            db.piloto.Remove(piloto);
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
