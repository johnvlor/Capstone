namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAnnouncementToEventTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Announcement", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Announcement", c => c.Boolean());
        }
    }
}
