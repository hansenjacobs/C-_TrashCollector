namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModelAddedAssignedZipCode1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ServiceZipCode", c => c.String(maxLength: 5));
            DropColumn("dbo.AspNetUsers", "AssignedZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AssignedZipCode", c => c.String(maxLength: 5));
            DropColumn("dbo.AspNetUsers", "ServiceZipCode");
        }
    }
}
