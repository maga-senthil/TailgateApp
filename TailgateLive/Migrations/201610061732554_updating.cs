namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "EmailId", newName: "LoginId");
            RenameIndex(table: "dbo.Users", name: "IX_EmailId", newName: "IX_LoginId");
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String());
            RenameIndex(table: "dbo.Users", name: "IX_LoginId", newName: "IX_EmailId");
            RenameColumn(table: "dbo.Users", name: "LoginId", newName: "EmailId");
        }
    }
}