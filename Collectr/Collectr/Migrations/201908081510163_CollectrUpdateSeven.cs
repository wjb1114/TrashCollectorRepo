namespace Collectr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectrUpdateSeven : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ExtraPickupDay", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Customers", "NoPickupStart", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Customers", "NoPickupEnd", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NoPickupEnd", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Customers", "NoPickupStart", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Customers", "ExtraPickupDay", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
