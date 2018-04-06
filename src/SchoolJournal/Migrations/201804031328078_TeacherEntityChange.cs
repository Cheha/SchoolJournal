namespace SchoolJournal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherEntityChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "FatherName", c => c.String());
            AddColumn("dbo.Teachers", "SchoolClassId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "SchoolClassId");
            DropColumn("dbo.Teachers", "FatherName");
        }
    }
}
