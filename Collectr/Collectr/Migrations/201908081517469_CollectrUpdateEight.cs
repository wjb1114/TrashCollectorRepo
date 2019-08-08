namespace Collectr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectrUpdateEight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastPickedUp", c => c.DateTime());
            AddColumn("dbo.Customers", "LatestPickedUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "LatestPickedUp");
            DropColumn("dbo.Customers", "LastPickedUp");
        }
    }
}
