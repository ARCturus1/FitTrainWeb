using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitTrain.DataLayer.Migrations;
using FitTrain.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitTrain.DataLayer
{
    public class FitTrainDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<UserSetting> UserSettings { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        

        static FitTrainDbContext()
        {
            Database.SetInitializer<FitTrainDbContext>(new MigrateDatabaseToLatestVersion<FitTrainDbContext, Configuration>());
        }

        public FitTrainDbContext() : base("FitTrainDbContext") { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //    modelBuilder.Entity<UserSetting>()
        //        .HasRequired(e => e.User)
        //        .WithMany()
        //        .HasForeignKey(e => e.UserId);
        //}
    }
}
