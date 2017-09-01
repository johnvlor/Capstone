namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "End", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "EventID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventID", c => c.String());
            AlterColumn("dbo.Events", "End", c => c.String());
            AlterColumn("dbo.Events", "Start", c => c.String());
        }
    }
}
