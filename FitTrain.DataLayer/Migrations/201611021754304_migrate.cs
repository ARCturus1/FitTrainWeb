namespace FitTrain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        Height = c.Decimal(precision: 18, scale: 2),
                        ApplicationUser_Id = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSettings", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserSettings", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropTable("dbo.UserSettings");
        }
    }
}
