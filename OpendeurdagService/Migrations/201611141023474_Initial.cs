namespace OpendeurdagService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
            DropForeignKey("dbo.DegreeStudents", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.DegreeStudents", "Degree_DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.StudentCampus", "Campus_CampusId", "dbo.Campus");
            DropForeignKey("dbo.StudentCampus", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.DegreeStudents", new[] { "Student_StudentId" });
            DropIndex("dbo.DegreeStudents", new[] { "Degree_DegreeId" });
            DropIndex("dbo.StudentCampus", new[] { "Campus_CampusId" });
            DropIndex("dbo.StudentCampus", new[] { "Student_StudentId" });
            DropTable("dbo.DegreeStudents");
            DropTable("dbo.StudentCampus");
            DropTable("dbo.Degrees");
            DropTable("dbo.Students");
            DropTable("dbo.Campus");
            DropTable("dbo.Activities");
        }
    }
}
