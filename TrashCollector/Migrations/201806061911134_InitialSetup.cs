namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine = c.String(),
                        PostalCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostalCodes", t => t.PostalCodeId, cascadeDelete: false)
                .Index(t => t.PostalCodeId);
            
            CreateTable(
                "dbo.PostalCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 5),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbbreviationShort = c.String(nullable: false, maxLength: 75),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(nullable: false, maxLength: 20),
                        NameLast = c.String(nullable: false, maxLength: 100),
                        NameFirst = c.String(nullable: false, maxLength: 50),
                        AddressId = c.Int(nullable: false),
                        WeeklyPickupDayId = c.Int(),
                        ServicePostalCodeId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.PostalCodes", t => t.ServicePostalCodeId, cascadeDelete: true)
                .ForeignKey("dbo.WeekDays", t => t.WeeklyPickupDayId)
                .Index(t => t.AddressId)
                .Index(t => t.WeeklyPickupDayId)
                .Index(t => t.ServicePostalCodeId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WeekDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        AbbreviationShort = c.String(nullable: false, maxLength: 1),
                        AbbreviationMedium = c.String(nullable: false, maxLength: 2),
                        AbbreviationLong = c.String(nullable: false, maxLength: 3),
                        AreOperating = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubmittedDateTime = c.DateTime(nullable: false),
                        ScheduledDate = c.DateTime(nullable: false),
                        TypeId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CompletionDateTime = c.DateTime(),
                        CompletedBy_Id = c.String(maxLength: 128),
                        RequestedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CompletedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestedBy_Id)
                .ForeignKey("dbo.WorkOrderStatuses", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.WorkOrderTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.StatusId)
                .Index(t => t.CompletedBy_Id)
                .Index(t => t.RequestedBy_Id);
            
            CreateTable(
                "dbo.WorkOrderStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsOpen = c.Boolean(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkOrderTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrders", "TypeId", "dbo.WorkOrderTypes");
            DropForeignKey("dbo.WorkOrders", "StatusId", "dbo.WorkOrderStatus");
            DropForeignKey("dbo.WorkOrders", "RequestedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkOrders", "CompletedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "WeeklyPickupDayId", "dbo.WeekDays");
            DropForeignKey("dbo.AspNetUsers", "ServicePostalCodeId", "dbo.PostalCodes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Addresses", "PostalCodeId", "dbo.PostalCodes");
            DropForeignKey("dbo.PostalCodes", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropIndex("dbo.WorkOrders", new[] { "RequestedBy_Id" });
            DropIndex("dbo.WorkOrders", new[] { "CompletedBy_Id" });
            DropIndex("dbo.WorkOrders", new[] { "StatusId" });
            DropIndex("dbo.WorkOrders", new[] { "TypeId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "ServicePostalCodeId" });
            DropIndex("dbo.AspNetUsers", new[] { "WeeklyPickupDayId" });
            DropIndex("dbo.AspNetUsers", new[] { "AddressId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.PostalCodes", new[] { "CityId" });
            DropIndex("dbo.Addresses", new[] { "PostalCodeId" });
            DropTable("dbo.WorkOrderTypes");
            DropTable("dbo.WorkOrderStatus");
            DropTable("dbo.WorkOrders");
            DropTable("dbo.WeekDays");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.PostalCodes");
            DropTable("dbo.Addresses");
        }
    }
}
