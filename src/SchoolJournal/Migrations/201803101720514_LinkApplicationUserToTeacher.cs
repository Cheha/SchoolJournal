namespace SchoolJournal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkApplicationUserToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "UserId");
        }
    }
}
