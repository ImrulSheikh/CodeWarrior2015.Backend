namespace CW.Backend.DAL.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTypeMatch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PostedUserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderedBy", "dbo.Users");
            DropIndex("dbo.Products", new[] { "PostedUserId" });
            DropIndex("dbo.Orders", new[] { "OrderedBy" });
            CreateTable(
                "dbo.Users",
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
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Sex = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        CreatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        Status = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            AddColumn("dbo.Products", "PostedBy_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "User_Id");
            CreateIndex("dbo.Products", "PostedBy_Id");
            AddForeignKey("dbo.Products", "PostedBy_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.Users", "Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Sex = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        UpdatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedBy = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Products", "PostedBy_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Products", new[] { "PostedBy_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropColumn("dbo.Orders", "User_Id");
            DropColumn("dbo.Products", "PostedBy_Id");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            CreateIndex("dbo.Orders", "OrderedBy");
            CreateIndex("dbo.Products", "PostedUserId");
            AddForeignKey("dbo.Orders", "OrderedBy", "dbo.Users", "Id");
            AddForeignKey("dbo.Products", "PostedUserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
