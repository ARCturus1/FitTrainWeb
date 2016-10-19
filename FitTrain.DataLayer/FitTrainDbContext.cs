using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitTrain.DataLayer.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitTrain.DataLayer
{
    public class ApplicationUser : IdentityUser { }
    public class FitTrainDbContext : IdentityDbContext<ApplicationUser>
    {
        static FitTrainDbContext()
        {
            Database.SetInitializer<FitTrainDbContext>(new MigrateDatabaseToLatestVersion<FitTrainDbContext, Configuration>());
        }

        public FitTrainDbContext() : base("FitTrainDbContext") { }
    }
}
