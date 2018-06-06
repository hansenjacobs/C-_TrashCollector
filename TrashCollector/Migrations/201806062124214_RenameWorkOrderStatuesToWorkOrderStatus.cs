namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameWorkOrderStatuesToWorkOrderStatus : DbMigration
    {
        public override void Up()
        {
            Sql("SP_RENAME 'WorkOrderStatuses', 'WorkOrderStatus'");
        }
        
        public override void Down()
        {
        }
    }
}
