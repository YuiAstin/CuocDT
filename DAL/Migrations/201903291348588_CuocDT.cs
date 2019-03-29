namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CuocDT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillDate = c.DateTime(nullable: false),
                        PayDate = c.DateTime(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SIMId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SIM", t => t.SIMId, cascadeDelete: true)
                .Index(t => t.SIMId);
            
            CreateTable(
                "dbo.SIM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumberId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        OpenTime = c.DateTime(nullable: false),
                        CloseTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PhoneNumber", t => t.PhoneNumberId, cascadeDelete: true)
                .Index(t => t.PhoneNumberId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        CMND = c.String(nullable: false, maxLength: 12),
                        Email = c.String(),
                        Job = c.String(nullable: false, maxLength: 20),
                        Position = c.String(maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CMND, unique: true);
            
            CreateTable(
                "dbo.PhoneCall",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CallerSIMId = c.Int(nullable: false),
                        CalleeSIMId = c.Int(nullable: false),
                        StartingTime = c.DateTime(nullable: false),
                        EndingTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SIM", t => t.CallerSIMId, cascadeDelete: true)
                .Index(t => t.CallerSIMId);
            
            CreateTable(
                "dbo.PhoneNumber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Number, unique: true);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SIM", "PhoneNumberId", "dbo.PhoneNumber");
            DropForeignKey("dbo.PhoneCall", "CallerSIMId", "dbo.SIM");
            DropForeignKey("dbo.SIM", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Bill", "SIMId", "dbo.SIM");
            DropIndex("dbo.Employee", new[] { "Username" });
            DropIndex("dbo.PhoneNumber", new[] { "Number" });
            DropIndex("dbo.PhoneCall", new[] { "CallerSIMId" });
            DropIndex("dbo.Customer", new[] { "CMND" });
            DropIndex("dbo.SIM", new[] { "CustomerId" });
            DropIndex("dbo.SIM", new[] { "PhoneNumberId" });
            DropIndex("dbo.Bill", new[] { "SIMId" });
            DropTable("dbo.Employee");
            DropTable("dbo.PhoneNumber");
            DropTable("dbo.PhoneCall");
            DropTable("dbo.Customer");
            DropTable("dbo.SIM");
            DropTable("dbo.Bill");
        }
    }
}
