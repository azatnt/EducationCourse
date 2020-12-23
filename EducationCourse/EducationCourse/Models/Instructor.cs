using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Course> Courses { get; set; }
        public Instructor()
        {
            Courses = new List<Course>();
        }
    }
}