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
using API.Models;

namespace API.Controllers
{
    public class CricketersController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Cricketers
        public IQueryable<cricketer> Getcricketers()
        {
            return db.cricketers;
        }

        // GET: api/Cricketers/5
        [ResponseType(typeof(cricketer))]
        public IHttpActionResult Getcricketer(int id)
        {
            cricketer cricketer = db.cricketers.Find(id);
            if (cricketer == null)
            {
                return NotFound();
            }

            return Ok(cricketer);
        }

        // PUT: api/Cricketers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcricketer(int id, cricketer cricketer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != cricketer.Jersey_Number)
            {
                return BadRequest();
            }

            db.Entry(cricketer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cricketerExists(id))
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

        // POST: api/Cricketers
        [ResponseType(typeof(cricketer))]
        public IHttpActionResult Postcricketer(cricketer cricketer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.cricketers.Add(cricketer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cricketer.Jersey_Number }, cricketer);
        }

        // DELETE: api/Cricketers/5
        [ResponseType(typeof(cricketer))]
        public IHttpActionResult Deletecricketer(int id)
        {
            cricketer cricketer = db.cricketers.Find(id);
            if (cricketer == null)
            {
                return NotFound();
            }

            db.cricketers.Remove(cricketer);
            db.SaveChanges();

            return Ok(cricketer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cricketerExists(int id)
        {
            return db.cricketers.Count(e => e.Jersey_Number == id) > 0;
        }
    }
}