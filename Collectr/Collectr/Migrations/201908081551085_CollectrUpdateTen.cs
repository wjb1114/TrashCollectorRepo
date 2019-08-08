namespace Collectr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectrUpdateTen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "NextPickup", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "NextPickup");
        }
    }
}
