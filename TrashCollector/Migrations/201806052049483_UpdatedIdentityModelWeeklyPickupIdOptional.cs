namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedIdentityModelWeeklyPickupIdOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "WeeklyPickupDayID", "dbo.WeekDays");
            DropIndex("dbo.AspNetUsers", new[] { "WeeklyPickupDayID" });
            AlterColumn("dbo.AspNetUsers", "WeeklyPickupDayId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "WeeklyPickupDayId");
            AddForeignKey("dbo.AspNetUsers", "WeeklyPickupDayId", "dbo.WeekDays", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "WeeklyPickupDayId", "dbo.WeekDays");
            DropIndex("dbo.AspNetUsers", new[] { "WeeklyPickupDayId" });
            AlterColumn("dbo.AspNetUsers", "WeeklyPickupDayId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "WeeklyPickupDayID");
            AddForeignKey("dbo.AspNetUsers", "WeeklyPickupDayID", "dbo.WeekDays", "Id", cascadeDelete: true);
        }
    }
}
