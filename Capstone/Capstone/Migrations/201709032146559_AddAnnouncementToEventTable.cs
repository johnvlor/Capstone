namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnouncementToEventTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Announcement", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Announcement");
        }
    }
}
