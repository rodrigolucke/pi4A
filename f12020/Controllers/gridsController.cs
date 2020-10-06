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
    public class gridsController : ApiController
    {
        private Database1Entities db = new Database1Entities();

        // GET: api/grids
        public Array Getgrid()
        {

           var grid = db.grid.
                Select(a => new
                {

                    nome = a.piloto.nome,
                    score = ( a.posicao == 1 ? 10 :

                    a.posicao == 2 ? 8 :
                    a.posicao == 3 ? 7 :
                    a.posicao == 3 ? 6 : 1),
                    gp = a.gp.nome


                })
             .ToArray();

         

            var score = grid
            .GroupBy(a => a.nome)
            .Select(a => new { Score = a.Sum(b => b.score), Piloto = a.Key })
            .OrderByDescending(a => a.Score)
            .ToList();
           


            System.Diagnostics.Debug.Write(grid);


            return score.ToArray();

        }

        // GET: api/grids/5
        [ResponseType(typeof(grid))]
        public IHttpActionResult Getgrid(int id)
        {
            grid grid = db.grid.Find(id);
            if (grid == null)
            {
                return NotFound();
            }

            return Ok(grid);
        }

        // PUT: api/grids/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgrid(int id, grid grid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grid.sequencial)
            {
                return BadRequest();
            }

            db.Entry(grid).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gridExists(id))
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

        // POST: api/grids
        [ResponseType(typeof(grid))]
        public IHttpActionResult Postgrid(grid grid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.grid.Add(grid);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grid.sequencial }, grid);
        }

        // DELETE: api/grids/5
        [ResponseType(typeof(grid))]
        public IHttpActionResult Deletegrid(int id)
        {
            grid grid = db.grid.Find(id);
            if (grid == null)
            {
                return NotFound();
            }

            db.grid.Remove(grid);
            db.SaveChanges();

            return Ok(grid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gridExists(int id)
        {
            return db.grid.Count(e => e.sequencial == id) > 0;
        }
    }
}
 