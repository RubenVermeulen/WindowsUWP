﻿using System;
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
    public class DegreesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public DegreesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Degrees
        public IQueryable<Degree> GetDegrees()
        {
            return db.Degrees.Include(d => d.Students)
                .Include(d => d.NewsItems)
                .Include(d => d.Campuses)
                .OrderBy(d => d.Name);
        }

        // GET: api/Degrees/5
        [ResponseType(typeof(Degree))]
        public IHttpActionResult GetDegree(int id)
        {
            Degree degree = db.Degrees.Include(d => d.Students)
                .Include(d => d.NewsItems)
                .Include(d => d.Campuses)
                .First(d => d.DegreeId.Equals(id));
            if (degree == null)
            {
                return NotFound();
            }

            return Ok(degree);
        }

        // PUT: api/Degrees/5
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult PutDegree(int id, Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != degree.DegreeId)
            {
                return BadRequest();
            }

            db.Entry(degree).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(id))
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

        // POST: api/Degrees
        [ResponseType(typeof(Degree))]
        [Authorize]
        public IHttpActionResult PostDegree(Degree degree)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Has campuses
            if (degree.Campuses.Count != 0)
            {
                // For some reason Where clause can't use the Campuses property of student
                var campusIds = degree.Campuses.Select(a => a.CampusId).ToList();

                var campuses = db.Campus.Where(a => campusIds.Any(b => b == a.CampusId));
                degree.Campuses = campuses.ToList();
            }

            db.Degrees.Add(degree);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = degree.DegreeId }, degree);
        }

        // DELETE: api/Degrees/5
        [ResponseType(typeof(Degree))]
        [Authorize]
        public IHttpActionResult DeleteDegree(int id)
        {
            Degree degree = db.Degrees.Find(id);
            if (degree == null)
            {
                return NotFound();
            }

            db.Degrees.Remove(degree);
            db.SaveChanges();

            return Ok(degree);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DegreeExists(int id)
        {
            return db.Degrees.Count(e => e.DegreeId == id) > 0;
        }
    }
}