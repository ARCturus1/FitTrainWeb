﻿using System;
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
    public class ExercisesController : ApiController
    {
        private FitTrainDbContext db = new FitTrainDbContext();

        // GET: api/Exercises
        public IEnumerable<Exercise> GetExercises(int? trainingId)
        {
            return trainingId.HasValue 
                ? db.Exercises.Where(x => x.TrainingId == trainingId.Value).Include(x => x.Approaches).ToList() 
                : db.Exercises.ToList();
        }

        // GET: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public async Task<IHttpActionResult> GetExercise(int id)
        {
            Exercise exercise = await db.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercises/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExercise(int id, Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.Id)
            {
                return BadRequest();
            }

            db.Entry(exercise).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercises
        [HttpPost]
        [ResponseType(typeof(Exercise))]
        public async Task<IHttpActionResult> PostExercise([FromBody]Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exercises.Add(exercise);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        [ResponseType(typeof(Exercise))]
        public async Task<IHttpActionResult> DeleteExercise(int id)
        {
            Exercise exercise = await db.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            db.Exercises.Remove(exercise);
            await db.SaveChangesAsync();

            return Ok(exercise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExerciseExists(int id)
        {
            return db.Exercises.Count(e => e.Id == id) > 0;
        }
    }
}