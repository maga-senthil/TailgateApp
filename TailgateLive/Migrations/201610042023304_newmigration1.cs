namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "HostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "HostId", c => c.Int(nullable: false));
        }
    }
}
