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
    public class NewsItemsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public NewsItemsController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/NewsItems
        public IQueryable<NewsItem> GetNewsItems()
        {
            return db.NewsItems.Include(n => n.Campuses).Include(n => n.Degrees);
        }

        // GET: api/NewsItems/5
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult GetNewsItem(int id)
        {
            NewsItem newsItem = db.NewsItems.Include(n => n.Campuses).Include(n => n.Degrees).First(n => n.NewsItemId == id);
            if (newsItem == null)
            {
                return NotFound();
            }

            return Ok(newsItem);
        }

        // PUT: api/NewsItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewsItem(int id, NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsItem.NewsItemId)
            {
                return BadRequest();
            }

            db.Entry(newsItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsItemExists(id))
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

        // POST: api/NewsItems
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult PostNewsItem(NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Has campuses
            if (newsItem.Campuses.Count != 0)
            {
                // For some reason Where clause can't use the Campuses property of student
                var campusIds = newsItem.Campuses.Select(a => a.CampusId).ToList();

                var campuses = db.Campus.Where(a => campusIds.Any(b => b == a.CampusId));
                newsItem.Campuses = campuses.ToList();
            }

            // Has degrees
            if (newsItem.Degrees.Count != 0)
            {
                // For some reason Where clause can't use the Degrees property of student
                var degreeIds = newsItem.Degrees.Select(a => a.DegreeId).ToList();

                var degrees = db.Degrees.Where(a => degreeIds.Any(b => b == a.DegreeId));
                newsItem.Degrees = degrees.ToList();
            }

            db.NewsItems.Add(newsItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newsItem.NewsItemId }, newsItem);
        }

        // DELETE: api/NewsItems/5
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult DeleteNewsItem(int id)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            db.NewsItems.Remove(newsItem);
            db.SaveChanges();

            return Ok(newsItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsItemExists(int id)
        {
            return db.NewsItems.Count(e => e.NewsItemId == id) > 0;
        }
    }
}