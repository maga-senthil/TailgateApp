namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameWeathers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        gameId = c.String(),
                        gameWeek = c.String(),
                        gameDate = c.String(),
                        awayTeam = c.String(),
                        homeTeam = c.String(),
                        gameTimeET = c.String(),
                        tvStation = c.String(),
                        winner = c.String(),
                        stadium = c.String(),
                        isDome = c.String(),
                        geoLat = c.String(),
                        geoLong = c.String(),
                        low = c.String(),
                        high = c.String(),
                        forecast = c.String(),
                        windChill = c.String(),
                        windSpeed = c.String(),
                        domeImg = c.String(),
                        smallImg = c.String(),
                        mediumImg = c.String(),
                        largeImg = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameWeathers");
        }
    }
}
