using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Models
{
    public class Lessons
    {
        public int ID_lesson { get; set; }
        public string lesson_name { get; set; }
        public int lesson_minPoints { get; set; }
        public List<Questions> lesson_questions { get; set; }
    }

    public class Lesson
    {
        public int ID_lesson { get; set; }
        public string lesson_name { get; set; }
        public int lesson_minPoints { get; set; }
        public string lesson_status { get; set; }
    }
}