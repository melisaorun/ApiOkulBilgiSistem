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
using ApiOkulBilgiSistem.Models;

namespace ApiOkulBilgiSistem.Controllers
{
    public class OdevlersController : ApiController
    {
        private OkulBilgiSistemiEntities db = new OkulBilgiSistemiEntities();

        // GET: api/Odevlers
        public IQueryable<Odevler> GetOdevlers()
        {
            return db.Odevlers;
        }

        // GET: api/Odevlers/5
        [ResponseType(typeof(Odevler))]
        public IHttpActionResult GetOdevler(int id)
        {
            Odevler odevler = db.Odevlers.Find(id);
            if (odevler == null)
            {
                return NotFound();
            }

            return Ok(odevler);
        }

        // PUT: api/Odevlers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOdevler(int id, Odevler odevler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != odevler.OdevNo)
            {
                return BadRequest();
            }

            db.Entry(odevler).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdevlerExists(id))
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

        // POST: api/Odevlers
        [ResponseType(typeof(Odevler))]
        public IHttpActionResult PostOdevler(Odevler odevler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Odevlers.Add(odevler);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = odevler.OdevNo }, odevler);
        }

        // DELETE: api/Odevlers/5
        [ResponseType(typeof(Odevler))]
        public IHttpActionResult DeleteOdevler(int id)
        {
            Odevler odevler = db.Odevlers.Find(id);
            if (odevler == null)
            {
                return NotFound();
            }

            db.Odevlers.Remove(odevler);
            db.SaveChanges();

            return Ok(odevler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OdevlerExists(int id)
        {
            return db.Odevlers.Count(e => e.OdevNo == id) > 0;
        }
    }
}