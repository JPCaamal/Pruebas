using Servicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicios.Class.ObjRespuestas
{
    public class ResponseAddLessons
    {
        public ResponseAddLessons(ResponseLessons Respuesta)
        {
            Response = new ResponseAddLesson();
            Response.Response = Respuesta;
        }
        private ResponseAddLesson response;
        public ResponseAddLesson Response
        {
            get { return response; }
            set { response = value; }
        }
    }

    public class ResponseListLessons
    {
        public ResponseListLessons(ResponseLessons Respuesta, List<Lesson> lessons)
        {
            Response = new ResponseListLesson();
            Response.Response = Respuesta;
            Response.Lessons = lessons;
        }
        private ResponseListLesson response;
        public ResponseListLesson Response
        {
            get { return response; }
            set { response = value; }
        }
    }
}