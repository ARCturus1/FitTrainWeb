using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitTrain.DataLayer.Migrations;
using FitTrain.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitTrain.DataLayer
{
    public class FitTrainDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserSetting> UserSettings { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        

        static FitTrainDbContext()
        {
            Database.SetInitializer<FitTrainDbContext>(new MigrateDatabaseToLatestVersion<FitTrainDbContext, Configuration>());
        }

        public FitTrainDbContext() : base("FitTrainDbContext") { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //    // Add configuration here

        //    modelBuilder.Entity<UserSetting>()
        //        .HasKey(e => e.Id);

        //    modelBuilder.Entity<ApplicationUser>()
        //        .HasKey(e => e.Id);

        //    modelBuilder.Entity<UserSetting>()
        //        .HasRequired(e => e.ApplicationUser)
        //        .WithMany()
        //        .HasForeignKey(e => e.ApplicationUserId );

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
