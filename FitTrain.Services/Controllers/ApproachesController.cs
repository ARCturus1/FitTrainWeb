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
using FitTrain.DataLayer;
using FitTrain.Domain.Entities.Training;

namespace FitTrain.Services.Controllers
{
    [Authorize]
    public class ApproachesController : ApiController
    {
        private FitTrainDbContext db = new FitTrainDbContext();

        // GET: api/Approaches
        public IQueryable<Approach> GetApproaches(int? exeId)
        {
            return exeId.HasValue ? db.Approaches.Where(x => x.ExcesiceId == exeId) : db.Approaches;
        }

        // GET: api/Approaches/5
        [ResponseType(typeof(Approach))]
        public async Task<IHttpActionResult> GetApproach(int id)
        {
            Approach approach = await db.Approaches.FindAsync(id);
            if (approach == null)
            {
                return NotFound();
            }

            return Ok(approach);
        }

        // PUT: api/Approaches/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApproach(int id, Approach approach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != approach.Id)
            {
                return BadRequest();
            }

            db.Entry(approach).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApproachExists(id))
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

        // POST: api/Approaches
        [ResponseType(typeof(Approach))]
        public async Task<IHttpActionResult> PostApproach(Approach approach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Approaches.Add(approach);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = approach.Id }, approach);
        }

        // DELETE: api/Approaches/5
        [ResponseType(typeof(Approach))]
        public async Task<IHttpActionResult> DeleteApproach(int id)
        {
            Approach approach = await db.Approaches.FindAsync(id);
            if (approach == null)
            {
                return NotFound();
            }

            db.Approaches.Remove(approach);
            await db.SaveChangesAsync();

            return Ok(approach);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApproachExists(int id)
        {
            return db.Approaches.Count(e => e.Id == id) > 0;
        }
    }
}