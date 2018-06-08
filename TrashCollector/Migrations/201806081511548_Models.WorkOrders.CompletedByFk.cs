namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsWorkOrdersCompletedByFk : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WorkOrders", "CompletedById");
            RenameColumn(table: "dbo.WorkOrders", name: "CompletedBy_UserId", newName: "CompletedById");
            RenameIndex(table: "dbo.WorkOrders", name: "IX_CompletedBy_UserId", newName: "IX_CompletedById");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.WorkOrders", name: "IX_CompletedById", newName: "IX_CompletedBy_UserId");
            RenameColumn(table: "dbo.WorkOrders", name: "CompletedById", newName: "CompletedBy_UserId");
            AddColumn("dbo.WorkOrders", "CompletedById", c => c.String(maxLength: 128));
        }
    }
}
