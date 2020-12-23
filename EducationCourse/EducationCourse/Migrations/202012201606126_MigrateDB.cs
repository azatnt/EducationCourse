namespace EducationCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LectureFiles", "FileSize");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LectureFiles", "FileSize", c => c.Int());
        }
    }
}
