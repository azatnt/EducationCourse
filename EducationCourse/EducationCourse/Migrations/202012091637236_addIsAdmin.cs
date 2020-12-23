namespace EducationCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsAdmin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerRole", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerRole", "RoleId", "dbo.Roles");
            DropIndex("dbo.CustomerRole", new[] { "CustomerId" });
            DropIndex("dbo.CustomerRole", new[] { "RoleId" });
            AddColumn("dbo.Customers", "isAdmin", c => c.Boolean(nullable: false));
            DropTable("dbo.Roles");
            DropTable("dbo.CustomerRole");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerRole",
                c => new
                    {
                        CustomerId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.RoleId });
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            DropColumn("dbo.Customers", "isAdmin");
            CreateIndex("dbo.CustomerRole", "RoleId");
            CreateIndex("dbo.CustomerRole", "CustomerId");
            AddForeignKey("dbo.CustomerRole", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.CustomerRole", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
