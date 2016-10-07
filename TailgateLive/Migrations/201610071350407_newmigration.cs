namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Events", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Events", "EventTitle", c => c.String());
            AlterColumn("dbo.Events", "EventDate", c => c.DateTime());
            AlterColumn("dbo.Events", "EventComments", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EventComments", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "EventTitle", c => c.String(nullable: false));
            DropColumn("dbo.Events", "Longitude");
            DropColumn("dbo.Events", "Latitude");
        }
    }
}
