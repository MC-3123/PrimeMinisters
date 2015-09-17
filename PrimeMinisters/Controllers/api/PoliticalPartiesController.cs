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
using PrimeMinisters.Models;

namespace PrimeMinisters.Controllers.api
{
    public class PoliticalPartiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PoliticalParties
        public IQueryable<PoliticalParty> GetPoliticalParties()
        {
            return db.PoliticalParties;
        }

        // GET: api/PoliticalParties/5
        [ResponseType(typeof(PoliticalParty))]
        public async Task<IHttpActionResult> GetPoliticalParty(int id)
        {
            PoliticalParty politicalParty = await db.PoliticalParties.FindAsync(id);
            if (politicalParty == null)
            {
                return NotFound();
            }

            return Ok(politicalParty);
        }

        // PUT: api/PoliticalParties/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPoliticalParty(int id, PoliticalParty politicalParty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != politicalParty.id)
            {
                return BadRequest();
            }

            db.Entry(politicalParty).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliticalPartyExists(id))
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

        // POST: api/PoliticalParties
        [ResponseType(typeof(PoliticalParty))]
        public async Task<IHttpActionResult> PostPoliticalParty(PoliticalParty politicalParty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PoliticalParties.Add(politicalParty);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = politicalParty.id }, politicalParty);
        }

        // DELETE: api/PoliticalParties/5
        [ResponseType(typeof(PoliticalParty))]
        public async Task<IHttpActionResult> DeletePoliticalParty(int id)
        {
            PoliticalParty politicalParty = await db.PoliticalParties.FindAsync(id);
            if (politicalParty == null)
            {
                return NotFound();
            }

            db.PoliticalParties.Remove(politicalParty);
            await db.SaveChangesAsync();

            return Ok(politicalParty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PoliticalPartyExists(int id)
        {
            return db.PoliticalParties.Count(e => e.id == id) > 0;
        }
    }
}