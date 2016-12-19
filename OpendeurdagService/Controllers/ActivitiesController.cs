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
    public class ActivitiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActivitiesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Activities
        public IQueryable<Activity> GetActivities()
        {
            return db.Activities.Include(a => a.Campuses)
                .OrderBy(a => a.BeginDate);
        }

        // GET: api/NextActivities
        [Route("api/nextactivities")]
        public IQueryable<Activity> GetNextActivities()
        {
            return db.Activities.Include(a => a.Campuses)
                .OrderBy(a => a.BeginDate).Take(2);
        }

        // GET: api/Activities/5
        [ResponseType(typeof(Activity))]
        public IHttpActionResult GetActivity(int id)
        {
            Activity activity = db.Activities.Include(a => a.Campuses)
                .First(a => a.ActivityId.Equals(id));

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/Activities/5
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult PutActivity(int id, Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activity.ActivityId)
            {
                return BadRequest();
            }

            db.Entry(activity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        // POST: api/Activities
        [ResponseType(typeof(Activity))]
        [Authorize]
        public IHttpActionResult PostActivity(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Has campuses
            if (activity.Campuses.Count != 0)
            {
                // For some reason Where clause can't use the Campuses property of student
                var campusIds = activity.Campuses.Select(a => a.CampusId).ToList();

                var campuses = db.Campus.Where(a => campusIds.Any(b => b == a.CampusId));
                activity.Campuses = campuses.ToList();
            }

            db.Activities.Add(activity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = activity.ActivityId }, activity);
        }

        // DELETE: api/Activities/5
        [ResponseType(typeof(Activity))]
        [Authorize]
        public IHttpActionResult DeleteActivity(int id)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return Ok(activity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActivityExists(int id)
        {
            return db.Activities.Count(e => e.ActivityId == id) > 0;
        }
    }
}