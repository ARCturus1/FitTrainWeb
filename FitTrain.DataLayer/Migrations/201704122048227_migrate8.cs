namespace FitTrain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExerciseTypes", "MusscleGroupsStr", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExerciseTypes", "MusscleGroupsStr");
        }
    }
}
