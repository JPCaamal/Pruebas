using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicios.Models;
namespace Servicios.Class.ObjRespuestas
{


    public class ResponseStudentCourse
    {
        public ResponseStudentCourse(RespStudent Respuesta)
        {
            Response = new RespStudentCourse();
            Response.Response = Respuesta;    
        }
        private RespStudentCourse response;
        public RespStudentCourse Response
        {
            get { return response; }
            set { response = value; }
        }
    }


    public class ResponseStudentCourses
    {
        public ResponseStudentCourses(RespStudent Respuesta, List<Course> courses )
        {
            Response = new RespStudentCourses();
            Response.Response = Respuesta;
            response.Courses = courses;
        }
        private RespStudentCourses response;
        public RespStudentCourses Response
        {
            get { return response; }
            set { response = value; }
        }
    }

    public class ResponseStudentLessons
    {
        public ResponseStudentLessons(RespStudent Respuesta, List<Lesson> lessons)
        {
            Response = new RespStudentLessons();
            Response.Response = Respuesta;
            response.Lessons = lessons;
        }
        private RespStudentLessons response;
        public RespStudentLessons Response
        {
            get { return response; }
            set { response = value; }
        }
    }

    public class ResponseStudentQuestions
    {
        public ResponseStudentQuestions(RespStudent Respuesta, List<Questions> Questions)
        {
            Response = new RespStudentQuestions();
            Response.Response = Respuesta;
            response.Questions = Questions;
        }
        private RespStudentQuestions response;
        public RespStudentQuestions Response
        {
            get { return response; }
            set { response = value; }
        }
    }

    public class ResponseStudentAnswers
    {
        public ResponseStudentAnswers(RespStudent Respuesta)
        {
            Response = new RespStudentAnswers();
            Response.Response = Respuesta;
        }
        private RespStudentAnswers response;
        public RespStudentAnswers Response
        {
            get { return response; }
            set { response = value; }
        }
    }

}