using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public ICollection<Test> Tests { get; set; }

        public ICollection<LectureFiles> LectureFiles { get; set; }
        public Course()
        {
            Tests = new List<Test>();
            Customers = new HashSet<Customer>();
            LectureFiles = new List<LectureFiles>();
        }
        

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        
    }
}