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
    public class VelilersController : ApiController
    {
        private OkulBilgiSistemiEntities db = new OkulBilgiSistemiEntities();

        // GET: api/Velilers
        public IQueryable<Veliler> GetVelilers()
        {
            return db.Velilers;
        }

        // GET: api/Velilers/5
        [ResponseType(typeof(Veliler))]
        public IHttpActionResult GetVeliler(int id)
        {
            Veliler veliler = db.Velilers.Find(id);
            if (veliler == null)
            {
                return NotFound();
            }

            return Ok(veliler);
        }

        // PUT: api/Velilers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVeliler(int id, Veliler veliler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veliler.VeliNo)
            {
                return BadRequest();
            }

            db.Entry(veliler).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VelilerExists(id))
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

        // POST: api/Velilers
        [ResponseType(typeof(Veliler))]
        public IHttpActionResult PostVeliler(Veliler veliler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Velilers.Add(veliler);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = veliler.VeliNo }, veliler);
        }

        // DELETE: api/Velilers/5
        [ResponseType(typeof(Veliler))]
        public IHttpActionResult DeleteVeliler(int id)
        {
            Veliler veliler = db.Velilers.Find(id);
            if (veliler == null)
            {
                return NotFound();
            }

            db.Velilers.Remove(veliler);
            db.SaveChanges();

            return Ok(veliler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VelilerExists(int id)
        {
            return db.Velilers.Count(e => e.VeliNo == id) > 0;
        }
    }
}