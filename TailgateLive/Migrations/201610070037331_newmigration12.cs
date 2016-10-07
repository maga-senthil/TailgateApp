namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration12 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventUsers", newName: "UserEvents");
            RenameTable(name: "dbo.TeamUsers", newName: "UserTeams");
            DropPrimaryKey("dbo.UserEvents");
            DropPrimaryKey("dbo.UserTeams");
            AddColumn("dbo.Comments", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.Teams", "Event_Id", c => c.Int());
            AddPrimaryKey("dbo.UserEvents", new[] { "User_Id", "Event_Id" });
            AddPrimaryKey("dbo.UserTeams", new[] { "User_Id", "Team_Id" });
            CreateIndex("dbo.Comments", "EventId");
            CreateIndex("dbo.Teams", "Event_Id");
            AddForeignKey("dbo.Teams", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Comments", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropForeignKey("dbo.Teams", "Event_Id", "dbo.Events");
            DropIndex("dbo.Teams", new[] { "Event_Id" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropPrimaryKey("dbo.UserTeams");
            DropPrimaryKey("dbo.UserEvents");
            DropColumn("dbo.Teams", "Event_Id");
            DropColumn("dbo.Comments", "EventId");
            AddPrimaryKey("dbo.UserTeams", new[] { "Team_Id", "User_Id" });
            AddPrimaryKey("dbo.UserEvents", new[] { "Event_Id", "User_Id" });
            RenameTable(name: "dbo.UserTeams", newName: "TeamUsers");
            RenameTable(name: "dbo.UserEvents", newName: "EventUsers");
        }
    }
}
