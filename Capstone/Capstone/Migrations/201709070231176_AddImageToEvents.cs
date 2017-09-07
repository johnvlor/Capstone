namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ImagePath", c => c.String());
            DropColumn("dbo.Events", "Additional");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Additional", c => c.String());
            DropColumn("dbo.Events", "ImagePath");
        }
    }
}
