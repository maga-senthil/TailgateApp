namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration55 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CommentEvents", newName: "EventComments");
            DropPrimaryKey("dbo.EventComments");
            AddPrimaryKey("dbo.EventComments", new[] { "Event_Id", "Comment_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EventComments");
            AddPrimaryKey("dbo.EventComments", new[] { "Comment_Id", "Event_Id" });
            RenameTable(name: "dbo.EventComments", newName: "CommentEvents");
        }
    }
}
