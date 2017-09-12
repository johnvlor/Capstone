namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSignupOptionToEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Register", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Register");
        }
    }
}
