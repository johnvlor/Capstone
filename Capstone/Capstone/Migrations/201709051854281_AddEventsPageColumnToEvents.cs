namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventsPageColumnToEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventsPage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventsPage");
        }
    }
}
