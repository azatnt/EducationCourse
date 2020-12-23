namespace EducationCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedFiles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LectureFiles", "Description", c => c.String());
            AddColumn("dbo.LectureFiles", "duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LectureFiles", "duration");
            DropColumn("dbo.LectureFiles", "Description");
        }
    }
}
