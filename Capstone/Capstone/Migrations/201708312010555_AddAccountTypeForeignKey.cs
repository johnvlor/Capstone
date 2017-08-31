namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTypeForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AccountTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "AccountTypeID");
            AddForeignKey("dbo.AspNetUsers", "AccountTypeID", "dbo.AccountTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "AccountTypeID", "dbo.AccountTypes");
            DropIndex("dbo.AspNetUsers", new[] { "AccountTypeID" });
            DropColumn("dbo.AspNetUsers", "AccountTypeID");
        }
    }
}
