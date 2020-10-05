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
    public class pilotosController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/pilotos
        public IQueryable<piloto> Getpiloto()
        {
            return db.piloto;
        }

        // GET: api/pilotos/5
        [ResponseType(typeof(piloto))]
        public IHttpActionResult Getpiloto(int id)
        {
            piloto piloto = db.piloto.Find(id);
            if (piloto == null)
            {
                return NotFound();
            }

            return Ok(piloto);
        }

        // PUT: api/pilotos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpiloto(int id, piloto piloto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != piloto.id_piloto)
            {
                return BadRequest();
            }

            db.Entry(piloto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pilotoExists(id))
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

        // POST: api/pilotos
        [ResponseType(typeof(piloto))]
        public IHttpActionResult Postpiloto(piloto piloto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.piloto.Add(piloto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = piloto.id_piloto }, piloto);
        }

        // DELETE: api/pilotos/5
        [ResponseType(typeof(piloto))]
        public IHttpActionResult Deletepiloto(int id)
        {
            piloto piloto = db.piloto.Find(id);
            if (piloto == null)
            {
                return NotFound();
            }

            db.piloto.Remove(piloto);
            db.SaveChanges();

            return Ok(piloto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pilotoExists(int id)
        {
            return db.piloto.Count(e => e.id_piloto == id) > 0;
        }
    }
}