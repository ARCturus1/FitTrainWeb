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
using FitTrain.Domain.Enums;
using FitTrain.Logic.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

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
        public async Task<IHttpActionResult> GetUserSetting(int id)
        {
            UserSetting userSetting = await db.UserSettings.FindAsync(id);
            if (userSetting == null)
            {
                return NotFound();
            }

            return Ok(userSetting);
        }

        [Route("api/UserSettings/GetUserSettingByMode")]
        [HttpGet]
        [ResponseType(typeof(UserSetting))]
        public async Task<IHttpActionResult> GetUserSettingByMode(int mode)
        {
            UserSetting userSetting = await db.UserSettings.OrderByDescending(x => x.AddedDate).FirstOrDefaultAsync();
            if (userSetting == null)
            {
                return NotFound();
            }
            DietModelFactory dietModelFactory = new DietModelFactory();
            
            return Ok(dietModelFactory.CreateDietModel((DietMode)mode, userSetting));
        }

        // PUT: api/UserSettings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserSetting(int id, UserSetting userSetting)
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
        [Authorize]
        public async Task<IHttpActionResult> PostUserSetting(UserSetting userSetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            userSetting.ApplicationUserId = manager.FindByName(User.Identity.Name)?.Id;
            userSetting.AddedDate = DateTime.Now;
            
            db.UserSettings.Add(userSetting);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (UserSettingExists(userSetting.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw e;
                }
            }

            return Ok();
        }

        // DELETE: api/UserSettings/5
        [ResponseType(typeof(UserSetting))]
        public async Task<IHttpActionResult> DeleteUserSetting(int id)
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

        private bool UserSettingExists(int id)
        {
            return db.UserSettings.Count(e => e.Id == id) > 0;
        }
    }
}