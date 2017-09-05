namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsForEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ContactName", c => c.String());
            AddColumn("dbo.Events", "ContactEmail", c => c.String());
            AddColumn("dbo.Events", "ContactPhone", c => c.String());
            AddColumn("dbo.Events", "Address", c => c.String());
            AddColumn("dbo.Events", "City", c => c.String());
            AddColumn("dbo.Events", "State", c => c.String());
            AddColumn("dbo.Events", "Zip", c => c.String());
            AddColumn("dbo.Events", "Additional", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Additional");
            DropColumn("dbo.Events", "Zip");
            DropColumn("dbo.Events", "State");
            DropColumn("dbo.Events", "City");
            DropColumn("dbo.Events", "Address");
            DropColumn("dbo.Events", "ContactPhone");
            DropColumn("dbo.Events", "ContactEmail");
            DropColumn("dbo.Events", "ContactName");
        }
    }
}
