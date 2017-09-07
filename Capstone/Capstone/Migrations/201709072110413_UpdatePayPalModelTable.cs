namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayPalModelTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PayPalModels", "FirstName");
            DropColumn("dbo.PayPalModels", "LastName");
            DropColumn("dbo.PayPalModels", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PayPalModels", "Email", c => c.String());
            AddColumn("dbo.PayPalModels", "LastName", c => c.String());
            AddColumn("dbo.PayPalModels", "FirstName", c => c.String());
        }
    }
}
