namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserEvents", newName: "EventUsers");
            RenameTable(name: "dbo.UserTeams", newName: "TeamUsers");
            DropForeignKey("dbo.EventComments", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventComments", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Events", "TeamId", "dbo.Teams");
            DropIndex("dbo.Events", new[] { "TeamId" });
            DropIndex("dbo.EventComments", new[] { "Event_Id" });
            DropIndex("dbo.EventComments", new[] { "Comment_Id" });
            DropPrimaryKey("dbo.EventUsers");
            DropPrimaryKey("dbo.TeamUsers");
            AddPrimaryKey("dbo.EventUsers", new[] { "Event_Id", "User_Id" });
            AddPrimaryKey("dbo.TeamUsers", new[] { "Team_Id", "User_Id" });
            DropColumn("dbo.Events", "TeamId");
            DropTable("dbo.EventComments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EventComments",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        Comment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Comment_Id });
            
            AddColumn("dbo.Events", "TeamId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.TeamUsers");
            DropPrimaryKey("dbo.EventUsers");
            AddPrimaryKey("dbo.TeamUsers", new[] { "User_Id", "Team_Id" });
            AddPrimaryKey("dbo.EventUsers", new[] { "User_Id", "Event_Id" });
            CreateIndex("dbo.EventComments", "Comment_Id");
            CreateIndex("dbo.EventComments", "Event_Id");
            CreateIndex("dbo.Events", "TeamId");
            AddForeignKey("dbo.Events", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EventComments", "Comment_Id", "dbo.Comments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EventComments", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.TeamUsers", newName: "UserTeams");
            RenameTable(name: "dbo.EventUsers", newName: "UserEvents");
        }
    }
}
