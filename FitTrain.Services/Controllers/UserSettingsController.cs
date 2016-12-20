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
using FitTrain.Domain.Models;

namespace FitTrain.Services.Controllers
{
    public class UserSettingsController : ApiController
    {
        private FitTrainDbContext db = new FitTrainDbContext();

        // GET: api/UserSettings
        public IQueryable<UserSetting> GetUserSettings()
        {
            return db.UserSettings;
        }

        // GET: api/UserSettings/5
        [ResponseType(typeof(UserSetting))]
        public async Task<IHttpActionResult> GetUserSetting(Guid id)
        {
            UserSetting userSetting = await db.UserSettings.FindAsync(id);
            if (userSetting == null)
            {
                return NotFound();
            }

            return Ok(userSetting);
        }

        // PUT: api/UserSettings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserSetting(Guid id, UserSetting userSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userSetting.Id)
            {
                return BadRequest();
            }

            db.Entry(userSetting).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSettingExists(id))
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

        // POST: api/UserSettings
        [ResponseType(typeof(UserSetting))]
        public async Task<IHttpActionResult> PostUserSetting(UserSetting userSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserSettings.Add(userSetting);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserSettingExists(userSetting.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userSetting.Id }, userSetting);
        }

        // DELETE: api/UserSettings/5
        [ResponseType(typeof(UserSetting))]
        public async Task<IHttpActionResult> DeleteUserSetting(Guid id)
        {
            UserSetting userSetting = await db.UserSettings.FindAsync(id);
            if (userSetting == null)
            {
                return NotFound();
            }

            db.UserSettings.Remove(userSetting);
            await db.SaveChangesAsync();

            return Ok(userSetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserSettingExists(Guid id)
        {
            return db.UserSettings.Count(e => e.Id == id) > 0;
        }
    }
}