using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitTrain.Domain.Entities.Training;
using FitTrain.Domain.Enums;

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
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Id = 1, Name = "Жим лёжа", MusscleGroups = new List<MusscleGroup>() { MusscleGroup.Chest}});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() {Id = 2, Name = "Присядания со штангой", MusscleGroups = new List<MusscleGroup> { MusscleGroup.Quadriceps, MusscleGroup.Hamstrings}});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Id = 3, Name = "Становая тяга", MusscleGroups = new List<MusscleGroup> { MusscleGroup.Back, MusscleGroup.Quadriceps, MusscleGroup.Trapezius}});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Name = "Жим лёжа", MusscleGroup = MusscleGroup.Chest});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Name = "Жим лёжа", MusscleGroup = MusscleGroup.Chest});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Name = "Жим лёжа", MusscleGroup = MusscleGroup.Chest});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Name = "Жим лёжа", MusscleGroup = MusscleGroup.Chest});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Name = "Жим лёжа", MusscleGroup = MusscleGroup.Chest});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Name = "Жим лёжа", MusscleGroup = MusscleGroup.Chest});
            //context.ExerciseTypes.AddOrUpdate(e => e.Id, new ExerciseType() { Name = "Жим лёжа", MusscleGroup = MusscleGroup.Chest});
            context.Approaches.AddOrUpdate(e => e.Id, new Approach()
            {
                Id = 1,
                StartTime = new DateTime(2017, 5, 1, 20, 0, 0),
                EndTime = new DateTime(2017, 5, 1, 20, 0, 25),
                ExcesiceId = 1,
                Times = 15,
                Weight = 20
            });
            context.Approaches.AddOrUpdate(e => e.Id, new Approach()
            {
                Id = 2,
                StartTime = new DateTime(2017, 5, 1, 20, 1, 0),
                EndTime = new DateTime(2017, 5, 1, 20, 1, 25),
                ExcesiceId = 1,
                Times = 22,
                Weight = 70
            });
            context.Approaches.AddOrUpdate(e => e.Id, new Approach()
            {
                Id = 3,
                StartTime = new DateTime(2017, 5, 1, 20, 2, 0),
                EndTime = new DateTime(2017, 5, 1, 20, 2, 25),
                ExcesiceId = 1,
                Times = 16,
                Weight = 70
            });
            context.Approaches.AddOrUpdate(e => e.Id, new Approach()
            {
                Id = 4,
                StartTime = new DateTime(2017, 5, 1, 20, 3, 0),
                EndTime = new DateTime(2017, 5, 1, 20, 3, 25),
                ExcesiceId = 1,
                Times = 8,
                Weight = 70
            });
            base.Seed(context);
        }
    }
}
