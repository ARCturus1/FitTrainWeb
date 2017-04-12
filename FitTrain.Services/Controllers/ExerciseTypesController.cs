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
    public class ExerciseTypesController : ApiController
    {
        private FitTrainDbContext db = new FitTrainDbContext();

        // GET: api/ExerciseTypes
        public IQueryable<ExerciseType> GetExerciseTypes()
        {
            return db.ExerciseTypes;
        }

        // GET: api/ExerciseTypes/5
        [ResponseType(typeof(ExerciseType))]
        public async Task<IHttpActionResult> GetExerciseType(int id)
        {
            ExerciseType exerciseType = await db.ExerciseTypes.FindAsync(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            return Ok(exerciseType);
        }

        // PUT: api/ExerciseTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExerciseType(int id, ExerciseType exerciseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exerciseType.Id)
            {
                return BadRequest();
            }

            db.Entry(exerciseType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseTypeExists(id))
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

        // POST: api/ExerciseTypes
        [ResponseType(typeof(ExerciseType))]
        public async Task<IHttpActionResult> PostExerciseType(ExerciseType exerciseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExerciseTypes.Add(exerciseType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = exerciseType.Id }, exerciseType);
        }

        // DELETE: api/ExerciseTypes/5
        [ResponseType(typeof(ExerciseType))]
        public async Task<IHttpActionResult> DeleteExerciseType(int id)
        {
            ExerciseType exerciseType = await db.ExerciseTypes.FindAsync(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            db.ExerciseTypes.Remove(exerciseType);
            await db.SaveChangesAsync();

            return Ok(exerciseType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseTypeExists(int id)
        {
            return db.ExerciseTypes.Count(e => e.Id == id) > 0;
        }
    }
}