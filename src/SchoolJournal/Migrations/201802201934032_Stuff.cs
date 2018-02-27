namespace SchoolJournal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SchoolClasses", "TeacherId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SchoolClasses", "TeacherId");
        }
    }
}
