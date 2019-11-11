namespace Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Permission_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.permission", t => t.Permission_Id)
                .Index(t => t.Permission_Id);
            
            CreateTable(
                "dbo.role_has_permission",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.PermissionId })
                .ForeignKey("dbo.permission", t => t.PermissionId, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.PermissionId);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.user_has_role",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NickName = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        FirstNames = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        LastName = c.String(maxLength: 60, storeType: "nvarchar"),
                        SecondLastName = c.String(maxLength: 60, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 150, storeType: "nvarchar"),
                        UpdatedAt = c.DateTime(precision: 0),
                        DeletedAt = c.DateTime(precision: 0),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.user_has_role", "UserId", "dbo.user");
            DropForeignKey("dbo.user_has_role", "RoleId", "dbo.role");
            DropForeignKey("dbo.role_has_permission", "RoleId", "dbo.role");
            DropForeignKey("dbo.role_has_permission", "PermissionId", "dbo.permission");
            DropForeignKey("dbo.permission", "Permission_Id", "dbo.permission");
            DropIndex("dbo.user_has_role", new[] { "RoleId" });
            DropIndex("dbo.user_has_role", new[] { "UserId" });
            DropIndex("dbo.role_has_permission", new[] { "PermissionId" });
            DropIndex("dbo.role_has_permission", new[] { "RoleId" });
            DropIndex("dbo.permission", new[] { "Permission_Id" });
            DropTable("dbo.user");
            DropTable("dbo.user_has_role");
            DropTable("dbo.role");
            DropTable("dbo.role_has_permission");
            DropTable("dbo.permission");
        }
    }
}
