namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFksWorkOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrders", "CompletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkOrders", "RequestedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WorkOrders", new[] { "CompletedBy_Id" });
            DropIndex("dbo.WorkOrders", new[] { "RequestedBy_Id" });
            RenameColumn(table: "dbo.WorkOrders", name: "CompletedBy_Id", newName: "CompletedById");
            RenameColumn(table: "dbo.WorkOrders", name: "RequestedBy_Id", newName: "RequestedById");
            AlterColumn("dbo.WorkOrders", "CompletedById", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.WorkOrders", "RequestedById", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.WorkOrders", "RequestedById");
            CreateIndex("dbo.WorkOrders", "CompletedById");
            AddForeignKey("dbo.WorkOrders", "CompletedById", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.WorkOrders", "RequestedById", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "RequestedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkOrders", "CompletedById", "dbo.AspNetUsers");
            DropIndex("dbo.WorkOrders", new[] { "CompletedById" });
            DropIndex("dbo.WorkOrders", new[] { "RequestedById" });
            AlterColumn("dbo.WorkOrders", "RequestedById", c => c.String(maxLength: 128));
            AlterColumn("dbo.WorkOrders", "CompletedById", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.WorkOrders", name: "RequestedById", newName: "RequestedBy_Id");
            RenameColumn(table: "dbo.WorkOrders", name: "CompletedById", newName: "CompletedBy_Id");
            CreateIndex("dbo.WorkOrders", "RequestedBy_Id");
            CreateIndex("dbo.WorkOrders", "CompletedBy_Id");
            AddForeignKey("dbo.WorkOrders", "RequestedBy_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkOrders", "CompletedBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
