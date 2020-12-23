namespace EducationCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LectureFiles",
                c => new
                    {
                        LectureFilesId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FileSize = c.Int(),
                        FilePath = c.String(),
                        CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.LectureFilesId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LectureFiles", "CourseId", "dbo.Courses");
            DropIndex("dbo.LectureFiles", new[] { "CourseId" });
            DropTable("dbo.LectureFiles");
        }
    }
}
