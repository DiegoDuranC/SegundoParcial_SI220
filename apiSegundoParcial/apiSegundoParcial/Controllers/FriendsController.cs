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
using apiSegundoParcial.Models;

namespace apiSegundoParcial.Controllers
{
    public class FriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Friends
        [Authorize]
        public IQueryable<Friends> GetFriends()
        {
            return db.Friends;
        }

        // GET: api/Friends/5
        [Authorize]
        [ResponseType(typeof(Friends))]
        public IHttpActionResult GetFriends(int id)
        {
            Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return NotFound();
            }

            return Ok(friends);
        }

        // PUT: api/Friends/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFriends(int id, Friends friends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friends.FriendID)
            {
                return BadRequest();
            }

            db.Entry(friends).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendsExists(id))
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

        // POST: api/Friends
        [Authorize]
        [ResponseType(typeof(Friends))]
        public IHttpActionResult PostFriends(Friends friends)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Friends.Add(friends);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = friends.FriendID }, friends);
        }

        // DELETE: api/Friends/5
        [Authorize]
        [ResponseType(typeof(Friends))]
        public IHttpActionResult DeleteFriends(int id)
        {
            Friends friends = db.Friends.Find(id);
            if (friends == null)
            {
                return NotFound();
            }

            db.Friends.Remove(friends);
            db.SaveChanges();

            return Ok(friends);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FriendsExists(int id)
        {
            return db.Friends.Count(e => e.FriendID == id) > 0;
        }
    }
}