namespace FitTrain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserSettings", new[] { "Id" });
            CreateIndex("dbo.UserSettings", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserSettings", new[] { "Id" });
            CreateIndex("dbo.UserSettings", "ApplicationUserId");
        }
    }
}
