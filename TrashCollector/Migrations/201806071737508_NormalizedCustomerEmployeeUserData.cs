namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NormalizedCustomerEmployeeUserData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUsers", "ServicePostalCodeId", "dbo.PostalCodes");
            DropForeignKey("dbo.AspNetUsers", "WeeklyPickupDayId", "dbo.WeekDays");
            DropForeignKey("dbo.WorkOrders", "RequestedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkOrders", "CompletedById", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "AddressId" });
            DropIndex("dbo.AspNetUsers", new[] { "WeeklyPickupDayId" });
            DropIndex("dbo.AspNetUsers", new[] { "ServicePostalCodeId" });
            DropIndex("dbo.WorkOrders", new[] { "RequestedById" });
            DropIndex("dbo.WorkOrders", new[] { "CompletedById" });
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        NameLast = c.String(nullable: false, maxLength: 100),
                        NameFirst = c.String(nullable: false, maxLength: 50),
                        ServicePostalCodeId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.PostalCodes", t => t.ServicePostalCodeId)
                .Index(t => t.ServicePostalCodeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(nullable: false, maxLength: 20),
                        NameLast = c.String(nullable: false, maxLength: 100),
                        NameFirst = c.String(nullable: false, maxLength: 50),
                        AddressId = c.Int(nullable: false),
                        WeeklyPickupDayId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: false)
                .ForeignKey("dbo.WeekDays", t => t.WeeklyPickupDayId)
                .Index(t => t.AddressId)
                .Index(t => t.WeeklyPickupDayId);
            
            AddColumn("dbo.WorkOrders", "CustomerUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.WorkOrders", "CompletedBy_UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.WorkOrders", "CustomerUserId");
            CreateIndex("dbo.WorkOrders", "CompletedBy_UserId");
            AddForeignKey("dbo.WorkOrders", "CustomerUserId", "dbo.Customers", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.WorkOrders", "CompletedBy_UserId", "dbo.Employees", "UserId");
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "NameLast");
            DropColumn("dbo.AspNetUsers", "NameFirst");
            DropColumn("dbo.AspNetUsers", "AddressId");
            DropColumn("dbo.AspNetUsers", "WeeklyPickupDayId");
            DropColumn("dbo.AspNetUsers", "ServicePostalCodeId");
            DropColumn("dbo.WorkOrders", "RequestedById");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrders", "RequestedById", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "ServicePostalCodeId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "WeeklyPickupDayId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "NameFirst", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "NameLast", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.WorkOrders", "CompletedBy_UserId", "dbo.Employees");
            DropForeignKey("dbo.WorkOrders", "CustomerUserId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "WeeklyPickupDayId", "dbo.WeekDays");
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Employees", "ServicePostalCodeId", "dbo.PostalCodes");
            DropIndex("dbo.Customers", new[] { "WeeklyPickupDayId" });
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropIndex("dbo.Employees", new[] { "ServicePostalCodeId" });
            DropIndex("dbo.WorkOrders", new[] { "CompletedBy_UserId" });
            DropIndex("dbo.WorkOrders", new[] { "CustomerUserId" });
            DropColumn("dbo.WorkOrders", "CompletedBy_UserId");
            DropColumn("dbo.WorkOrders", "CustomerUserId");
            DropTable("dbo.Customers");
            DropTable("dbo.Employees");
            CreateIndex("dbo.WorkOrders", "CompletedById");
            CreateIndex("dbo.WorkOrders", "RequestedById");
            CreateIndex("dbo.AspNetUsers", "ServicePostalCodeId");
            CreateIndex("dbo.AspNetUsers", "WeeklyPickupDayId");
            CreateIndex("dbo.AspNetUsers", "AddressId");
            AddForeignKey("dbo.WorkOrders", "CompletedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkOrders", "RequestedById", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "WeeklyPickupDayId", "dbo.WeekDays", "Id");
            AddForeignKey("dbo.AspNetUsers", "ServicePostalCodeId", "dbo.PostalCodes", "Id");
            AddForeignKey("dbo.AspNetUsers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
