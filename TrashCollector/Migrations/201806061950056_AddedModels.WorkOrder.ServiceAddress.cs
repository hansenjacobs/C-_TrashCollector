namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelsWorkOrderServiceAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "ServiceAddress_Id", c => c.Int());
            CreateIndex("dbo.WorkOrders", "ServiceAddress_Id");
            AddForeignKey("dbo.WorkOrders", "ServiceAddress_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "ServiceAddress_Id", "dbo.Addresses");
            DropIndex("dbo.WorkOrders", new[] { "ServiceAddress_Id" });
            DropColumn("dbo.WorkOrders", "ServiceAddress_Id");
        }
    }
}
