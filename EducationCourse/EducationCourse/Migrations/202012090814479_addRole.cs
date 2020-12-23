namespace EducationCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseCustomers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseCustomers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CourseCustomers", new[] { "CustomerId" });
            DropIndex("dbo.CourseCustomers", new[] { "CourseId" });
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.CustomerRole",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.RoleId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RoleId);
            
            DropTable("dbo.CourseCustomers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseCustomers",
                c => new
                    {
                        CourseCustomerId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseCustomerId);
            
            DropForeignKey("dbo.CustomerRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.CustomerRole", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerRole", new[] { "RoleId" });
            DropIndex("dbo.CustomerRole", new[] { "CustomerId" });
            DropTable("dbo.CustomerRole");
            DropTable("dbo.Roles");
            CreateIndex("dbo.CourseCustomers", "CourseId");
            CreateIndex("dbo.CourseCustomers", "CustomerId");
            AddForeignKey("dbo.CourseCustomers", "CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.CourseCustomers", "CourseId", "dbo.Courses", "CourseId");
        }
    }
}
