namespace Collectr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectrUpdateSix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ExtraPickupDay", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Customers", "NoPickupStart", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Customers", "NoPickupEnd", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NoPickupEnd", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Customers", "NoPickupStart", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Customers", "ExtraPickupDay", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
