namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityModelsApplicationUserServicePostalCodeNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "ServicePostalCodeId", "dbo.PostalCodes");
            DropIndex("dbo.AspNetUsers", new[] { "ServicePostalCodeId" });
            AlterColumn("dbo.AspNetUsers", "ServicePostalCodeId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "ServicePostalCodeId");
            AddForeignKey("dbo.AspNetUsers", "ServicePostalCodeId", "dbo.PostalCodes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "ServicePostalCodeId", "dbo.PostalCodes");
            DropIndex("dbo.AspNetUsers", new[] { "ServicePostalCodeId" });
            AlterColumn("dbo.AspNetUsers", "ServicePostalCodeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ServicePostalCodeId");
            AddForeignKey("dbo.AspNetUsers", "ServicePostalCodeId", "dbo.PostalCodes", "Id", cascadeDelete: true);
        }
    }
}
