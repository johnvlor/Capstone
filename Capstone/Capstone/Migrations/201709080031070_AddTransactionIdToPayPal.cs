namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionIdToPayPal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PayPalModels", "TransactionID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayPalModels", "TransactionID");
        }
    }
}
