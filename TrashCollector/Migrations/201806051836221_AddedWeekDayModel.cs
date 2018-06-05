namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWeekDayModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeekDays", "AreOperating", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeekDays", "AreOperating");
        }
    }
}
