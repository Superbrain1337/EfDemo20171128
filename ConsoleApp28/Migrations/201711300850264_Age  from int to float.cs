namespace ConsoleApp28.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agefrominttofloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leksaks", "MinstaÅlder", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leksaks", "MinstaÅlder", c => c.Int(nullable: false));
        }
    }
}
