namespace Collectr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "WeeklyPickupDay", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Balance", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "ExtraPickupDay", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "NoPickupStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "NoPickupEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "NoPickupEnd");
            DropColumn("dbo.Customers", "NoPickupStart");
            DropColumn("dbo.Customers", "ExtraPickupDay");
            DropColumn("dbo.Customers", "Balance");
            DropColumn("dbo.Customers", "WeeklyPickupDay");
        }
    }
}
