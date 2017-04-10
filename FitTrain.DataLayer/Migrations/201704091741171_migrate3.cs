namespace FitTrain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainings", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainings", "EndTime", c => c.DateTime(nullable: false));
        }
    }
}
