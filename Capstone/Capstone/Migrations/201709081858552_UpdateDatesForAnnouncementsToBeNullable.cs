namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatesForAnnouncementsToBeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "Start", c => c.DateTime());
            AlterColumn("dbo.Announcements", "End", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Announcements", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Announcements", "Start", c => c.DateTime(nullable: false));
        }
    }
}
