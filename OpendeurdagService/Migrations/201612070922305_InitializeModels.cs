namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CampusId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        DegreeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DegreeId);
            
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
            
            CreateTable(
                "dbo.StudentCampus",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Campus_CampusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Campus_CampusId })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Campus", t => t.Campus_CampusId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Campus_CampusId);
            
            CreateTable(
                "dbo.DegreeStudents",
                c => new
                    {
                        Degree_DegreeId = c.Int(nullable: false),
                        Student_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Degree_DegreeId, t.Student_StudentId })
                .ForeignKey("dbo.Degrees", t => t.Degree_DegreeId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .Index(t => t.Degree_DegreeId)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DegreeStudents", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.DegreeStudents", "Degree_DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.StudentCampus", "Campus_CampusId", "dbo.Campus");
            DropForeignKey("dbo.StudentCampus", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.DegreeStudents", new[] { "Student_StudentId" });
            DropIndex("dbo.DegreeStudents", new[] { "Degree_DegreeId" });
            DropIndex("dbo.StudentCampus", new[] { "Campus_CampusId" });
            DropIndex("dbo.StudentCampus", new[] { "Student_StudentId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.DegreeStudents");
            DropTable("dbo.StudentCampus");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Degrees");
            DropTable("dbo.Students");
            DropTable("dbo.Campus");
            DropTable("dbo.Activities");
        }
    }
}
