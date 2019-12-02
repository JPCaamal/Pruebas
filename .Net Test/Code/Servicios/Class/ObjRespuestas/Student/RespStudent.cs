using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjRespuestas
{
    public class RespStudent
    {
        public string estatus { get; set; }
        public CodigosRespuesta.codigo code { get; set; }
    }

    public class RespStudentCourse
    {
        public RespStudent Response { get; set; }
    }
    public class RespStudentCourses
    {
        public RespStudent Response { get; set; }
        public List<Course> Courses { get; set; }
    }

    public class RespStudentLessons
    {
        public RespStudent Response { get; set; }
        public List<Lesson> Lessons { get; set; }
    }

    public class RespStudentAnswers
    {
        public RespStudent Response { get; set; }        
    }

    public class RespStudentQuestions
    {
        public RespStudent Response { get; set; }
        public List<Questions> Questions { get; set; }
    }
}