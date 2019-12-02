using Servicios.Models;
using Servicios.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjPeticiones
{
    public class RQStudent
    {
        public string user_number { get; set; }
        public string user_password { get; set; }
    }
    public class RQStudentCourse
    {
        public string user_number { get; set; }
        public string user_password { get; set; }
        public int ID_Course { get; set; }
    }
    public class RQStudentCourses
    {
        public string user_number { get; set; }
        public string user_password { get; set; }       
    }

    public class RQStudentLessons
    {
        public string user_number { get; set; }
        public string user_password { get; set; }
        public int ID_course { get; set; }
    }

    public class RQStudentQuestions
    {
        public string user_number { get; set; }
        public string user_password { get; set; }
        public int ID_lesson { get; set; }
    }

    public class RQStudentAnswer
    {
        public string user_number { get; set; }
        public string user_password { get; set; }
        public List<Questions> Questions { get; set; }
        public int ID_lesson { get; set; }
    }

}