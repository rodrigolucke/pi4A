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
    builder.EntitySet<usuario>("usuarios");
    builder.EntitySet<usuario_token>("usuario_token"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class usuariosController : ODataController
    {
        private Database1Entities db = new Database1Entities();

        // GET: odata/usuarios
        [EnableQuery]
        public IQueryable<usuario> Getusuarios()
        {
            return db.usuario;
        }

        // GET: odata/usuarios(5)
        [EnableQuery]
        public SingleResult<usuario> Getusuario([FromODataUri] int key)
        {
            return SingleResult.Create(db.usuario.Where(usuario => usuario.id_usuario == key));
        }

        // PUT: odata/usuarios(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<usuario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuario usuario = db.usuario.Find(key);
            if (usuario == null)
            {
                return NotFound();
            }

            patch.Put(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuarioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(usuario);
        }

        // POST: odata/usuarios
        public IHttpActionResult Post(usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuario.Add(usuario);
            db.SaveChanges();

            return Created(usuario);
        }

        // PATCH: odata/usuarios(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<usuario> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            usuario usuario = db.usuario.Find(key);
            if (usuario == null)
            {
                return NotFound();
            }

            patch.Patch(usuario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuarioExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(usuario);
        }

        // DELETE: odata/usuarios(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            usuario usuario = db.usuario.Find(key);
            if (usuario == null)
            {
                return NotFound();
            }

            db.usuario.Remove(usuario);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/usuarios(5)/usuario_token
        [EnableQuery]
        public IQueryable<usuario_token> Getusuario_token([FromODataUri] int key)
        {
            return db.usuario.Where(m => m.id_usuario == key).SelectMany(m => m.usuario_token);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuarioExists(int key)
        {
            return db.usuario.Count(e => e.id_usuario == key) > 0;
        }
    }
}
