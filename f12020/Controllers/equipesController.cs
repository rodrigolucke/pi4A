using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using f12020.Models;

namespace f12020.Controllers
{
    [BasicAuthentication]
    public class equipesController : AuthenticatorController
    {
        string t = Thread.CurrentPrincipal.Identity.Name;
        private f1apiEntities db = new f1apiEntities();
        // GET: api/equipes/token
       
        public IQueryable<equipe> Getequipe(){

            return  db.equipe;
        }

        // GET: api/equipes/5
        [ResponseType(typeof(equipe))]
        public IHttpActionResult Getequipe(int id)
        {   
            equipe equipe = db.equipe.Find(id);
            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

        // PUT: api/equipes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putequipe(int id, equipe equipe)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipe.id_equipe)
            {
                return BadRequest();
            }

            db.Entry(equipe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!equipeExists(id))
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

        // POST: api/equipes
        [ResponseType(typeof(equipe))]
        public IHttpActionResult Postequipe(equipe equipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.equipe.Add(equipe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equipe.id_equipe }, equipe);
        }

        // DELETE: api/equipes/5
        [ResponseType(typeof(equipe))]
        public IHttpActionResult Deleteequipe(int id)
        {
            equipe equipe = db.equipe.Find(id);
            if (equipe == null)
            {
                return NotFound();
            }

            db.equipe.Remove(equipe);
            db.SaveChanges();

            return Ok(equipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool equipeExists(int id)
        {
            return db.equipe.Count(e => e.id_equipe == id) > 0;
        }
    }
}