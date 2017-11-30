namespace ConsoleApp28.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leksaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MinstaÅlder = c.Int(nullable: false),
                        Pris = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tillverkare_TillverkareId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tillverkares", t => t.Tillverkare_TillverkareId)
                .Index(t => t.Tillverkare_TillverkareId);
            
            CreateTable(
                "dbo.Tillverkares",
                c => new
                    {
                        TillverkareId = c.Int(nullable: false, identity: true),
                        Namn = c.String(),
                    })
                .PrimaryKey(t => t.TillverkareId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leksaks", "Tillverkare_TillverkareId", "dbo.Tillverkares");
            DropIndex("dbo.Leksaks", new[] { "Tillverkare_TillverkareId" });
            DropTable("dbo.Tillverkares");
            DropTable("dbo.Leksaks");
        }
    }
}
