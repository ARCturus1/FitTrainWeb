namespace FitTrain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("UserSettings", "AddedDate", builder => builder.DateTime(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
