namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateTypeForPayPal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PayPalModels", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PayPalModels", "Date", c => c.String());
        }
    }
}
