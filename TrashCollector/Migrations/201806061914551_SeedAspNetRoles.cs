namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAspNetRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bf03cb54-6933-4250-ad0a-7942db606e01', N'Customer')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'0e14e046-4d42-4a72-890c-03909ef7a2cf', N'Employee')");
        }
        
        public override void Down()
        {
        }
    }
}
