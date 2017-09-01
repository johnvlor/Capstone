namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllDayColumnToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "AllDay", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Events", "Start", c => c.String());
            AlterColumn("dbo.Events", "End", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Start", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "AllDay");
        }
    }
}
