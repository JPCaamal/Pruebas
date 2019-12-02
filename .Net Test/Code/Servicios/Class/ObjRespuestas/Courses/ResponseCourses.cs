using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjRespuestas
{
    public class ResponseAddCourses
    {
        public ResponseAddCourses(ResponseCourse Respuesta)
        {
            Response = new ResponseAddCourse();
            Response.Response = Respuesta;      
        }
        private ResponseAddCourse response;
        public ResponseAddCourse Response
        {
            get { return response; }
            set { response = value; }
        }
    }

    public class ResponseListCourses
    {
        public ResponseListCourses(ResponseCourse Respuesta, List<Course> courses)
        {
            Response = new ResponseListCourse();
            Response.Response = Respuesta;
            Response.Courses = courses;
        }
        private ResponseListCourse response;
        public ResponseListCourse Response
        {
            get { return response; }
            set { response = value; }
        }
    }
}