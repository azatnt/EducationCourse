using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationCourse.Models
{
    public class LectureFiles
    {
        public int LectureFilesId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
    }
}