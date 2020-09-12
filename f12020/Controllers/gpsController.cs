using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using f12020.Models;

namespace f12020.Controllers
{
    public class gpsController : ApiController
    {
        private f1apiEntities db = new f1apiEntities();

        // GET: api/gps
        public IQueryable<gp> Getgp()
        {
            return db.gp;
        }

        // GET: api/gps/5
        [ResponseType(typeof(gp))]
        public IHttpActionResult Getgp(int id)
        {
            gp gp = db.gp.Find(id);
            if (gp == null)
            {
                return NotFound();
            }

            return Ok(gp);
        }

        // PUT: api/gps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgp(int id, gp gp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gp.id_gp)
            {
                return BadRequest();
            }

            db.Entry(gp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gpExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/gps
        [ResponseType(typeof(gp))]
        public IHttpActionResult Postgp(gp gp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gp.Add(gp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gp.id_gp }, gp);
        }

        // DELETE: api/gps/5
        [ResponseType(typeof(gp))]
        public IHttpActionResult Deletegp(int id)
        {
            gp gp = db.gp.Find(id);
            if (gp == null)
            {
                return NotFound();
            }

            db.gp.Remove(gp);
            db.SaveChanges();

            return Ok(gp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gpExists(int id)
        {
            return db.gp.Count(e => e.id_gp == id) > 0;
        }
    }
}