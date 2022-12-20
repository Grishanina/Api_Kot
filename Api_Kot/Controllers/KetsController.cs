using Api_Kot.Models;
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


namespace Api_Kot.Controllers
{
    public class KetsController : ApiController
    {
        private KotEntities db = new KotEntities();

		// GET: api/Kets
		[ResponseType(typeof(List<KetModel>))]
		public IHttpActionResult GetKet_1()
        {
			//return db.Ket;
			return Ok(db.Ket.ToList().ConvertAll(x => new KetModel(x)));
		}

        // GET: api/Kets/5
        [ResponseType(typeof(Ket))]
        public IHttpActionResult GetKet(int id)
        {
            Ket ket = db.Ket.Find(id);
            if (ket == null)
            {
                return NotFound();
            }

            return Ok(ket);
        }

        // PUT: api/Kets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKet(int id, Ket ket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ket.ID)
            {
                return BadRequest();
            }

            db.Entry(ket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KetExists(id))
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

        // POST: api/Kets
        [ResponseType(typeof(Ket))]
        public IHttpActionResult PostKet(Ket ket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ket.Add(ket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ket.ID }, ket);
        }

        // DELETE: api/Kets/5
        [ResponseType(typeof(Ket))]
        public IHttpActionResult DeleteKet(int id)
        {
            Ket ket = db.Ket.Find(id);
            if (ket == null)
            {
                return NotFound();
            }

            db.Ket.Remove(ket);
            db.SaveChanges();

            return Ok(ket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KetExists(int id)
        {
            return db.Ket.Count(e => e.ID == id) > 0;
        }
    }
}