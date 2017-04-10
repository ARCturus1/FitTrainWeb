using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using FitTrain.DataLayer;
using FitTrain.Domain.Entities;
using FitTrain.Domain.Entities.Training;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitTrain.Services.Controllers
{
    [Authorize]
    public class TrainingsController : ApiController
    {
        private FitTrainDbContext db = new FitTrainDbContext();
        UserManager<ApplicationUser> userManager = null;

        public TrainingsController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: api/Trainings
        public IQueryable<Training> GetTrainings()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return db.Trainings.Where(x => x.ApplicationUserId == userId).Include(x => x.Exercises);
        }

        // GET: api/Trainings/5
        [ResponseType(typeof(Training))]
        public async Task<IHttpActionResult> GetTraining(int id)
        {
            Training training = await db.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }

        // PUT: api/Trainings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTraining(int id, Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != training.Id)
            {
                return BadRequest();
            }

            db.Entry(training).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(id))
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

        // POST: api/Trainings
        [ResponseType(typeof(Training))]
        public async Task<IHttpActionResult> PostTraining(Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            training.ApplicationUserId = HttpContext.Current.User.Identity.GetUserId();

            db.Trainings.Add(training);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = training.Id }, training);
        }

        // DELETE: api/Trainings/5
        [ResponseType(typeof(Training))]
        public async Task<IHttpActionResult> DeleteTraining(int id)
        {
            Training training = await db.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            db.Trainings.Remove(training);
            await db.SaveChangesAsync();

            return Ok(training);
        }

        [HttpGet]
        [Route("api/Trainings/GetCurrentTraining")]
        [ResponseType(typeof(Training))]
        public async Task<IHttpActionResult> GetCurrentTraining()
        {
            var userId = userManager.Users.First(x => x.UserName == User.Identity.Name).Id;
            Training training = await db.Trainings.OrderByDescending(x => x.StartTime)
                .FirstOrDefaultAsync(x => !x.EndTime.HasValue && x.ApplicationUserId == userId);
            if (training == null)
            {
                training = new Training() {StartTime = DateTime.Now, ApplicationUserId = userId };
                db.Trainings.Add(training);
                await db.SaveChangesAsync();
            }

            return Ok(training);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainingExists(int id)
        {
            return db.Trainings.Count(e => e.Id == id) > 0;
        }
    }
}