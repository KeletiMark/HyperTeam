namespace HyperTeamWebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SlotType = c.Int(nullable: false),
                        ClockFrequency = c.Int(nullable: false),
                        MemorySizeInGb = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Latecy = c.Int(nullable: false),
                        Manufacturer = c.String(),
                        Type = c.String(),
                        ImgURL = c.String(),
                        PurchasePrice = c.Int(nullable: false),
                        SellingPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Motherboards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocketType = c.Int(nullable: false),
                        SlotType = c.Int(nullable: false),
                        USB3Ports = c.Int(nullable: false),
                        WifiAdapter = c.Boolean(nullable: false),
                        MotherBoardSize = c.Int(nullable: false),
                        Manufacturer = c.String(),
                        Type = c.String(),
                        ImgURL = c.String(),
                        PurchasePrice = c.Int(nullable: false),
                        SellingPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Processors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SocketType = c.Int(nullable: false),
                        Cores = c.Int(nullable: false),
                        ClockFrequency = c.Int(nullable: false),
                        L3CacheSize = c.Int(nullable: false),
                        SMTSupport = c.Boolean(nullable: false),
                        Manufacturer = c.String(),
                        Type = c.String(),
                        ImgURL = c.String(),
                        PurchasePrice = c.Int(nullable: false),
                        SellingPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Processors");
            DropTable("dbo.Motherboards");
            DropTable("dbo.Memories");
        }
    }
}
