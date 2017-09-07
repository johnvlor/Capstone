namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAddressColumnsFromMembers : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "Address");
            DropColumn("dbo.Members", "City");
            DropColumn("dbo.Members", "State");
            DropColumn("dbo.Members", "Zip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Zip", c => c.String());
            AddColumn("dbo.Members", "State", c => c.String());
            AddColumn("dbo.Members", "City", c => c.String());
            AddColumn("dbo.Members", "Address", c => c.String());
        }
    }
}
