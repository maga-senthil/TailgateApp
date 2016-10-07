namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NFLGameSchedules", "EventId", "dbo.Events");
            DropIndex("dbo.NFLGameSchedules", new[] { "EventId" });
            AddColumn("dbo.Events", "NFLGameScheduleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "NFLGameScheduleId");
            AddForeignKey("dbo.Events", "NFLGameScheduleId", "dbo.NFLGameSchedules", "Id", cascadeDelete: true);
            DropColumn("dbo.NFLGameSchedules", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NFLGameSchedules", "EventId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "NFLGameScheduleId", "dbo.NFLGameSchedules");
            DropIndex("dbo.Events", new[] { "NFLGameScheduleId" });
            DropColumn("dbo.Events", "NFLGameScheduleId");
            CreateIndex("dbo.NFLGameSchedules", "EventId");
            AddForeignKey("dbo.NFLGameSchedules", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
