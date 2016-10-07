namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remvdTeamFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "TeamId", "dbo.Teams");
            DropIndex("dbo.Events", new[] { "TeamId" });
            AddColumn("dbo.Teams", "Team_Id", c => c.Int());
            CreateIndex("dbo.Teams", "Team_Id");
            AddForeignKey("dbo.Teams", "Team_Id", "dbo.Teams", "Id");
            DropColumn("dbo.Events", "TeamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "TeamId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Teams", "Team_Id", "dbo.Teams");
            DropIndex("dbo.Teams", new[] { "Team_Id" });
            DropColumn("dbo.Teams", "Team_Id");
            CreateIndex("dbo.Events", "TeamId");
            AddForeignKey("dbo.Events", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
    }
}
