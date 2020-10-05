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
    public class grids1Controller : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: grids1
        public ActionResult Index()
        {
            var grid = db.grid.Include(g => g.gp).Include(g => g.piloto);
            return View(grid.ToList());
        }

        // GET: grids1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grid grid = db.grid.Find(id);
            if (grid == null)
            {
                return HttpNotFound();
            }
            return View(grid);
        }

        // GET: grids1/Create
        public ActionResult Create()
        {
            ViewBag.gp_id_gp = new SelectList(db.gp, "id_gp", "nome");
            ViewBag.piloto_id_piloto = new SelectList(db.piloto, "id_piloto", "nome");
            return View();
        }

        // POST: grids1/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sequencial,piloto_id_piloto,gp_id_gp,posicao")] grid grid)
        {
            if (ModelState.IsValid)
            {
                db.grid.Add(grid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gp_id_gp = new SelectList(db.gp, "id_gp", "nome", grid.gp_id_gp);
            ViewBag.piloto_id_piloto = new SelectList(db.piloto, "id_piloto", "nome", grid.piloto_id_piloto);
            return View(grid);
        }

        // GET: grids1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grid grid = db.grid.Find(id);
            if (grid == null)
            {
                return HttpNotFound();
            }
            ViewBag.gp_id_gp = new SelectList(db.gp, "id_gp", "nome", grid.gp_id_gp);
            ViewBag.piloto_id_piloto = new SelectList(db.piloto, "id_piloto", "nome", grid.piloto_id_piloto);
            return View(grid);
        }

        // POST: grids1/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sequencial,piloto_id_piloto,gp_id_gp,posicao")] grid grid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gp_id_gp = new SelectList(db.gp, "id_gp", "nome", grid.gp_id_gp);
            ViewBag.piloto_id_piloto = new SelectList(db.piloto, "id_piloto", "nome", grid.piloto_id_piloto);
            return View(grid);
        }

        // GET: grids1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            grid grid = db.grid.Find(id);
            if (grid == null)
            {
                return HttpNotFound();
            }
            return View(grid);
        }

        // POST: grids1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            grid grid = db.grid.Find(id);
            db.grid.Remove(grid);
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
