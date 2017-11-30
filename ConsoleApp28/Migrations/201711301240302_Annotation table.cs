namespace ConsoleApp28.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotationtable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tillverkares", newName: "TillverkareUtanS");
            AlterColumn("dbo.TillverkareUtanS", "Namn", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TillverkareUtanS", "Namn", c => c.String());
            RenameTable(name: "dbo.TillverkareUtanS", newName: "Tillverkares");
        }
    }
}
