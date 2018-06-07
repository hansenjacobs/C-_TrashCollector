namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsWorkOrderServiceAddressId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrders", "ServiceAddress_Id", "dbo.Addresses");
            DropIndex("dbo.WorkOrders", new[] { "ServiceAddress_Id" });
            RenameColumn(table: "dbo.WorkOrders", name: "ServiceAddress_Id", newName: "ServiceAddressId");
            AlterColumn("dbo.WorkOrders", "ServiceAddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkOrders", "ServiceAddressId");
            AddForeignKey("dbo.WorkOrders", "ServiceAddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "ServiceAddressId", "dbo.Addresses");
            DropIndex("dbo.WorkOrders", new[] { "ServiceAddressId" });
            AlterColumn("dbo.WorkOrders", "ServiceAddressId", c => c.Int());
            RenameColumn(table: "dbo.WorkOrders", name: "ServiceAddressId", newName: "ServiceAddress_Id");
            CreateIndex("dbo.WorkOrders", "ServiceAddress_Id");
            AddForeignKey("dbo.WorkOrders", "ServiceAddress_Id", "dbo.Addresses", "Id");
        }
    }
}
