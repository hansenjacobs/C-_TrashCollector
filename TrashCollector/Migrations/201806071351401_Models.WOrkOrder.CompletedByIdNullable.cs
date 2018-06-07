namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsWOrkOrderCompletedByIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrders", "CompletedById", "dbo.AspNetUsers");
            DropIndex("dbo.WorkOrders", new[] { "CompletedById" });
            AlterColumn("dbo.WorkOrders", "CompletedById", c => c.String(maxLength: 128));
            CreateIndex("dbo.WorkOrders", "CompletedById");
            AddForeignKey("dbo.WorkOrders", "CompletedById", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "CompletedById", "dbo.AspNetUsers");
            DropIndex("dbo.WorkOrders", new[] { "CompletedById" });
            AlterColumn("dbo.WorkOrders", "CompletedById", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.WorkOrders", "CompletedById");
            AddForeignKey("dbo.WorkOrders", "CompletedById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
