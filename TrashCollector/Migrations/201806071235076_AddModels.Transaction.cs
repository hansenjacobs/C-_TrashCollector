namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAccountId = c.String(nullable: false, maxLength: 128),
                        TransactionDateTime = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 75),
                        Amount = c.Double(nullable: false),
                        EnteredById = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.EnteredById, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccountId, cascadeDelete: false)
                .Index(t => t.UserAccountId)
                .Index(t => t.EnteredById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "UserAccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "EnteredById", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "EnteredById" });
            DropIndex("dbo.Transactions", new[] { "UserAccountId" });
            DropTable("dbo.Transactions");
        }
    }
}
