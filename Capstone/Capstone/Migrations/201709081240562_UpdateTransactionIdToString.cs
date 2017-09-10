namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTransactionIdToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PayPalModels", "PayPalTransactionID", c => c.String());
            DropColumn("dbo.PayPalModels", "TransactionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PayPalModels", "TransactionID", c => c.Int(nullable: false));
            DropColumn("dbo.PayPalModels", "PayPalTransactionID");
        }
    }
}
