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
    public class GameDetailsController : ApiController
    {
        private GameContext db = new GameContext();

        // GET: api/GameDetails
        public IQueryable<GameDetail> GetGameDetails()
        {
            return db.GameDetails;
        }

        // GET: api/GameDetails/5
        [ResponseType(typeof(GameDetail))]
        public async Task<IHttpActionResult> GetGameDetail(int id)
        {
            GameDetail gameDetail = await db.GameDetails.FindAsync(id);
            if (gameDetail == null)
            {
                return NotFound();
            }

            return Ok(gameDetail);
        }

        // PUT: api/GameDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGameDetail(int id, GameDetail gameDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(gameDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameDetailExists(id))
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

        // POST: api/GameDetails
        [ResponseType(typeof(GameDetail))]
        public async Task<IHttpActionResult> PostGameDetail(GameDetail gameDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GameDetails.Add(gameDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gameDetail.Id }, gameDetail);
        }

        // DELETE: api/GameDetails/5
        [ResponseType(typeof(GameDetail))]
        public async Task<IHttpActionResult> DeleteGameDetail(int id)
        {
            GameDetail gameDetail = await db.GameDetails.FindAsync(id);
            if (gameDetail == null)
            {
                return NotFound();
            }

            db.GameDetails.Remove(gameDetail);
            await db.SaveChangesAsync();

            return Ok(gameDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameDetailExists(int id)
        {
            return db.GameDetails.Count(e => e.Id == id) > 0;
        }
    }
}