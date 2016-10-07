namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration06 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comments = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommentEvents",
                c => new
                    {
                        Comment_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Comment_Id, t.Event_Id })
                .ForeignKey("dbo.Comments", t => t.Comment_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Comment_Id)
                .Index(t => t.Event_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.CommentEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.CommentEvents", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.CommentEvents", new[] { "Event_Id" });
            DropIndex("dbo.CommentEvents", new[] { "Comment_Id" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.CommentEvents");
            DropTable("dbo.Comments");
        }
    }
}
