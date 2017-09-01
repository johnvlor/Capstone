namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveForeignKeyAttributeFromUserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "UserID" });
            AddColumn("dbo.Users", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "UserID", c => c.String());
            CreateIndex("dbo.Users", "ApplicationUser_Id");
            AddForeignKey("dbo.Users", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Users", "UserID", c => c.String(maxLength: 128));
            DropColumn("dbo.Users", "ApplicationUser_Id");
            CreateIndex("dbo.Users", "UserID");
            AddForeignKey("dbo.Users", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
