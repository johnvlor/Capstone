namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayPalTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PayPals", newName: "PayPalModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PayPalModels", newName: "PayPals");
        }
    }
}
