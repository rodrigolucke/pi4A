using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using f12020.Models;

namespace f12020.Controllers
{
    /*
    A classe WebApiConfig pode requerer alterações adicionais para adicionar uma rota para esse controlador. Misture essas declarações no método Register da classe WebApiConfig conforme aplicável. Note que URLs OData diferenciam maiúsculas e minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using f12020.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<temporada>("temporadas");
    builder.EntitySet<gp>("gp"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class temporadasController : ODataController
    {
        private f1apiEntities db = new f1apiEntities();

        // GET: odata/temporadas
        [EnableQuery]
        public IQueryable<temporada> Gettemporadas()
        {
            return db.temporada;
        }

        // GET: odata/temporadas(5)
        [EnableQuery]
        public SingleResult<temporada> Gettemporada([FromODataUri] int key)
        {
            return SingleResult.Create(db.temporada.Where(temporada => temporada.id_temporada == key));
        }

        // PUT: odata/temporadas(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<temporada> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            temporada temporada = db.temporada.Find(key);
            if (temporada == null)
            {
                return NotFound();
            }

            patch.Put(temporada);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!temporadaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(temporada);
        }

        // POST: odata/temporadas
        public IHttpActionResult Post(temporada temporada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.temporada.Add(temporada);
            db.SaveChanges();

            return Created(temporada);
        }

        // PATCH: odata/temporadas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<temporada> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            temporada temporada = db.temporada.Find(key);
            if (temporada == null)
            {
                return NotFound();
            }

            patch.Patch(temporada);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!temporadaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(temporada);
        }

        // DELETE: odata/temporadas(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            temporada temporada = db.temporada.Find(key);
            if (temporada == null)
            {
                return NotFound();
            }

            db.temporada.Remove(temporada);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/temporadas(5)/gp
        [EnableQuery]
        public IQueryable<gp> Getgp([FromODataUri] int key)
        {
            return db.temporada.Where(m => m.id_temporada == key).SelectMany(m => m.gp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool temporadaExists(int key)
        {
            return db.temporada.Count(e => e.id_temporada == key) > 0;
        }
    }
}
