namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedWeekDays : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT[dbo].[WeekDays] ON INSERT INTO dbo.WeekDays (Id, Name, AbbreviationShort, AbbreviationMedium, AbbreviationLong, AreOperating) VALUES (0, 'Sunday', 'U', 'Su', 'Sun', 0)");
            Sql("SET IDENTITY_INSERT[dbo].[WeekDays] ON INSERT INTO dbo.WeekDays (Id, Name, AbbreviationShort, AbbreviationMedium, AbbreviationLong, AreOperating) VALUES (1, 'Monday', 'M', 'Mo', 'Mon', 1)");
            Sql("SET IDENTITY_INSERT[dbo].[WeekDays] ON INSERT INTO dbo.WeekDays (Id, Name, AbbreviationShort, AbbreviationMedium, AbbreviationLong, AreOperating) VALUES (2, 'Tuesday', 'T', 'Tu', 'Tue', 1)");
            Sql("SET IDENTITY_INSERT[dbo].[WeekDays] ON INSERT INTO dbo.WeekDays (Id, Name, AbbreviationShort, AbbreviationMedium, AbbreviationLong, AreOperating) VALUES (3, 'Wednesday', 'W', 'We', 'Wed', 1)");
            Sql("SET IDENTITY_INSERT[dbo].[WeekDays] ON INSERT INTO dbo.WeekDays (Id, Name, AbbreviationShort, AbbreviationMedium, AbbreviationLong, AreOperating) VALUES (4, 'Thursday', 'R', 'Th', 'Thu', 1)");
            Sql("SET IDENTITY_INSERT[dbo].[WeekDays] ON INSERT INTO dbo.WeekDays (Id, Name, AbbreviationShort, AbbreviationMedium, AbbreviationLong, AreOperating) VALUES (5, 'Friday', 'F', 'Fr', 'Fri', 1)");
            Sql("SET IDENTITY_INSERT[dbo].[WeekDays] ON INSERT INTO dbo.WeekDays (Id, Name, AbbreviationShort, AbbreviationMedium, AbbreviationLong, AreOperating) VALUES (6, 'Saturday', 'S', 'Sa', 'Sat', 0)");
        }
        
        public override void Down()
        {
        }
    }
}
