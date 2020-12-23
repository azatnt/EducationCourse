using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string Topic { get; set; }
        public string Variants1 { get; set; }
        public string Variants2 { get; set; }
        public string Variants3 { get; set; }
        public string Variants4 { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Test()
        {
            Answers = new List<Answer>();
          
        }
    }
}