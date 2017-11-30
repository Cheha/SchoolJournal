namespace SchoolJounal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SchoolClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolClasses", t => t.SchoolClassId, cascadeDelete: true)
                .Index(t => t.SchoolClassId);
            
            CreateTable(
                "dbo.SchoolClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolClassSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolClassId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolClasses", t => t.SchoolClassId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SchoolClassId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherSchoolClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SchoolClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolClasses", t => t.SchoolClassId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SchoolClassId);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSubjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TeacherSchoolClasses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSchoolClasses", "SchoolClassId", "dbo.SchoolClasses");
            DropForeignKey("dbo.SchoolClassSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SchoolClassSubjects", "SchoolClassId", "dbo.SchoolClasses");
            DropForeignKey("dbo.Marks", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "SchoolClassId", "dbo.SchoolClasses");
            DropIndex("dbo.TeacherSubjects", new[] { "SubjectId" });
            DropIndex("dbo.TeacherSubjects", new[] { "TeacherId" });
            DropIndex("dbo.TeacherSchoolClasses", new[] { "SchoolClassId" });
            DropIndex("dbo.TeacherSchoolClasses", new[] { "TeacherId" });
            DropIndex("dbo.SchoolClassSubjects", new[] { "SubjectId" });
            DropIndex("dbo.SchoolClassSubjects", new[] { "SchoolClassId" });
            DropIndex("dbo.Students", new[] { "SchoolClassId" });
            DropIndex("dbo.Marks", new[] { "SubjectId" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.TeacherSchoolClasses");
            DropTable("dbo.Teachers");
            DropTable("dbo.SchoolClassSubjects");
            DropTable("dbo.Subjects");
            DropTable("dbo.SchoolClasses");
            DropTable("dbo.Students");
            DropTable("dbo.Marks");
        }
    }
}
