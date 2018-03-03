namespace SchoolJournal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherToAppUserRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeacherSchoolClasses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSubjects", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.TeacherSchoolClasses", new[] { "TeacherId" });
            DropIndex("dbo.TeacherSubjects", new[] { "TeacherId" });
            DropPrimaryKey("dbo.Teachers");
            DropColumn("dbo.Teachers", "Id");
            AddColumn("dbo.Teachers", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.TeacherSchoolClasses", "TeacherId");
            AddColumn("dbo.TeacherSchoolClasses", "TeacherId", c => c.String(maxLength: 128));
            DropColumn("dbo.TeacherSubjects", "TeacherId");
            AddColumn("dbo.TeacherSubjects", "TeacherId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Teachers", "Id");
            CreateIndex("dbo.Teachers", "Id");
            CreateIndex("dbo.TeacherSchoolClasses", "TeacherId");
            CreateIndex("dbo.TeacherSubjects", "TeacherId");
            AddForeignKey("dbo.Teachers", "Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TeacherSchoolClasses", "TeacherId", "dbo.Teachers", "Id");
            AddForeignKey("dbo.TeacherSubjects", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSubjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSchoolClasses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.TeacherSubjects", new[] { "TeacherId" });
            DropIndex("dbo.TeacherSchoolClasses", new[] { "TeacherId" });
            DropIndex("dbo.Teachers", new[] { "Id" });
            DropPrimaryKey("dbo.Teachers");
            DropColumn("dbo.TeacherSubjects", "TeacherId");
            AddColumn("dbo.TeacherSubjects", "TeacherId", c => c.Int(nullable: false));
            DropColumn("dbo.TeacherSchoolClasses", "TeacherId");
            AddColumn("dbo.TeacherSchoolClasses", "TeacherId", c => c.Int(nullable: false));
            DropColumn("dbo.Teachers", "Id");
            AddColumn("dbo.Teachers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Teachers", "Id");
            CreateIndex("dbo.TeacherSubjects", "TeacherId");
            CreateIndex("dbo.TeacherSchoolClasses", "TeacherId");
            AddForeignKey("dbo.TeacherSubjects", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeacherSchoolClasses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
    }
}
