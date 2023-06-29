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
    public class OgrencilersController : ApiController
    {
        private OkulBilgiSistemiEntities db = new OkulBilgiSistemiEntities();

        // GET: api/Ogrencilers
        public IQueryable<Ogrenciler> GetOgrencilers()
        {
            return db.Ogrencilers;
        }

        // GET: api/Ogrencilers/5
        [ResponseType(typeof(Ogrenciler))]
        public IHttpActionResult GetOgrenciler(int id)
        {
            Ogrenciler ogrenciler = db.Ogrencilers.Find(id);
            if (ogrenciler == null)
            {
                return NotFound();
            }

            return Ok(ogrenciler);
        }

        // PUT: api/Ogrencilers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOgrenciler(int id, Ogrenciler ogrenciler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ogrenciler.OgrenciNo)
            {
                return BadRequest();
            }

            db.Entry(ogrenciler).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OgrencilerExists(id))
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

        // POST: api/Ogrencilers
        [ResponseType(typeof(Ogrenciler))]
        public IHttpActionResult PostOgrenciler(Ogrenciler ogrenciler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ogrencilers.Add(ogrenciler);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ogrenciler.OgrenciNo }, ogrenciler);
        }

        // DELETE: api/Ogrencilers/5
        [ResponseType(typeof(Ogrenciler))]
        public IHttpActionResult DeleteOgrenciler(int id)
        {
            Ogrenciler ogrenciler = db.Ogrencilers.Find(id);
            if (ogrenciler == null)
            {
                return NotFound();
            }

            db.Ogrencilers.Remove(ogrenciler);
            db.SaveChanges();

            return Ok(ogrenciler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OgrencilerExists(int id)
        {
            return db.Ogrencilers.Count(e => e.OgrenciNo == id) > 0;
        }
    }
}