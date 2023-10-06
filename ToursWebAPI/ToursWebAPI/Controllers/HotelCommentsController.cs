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
using ToursWebAPI.Entities;
using ToursWebAPI.Models;

namespace ToursWebAPI.Controllers
{
    public class HotelCommentsController : ApiController
    {
        private ToursEntities db = new ToursEntities();

        // GET: api/HotelComments
        [ResponseType(typeof(List<ResponseHotelComments>))]
        public IHttpActionResult GetHotelComments()
        {
            return Ok(db.HotelComments.ToList().ConvertAll(p => new ResponseHotelComments(p)));
        }

        [Route("api/getHotelComments")]
        public IHttpActionResult GetHotelComments(int hotelId)
        {
            var hotelComments = db.HotelComments.ToList().ConvertAll(p => new ResponseHotelComments(p)).Where(p => p.HotelId == hotelId).ToList();
            return Ok(hotelComments);
        }

        // GET: api/HotelComments/5
        [ResponseType(typeof(HotelComment))]
        public IHttpActionResult GetHotelComment(int id)
        {
            HotelComment hotelComment = db.HotelComments.Find(id);
            if (hotelComment == null)
            {
                return NotFound();
            }

            return Ok(hotelComment);
        }

        // PUT: api/HotelComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotelComment(int id, HotelComment hotelComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelComment.Id)
            {
                return BadRequest();
            }

            db.Entry(hotelComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelCommentExists(id))
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

        // POST: api/HotelComments
        [ResponseType(typeof(HotelComment))]
        public IHttpActionResult PostHotelComment(HotelComment hotelComment)
        {
            hotelComment.CreationDate = DateTime.Now;

            if (string.IsNullOrWhiteSpace(hotelComment.Author) || hotelComment.Author.Length > 100)
                ModelState.AddModelError("Author", "Author is required string up to 100 symbols.");
            if (string.IsNullOrWhiteSpace(hotelComment.Text))
                ModelState.AddModelError("Text", "Text is required string.");
            if (!(db.Hotels.ToList().FirstOrDefault(p => p.Id == hotelComment.HotelId) is Hotel))
                ModelState.AddModelError("HotelId", "HotelId is hotel's id from database.");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HotelComments.Add(hotelComment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hotelComment.Id }, hotelComment);
        }

        // DELETE: api/HotelComments/5
        [ResponseType(typeof(HotelComment))]
        public IHttpActionResult DeleteHotelComment(int id)
        {
            HotelComment hotelComment = db.HotelComments.Find(id);
            if (hotelComment == null)
            {
                return NotFound();
            }

            db.HotelComments.Remove(hotelComment);
            db.SaveChanges();

            return Ok(hotelComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelCommentExists(int id)
        {
            return db.HotelComments.Count(e => e.Id == id) > 0;
        }
    }
}