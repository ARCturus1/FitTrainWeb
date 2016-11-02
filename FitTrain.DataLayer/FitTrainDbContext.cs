using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitTrain.DataLayer.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitTrain.DataLayer
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? BirthDate { get; set; }
        public ICollection<UserSetting> UserSettings { get; set; }
    }

    public class UserSetting
    {
        [Key]
        public Guid Id { get; set; }
        
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
    }

    public class FitTrainDbContext : IdentityDbContext<ApplicationUser>
    {
        static FitTrainDbContext()
        {
            Database.SetInitializer<FitTrainDbContext>(new MigrateDatabaseToLatestVersion<FitTrainDbContext, Configuration>());
        }

        public FitTrainDbContext() : base("FitTrainDbContext") { }
    }
}
