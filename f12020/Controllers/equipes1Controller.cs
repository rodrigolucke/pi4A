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
    public class equipes1Controller : Controller
    {
        private f1apiEntities db = new f1apiEntities();

        // GET: equipes1
        [Authorize(Roles = "ok,usuarios")]
        public ActionResult Index() => View(db.equipe.ToList());

        // GET: equipes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipe equipe = db.equipe.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // GET: equipes1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: equipes1/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_equipe,nome")] equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.equipe.Add(equipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipe);
        }

        // GET: equipes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipe equipe = db.equipe.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // POST: equipes1/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_equipe,nome")] equipe equipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipe);
        }

        // GET: equipes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            equipe equipe = db.equipe.Find(id);
            if (equipe == null)
            {
                return HttpNotFound();
            }
            return View(equipe);
        }

        // POST: equipes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            equipe equipe = db.equipe.Find(id);
            db.equipe.Remove(equipe);
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
