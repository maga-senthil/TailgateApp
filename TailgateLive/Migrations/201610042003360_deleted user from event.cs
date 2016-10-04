namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteduserfromevent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Events", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Event_Id", "dbo.Events");
            DropIndex("dbo.Events", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Event_Id" });
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Event_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Event_Id);
            
            DropColumn("dbo.Events", "UserId");
            DropColumn("dbo.Events", "User_Id");
            DropColumn("dbo.Users", "Event_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Event_Id", c => c.Int());
            AddColumn("dbo.Events", "User_Id", c => c.Int());
            AddColumn("dbo.Events", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.UserEvents", "User_Id", "dbo.Users");
            DropIndex("dbo.UserEvents", new[] { "Event_Id" });
            DropIndex("dbo.UserEvents", new[] { "User_Id" });
            DropTable("dbo.UserEvents");
            CreateIndex("dbo.Users", "Event_Id");
            CreateIndex("dbo.Events", "User_Id");
            CreateIndex("dbo.Events", "UserId");
            AddForeignKey("dbo.Users", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Events", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "User_Id", "dbo.Users", "Id");
        }
    }
}
