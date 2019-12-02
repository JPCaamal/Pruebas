using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Models
{
    public class Courses
    {
        public int ID_course { get; set; }
        public string course_name { get; set; }
        public List<Lessons> course_lessons { get; set; }
    }

    public class Course
    {
        public int ID_course { get; set; }
        public string course_name { get; set; }
        public string course_status { get; set; }
    }
}