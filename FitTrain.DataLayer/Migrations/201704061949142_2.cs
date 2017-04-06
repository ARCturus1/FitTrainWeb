namespace FitTrain.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DietPeroidId = c.Int(nullable: false),
                        DietMode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DietPeriods", t => t.DietPeroidId, cascadeDelete: true)
                .Index(t => t.DietPeroidId);
            
            CreateTable(
                "dbo.DietPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserSettingId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSettings", t => t.UserSettingId, cascadeDelete: true)
                .Index(t => t.UserSettingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DietDays", "DietPeroidId", "dbo.DietPeriods");
            DropForeignKey("dbo.DietPeriods", "UserSettingId", "dbo.UserSettings");
            DropIndex("dbo.DietPeriods", new[] { "UserSettingId" });
            DropIndex("dbo.DietDays", new[] { "DietPeroidId" });
            DropTable("dbo.DietPeriods");
            DropTable("dbo.DietDays");
        }
    }
}
