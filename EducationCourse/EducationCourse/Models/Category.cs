using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public ICollection<Course> Courses { get; set; }
        public Category()
        {
            Courses = new List<Course>();
        }
    }
}