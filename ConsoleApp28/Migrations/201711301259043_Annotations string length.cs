namespace ConsoleApp28.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotationsstringlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leksaks", "Namn", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leksaks", "Namn", c => c.String(maxLength: 4000));
        }
    }
}
