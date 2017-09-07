namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToPayPalModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PayPalModels", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PayPalModels", "Date");
        }
    }
}
