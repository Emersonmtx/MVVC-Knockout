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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class tblFilmesController : ApiController
    {
        private EmersonmtxEntities db = new EmersonmtxEntities();

        // GET: api/tblFilmes
        public IQueryable<tblFilmes> GettblFilmes()
        {
            return db.tblFilmes;
        }

        // GET: api/tblFilmes/5
        [ResponseType(typeof(tblFilmes))]
        public IHttpActionResult GettblFilmes(int id)
        {
            tblFilmes tblFilmes = db.tblFilmes.Find(id);
            if (tblFilmes == null)
            {
                return NotFound();
            }

            return Ok(tblFilmes);
        }

        // PUT: api/tblFilmes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFilmes(int id, tblFilmes tblFilmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblFilmes.cod_filme)
            {
                return BadRequest();
            }

            db.Entry(tblFilmes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFilmesExists(id))
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

        // POST: api/tblFilmes
        [ResponseType(typeof(tblFilmes))]
        public IHttpActionResult PosttblFilmes(tblFilmes tblFilmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblFilmes.Add(tblFilmes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFilmes.cod_filme }, tblFilmes);
        }

        // DELETE: api/tblFilmes/5
        [ResponseType(typeof(tblFilmes))]
        public IHttpActionResult DeletetblFilmes(int id)
        {
            tblFilmes tblFilmes = db.tblFilmes.Find(id);
            if (tblFilmes == null)
            {
                return NotFound();
            }

            db.tblFilmes.Remove(tblFilmes);
            db.SaveChanges();

            return Ok(tblFilmes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFilmesExists(int id)
        {
            return db.tblFilmes.Count(e => e.cod_filme == id) > 0;
        }
    }
}