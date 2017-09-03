namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventIDForeignKeyToMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "EventID", c => c.String());
            AddColumn("dbo.Members", "Event_ID", c => c.Int());
            CreateIndex("dbo.Members", "Event_ID");
            AddForeignKey("dbo.Members", "Event_ID", "dbo.Events", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Event_ID", "dbo.Events");
            DropIndex("dbo.Members", new[] { "Event_ID" });
            DropColumn("dbo.Members", "Event_ID");
            DropColumn("dbo.Members", "EventID");
        }
    }
}
