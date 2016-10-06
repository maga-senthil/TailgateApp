namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datenullableineventmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EventDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
        }
    }
}
