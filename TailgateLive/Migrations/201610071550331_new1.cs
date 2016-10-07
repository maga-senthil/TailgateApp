namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.UserTeams", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserTeams", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Events", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Event_Id", "dbo.Events");
            DropIndex("dbo.Events", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "Team_Id" });
            DropIndex("dbo.Teams", new[] { "Event_Id" });
            DropIndex("dbo.UserTeams", new[] { "User_Id" });
            DropIndex("dbo.UserTeams", new[] { "Team_Id" });
            AddColumn("dbo.Teams", "Code", c => c.String());
            AddColumn("dbo.Teams", "FullName", c => c.String());
            AddColumn("dbo.Teams", "ShortName", c => c.String());
            AddColumn("dbo.Teams", "User_Id", c => c.Int());
            CreateIndex("dbo.Teams", "User_Id");
            AddForeignKey("dbo.Teams", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Events", "TeamId");
            DropColumn("dbo.Teams", "TeamName");
            DropColumn("dbo.Teams", "Team_Id");
            DropColumn("dbo.Teams", "Event_Id");
            DropTable("dbo.UserTeams");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserTeams",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Team_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Team_Id });
            
            AddColumn("dbo.Teams", "Event_Id", c => c.Int());
            AddColumn("dbo.Teams", "Team_Id", c => c.Int());
            AddColumn("dbo.Teams", "TeamName", c => c.String());
            AddColumn("dbo.Events", "TeamId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Teams", "User_Id", "dbo.Users");
            DropIndex("dbo.Teams", new[] { "User_Id" });
            DropColumn("dbo.Teams", "User_Id");
            DropColumn("dbo.Teams", "ShortName");
            DropColumn("dbo.Teams", "FullName");
            DropColumn("dbo.Teams", "Code");
            CreateIndex("dbo.UserTeams", "Team_Id");
            CreateIndex("dbo.UserTeams", "User_Id");
            CreateIndex("dbo.Teams", "Event_Id");
            CreateIndex("dbo.Teams", "Team_Id");
            CreateIndex("dbo.Events", "TeamId");
            AddForeignKey("dbo.Teams", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Events", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserTeams", "Team_Id", "dbo.Teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserTeams", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Teams", "Team_Id", "dbo.Teams", "Id");
        }
    }
}
