namespace FitTrain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approaches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExcesiceId = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Times = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exercises", t => t.ExcesiceId, cascadeDelete: true)
                .Index(t => t.ExcesiceId);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciseTypeId = c.Int(nullable: false),
                        TrainingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExerciseTypes", t => t.ExerciseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Trainings", t => t.TrainingId, cascadeDelete: true)
                .Index(t => t.ExerciseTypeId)
                .Index(t => t.TrainingId);
            
            CreateTable(
                "dbo.ExerciseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MusscleGroup = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 4000),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Approaches", "ExcesiceId", "dbo.Exercises");
            DropForeignKey("dbo.Exercises", "TrainingId", "dbo.Trainings");
            DropForeignKey("dbo.Trainings", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Exercises", "ExerciseTypeId", "dbo.ExerciseTypes");
            DropIndex("dbo.Trainings", new[] { "ApplicationUserId" });
            DropIndex("dbo.Exercises", new[] { "TrainingId" });
            DropIndex("dbo.Exercises", new[] { "ExerciseTypeId" });
            DropIndex("dbo.Approaches", new[] { "ExcesiceId" });
            DropTable("dbo.Trainings");
            DropTable("dbo.ExerciseTypes");
            DropTable("dbo.Exercises");
            DropTable("dbo.Approaches");
        }
    }
}
