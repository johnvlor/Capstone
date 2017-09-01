namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventID");
        }
    }
}
