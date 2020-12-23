using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class CourseContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<LectureFiles> LectureFiles { get; set; }



        public CourseContext() : base("CourseContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CourseContext>(null);
            base.OnModelCreating(modelBuilder);



            //modelBuilder.Entity<Customer>()
            //    .HasMany<Role>(u => u.Roles)
            //    .WithMany(r => r.Customers)
            //    .Map(ur => {
            //        ur.MapLeftKey("CustomerId");
            //        ur.MapRightKey("RoleId");
            //        ur.ToTable("CustomerRole");
            //    });
        }



    }
}