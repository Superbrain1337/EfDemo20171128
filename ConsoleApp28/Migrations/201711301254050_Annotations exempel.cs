namespace ConsoleApp28.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotationsexempel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leksaks", "Tillverkare_TillverkareId", "dbo.TillverkareUtanS");
            DropIndex("dbo.Leksaks", new[] { "Tillverkare_TillverkareId" });
            RenameColumn(table: "dbo.Leksaks", name: "Name", newName: "Namn");
            RenameColumn(table: "dbo.Leksaks", name: "Tillverkare_TillverkareId", newName: "TillverkareIdFK");
            AlterColumn("dbo.Leksaks", "Namn", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Leksaks", "TillverkareIdFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Leksaks", "TillverkareIdFK");
            AddForeignKey("dbo.Leksaks", "TillverkareIdFK", "dbo.TillverkareUtanS", "TillverkareId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leksaks", "TillverkareIdFK", "dbo.TillverkareUtanS");
            DropIndex("dbo.Leksaks", new[] { "TillverkareIdFK" });
            AlterColumn("dbo.Leksaks", "TillverkareIdFK", c => c.Int());
            AlterColumn("dbo.Leksaks", "Namn", c => c.String());
            RenameColumn(table: "dbo.Leksaks", name: "TillverkareIdFK", newName: "Tillverkare_TillverkareId");
            RenameColumn(table: "dbo.Leksaks", name: "Namn", newName: "Name");
            CreateIndex("dbo.Leksaks", "Tillverkare_TillverkareId");
            AddForeignKey("dbo.Leksaks", "Tillverkare_TillverkareId", "dbo.TillverkareUtanS", "TillverkareId");
        }
    }
}
