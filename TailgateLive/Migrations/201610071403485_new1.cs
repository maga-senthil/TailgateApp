namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TeamUsers", newName: "UserTeams");
            DropPrimaryKey("dbo.UserTeams");
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comments = c.String(),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            AddColumn("dbo.Events", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Events", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Teams", "Event_Id", c => c.Int());
            AlterColumn("dbo.Events", "EventTitle", c => c.String());
            AlterColumn("dbo.Events", "EventDate", c => c.DateTime());
            AlterColumn("dbo.Events", "EventComments", c => c.String());
            AddPrimaryKey("dbo.UserTeams", new[] { "User_Id", "Team_Id" });
            CreateIndex("dbo.Teams", "Event_Id");
            AddForeignKey("dbo.Teams", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropForeignKey("dbo.Teams", "Event_Id", "dbo.Events");
            DropIndex("dbo.Teams", new[] { "Event_Id" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropPrimaryKey("dbo.UserTeams");
            AlterColumn("dbo.Events", "EventComments", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "EventTitle", c => c.String(nullable: false));
            DropColumn("dbo.Teams", "Event_Id");
            DropColumn("dbo.Events", "Longitude");
            DropColumn("dbo.Events", "Latitude");
            DropTable("dbo.Comments");
            AddPrimaryKey("dbo.UserTeams", new[] { "Team_Id", "User_Id" });
            RenameTable(name: "dbo.UserTeams", newName: "TeamUsers");
        }
    }
}
