namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdForeignKeyAndAccountTypeToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Users", "UserID");
            AddForeignKey("dbo.Users", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "UserID" });
            DropColumn("dbo.Users", "UserID");
        }
    }
}
