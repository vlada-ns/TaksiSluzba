namespace TaksiSluzba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        City = c.String(),
                        AreaCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        RegistrationPlate = c.String(nullable: false, maxLength: 10),
                        TaxiNumber = c.String(nullable: false),
                        CarType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.TaxiNumber, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Gender = c.Int(nullable: false),
                        JMBG = c.Long(nullable: false),
                        Telephone = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 50),
                        Role = c.String(),
                        Blocked = c.Boolean(),
                        LocationId = c.Int(),
                        Blocked1 = c.Boolean(),
                        BonusPoints = c.Int(),
                        EmployeeOfTheMonth = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.Username, unique: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Drives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDateTime = c.DateTime(nullable: false),
                        LocationId = c.Int(nullable: false),
                        CarType = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        DestinationId = c.Int(),
                        DispatcherId = c.Int(),
                        DriverId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.CustomerId)
                .ForeignKey("dbo.Locations", t => t.DestinationId)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.DispatcherId)
                .ForeignKey("dbo.Users", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.CustomerId)
                .Index(t => t.DestinationId)
                .Index(t => t.DispatcherId)
                .Index(t => t.DriverId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(maxLength: 200),
                        PublicationDate = c.DateTime(nullable: false),
                        Grade = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drives", t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        XCoordinate = c.String(),
                        YCoordinate = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cars", "Id", "dbo.Users");
            DropForeignKey("dbo.Users", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Drives", "DriverId", "dbo.Users");
            DropForeignKey("dbo.Drives", "DispatcherId", "dbo.Users");
            DropForeignKey("dbo.Drives", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Drives", "DestinationId", "dbo.Locations");
            DropForeignKey("dbo.Locations", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Drives", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Drives", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Id", "dbo.Drives");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Locations", new[] { "AddressId" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Id" });
            DropIndex("dbo.Drives", new[] { "User_Id" });
            DropIndex("dbo.Drives", new[] { "DriverId" });
            DropIndex("dbo.Drives", new[] { "DispatcherId" });
            DropIndex("dbo.Drives", new[] { "DestinationId" });
            DropIndex("dbo.Drives", new[] { "CustomerId" });
            DropIndex("dbo.Drives", new[] { "LocationId" });
            DropIndex("dbo.Users", new[] { "LocationId" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Cars", new[] { "TaxiNumber" });
            DropIndex("dbo.Cars", new[] { "Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Locations");
            DropTable("dbo.Comments");
            DropTable("dbo.Drives");
            DropTable("dbo.Users");
            DropTable("dbo.Cars");
            DropTable("dbo.Addresses");
        }
    }
}
