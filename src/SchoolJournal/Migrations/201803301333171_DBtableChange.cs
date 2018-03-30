namespace SchoolJournal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBtableChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherSchoolClasses", "SchoolClassId", "dbo.SchoolClasses");
            DropForeignKey("dbo.TeacherSchoolClasses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.TeacherSchoolClasses", new[] { "TeacherId" });
            DropIndex("dbo.TeacherSchoolClasses", new[] { "SchoolClassId" });
            CreateTable(
                "dbo.TeacherSchoolClassSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SchoolClassSubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolClassSubjects", t => t.SchoolClassSubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SchoolClassSubjectId);
            
            DropTable("dbo.TeacherSchoolClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeacherSchoolClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SchoolClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.TeacherSchoolClassSubjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSchoolClassSubjects", "SchoolClassSubjectId", "dbo.SchoolClassSubjects");
            DropIndex("dbo.TeacherSchoolClassSubjects", new[] { "SchoolClassSubjectId" });
            DropIndex("dbo.TeacherSchoolClassSubjects", new[] { "TeacherId" });
            DropTable("dbo.TeacherSchoolClassSubjects");
            CreateIndex("dbo.TeacherSchoolClasses", "SchoolClassId");
            CreateIndex("dbo.TeacherSchoolClasses", "TeacherId");
            AddForeignKey("dbo.TeacherSchoolClasses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherSchoolClasses", "SchoolClassId", "dbo.SchoolClasses", "Id", cascadeDelete: true);
        }
    }
}
