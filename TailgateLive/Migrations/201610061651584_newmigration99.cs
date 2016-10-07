namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration99 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TeamUsers", newName: "UserTeams");
            DropPrimaryKey("dbo.UserTeams");
            AddColumn("dbo.Events", "TeamId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserTeams", new[] { "User_Id", "Team_Id" });
            CreateIndex("dbo.Events", "TeamId");
            AddForeignKey("dbo.Events", "TeamId", "dbo.Teams", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "TeamId", "dbo.Teams");
            DropIndex("dbo.Events", new[] { "TeamId" });
            DropPrimaryKey("dbo.UserTeams");
            DropColumn("dbo.Events", "TeamId");
            AddPrimaryKey("dbo.UserTeams", new[] { "Team_Id", "User_Id" });
            RenameTable(name: "dbo.UserTeams", newName: "TeamUsers");
        }
    }
}
