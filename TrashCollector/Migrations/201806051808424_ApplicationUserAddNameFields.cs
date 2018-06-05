namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserAddNameFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NameLast", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "NameFirst", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NameFirst");
            DropColumn("dbo.AspNetUsers", "NameLast");
        }
    }
}
