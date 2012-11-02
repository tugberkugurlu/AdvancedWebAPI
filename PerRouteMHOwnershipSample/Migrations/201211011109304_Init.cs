namespace _09_PerRouteMHOwnershipSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 320),
                        HashedPassword = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        CustomerKey = c.Int(nullable: false),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Customers", t => t.CustomerKey, cascadeDelete: true)
                .Index(t => t.CustomerKey);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "CustomerKey" });
            DropForeignKey("dbo.Orders", "CustomerKey", "dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
