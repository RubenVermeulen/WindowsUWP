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
using OpendeurdagService.Models;

namespace OpendeurdagService.Controllers
{
    public class CampusesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public CampusesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Campuses
        public IQueryable<Campus> GetCampus()
        {
            return db.Campus.Include(c => c.Students);
        }

        // GET: api/Campuses/5
        [ResponseType(typeof(Campus))]
        public IHttpActionResult GetCampus(int id)
        {
            Campus campus = db.Campus.Include(c => c.Students).First(c => c.CampusId.Equals(id));
            if (campus == null)
            {
                return NotFound();
            }

            return Ok(campus);
        }

        // PUT: api/Campuses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampus(int id, Campus campus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campus.CampusId)
            {
                return BadRequest();
            }

            db.Entry(campus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampusExists(id))
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

        // POST: api/Campuses
        [ResponseType(typeof(Campus))]
        public IHttpActionResult PostCampus(Campus campus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Campus.Add(campus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campus.CampusId }, campus);
        }

        // DELETE: api/Campuses/5
        [ResponseType(typeof(Campus))]
        public IHttpActionResult DeleteCampus(int id)
        {
            Campus campus = db.Campus.Find(id);
            if (campus == null)
            {
                return NotFound();
            }

            db.Campus.Remove(campus);
            db.SaveChanges();

            return Ok(campus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampusExists(int id)
        {
            return db.Campus.Count(e => e.CampusId == id) > 0;
        }
    }
}