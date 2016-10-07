namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
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
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(),
                        EventDate = c.DateTime(),
                        EventRating = c.Int(nullable: false),
                        EventStatus = c.Boolean(nullable: false),
                        EventComments = c.String(),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NFLGameScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NFLGameSchedules", t => t.NFLGameScheduleId, cascadeDelete: true)
                .Index(t => t.NFLGameScheduleId);
            
            CreateTable(
                "dbo.NFLGameSchedules",
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserZipCode = c.Int(nullable: false),
                        UserRating = c.Int(nullable: false),
                        LoginId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LoginId)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        FullName = c.String(),
                        ShortName = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropForeignKey("dbo.Teams", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.UserEvents", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "LoginId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "NFLGameScheduleId", "dbo.NFLGameSchedules");
            DropIndex("dbo.UserEvents", new[] { "Event_Id" });
            DropIndex("dbo.UserEvents", new[] { "User_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Teams", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "LoginId" });
            DropIndex("dbo.Events", new[] { "NFLGameScheduleId" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.UserEvents");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Teams");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.NFLGameSchedules");
            DropTable("dbo.Events");
            DropTable("dbo.Comments");
        }
    }
}
