namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventIDForeignKeyInMembers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Event_ID", "dbo.Events");
            DropIndex("dbo.Members", new[] { "Event_ID" });
            DropColumn("dbo.Members", "EventID");
            RenameColumn(table: "dbo.Members", name: "Event_ID", newName: "EventID");
            AlterColumn("dbo.Members", "EventID", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "EventID", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "EventID");
            AddForeignKey("dbo.Members", "EventID", "dbo.Events", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "EventID", "dbo.Events");
            DropIndex("dbo.Members", new[] { "EventID" });
            AlterColumn("dbo.Members", "EventID", c => c.Int());
            AlterColumn("dbo.Members", "EventID", c => c.String());
            RenameColumn(table: "dbo.Members", name: "EventID", newName: "Event_ID");
            AddColumn("dbo.Members", "EventID", c => c.String());
            CreateIndex("dbo.Members", "Event_ID");
            AddForeignKey("dbo.Members", "Event_ID", "dbo.Events", "ID");
        }
    }
}
