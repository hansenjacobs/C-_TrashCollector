namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModelAddedAssignedZipCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AssignedZipCode", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AssignedZipCode");
        }
    }
}
