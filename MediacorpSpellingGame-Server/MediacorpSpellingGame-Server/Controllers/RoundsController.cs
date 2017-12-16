using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MediacorpSpellingGame_Server.Models;

namespace MediacorpSpellingGame_Server.Controllers
{
    public class RoundsController : ApiController
    {
        private GameContext db = new GameContext();

        // GET: api/Rounds
        public IQueryable<Round> GetRounds()
        {
            return db.Rounds;
        }

        // GET: api/Rounds/5
        [ResponseType(typeof(Round))]
        public async Task<IHttpActionResult> GetRound(int id)
        {
            Round round = await db.Rounds.FindAsync(id);
            if (round == null)
            {
                return NotFound();
            }

            return Ok(round);
        }

        // PUT: api/Rounds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRound(int id, Round round)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != round.Id)
            {
                return BadRequest();
            }

            db.Entry(round).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundExists(id))
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

        // POST: api/Rounds
        [ResponseType(typeof(Round))]
        public async Task<IHttpActionResult> PostRound(Round round)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rounds.Add(round);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = round.Id }, round);
        }

        // DELETE: api/Rounds/5
        [ResponseType(typeof(Round))]
        public async Task<IHttpActionResult> DeleteRound(int id)
        {
            Round round = await db.Rounds.FindAsync(id);
            if (round == null)
            {
                return NotFound();
            }

            db.Rounds.Remove(round);
            await db.SaveChangesAsync();

            return Ok(round);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundExists(int id)
        {
            return db.Rounds.Count(e => e.Id == id) > 0;
        }
    }
}