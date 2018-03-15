namespace SchoolJournal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToMarks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marks", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marks", "Date");
        }
    }
}
