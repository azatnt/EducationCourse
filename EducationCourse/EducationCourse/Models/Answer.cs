using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Description { get; set; }
        public int? TestId { get; set; }
        public Test Test { get; set; }
    }
}