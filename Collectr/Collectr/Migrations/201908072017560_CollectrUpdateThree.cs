namespace Collectr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectrUpdateThree : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmailAddress");
        }
    }
}
