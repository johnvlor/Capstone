namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalAttendanceColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendances", "Total");
        }
    }
}
