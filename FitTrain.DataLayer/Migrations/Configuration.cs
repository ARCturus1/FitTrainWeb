using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrain.DataLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FitTrainDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FitTrainDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.PostedNews.AddOrUpdate(n => n.Name,
            //    new PostedNew()
            //    {
            //        Name = "New 1 the best new in world!",
            //        Description = "The new about the best thinks in my own live and more, more, more..."
            //    }, new PostedNew()
            //    {
            //        Name = "New 2 the best new in world!",
            //        Description = "The new about the best thinks in my own live and more, more, more..."
            //    });
            base.Seed(context);
        }
    }
}
