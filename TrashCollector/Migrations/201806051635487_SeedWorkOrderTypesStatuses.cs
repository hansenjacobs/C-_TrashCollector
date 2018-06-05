namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedWorkOrderTypesStatuses : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT [dbo].[WorkOrderTypes] ON INSERT INTO WorkOrderTypes (Id, Name) VALUES (1, 'Reocurring Weekly') SET IDENTITY_INSERT [dbo].[WorkOrderTypes] OFF");
            Sql("SET IDENTITY_INSERT [dbo].[WorkOrderTypes] ON INSERT INTO WorkOrderTypes (Id, Name) VALUES (2, 'One Time') SET IDENTITY_INSERT [dbo].[WorkOrderTypes] OFF");

            Sql("SET IDENTITY_INSERT [dbo].[WorkOrderStatuses] ON INSERT INTO WorkOrderStatuses (Id, Name, IsOpen, IsConfirmed) VALUES (1, 'Requested', 1, 0) SET IDENTITY_INSERT [dbo].[WorkOrderStatuses] OFF");
            Sql("SET IDENTITY_INSERT [dbo].[WorkOrderStatuses] ON INSERT INTO WorkOrderStatuses (Id, Name, IsOpen, IsConfirmed) VALUES (2, 'Confirmed', 1, 1) SET IDENTITY_INSERT [dbo].[WorkOrderStatuses] OFF");
            Sql("SET IDENTITY_INSERT [dbo].[WorkOrderStatuses] ON INSERT INTO WorkOrderStatuses (Id, Name, IsOpen, IsConfirmed) VALUES (3, 'Completed', 0, 1) SET IDENTITY_INSERT [dbo].[WorkOrderStatuses] OFF");
            Sql("SET IDENTITY_INSERT [dbo].[WorkOrderStatuses] ON INSERT INTO WorkOrderStatuses (Id, Name, IsOpen, IsConfirmed) VALUES (4, 'Canceled', 0, 0) SET IDENTITY_INSERT [dbo].[WorkOrderStatuses] OFF");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM WorkOrderTypes");
            Sql("DELETE FROM WorkOrderStatuses");
        }
    }
}
