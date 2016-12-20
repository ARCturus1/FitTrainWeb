namespace FitTrain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
    }
}
